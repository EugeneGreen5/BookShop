using BookShop.Config;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Configuration;

public class OrderProductEntityConfiguration : BaseEntityConfiguration<OrderProductEntity>
{
    public override void ConfigEntity(EntityTypeBuilder<OrderProductEntity> builder)
    {
        builder.ToTable("order_product");

        builder.HasOne(c => c.Product)
            .WithMany()
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
