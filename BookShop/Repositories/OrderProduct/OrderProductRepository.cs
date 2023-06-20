using BookShop.Data;
using BookShop.Models.DTO.Order;
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

    public async Task<OrderProductEntity> GetByDtoAsync(OrderProductRequestDto input)=>
        await _context.OrderProducts.Include(c => c.Product).FirstOrDefaultAsync(c => c.OrderId.Equals(input.OrderId)
                                                                                     && c.ProductId.Equals(input.ProductId));
    public async Task<OrderProductEntity> GetFromDb(OrderProductRequestDto input) =>
        await _context.OrderProducts.Include(c => c.Product).FirstOrDefaultAsync(c => c.OrderId.Equals(input.OrderId)
                                                                                 && c.ProductId.Equals(input.ProductId));

    public async Task PostAsync(OrderProductEntity input)
    {
        await _context.OrderProducts.AddAsync(input);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrderProductRequestDto input)
    {
        var orderProduct = await GetFromDb(input);
        orderProduct.Amount = input.Amount;
        await _context.SaveChangesAsync();
    }

    public Task<List<OrderProductEntity>> GetListAsync() =>
        _context.OrderProducts.Include(c => c.Product).ToListAsync();
}
