using Basketball.Models;
using Microsoft.EntityFrameworkCore;

namespace Basketball.Data
{
    public class BasketballDbContext : DbContext
    {
        public DbSet<BasketballClub> BasketballClubs => Set<BasketballClub>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Country> Countries => Set<Country>();

        public BasketballDbContext(DbContextOptions<BasketballDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Grouping the configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);
        }
    }
}
