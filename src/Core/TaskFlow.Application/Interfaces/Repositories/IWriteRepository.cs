using TaskFlow.Domain.Common;

namespace TaskFlow.Application.Interfaces.Repositories
{
    public interface IWriteRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        TEntity Update(TEntity entit);
        void Delete(TEntity entity);
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
