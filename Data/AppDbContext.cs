using DigitalMatterWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalMatterWebApp.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Define your tables as DbSets
        public DbSet<Group> Groups { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Firmware> Firmwares { get; set; }

        // Additional configuration can go here (e.g., relationships)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: Configure a one-to-many relationship
            modelBuilder.Entity<Group>()
                .HasOne(g => g.ParentGroup)
                .WithMany(g => g.SubGroups)
                .HasForeignKey(g => g.ParentGroupID);

            modelBuilder.Entity<Firmware>().ToTable("Firmware");
        }
    }
}