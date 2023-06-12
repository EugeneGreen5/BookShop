using BookShop.Models.Entities;
using System.Linq.Expressions;

namespace BookShop.Repositories.Product;

public interface IProductRepository
{
    Task<List<ProductEntity>> GetListAsync();
    Task<ProductEntity> GetAsync(Guid input);
    Task PostAsync(ProductEntity input);
    Task<bool> AnyAsync(Expression<Func<ProductEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task UpdateAsync(ProductEntity input);
}
