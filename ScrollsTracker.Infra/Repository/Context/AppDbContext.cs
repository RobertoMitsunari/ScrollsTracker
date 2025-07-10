using Microsoft.EntityFrameworkCore;
using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Infra.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Obra> Obras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Obra>()
                .Property(i => i.Id);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
