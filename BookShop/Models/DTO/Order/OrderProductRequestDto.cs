namespace BookShop.Models.DTO.Order;

public class OrderProductRequestDto
{
    public Guid OrderId { get; init; }
    public Guid ProductId { get; init; }
    public int Amount { get; set; }
}
