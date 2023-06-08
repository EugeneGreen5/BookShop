using BookShop.Models.DTO.Users;
using BookShop.Models.Entities;
using System.Linq.Expressions;

namespace BookShop.Repositories;

public interface IRepository<T> 
    where T : IEntity
{
    Task<T> GetListAsync(); 
    Task<T> GetAsync(String email);
    Task PostAsync(T newUser);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
}
