using BookShop.Models.DTO.Users;
using BookShop.Models.Entities;
using System.Linq.Expressions;

namespace BookShop.Repositories;

public interface IRepository<T> 
    where T : IEntity
{
    Task<List<T>> GetListAsync(); 
    Task<T> GetAsync(String input);
    Task PostAsync(T input);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
}
