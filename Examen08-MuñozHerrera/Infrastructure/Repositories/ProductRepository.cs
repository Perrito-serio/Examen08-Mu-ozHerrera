// Ruta: Infrastructure/Repositories/ProductRepository.cs
using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.Core.Interfaces;
using Examen08_MuñozHerrera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Examen08_MuñozHerrera.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsByPriceGreaterThanAsync(decimal price)
    {
        return await _context.Products
            .Where(p => p.Price > price) 
            .ToListAsync();
    }
    
    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }
    
    public async Task<decimal> GetAverageProductPriceAsync()
    {
        return await _context.Products.AverageAsync(p => p.Price); 
    }
    
    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description)) 
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Product>> GetProductsSoldToClientAsync(int clientId)
    {
   
        return await _context.Products
            .Where(p => p.Orderdetails.Any(od => od.Order.Clientid == clientId))
            .Distinct()
            .ToListAsync();
    }

}