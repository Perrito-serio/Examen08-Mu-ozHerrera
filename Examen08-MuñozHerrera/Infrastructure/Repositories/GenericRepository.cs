// Ruta: Infrastructure/Repositories/GenericRepository.cs
using Examen08_MuñozHerrera.Core.Interfaces;
using Examen08_MuñozHerrera.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Examen08_MuñozHerrera.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    // ... puedes implementar los otros métodos si los necesitas
    public Task<T> GetByIdAsync(int id) => throw new NotImplementedException();
    public Task AddAsync(T entity) => throw new NotImplementedException();
    public void Update(T entity) => throw new NotImplementedException();
    public void Remove(T entity) => throw new NotImplementedException();
}