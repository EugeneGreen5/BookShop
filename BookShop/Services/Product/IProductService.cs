using BookShop.Models.DTO;
using BookShop.Models.Entities;

namespace BookShop.Services.Product;


public interface IProductService
{
    public Task<List<ProductEntity>> GetListAllProducts();
    public Task<ResponseDTO> ProductHandlerAsync(ProductEntity product);
}
