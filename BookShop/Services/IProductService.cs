using BookShop.Models.Entities;

namespace BookShop.Services;


public interface IProductService
{
    public Task<List<ProductEntity>> GetListAllProducts();
}
