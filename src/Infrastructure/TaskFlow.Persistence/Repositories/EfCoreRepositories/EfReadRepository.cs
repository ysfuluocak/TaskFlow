using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories;

public class EfReadRepository<TEntity> : IReadRepository<TEntity>
    where TEntity : class, new()
{
    private readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public EfReadRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        var result = predicate != null ? _dbSet.AsNoTracking().Where(predicate) : _dbSet.AsNoTracking();

        return await result.ToListAsync();
    }

    public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate,CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate,cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(object id,CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id,cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        return await _dbSet.CountAsync(predicate);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate,CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(predicate,cancellationToken);
    }
}