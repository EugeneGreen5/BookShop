using BookShop.Models.DTO;
using BookShop.Models.DTO.Users;

namespace BookShop.Services;

public interface IUserService
{
    public Task<ResponseDTO> UserRegistrationHandler(UserRequestDTO newUser);
}
