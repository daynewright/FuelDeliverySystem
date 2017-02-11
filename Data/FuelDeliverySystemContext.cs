using Microsoft.EntityFrameworkCore;
using FuelDeliverySystem.Models;

namespace FuelDeliverySystem.Data
{
    public class FuelDeliverySystemContext : DbContext
    {
        public FuelDeliverySystemContext(DbContextOptions<FuelDeliverySystemContext> options)
        : base(options) 
        {

        }

        public DbSet<Truck> Truck { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<OperatingRegion> OperatingRegion { get; set; }
        public DbSet<Stop> Stop { get; set; }
        public DbSet<Trip> Trip { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>()
            .Property(b => b.DateCreated)
            .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

            modelBuilder.Entity<Location>()
            .Property(b => b.DateCreated)
            .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

            modelBuilder.Entity<OperatingRegion>()
            .Property(b => b.DateCreated)
            .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

            modelBuilder.Entity<Stop>()
            .Property(b => b.DateCreated)
            .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

            modelBuilder.Entity<Trip>()
            .Property(b => b.DateCreated)
            .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");
        }
    }
}