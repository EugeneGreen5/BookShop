using BookShop.Models.DTO;
using BookShop.Models.DTO.Users;

namespace BookShop.Services;

public interface IUserService
{
    public Task<ResponseDTO> UserRegistrationHandlerAsync(UserRequestDTO newUser);
    public Task<ResponseDTO> UserAuthorizationHandlerAsync(UserRequestDTO user);

}
