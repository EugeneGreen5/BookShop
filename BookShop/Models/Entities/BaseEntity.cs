namespace BookShop.Models.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; init; }

    public BaseEntity() 
    {
        Id = Guid.NewGuid();   
    }
}
