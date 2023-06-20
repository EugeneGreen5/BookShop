using BookShop.Models.DTO.Order;
using BookShop.Models.Entities;
using System.Linq.Expressions;

namespace BookShop.Repositories.OrderProduct;

public interface IOrderProductRepository
{
    Task PostAsync(OrderProductEntity input);
    Task UpdateAsync(OrderProductRequestDto input);
    Task<OrderProductEntity> GetByDtoAsync(OrderProductRequestDto input);
    Task<bool> AnyAsync(Expression<Func<OrderProductEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task<List<OrderProductEntity>> GetListAsync();
    Task<OrderProductEntity> GetFromDb(OrderProductRequestDto input);
}
