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
}