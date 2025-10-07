// Ruta: Infrastructure/Repositories/OrderRepository.cs
using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.Core.Interfaces;
using Examen08_MuñozHerrera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

using Examen08_MuñozHerrera.DTOs;

namespace Examen08_MuñozHerrera.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        // La consulta LINQ para filtrar por fecha.
        // Se lee como: "De la tabla Orders, selecciona aquellas donde la OrderDate sea mayor que la fecha proporcionada".
        return await _context.Orders
            .Where(o => o.Orderdate > date) // <-- ¡La lógica LINQ de filtrado!
            .ToListAsync();
    }
    
    public async Task<IEnumerable<OrderWithDetailsDto>> GetAllOrdersWithDetailsAsync()
    {
        return await _context.Orders
            // 1. Incluimos la información del Cliente.
            .Include(o => o.Client)
            // 2. Incluimos los Detalles de la Orden.
            .Include(o => o.Orderdetails)
            // 3. Y para cada Detalle, incluimos la información del Producto.
            .ThenInclude(od => od.Product)
            // 4. Proyectamos todo a nuestro DTO maestro.
            .Select(o => new OrderWithDetailsDto
            {
                OrderId = o.Orderid,
                OrderDate = o.Orderdate,
                ClientName = o.Client.Name,
                // 5. Para la lista de detalles, hacemos una sub-proyección.
                Details = o.Orderdetails.Select(od => new OrderProductDetailDto
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity
                }).ToList()
            })
            .ToListAsync();
    }
}