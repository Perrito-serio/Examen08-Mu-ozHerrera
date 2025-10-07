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
            .Where(c => c.Name.Contains(name)) 
            .ToListAsync();
    }
    
    public async Task<ClientWithOrderCountDto?> GetClientWithMostOrdersAsync()
    {
        return await _context.Clients
            .Include(c => c.Orders)
            .Select(c => new ClientWithOrderCountDto
            {
                ClientName = c.Name,
                OrderCount = c.Orders.Count()
            })
            .OrderByDescending(dto => dto.OrderCount)
            .FirstOrDefaultAsync();
    }
    
    public async Task<IEnumerable<Client>> GetClientsByProductAsync(int productId)
    {
        return await _context.Clients

            .Where(c => c.Orders.Any(o => o.Orderdetails.Any(od => od.Productid == productId)))

            .Distinct()

            .ToListAsync();
    }
}