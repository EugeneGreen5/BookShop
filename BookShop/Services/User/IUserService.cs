using BookShop.Models.DTO;
using BookShop.Models.DTO.Users;
using BookShop.Models.Entities;

namespace BookShop.Services;

public interface IUserService
{
    public Task<ResponseDTO> UserRegistrationHandlerAsync(UserRequestDTO newUser);
    public Task<ResponseDTO> UserAuthorizationHandlerAsync(UserRequestDTO user);
    public Task<UserEntity> GetFullInfoAsync(UserRequestDTO user);
}
