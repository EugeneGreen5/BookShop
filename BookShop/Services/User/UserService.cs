using BookShop.Models.DTO;
using BookShop.Models.DTO.Users;
using BookShop.Models.Entities;
using BookShop.Repositories;

namespace BookShop.Services;

public class UserService : IUserService
{
    private readonly IRepository<UserEntity> _dbUser;
    public UserService(IRepository<UserEntity> dbUser)
    {
        _dbUser = dbUser;
    }

    public async Task<ResponseDTO> UserRegistrationHandlerAsync(UserRequestDTO newUser)
    {
        var isExists = await _dbUser.AnyAsync(c => c.Equals(
            new UserEntity
                {
                    Email = newUser.Email,
                    Password = newUser.Password
                })); 
        if (!isExists)
        {
            CreateUserAsync(newUser);
            return new ResponseDTO
            {
                Code = 200,
                Message = "Пользователь зарегистрирован"
            };
        }
        return new ResponseDTO
        {
            Code = 200,
            Message = "Пользователь с данным логином зарегистрирован"
        };
    }

    public async Task<ResponseDTO> UserAuthorizationHandlerAsync(UserRequestDTO user)
    {
        var isExists = await _dbUser.AnyAsync(c => c.Password.Equals(user.Password) && c.Email.Equals(user.Email));
        if (isExists)
        {
            return new ResponseDTO
            {
                Code = 200,
                Message = "Успешная авторизация."
            };
        }
        
        var isExistsLogin = await _dbUser.AnyAsync(c => c.Email.Equals(user.Email));
        if (isExistsLogin) 
        {
            return new ResponseDTO {
                Code = 200,
                Message = "Неверный пароль."
            };
        }
        return new ResponseDTO
        {
            Code = 200,
            Message = "Пользователь не зарегистрирован."
        };
    }

    private async void CreateUserAsync(UserRequestDTO newUser)
    {
        UserEntity userEntity = new UserEntity()
        {
            Email = newUser.Email,
            Password = newUser.Password
        };
        await _dbUser.PostAsync(userEntity);
    }

}
