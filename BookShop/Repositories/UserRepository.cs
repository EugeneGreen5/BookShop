using BookShop.Data;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.Repositories;

public class UserRepository : IRepository<UserRepository>
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<bool> AnyAsync(Expression<Func<IEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
       return _context.Set<UserEntity>().AnyAsync(expression, cancellationToken);
    }

    public Task<UserRepository> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserRepository> GetListAsync()
    {
        throw new NotImplementedException();
    }
}
