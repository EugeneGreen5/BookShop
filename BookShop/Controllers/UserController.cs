using BookShop.Helpers;
using BookShop.Models.DTO;
using BookShop.Models.DTO.Users;
using BookShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookShop.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class UserController
{
    private readonly IUserService _service;
    private readonly JWTSettings _options;
    public UserController(IUserService service,
        IOptions<JWTSettings> optAccess)
    {
        _service = service;
        _options = optAccess.Value;
    }
    [HttpGet("get")]
    public string Get() => "get";


    [HttpPost("registration")]
    public async Task<ActionResult<ResponseDTO>> RegistrationAsync(UserRequestDTO newUser) =>
        await _service.UserRegistrationHandlerAsync(newUser);

    [HttpPost("authorization")]
    public async Task<ActionResult<ResponseDTO>> AuthorizationAsync(UserRequestDTO user) =>
        await _service.UserAuthorizationHandlerAsync(user);

    [HttpPost("token")]
    public string GetToken(UserRequestDTO user)
    {
        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim("Email", user.Email));
        claims.Add(new Claim("Role","user"));
        var signineKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

        var jwt = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
            notBefore:DateTime.UtcNow,
            signingCredentials: new SigningCredentials(signineKey,SecurityAlgorithms.HmacSha256)
            );
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
