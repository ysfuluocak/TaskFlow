using TaskFlow.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaskFlow.Application.Interfaces.Repositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories
{
    public class EfWriteRepository<TEntity, TContext> : IWriteRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public EfWriteRepository(TContext context)
        {
            Context = context;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
            EntityEntry state = Context.Set<TEntity>().Entry(entity);
        }


        public void Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
            Context.Set<TEntity>().Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Set<TEntity>().Update(entity);

            return entity;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
