namespace BookShop.Models.Entities;

public class UserEntity : IEntity
{
    public Guid Id { get; init; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserEntity()
    { 
        Id = Guid.NewGuid();
    }
}
