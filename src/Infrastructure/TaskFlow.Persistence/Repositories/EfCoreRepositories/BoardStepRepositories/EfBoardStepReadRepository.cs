using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.BoardStepRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.BoardStepRepositories
{
    public class EfBoardStepReadRepository : EfReadRepository<BoardStep, TaskDbContext>, IBoardStepReadRepository
    {
        public EfBoardStepReadRepository(TaskDbContext context) : base(context)
        {
        }
    }
}
