namespace BookShop.Models.Entities;

public class ProductEntity : IEntity
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
   
    public ProductEntity() 
    {
        Id = Guid.NewGuid();
    }
}