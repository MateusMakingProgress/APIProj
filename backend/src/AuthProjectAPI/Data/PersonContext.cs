using AuthProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthProjectAPI.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
        }
        public DbSet<PersonModel> People { get; set; }
    }
}
