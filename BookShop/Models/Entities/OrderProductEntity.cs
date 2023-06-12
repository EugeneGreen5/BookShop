namespace BookShop.Models.Entities;

public class OrderProductEntity : IEntity
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid ProductId { get; init; }
    public int Amount { get; set; }
    public ProductEntity Product { get; set; }
    public OrderProductEntity()
    { 
        Id = Guid.NewGuid();
    }
}
