using BookShop.Config;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Configuration;

public class OrdersEntityConfiguration : BaseEntityConfiguration<OrdersEntity>
{
    public override void ConfigEntity(EntityTypeBuilder<OrdersEntity> builder)
    {
        builder.ToTable("orders");

        builder.HasMany(c => c.OrderProducts)
            .WithOne()
            .HasForeignKey(c => c.OrderId);
    }
}
