// Ruta: Controllers/ProductsController.cs
using Examen08_MuñozHerrera.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen08_MuñozHerrera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // GET: api/products/price-greater-than?price=20
    [HttpGet("price-greater-than")]
    public async Task<IActionResult> GetProductsByPrice([FromQuery] decimal price)
    {
        var products = await _productRepository.GetProductsByPriceGreaterThanAsync(price);
        return Ok(products);
    }
}