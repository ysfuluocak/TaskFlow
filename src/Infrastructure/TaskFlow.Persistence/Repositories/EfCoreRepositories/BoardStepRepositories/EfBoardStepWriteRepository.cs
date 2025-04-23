using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.BoardStepRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.BoardStepRepositories
{
    public class EfBoardStepWriteRepository : EfWriteRepository<BoardStep, TaskDbContext>, IBoardStepWriteRepository
    {
        public EfBoardStepWriteRepository(TaskDbContext context) : base(context)
        {
        }
    }
}
