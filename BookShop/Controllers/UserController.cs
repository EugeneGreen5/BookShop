using BookShop.Models.DTO;
using BookShop.Models.DTO.Users;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController
{
    [HttpPost("registration")]
    public async Task<ActionResult<ResponseDTO>> RegistrationAsync(UserRequestDTO newUser)
    {
        
    }
}
