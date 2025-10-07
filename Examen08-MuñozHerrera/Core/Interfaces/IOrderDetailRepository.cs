// Ruta: Core/Interfaces/IOrderDetailRepository.cs
using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.DTOs;

namespace Examen08_MuñozHerrera.Core.Interfaces;

public interface IOrderDetailRepository : IGenericRepository<Orderdetail>
{
    Task<IEnumerable<OrderProductDetailDto>> GetDetailsByOrderIdAsync(int orderId);

    Task<int> GetTotalQuantityByOrderIdAsync(int orderId);

}