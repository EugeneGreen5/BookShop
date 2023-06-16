using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<OrdersEntity> Orders { get; set; }
    public DbSet<OrderProductEntity> OrderProducts { get; set; }
    public ApplicationDbContext(DbContextOptions options) 
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
