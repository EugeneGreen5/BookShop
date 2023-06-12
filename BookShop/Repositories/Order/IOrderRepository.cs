using BookShop.Models.Entities;
using System.Linq.Expressions;

namespace BookShop.Repositories.Order;

public interface IOrderRepository
{
    Task<List<OrdersEntity>> GetListAsync();
    Task<OrdersEntity> GetAsync(Guid input);
    Task PostAsync(OrdersEntity input);
    Task<bool> AnyAsync(Expression<Func<OrdersEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task UpdateAsync(OrdersEntity input);
}
