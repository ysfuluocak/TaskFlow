using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.BoardRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.BoardRepositories
{
    public class EfBoardWriteRepository : EfWriteRepository<Board, TaskDbContext>, IBoardWriteRepository
    {
        public EfBoardWriteRepository(TaskDbContext context) : base(context)
        { }
    }
}
