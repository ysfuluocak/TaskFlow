using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories
{
    public class EfWriteRepository<TEntity> : IWriteRepository<TEntity>
        where TEntity : class, new()
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public EfWriteRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
           return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            EntityEntry state = _dbSet.Entry(entity);
        }


        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(()=>_dbSet.Remove(entity));
        }

        public async Task DeleteByIdAsync(object id, CancellationToken cancellationToken)
        {
            var entity = await _dbSet.FindAsync(id,cancellationToken);
            await DeleteAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await Task.Run(() => _dbSet.Update(entity));
        }
    }
}
