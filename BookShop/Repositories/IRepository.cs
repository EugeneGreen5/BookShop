using BookShop.Models.Entities;
using System.Linq.Expressions;

namespace BookShop.Repositories;

public interface IRepository<T> 
    where T : IEntity
{
    Task<List<T>> GetListAsync(); 
    Task<T> GetAsync(object? input);
    Task PostAsync(T input);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task UpdateAsync(OrdersEntity input);
}
