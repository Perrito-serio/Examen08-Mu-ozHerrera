using Microsoft.AspNetCore.Mvc;

namespace Examen08_MuñozHerrera.Application.Services;

[ApiController]
[Route("[controller]")]
public class NAME : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}