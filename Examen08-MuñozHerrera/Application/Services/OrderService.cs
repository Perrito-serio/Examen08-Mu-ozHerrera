using Examen08_MuñozHerrera.DTOs;
using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.Core.Interfaces;
using Examen08_MuñozHerrera.DTOs;

namespace Examen08_MuñozHerrera.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
    {
        _orderRepository = orderRepository;
        _orderDetailRepository = orderDetailRepository;
    }

    public Task<IEnumerable<OrderProductDetailDto>> GetDetailsByOrderIdAsync(int orderId)
    {
        return _orderDetailRepository.GetDetailsByOrderIdAsync(orderId);
    }

    public Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
    {
        return _orderDetailRepository.GetTotalQuantityByOrderIdAsync(orderId);
    }

    public Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return _orderRepository.GetOrdersAfterDateAsync(date);
    }

    public Task<IEnumerable<OrderWithDetailsDto>> GetAllOrdersWithDetailsAsync()
    {
        return _orderRepository.GetAllOrdersWithDetailsAsync();
    }
}
