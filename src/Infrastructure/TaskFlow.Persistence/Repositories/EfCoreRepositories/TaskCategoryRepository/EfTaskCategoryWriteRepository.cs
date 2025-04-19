using TaskFlow.Application.Interfaces.Repositories.TaskCategoryRepositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.TaskCategoryRepository
{
    public class EfTaskCategoryWriteRepository : EfWriteRepository<TaskCategory>, ITaskCategoryWriteRepository
    {

        public EfTaskCategoryWriteRepository(TaskDbContext context) : base(context)
        {

        }
    }
}
