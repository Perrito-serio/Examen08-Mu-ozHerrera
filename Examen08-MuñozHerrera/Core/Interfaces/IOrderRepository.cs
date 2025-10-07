// Ruta: Core/Interfaces/IOrderRepository.cs
using Examen08_MuñozHerrera.Core.Entities;

namespace Examen08_MuñozHerrera.Core.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);
}