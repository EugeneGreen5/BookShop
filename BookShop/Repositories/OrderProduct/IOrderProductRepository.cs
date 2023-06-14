using BookShop.Models.Entities;
using System.Linq.Expressions;

namespace BookShop.Repositories.OrderProduct;

public interface IOrderProductRepository
{
    Task PostAsync(OrderProductEntity input);
    Task UpdateAsync(OrderProductEntity input);
    Task<bool> AnyAsync(Expression<Func<OrderProductEntity, bool>> expression, CancellationToken cancellationToken = default);
}
