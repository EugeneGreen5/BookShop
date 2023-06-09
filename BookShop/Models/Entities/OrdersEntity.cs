namespace BookShop.Models.Entities;

public class OrdersEntity : IEntity
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public string State { get; set; }
   
    public OrdersEntity()
    {
        Id = Guid.NewGuid();
    }
}
