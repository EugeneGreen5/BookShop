using BookShop.Models.Entities;
using System.Linq.Expressions;

namespace BookShop.Repositories.User;

public interface IUserRepository 
{
    public Task<List<UserEntity>> GetListAsync();
    public Task<UserEntity> GetAsync(string input);
    public Task<UserEntity> GetFullInfoAsync(string email);
    public Task PostAsync(UserEntity input);
    public Task<bool> AnyAsync(Expression<Func<UserEntity, bool>> expression, CancellationToken cancellationToken = default);
    public Task UpdateAsync(UserEntity input);
}
