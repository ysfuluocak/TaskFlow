namespace TaskFlow.Application.Interfaces.Repositories
{
    public interface IWriteRepository<TEntity>
        where TEntity : class,new()
    {
        Task AddAsync(TEntity entity,CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity,CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(object id,CancellationToken cancellationToken);
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
