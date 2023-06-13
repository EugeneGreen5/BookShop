using BookShop.Models.DTO;
using BookShop.Models.Entities;
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

    [HttpPost]
    public async Task<ResponseDTO> CreateOrder(OrdersEntity newOrder)
        => await _service.CreateOrder(newOrder);
}
