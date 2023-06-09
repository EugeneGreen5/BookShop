using BookShop.Models.Entities;
using BookShop.Repositories;

namespace BookShop.Services;

public class ProductService : IProductService
{
    private readonly IRepository<ProductEntity> _dbProduct;
    public ProductService(IRepository<ProductEntity> dbProduct)
    {
        _dbProduct = dbProduct;
    }
    public async Task<List<ProductEntity>> GetListAllProducts() =>
        await _dbProduct.GetListAsync();
}
