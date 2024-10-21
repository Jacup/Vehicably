using Vehicably.Domain.Models;

namespace Vehicably.Infrastructure.Services.Interfaces;

public interface IRepository<T> where T : DbObject
{
    Task DeleteAsync(Guid id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(Guid id);

    Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> ids);

    Task InsertAsync(T entity);

    Task UpdateAsync(T entity);
}
