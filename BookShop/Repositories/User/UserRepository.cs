using BookShop.Data;
using BookShop.Models.DTO.Users;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.Repositories.User;

public class UserRepository : IUserRepository
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

    public async Task<UserEntity> GetAsync(string email)
    {
        return await _context.users.FirstAsync(x => x.Email == email);
    }

    public Task<List<UserEntity>> GetListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task PostAsync(UserEntity newUser)
    {
        await _context.AddAsync(newUser);
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(UserEntity input)
    {
        throw new NotImplementedException();
    }
}
