using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.AttachmentRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.AttachmentRepositories
{
    public class EfAttachmentWriteRepository : EfWriteRepository<Attachment, TaskDbContext>, IAttachmentWriteRepository
    {
        public EfAttachmentWriteRepository(TaskDbContext context) : base(context)
        {
        }
    }
}
