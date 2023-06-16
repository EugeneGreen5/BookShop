using BookShop.Models.DTO;
using BookShop.Models.DTO.Order;
using BookShop.Models.Entities;
using BookShop.Repositories;
using BookShop.Repositories.Order;
using BookShop.Repositories.OrderProduct;

namespace BookShop.Services.Order;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _dbOrder;
    private readonly IOrderProductRepository _dbOrderProduct;
    public OrderService(IOrderRepository dbOrder,
        IOrderProductRepository dbOrderProduct)
    {
        _dbOrder = dbOrder;
        _dbOrderProduct = dbOrderProduct;
    }

    public async Task<ResponseDTO> CreateOrder(OrdersEntity newOrder)
    {
        await _dbOrder.PostAsync(newOrder);

        return new ResponseDTO
        {
            Code = 200,
            Message = "Заказ успешно создан."
        };
    }

    public async Task<ResponseDTO> CreateOrderProduct(OrderProductRequestDto newOrderProduct)
    {   
        var isExists = await _dbOrderProduct.AnyAsync(c => c.OrderId.Equals(newOrderProduct.OrderId)
                                                            && c.ProductId.Equals(newOrderProduct.ProductId));
        if (isExists) 
        {
            return new ResponseDTO
            {
                Code = 200,
                Message = "Данный продукт в заказе уже существует"
            };
        }

        var orderProduct = await MapDtoToEntity(newOrderProduct);
        await _dbOrderProduct.PostAsync(orderProduct);

        return new ResponseDTO
        {
            Code = 200,
            Message = "Продукт в заказ успешно добавлен"
        };
     }

    public async Task<List<OrderProductEntity>> GetOrderProductList() =>
                await _dbOrderProduct.GetListAsync();

    public async Task<ResponseDTO> UpdateOrder(OrdersEntity newOrder)
    {
        var isExists = await _dbOrder.AnyAsync(c => c.UserId.Equals(newOrder.UserId));
        if (!isExists)
        {
            return new ResponseDTO
            {
                Code = 200,
                Message = "У данного пользователя нет заказа"
            };
        }
        
        await _dbOrder.UpdateAsync(newOrder);
        return new ResponseDTO
        {
            Code = 200,
            Message = "Статус заказа успешно изменён"
        };
    }

    private async Task<OrderProductEntity> MapDtoToEntity(OrderProductRequestDto dto) =>
        new OrderProductEntity
        {
            ProductId = dto.ProductId,
            OrderId = dto.OrderId,
            Amount = dto.Amount
        };
}
