using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.BoardRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.BoardRepositories
{
    public class EfBoardReadRepository : EfReadRepository<Board, TaskDbContext>, IBoardReadRepository
    {
        public EfBoardReadRepository(TaskDbContext context) : base(context)
        { }
    }
}
