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
        // La consulta LINQ para resolver el ejercicio.
        // Se lee como: "De la tabla Products, selecciona aquellos donde el Precio es mayor que el precio proporcionado".
        return await _context.Products
            .Where(p => p.Price > price) // <-- ¡La lógica LINQ!
            .ToListAsync();
    }
    
    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _context.Products
            // 1. Ordena todos los productos por su precio en orden descendente (del más caro al más barato).
            .OrderByDescending(p => p.Price)
            // 2. Toma el primer elemento de la lista ordenada.
            .FirstOrDefaultAsync();
    }
    
    public async Task<decimal> GetAverageProductPriceAsync()
    {
        // Si no hay productos, AverageAsync lanzará una excepción. 
        // Una comprobación previa es una buena práctica.
        if (!await _context.Products.AnyAsync())
        {
            return 0;
        }

        // Calcula el promedio del valor de la columna 'Price' para todos los productos.
        return await _context.Products.AverageAsync(p => p.Price); // <-- ¡La lógica LINQ de agregación!
    }
    
    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        // La consulta LINQ para filtrar por descripción nula o vacía.
        // string.IsNullOrEmpty() se traduce eficientemente a SQL.
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description)) // <-- ¡La lógica LINQ!
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Product>> GetProductsSoldToClientAsync(int clientId)
    {
        // La consulta se puede leer así:
        // "Desde la tabla de Productos..."
        return await _context.Products
            // "...filtra (Where) y quédate solo con aquellos productos (p) para los cuales..."
            // "...exista al menos un (Any) detalle de orden (od) en su lista de detalles..."
            // "...tal que el ClientId de la orden (Order) asociada a ese detalle sea igual al clientId que nos pasaron."
            .Where(p => p.Orderdetails.Any(od => od.Order.Clientid == clientId))

            // "Finalmente, de la lista resultante, asegúrate de que no haya duplicados."
            .Distinct() 

            // "Y convierte el resultado en una lista."
            .ToListAsync();
    }

}