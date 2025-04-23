using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.TaskEntityRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.TaskEntityRepositories
{
    public class EfTaskEntityWriteRepository : EfWriteRepository<TaskEntity, TaskDbContext>, ITaskEntityWriteRepository
    {
        public EfTaskEntityWriteRepository(TaskDbContext context) : base(context)
        { }
    }
}
