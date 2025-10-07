using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.Core.Interfaces;
using Examen08_MuñozHerrera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

using Examen08_MuñozHerrera.DTOs;

namespace Examen08_MuñozHerrera.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.Orderdate > date) 
            .ToListAsync();
    }
    
    public async Task<IEnumerable<OrderWithDetailsDto>> GetAllOrdersWithDetailsAsync()
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .Select(o => new OrderWithDetailsDto
            {
                OrderId = o.Orderid,
                OrderDate = o.Orderdate,
                ClientName = o.Client.Name,
                Details = o.Orderdetails.Select(od => new OrderProductDetailDto
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity
                }).ToList()
            })
            .ToListAsync();
    }
}