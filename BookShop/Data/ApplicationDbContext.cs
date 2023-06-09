using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity> users { get; set; }
    public DbSet<ProductEntity> products { get; set; }
    public DbSet<OrdersEntity> orders { get; set; }
    public DbSet<OrderProductEntity> orderProducts { get; set; }
    public ApplicationDbContext(DbContextOptions options) 
        : base(options)
    {
        Database.EnsureCreated();
    }
}
