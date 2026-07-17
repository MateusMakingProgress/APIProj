using AuthProjectAPI.Models;

namespace AuthProjectAPI.Routes
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
            app.MapGet("/api/person", () => new PersonModel(name: "Mateus"));
        }
    }
}
