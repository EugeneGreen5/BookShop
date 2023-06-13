using BookShop.Config;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Configuration;

public class OrderProductEntityConfiguration : BaseEntityConfiguration<OrderProductEntity>
{
    public override void ConfigEntity(EntityTypeBuilder<OrderProductEntity> builder)
    {
        throw new NotImplementedException();
    }
}
