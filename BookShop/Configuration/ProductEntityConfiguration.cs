using BookShop.Config;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Configuration;

public class ProductEntityConfiguration : BaseEntityConfiguration<ProductEntity>
{
    public override void ConfigEntity(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("products");
    }
}
