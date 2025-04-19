using TaskFlow.Application.Interfaces.Repositories.TaskCategoryRepositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.TaskCategoryRepository
{
    public class EfTaskCategoryReadRepository : EfReadRepository<TaskCategory>, ITaskCategoryReadRepository
    {
        public EfTaskCategoryReadRepository(TaskDbContext context) : base(context)
        {
        }
    }
}
