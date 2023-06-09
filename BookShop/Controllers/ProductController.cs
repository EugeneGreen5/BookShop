using BookShop.Models.Entities;
using BookShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController
{
    private readonly IProductService _service;
    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<ProductEntity>> GetList() 
        => await _service.GetListAllProducts();

    [HttpPost]
    public async Task<>
}
