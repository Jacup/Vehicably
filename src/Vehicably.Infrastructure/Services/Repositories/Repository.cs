using Microsoft.EntityFrameworkCore;
using Vehicably.Domain.Models;
using Vehicably.Infrastructure.DAL;
using Vehicably.Infrastructure.Exceptions;
using Vehicably.Infrastructure.Services.Interfaces;

namespace Vehicably.Infrastructure.Services.Repositories;

public class Repository<T> : IRepository<T> where T : DbObject
{
    private readonly VehicablyDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(VehicablyDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }

    protected DbSet<T> DbSet => _dbSet;

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id) ?? throw new EntityNotFoundException<T>(id);

        _dbSet.Remove(entity);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return await _dbSet
            .Where(entity => ids.Contains((Guid)typeof(T).GetProperty("Id")!.GetValue(entity)))
            .ToListAsync();
    }

    public virtual async Task InsertAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task UpdateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var current = await _dbSet.FindAsync(entity.Id) ?? throw new EntityNotFoundException<T>(entity.Id);
        _dbSet.Entry(current).CurrentValues.SetValues(entity);
    }

    public virtual async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
