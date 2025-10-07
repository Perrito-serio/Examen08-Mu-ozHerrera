// Ruta: Infrastructure/Repositories/ClientRepository.cs
using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.Core.Interfaces;
using Examen08_MuñozHerrera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

using Examen08_MuñozHerrera.DTOs;

namespace Examen08_MuñozHerrera.Infrastructure.Repositories;

public class ClientRepository : GenericRepository<Client>, IClientRepository
{
    public ClientRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Client>> FindClientsByNameAsync(string name)
    {
        return await _context.Clients
            .Where(c => c.Name.Contains(name)) // <-- ¡Aquí está la magia de LINQ!
            .ToListAsync();
    }
    
    public async Task<ClientWithOrderCountDto?> GetClientWithMostOrdersAsync()
    {
        return await _context.Clients
            // 1. Incluimos la colección de Orders de cada cliente para poder contarlas.
            .Include(c => c.Orders)
            // 2. Proyectamos el resultado directamente a nuestro DTO.
            .Select(c => new ClientWithOrderCountDto
            {
                ClientName = c.Name,
                // 3. Contamos la cantidad de elementos en la colección de Orders de cada cliente.
                OrderCount = c.Orders.Count()
            })
            // 4. Ordenamos los DTOs resultantes por la cantidad de pedidos en orden descendente.
            .OrderByDescending(dto => dto.OrderCount)
            // 5. Tomamos el primer resultado, que será el cliente con más pedidos.
            .FirstOrDefaultAsync();
    }
    
    public async Task<IEnumerable<Client>> GetClientsByProductAsync(int productId)
    {
        // La consulta se puede leer así:
        // "Desde la tabla de Clientes..."
        return await _context.Clients
            // "...filtra (Where) y quédate solo con aquellos clientes (c) para los cuales..."
            // "...exista al menos un (Any) pedido (o) en su lista de pedidos..."
            // "...que a su vez tenga al menos un (Any) detalle de orden (od)..."
            // "...cuyo ProductId sea igual al productId que nos pasaron."
            .Where(c => c.Orders.Any(o => o.Orderdetails.Any(od => od.Productid == productId)))

            // "Asegúrate de que la lista final no tenga clientes duplicados."
            .Distinct()

            .ToListAsync();
    }
}