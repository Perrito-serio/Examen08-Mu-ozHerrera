// Ruta: Core/Interfaces/IClientRepository.cs
using Examen08_MuñozHerrera.Core.Entities;

namespace Examen08_MuñozHerrera.Core.Interfaces;

public interface IClientRepository : IGenericRepository<Client>
{
    Task<IEnumerable<Client>> FindClientsByNameAsync(string name);
}