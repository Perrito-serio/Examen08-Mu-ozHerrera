using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.DTOs;
using Examen08_MuñozHerrera.DTOs;

namespace Examen08_MuñozHerrera.Core.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderProductDetailDto>> GetDetailsByOrderIdAsync(int orderId);
    Task<int> GetTotalQuantityByOrderIdAsync(int orderId);
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);
    Task<IEnumerable<OrderWithDetailsDto>> GetAllOrdersWithDetailsAsync();
}
