// Ruta: Core/Interfaces/IClientRepository.cs
using Examen08_MuñozHerrera.Core.Entities;

using Examen08_MuñozHerrera.DTOs; 

namespace Examen08_MuñozHerrera.Core.Interfaces;

public interface IClientRepository : IGenericRepository<Client>
{
    Task<IEnumerable<Client>> FindClientsByNameAsync(string name);
    
    Task<ClientWithOrderCountDto?> GetClientWithMostOrdersAsync();

    Task<IEnumerable<Client>> GetClientsByProductAsync(int productId);

    
}