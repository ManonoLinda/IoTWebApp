using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace DigitalMatterWebApp.Data
{
    public class AppDbContext : DbContext
    {
        // Define your tables as DbSets
        public DbSet<Group> Groups { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Firmware> Firmwares { get; set; }

        // Configures the connection to the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace with your actual connection string
            optionsBuilder.UseSqlServer("Server=Ratos-Laptop;Database=IoTDevicesTracking;Trusted_Connection=True;TrustServerCertificate=True");
        }

        // Additional configuration can go here (e.g., relationships)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: Configure a one-to-many relationship
            modelBuilder.Entity<Group>()
                .HasOne(g => g.ParentGroup)
                .WithMany(g => g.SubGroups)
                .HasForeignKey(g => g.ParentGroupID);
        }
    }
}