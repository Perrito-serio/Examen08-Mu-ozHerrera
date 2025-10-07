// Ruta: Infrastructure/Repositories/ClientRepository.cs
using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.Core.Interfaces;
using Examen08_MuñozHerrera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
}