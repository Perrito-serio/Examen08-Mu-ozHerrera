// Ruta: Infrastructure/Repositories/OrderDetailRepository.cs
using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.Core.Interfaces;
using Examen08_MuñozHerrera.DTOs;
using Examen08_MuñozHerrera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Examen08_MuñozHerrera.Infrastructure.Repositories;

public class OrderDetailRepository : GenericRepository<Orderdetail>, IOrderDetailRepository
{
    public OrderDetailRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<OrderProductDetailDto>> GetDetailsByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            // 1. Incluimos la información del Producto relacionado para poder acceder a su nombre.
            .Include(od => od.Product) 
            // 2. Filtramos los detalles que pertenecen a la orden específica.
            .Where(od => od.Orderid == orderId) 
            // 3. Proyectamos el resultado a nuestro DTO, seleccionando solo los campos que necesitamos.
            .Select(od => new OrderProductDetailDto 
            {
                ProductName = od.Product.Name, // Tomamos el nombre del producto relacionado
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
    
    public async Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            // 1. Filtramos los detalles por el ID de la orden.
            .Where(od => od.Orderid == orderId)
            // 2. Sumamos directamente el valor de la columna 'Quantity' para los registros filtrados.
            .SumAsync(od => od.Quantity); // <-- ¡La lógica LINQ de agregación!
    }
}