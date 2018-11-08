using Heroes.Models;
using Microsoft.EntityFrameworkCore;

namespace Heroes.DbContext
{
    public class HeroesDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public HeroesDbContext(DbContextOptions<HeroesDbContext> options) : base(options)
        {

        }
        public DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>().HasKey(x => x.Id);
        }
    }
}
