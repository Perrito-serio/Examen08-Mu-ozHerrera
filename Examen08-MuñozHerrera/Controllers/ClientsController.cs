// Ruta: Controllers/ClientsController.cs
using Examen08_MuñozHerrera.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen08_MuñozHerrera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientRepository _clientRepository;

    public ClientsController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    // GET: api/clients/search?name=Juan
    [HttpGet("search")]
    public async Task<IActionResult> GetClientsByName([FromQuery] string name)
    {
        var clients = await _clientRepository.FindClientsByNameAsync(name);
        return Ok(clients);
    }
    
    [HttpGet("with-most-orders")]
    public async Task<IActionResult> GetClientWithMostOrders()
    {
        var client = await _clientRepository.GetClientWithMostOrdersAsync();
        if (client == null)
        {
            return NotFound("No se encontraron clientes con pedidos.");
        }
        return Ok(client);
    }
}