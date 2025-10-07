// Ruta: DTOs/OrderWithDetailsDto.cs
namespace Examen08_MuñozHerrera.DTOs;

public class OrderWithDetailsDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string ClientName { get; set; }
    public List<OrderProductDetailDto> Details { get; set; }
}