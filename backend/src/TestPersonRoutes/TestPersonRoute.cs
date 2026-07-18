using AuthProjectAPI.Data;
using AuthProjectAPI.Models;
using AuthProjectAPI.Routes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace TestPersonRoutes
{
    public class TestPersonRoute : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TestPersonRoute(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void ShouldHavePersonRoutes()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            app.PersonRoutes();
            var routeGroup = app.MapGroup("person");
            Assert.NotNull(routeGroup);
        }

        [Fact]
        public void ShouldHavePostRoute()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            app.PersonRoutes();
            var routeGroup = app.MapGroup("person");
            var postRoute = routeGroup.MapPost("", (PersonRequest request, PersonContext context) => Results.Ok());
            Assert.NotNull(postRoute);
        }

        [Fact]
        public void ShouldHaveGetRoute()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            app.PersonRoutes();
            var routeGroup = app.MapGroup("person");
            var getRoute = routeGroup.MapGet("", (PersonContext context) => Results.Ok());
            Assert.NotNull(getRoute);
        }

        [Fact]
        public void ShouldHavePutRoute()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            app.PersonRoutes();
            var routeGroup = app.MapGroup("person");
            var putRoute = routeGroup.MapPut("{id:guid}", (Guid id, PersonRequest request, PersonContext context) => Results.Ok());
            Assert.NotNull(putRoute);
        }

        [Fact]
        public void ShouldHaveDeleteRoute()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            app.PersonRoutes();
            var routeGroup = app.MapGroup("person");
            var deleteRoute = routeGroup.MapDelete("{id:guid}", (Guid id, PersonContext context) => Results.Ok());
            Assert.NotNull(deleteRoute);
        }

        [Fact]
        public void ShuldReturnNullIfPerson
    }
}