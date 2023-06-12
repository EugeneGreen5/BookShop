namespace BookShop.Models.DTO.Order;

public class OrderRequestDto
{
    public Guid UserId { get; init; }
    public Guid ProductId { get; init; }
    public string State { get; set; }

}
