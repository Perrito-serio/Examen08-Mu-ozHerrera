// Ruta: Infrastructure/Repositories/OrderRepository.cs
using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.Core.Interfaces;
using Examen08_MuñozHerrera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
}