using Microsoft.EntityFrameworkCore;

namespace YourProject.Models;  // Adjust namespace

public class YourAppContext : DbContext
{
    public YourAppContext(DbContextOptions<YourAppContext> options)
        : base(options)
    {
    }

    // Add your DbSets here, e.g.:
    // public DbSet<YourEntity> YourEntities { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Optional: Configure entities, relationships, indexes
        // modelBuilder.Entity<YourEntity>().HasKey(e => e.Id);
        base.OnModelCreating(modelBuilder);
    }
}
