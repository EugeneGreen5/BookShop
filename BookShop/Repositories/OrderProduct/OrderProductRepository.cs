using BookShop.Data;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.Repositories.OrderProduct;

public class OrderProductRepository : IOrderProductRepository
{
    private readonly ApplicationDbContext _context;
    public OrderProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> AnyAsync(Expression<Func<OrderProductEntity, bool>> expression, CancellationToken cancellationToken = default) =>
        await _context.Set<OrderProductEntity>().AnyAsync(expression, cancellationToken);


    public async Task PostAsync(OrderProductEntity input)
    {
        await _context.orderProducts.AddAsync(input);
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(OrderProductEntity input)
    {
        throw new NotImplementedException();
    }
}
