using BookShop.Data;
using BookShop.Models.DTO.Users;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.Repositories;

public class UserRepository : IRepository<UserEntity>
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(Expression<Func<UserEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _context.Set<UserEntity>().AnyAsync(expression, cancellationToken);
    }

    public async Task<UserEntity> GetAsync(String email)
    {
        return await _context.users.FirstAsync(x => x.Email == email);
    }

    public Task<UserEntity> GetListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task PostAsync(UserEntity newUser)
    {
        await _context.AddAsync(newUser);
        await _context.SaveChangesAsync();
    }
}
