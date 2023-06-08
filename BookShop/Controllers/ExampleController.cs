using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers;

[ApiController]
[Authorize]
[Route("/api/get")]
public class ExampleController
{
    [HttpGet]
    public string Get() => "example";   
}
