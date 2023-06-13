using BookShop.Config;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Configuration;

public class UsersEntityConfiguration : BaseEntityConfiguration<UserEntity>
{
    public override void ConfigEntity(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");
        builder.HasMany(c => c.Orders)
            .WithOne()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
