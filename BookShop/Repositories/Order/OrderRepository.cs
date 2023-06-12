using BookShop.Data;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.Repositories.Order;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(Expression<Func<OrdersEntity, bool>> expression, CancellationToken cancellationToken = default) =>
        await _context.Set<OrdersEntity>().AnyAsync(expression, cancellationToken);

    public Task<OrdersEntity> GetAsync(Guid input)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrdersEntity>> GetListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task PostAsync(OrdersEntity input)
    {
        await _context.AddAsync(input);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrdersEntity input)
    {

    }
}
