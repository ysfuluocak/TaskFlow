using System.Linq.Expressions;

namespace TaskFlow.Application.Interfaces.Repositories;

public interface IReadRepository<TEntity>
        where TEntity : class, new()
{
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity?> Get(Expression<Func<TEntity,bool>> predicate,CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(object id,CancellationToken cancellationToken);
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate,CancellationToken cancellationToken);
}