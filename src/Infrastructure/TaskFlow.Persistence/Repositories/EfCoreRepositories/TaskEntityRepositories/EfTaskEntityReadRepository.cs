using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.TaskEntityRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.TaskEntityRepositories
{
    public class EfTaskEntityReadRepository : EfReadRepository<TaskEntity, TaskDbContext>, ITaskEntityReadRepository
    {
        public EfTaskEntityReadRepository(TaskDbContext context) : base(context) { }

    }
}
