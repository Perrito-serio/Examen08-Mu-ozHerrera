// Ruta: Core/Interfaces/IProductRepository.cs
using Examen08_MuñozHerrera.Core.Entities;

namespace Examen08_MuñozHerrera.Core.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByPriceGreaterThanAsync(decimal price);
    
    Task<Product?> GetMostExpensiveProductAsync();
    
    
}