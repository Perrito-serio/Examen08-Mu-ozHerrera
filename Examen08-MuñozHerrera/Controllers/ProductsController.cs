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
    
    // GET: api/products/most-expensive
    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensiveProduct()
    {
        var product = await _productRepository.GetMostExpensiveProductAsync();

        // Es una buena práctica verificar si se encontró un producto antes de devolverlo.
        if (product == null)
        {
            return NotFound("No se encontraron productos en la base de datos.");
        }
            
        return Ok(product);
    }
}