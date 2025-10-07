// Ruta: Controllers/OrdersController.cs
using Examen08_MuñozHerrera.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen08_MuñozHerrera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrdersController(IOrderDetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
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
        // Devolvemos el resultado en un objeto anónimo para que la respuesta JSON sea más clara.
        return Ok(new { orderId = orderId, totalQuantity = total });
    }
}