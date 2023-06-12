using BookShop.Services.Order;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController
{
    private readonly IOrderService _service;
    public OrderController(IOrderService service)
    {
        _service = service;
    }


}
