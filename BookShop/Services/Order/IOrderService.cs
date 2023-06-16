using BookShop.Models.DTO;
using BookShop.Models.DTO.Order;
using BookShop.Models.Entities;

namespace BookShop.Services.Order;

public interface IOrderService
{
    public Task<ResponseDTO> CreateOrder(OrdersEntity newOrder);
    public Task<ResponseDTO> UpdateOrder(OrdersEntity newOrder);
    public Task<List<OrderProductEntity>> GetOrderProductList();
    public Task<ResponseDTO> CreateOrderProduct(OrderProductRequestDto newOrderProduct);
}
