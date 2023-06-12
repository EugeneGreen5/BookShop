using BookShop.Data;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.Repositories.Product;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(Expression<Func<ProductEntity, bool>> expression, CancellationToken cancellationToken = default) =>
        await _context.Set<ProductEntity>().AnyAsync(expression, cancellationToken);

    public Task<ProductEntity> GetAsync(Guid input)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductEntity>> GetListAsync() =>
        await _context.products.ToListAsync();

    public async Task PostAsync(ProductEntity input)
    {
        await _context.AddAsync(input);
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(ProductEntity input)
    {
        throw new NotImplementedException();
    }
}
