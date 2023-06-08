using BookShop.Models.DTO;
using BookShop.Models.DTO.Users;
using BookShop.Services;
using Microsoft.AspNetCore.Mvc;
    
namespace BookShop.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class UserController
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }
    [HttpGet("get")]
    public string Get() => "get";


    [HttpPost("registration")]
    public async Task<ActionResult<ResponseDTO>> RegistrationAsync(UserRequestDTO newUser) =>
        await _service.UserRegistrationHandlerAsync(newUser);

    [HttpPost("authorization")]
    public async Task<ActionResult<ResponseDTO>> AuthorizationAsync(UserRequestDTO user) =>
        await _service.UserAuthorizationHandlerAsync(user);
    
}
