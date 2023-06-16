namespace BookShop.Models.Entities;

public class OrdersEntity : BaseEntity
{
    public Guid UserId { get; init; }
    public string State { get; set; }
    public virtual ICollection<OrderProductEntity> OrderProducts { get; set; } = new List<OrderProductEntity>();
   
}
