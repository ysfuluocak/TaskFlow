using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Domain.Common;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories;

public class EfReadRepository<TEntity> : IReadRepository<TEntity>
    where TEntity : BaseEntity, new()
{
    private readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public EfReadRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    //withDeleted false olmasi deletedDate null olanlari getir.(deletedDate null olmasi silinmemis demek)
    public async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        if (!enableTracking)
            query = query.AsNoTracking();

        if (!withDeleted)
            query = query.Where(x => x.DeletedDate == null);

        if (include != null)
            query = include(query);

        return await query.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 1,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        if (!enableTracking)
            query = query.AsNoTracking();

        if (!withDeleted)
            query = query.Where(x => x.DeletedDate == null);

        if (include != null)
            query = include(query);

        if (predicate != null)
            query = query.Where(predicate);

        if (orderBy != null)
            query = orderBy(query);

        int totalCount = await query.CountAsync(cancellationToken);

        return await query.Skip(index - 1 * size).Take(size).ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        if (!withDeleted)
            query = query.Where(x => x.DeletedDate == null);

        if (predicate != null)
            query = query.Where(predicate);

        return await query.CountAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        if (!withDeleted)
            query = query.Where(x => x.DeletedDate == null);

        if (predicate != null)
            query = query.Where(predicate);

        return await query.AnyAsync(cancellationToken);
    }
}