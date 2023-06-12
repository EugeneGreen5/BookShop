using BookShop.Models.Entities;
using System.Linq.Expressions;

namespace BookShop.Repositories.User;

public interface IUserRepository 
{
    Task<List<UserEntity>> GetListAsync();
    Task<UserEntity> GetAsync(string input);
    Task PostAsync(UserEntity input);
    Task<bool> AnyAsync(Expression<Func<UserEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task UpdateAsync(UserEntity input);
}
