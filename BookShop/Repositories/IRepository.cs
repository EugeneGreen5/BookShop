using BookShop.Models.Entities;
using System.Linq.Expressions;

namespace BookShop.Repositories;

public interface IRepository<T> 
    where T : IEntity
{
    Task<T> GetListAsync(); 
    Task<T> GetAsync(Guid id);

    Task<bool> AnyAsync(Expression<Func<IEntity, bool>> expression, CancellationToken cancellationToken = default);
}
