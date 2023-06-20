using BookShop.Models.DTO;
using BookShop.Models.DTO.Order;
using BookShop.Models.Entities;
using BookShop.Services.Order;
using Microsoft.AspNetCore.Mvc;

namespace BookSzhop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController
{
    private readonly IOrderService _service;
    public OrderController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet("list")]
    public async Task<List<OrderProductEntity>> GetList() =>
        await _service.GetOrderProductList();

    [HttpPost]
    public async Task<ResponseDTO> CreateOrder(OrdersEntity newOrder) => 
        await _service.CreateOrder(newOrder);

    [HttpPost("product")]
    public async Task<ResponseDTO> CreateOrderProduct(OrderProductRequestDto newProduct) =>
        await _service.CreateOrderProduct(newProduct);

    [HttpPut]
    public async Task<ResponseDTO> UpdateStateOrder(OrdersEntity newOrder)=> 
        await _service.UpdateOrder(newOrder);

    [HttpPut("amount")]
    public async Task<ResponseDTO> UpdateCounterOrderProduct(OrderProductRequestDto newOrderProduct) =>
        await _service.UpdateCounterProduct(newOrderProduct);

}
