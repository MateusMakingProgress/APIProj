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
                var person = new PersonModel(request.name);
                await context.AddAsync(person);
                await context.SaveChangesAsync();
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
                
                person.ChangeName(request.name);
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
