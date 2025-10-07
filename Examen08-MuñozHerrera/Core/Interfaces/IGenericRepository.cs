// Ruta: Core/Interfaces/IGenericRepository.cs
namespace Examen08_MuñozHerrera.Core.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}