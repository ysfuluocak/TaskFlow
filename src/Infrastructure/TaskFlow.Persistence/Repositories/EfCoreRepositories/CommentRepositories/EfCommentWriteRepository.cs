using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.CommentRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.CommentRepositories
{
    public class EfCommentWriteRepository : EfWriteRepository<Comment, TaskDbContext>, ICommentWriteRepository
    {
        public EfCommentWriteRepository(TaskDbContext context) : base(context)
        {
        }
    }
}
