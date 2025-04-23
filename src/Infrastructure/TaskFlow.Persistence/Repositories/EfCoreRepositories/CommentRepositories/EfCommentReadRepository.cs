using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.CommentRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.CommentRepositories
{
    public class EfCommentReadRepository : EfReadRepository<Comment, TaskDbContext>, ICommentReadRepository
    {
        public EfCommentReadRepository(TaskDbContext context) : base(context)
        {
        }
    }
}
