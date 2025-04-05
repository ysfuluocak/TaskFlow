using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.TaskRepository
{
    public class EfTaskWriteRepository : EfWriteRepository<TaskItem>,ITaskWriteRepository
    {
        public EfTaskWriteRepository(TaskDbContext context) : base(context)
        {
        }
    }
}
