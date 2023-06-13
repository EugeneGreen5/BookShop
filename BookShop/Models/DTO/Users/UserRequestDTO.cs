namespace BookShop.Models.DTO.Users;

public class UserRequestDTO
{
    public Guid Id { get; init; }
    public string Email { get; set; }
    public string Password { get; set; }
}
