using Microsoft.EntityFrameworkCore;
using MinimartApp.Domain.Entities;
using System.Data;

namespace MinimartApp.Infrastructure.Persistence
{
    public class MinimartDbContext : DbContext
    {
        public MinimartDbContext(DbContextOptions<MinimartDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Inventory> Inventories => Set<Inventory>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships, keys, etc.
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }
}
