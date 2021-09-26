using BookingSystem.Persistence.Entities;
using BookingSystem.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Persistence.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Resource> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var db = $"Data Source=../BookingSystem.db";
            optionsBuilder.UseSqlite(db);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasData(ResourceSeed.ResourceSeeds);
        }
    }
}
