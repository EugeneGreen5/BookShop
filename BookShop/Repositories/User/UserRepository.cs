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
        return await _context.Users.FirstAsync(x => x.Email == email);
    }

    public async Task<UserEntity> GetFullInfoAsync(string email) =>
        await _context.Users.Include(x => x.Orders).ThenInclude(c => c.OrderProducts).ThenInclude(c => c.Product).FirstOrDefaultAsync(c => c.Email.Equals(email));

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
