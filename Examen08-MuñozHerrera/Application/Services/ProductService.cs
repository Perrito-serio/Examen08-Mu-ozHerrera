using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.Core.Interfaces;

namespace Examen08_MuñozHerrera.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<IEnumerable<Product>> GetProductsByPriceGreaterThanAsync(decimal price)
    {
        return _productRepository.GetProductsByPriceGreaterThanAsync(price);
    }

    public Task<Product?> GetMostExpensiveProductAsync()
    {
        return _productRepository.GetMostExpensiveProductAsync();
    }

    public Task<decimal> GetAverageProductPriceAsync()
    {
        return _productRepository.GetAverageProductPriceAsync();
    }

    public Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        return _productRepository.GetProductsWithoutDescriptionAsync();
    }

    public Task<IEnumerable<Product>> GetProductsSoldToClientAsync(int clientId)
    {
        return _productRepository.GetProductsSoldToClientAsync(clientId);
    }
}
