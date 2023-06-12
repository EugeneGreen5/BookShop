using BookShop.Models.DTO;
using BookShop.Models.Entities;
using BookShop.Repositories;

namespace BookShop.Services.Order;

public class OrderService : IOrderService
{
    private readonly IRepository<OrdersEntity> _dbOrder;
    public OrderService(IRepository<OrdersEntity> dbOrder)
    {
        _dbOrder = dbOrder;
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

    public Task<List<OrdersEntity>> GetOrdersList()
    {
        throw new NotImplementedException();
    }

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
}
