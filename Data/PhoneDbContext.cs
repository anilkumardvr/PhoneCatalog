
// File: Data/PhoneDbContext.cs
using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Models;

namespace PhoneCatalog.Data
{
    public class PhoneDbContext : DbContext
    {
        public PhoneDbContext(DbContextOptions<PhoneDbContext> options) : base(options) { }

        public DbSet<Phone> Phones => Set<Phone>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Brand).HasMaxLength(100).IsRequired();
                e.Property(p => p.Model).HasMaxLength(100).IsRequired();
                e.Property(p => p.ImageUrl).HasMaxLength(2048);
                e.Property(p => p.Price).HasColumnType("decimal(10,2)");
                e.Property(p => p.Description).HasMaxLength(4000);
            });
        }
    }
}
