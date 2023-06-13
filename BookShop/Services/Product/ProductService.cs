using BookShop.Models.DTO;
using BookShop.Models.Entities;
using BookShop.Repositories;
using BookShop.Repositories.Product;
using BookShop.Repositories.User;

namespace BookShop.Services.Product;

public class ProductService : IProductService
{
    private readonly IProductRepository _dbProduct;
    public ProductService(IProductRepository dbProduct)
    {
        _dbProduct = dbProduct;
    }
    public async Task<List<ProductEntity>> GetListAllProducts() =>
        await _dbProduct.GetListAsync();

    public async Task<ResponseDTO> ProductHandlerAsync(ProductEntity product)
    {
        var isExist = await _dbProduct.AnyAsync(c => c.Name.Equals(product.Name));

        if (isExist)
        {
            return new ResponseDTO
            {
                Code = 200,
                Message = "Продукт с данным название уже существует "
            };
        }

        await CreateProduct(product);

        return new ResponseDTO
        {
            Code = 200,
            Message = "Продукт успешно создан"
        };

    }

    private async Task CreateProduct(ProductEntity product)
    {
        await _dbProduct.PostAsync(product);
    }
}
