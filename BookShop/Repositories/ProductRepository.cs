using BookShop.Data;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.Repositories;

public class ProductRepository : IRepository<ProductEntity>
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(Expression<Func<ProductEntity, bool>> expression, CancellationToken cancellationToken = default) =>
        await _context.Set<ProductEntity>().AnyAsync(expression, cancellationToken);

    public Task<ProductEntity> GetAsync(string input)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductEntity>> GetListAsync() =>
        await _context.products.ToListAsync();

    public Task PostAsync(ProductEntity input)
    {
        throw new NotImplementedException();
    }
}
