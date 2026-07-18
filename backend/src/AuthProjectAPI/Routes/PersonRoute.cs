using AuthProjectAPI.Data;
using AuthProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthProjectAPI.Routes
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
            var personRoute = app.MapGroup("person");

            personRoute.MapPost("", async (PersonRequest request, PersonContext context) =>
            {
                if (!request.IsValid())
                    return Results.BadRequest("Invalid request data.");

                var person = new PersonModel(request.name, request.lastName);

                await context.AddAsync(person);
                await context.SaveChangesAsync();
                return Results.Ok();
            });

            personRoute.MapGet("", async (PersonContext context) =>
            {
                var people = await context.People.ToListAsync();
                return Results.Ok(people);
            });

            personRoute.MapPut("{id:guid}", async (Guid id, PersonRequest request, PersonContext context) =>
            {
                var person = await context.People.FirstOrDefaultAsync(p => p.Id == id);

                if (person == null)
                    return Results.NotFound();

                if (!request.IsValid())
                    return Results.BadRequest("Invalid request data.");

                person.ChangeName(request.name, request.lastName);
                await context.SaveChangesAsync();
                return Results.Ok(person);

            });

            personRoute.MapDelete("{id:guid}", async (Guid id, PersonContext context) =>
            {
                var person = await context.People.FirstOrDefaultAsync(p => p.Id == id);

                if (person == null)
                    return Results.NotFound();

                context.Remove(person);
                await context.SaveChangesAsync();
                return Results.Ok(person);
            });
        }
    }
}
