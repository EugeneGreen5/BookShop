namespace BookShop.Models.Entities;

public class UserEntity : BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual ICollection<OrdersEntity> Orders { get; set; } = new List<OrdersEntity>();
}
