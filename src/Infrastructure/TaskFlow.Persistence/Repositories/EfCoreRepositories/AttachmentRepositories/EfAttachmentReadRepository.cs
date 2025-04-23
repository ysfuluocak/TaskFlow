using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.AttachmentRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.AttachmentRepositories
{
    public class EfAttachmentReadRepository : EfReadRepository<Attachment, TaskDbContext>, IAttachmentReadRepository
    {
        public EfAttachmentReadRepository(TaskDbContext context) : base(context)
        {
        }
    }
}
