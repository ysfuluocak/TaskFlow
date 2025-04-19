using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Domain.Common;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories
{
    public class EfWriteRepository<TEntity> : IWriteRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public EfWriteRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            EntityEntry state = _dbSet.Entry(entity);
        }


        public void Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
             _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _dbSet.Update(entity);

            return entity;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
