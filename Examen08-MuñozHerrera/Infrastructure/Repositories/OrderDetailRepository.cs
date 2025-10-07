using Examen08_MuñozHerrera.Core.Entities;
using Examen08_MuñozHerrera.Core.Interfaces;
using Examen08_MuñozHerrera.DTOs;
using Examen08_MuñozHerrera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Examen08_MuñozHerrera.Infrastructure.Repositories;

public class OrderDetailRepository : GenericRepository<Orderdetail>, IOrderDetailRepository
{
    public OrderDetailRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<OrderProductDetailDto>> GetDetailsByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Include(od => od.Product) 
            .Where(od => od.Orderid == orderId) 
            .Select(od => new OrderProductDetailDto 
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
    
    public async Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.Orderid == orderId)
            .SumAsync(od => od.Quantity);
    }
}