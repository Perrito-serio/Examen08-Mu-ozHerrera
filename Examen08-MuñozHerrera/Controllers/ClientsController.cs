using Microsoft.AspNetCore.Mvc;
using Examen08_MuñozHerrera.Core.Interfaces; // <-- Importante

namespace Examen08_MuñozHerrera.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService; // <-- Inyecta el SERVICIO

        public ClientsController(IClientService clientService) // <-- Pide el SERVICIO
        {
            _clientService = clientService;
        }

        [HttpGet("most-orders")]
        public async Task<IActionResult> GetClientWithMostOrders()
        {
            var clientDto = await _clientService.GetClientWithMostOrdersAsync(); // <-- Llama al SERVICIO
            if (clientDto == null)
            {
                return NotFound("No se encontraron clientes con órdenes.");
            }
            return Ok(clientDto);
        }
    }
}