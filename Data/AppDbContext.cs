using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Models;

namespace PhoneCatalog.Data;

public class AppDbContext : DbContext
{
    public DbSet<Phone> Phones => Set<Phone>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phone>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Id).HasMaxLength(64);
            e.Property(p => p.Brand).HasMaxLength(64);
            e.Property(p => p.Model).HasMaxLength(128);
            e.Property(p => p.Price).HasColumnType("decimal(18,2)");
        });
    }
}
