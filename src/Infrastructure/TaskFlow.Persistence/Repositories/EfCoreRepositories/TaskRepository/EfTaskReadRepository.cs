using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.TaskRepository
{
    public class EfTaskReadRepository : EfReadRepository<TaskItem>,ITaskReadRepository
    {
        public EfTaskReadRepository(TaskDbContext context) : base(context)
        {

        }
    }
}
