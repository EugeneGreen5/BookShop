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

    public async Task<OrdersEntity> GetAsync(Guid input)
        => await _context.Orders.FirstOrDefaultAsync(c => c.Id.Equals(input));

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
        var order = await GetAsync(input.Id);
        order.State = input.State;
        await _context.SaveChangesAsync();
    }
}
