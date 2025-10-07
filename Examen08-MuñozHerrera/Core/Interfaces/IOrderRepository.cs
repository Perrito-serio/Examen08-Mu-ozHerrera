// Ruta: Core/Interfaces/IOrderRepository.cs
using Examen08_MuñozHerrera.Core.Entities;

using Examen08_MuñozHerrera.DTOs;

namespace Examen08_MuñozHerrera.Core.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);
    
    Task<IEnumerable<OrderWithDetailsDto>> GetAllOrdersWithDetailsAsync();

    
}