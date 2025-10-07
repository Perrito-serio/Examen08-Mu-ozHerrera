using Examen08_MuñozHerrera.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen08_MuñozHerrera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IOrderRepository _orderRepository; 

    public OrdersController(IOrderDetailRepository orderDetailRepository, IOrderRepository orderRepository)
    {
        _orderDetailRepository = orderDetailRepository;
        _orderRepository = orderRepository;

    }

    // GET: api/orders/1/details
    [HttpGet("{orderId}/details")]
    public async Task<IActionResult> GetOrderDetails(int orderId)
    {
        var details = await _orderDetailRepository.GetDetailsByOrderIdAsync(orderId);
        return Ok(details);
    }
    
    // GET: api/orders/1/total-quantity
    [HttpGet("{orderId}/total-quantity")]
    public async Task<IActionResult> GetTotalQuantity(int orderId)
    {
        var total = await _orderDetailRepository.GetTotalQuantityByOrderIdAsync(orderId);
        return Ok(new { orderId = orderId, totalQuantity = total });
    }
    
    // GET: api/orders/after-date?date=2025-05-03
    [HttpGet("after-date")]
    public async Task<IActionResult> GetOrdersAfterDate([FromQuery] DateTime date)
    {
        var orders = await _orderRepository.GetOrdersAfterDateAsync(date);
        return Ok(orders);
    }
    
    [HttpGet("with-details")]
    public async Task<IActionResult> GetAllOrdersWithDetails()
    {
        var orders = await _orderRepository.GetAllOrdersWithDetailsAsync();
        return Ok(orders);
    }
}