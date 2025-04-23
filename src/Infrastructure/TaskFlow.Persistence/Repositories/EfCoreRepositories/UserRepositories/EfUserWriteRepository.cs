using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.UserRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.UserRepositories
{
    public class EfUserWriteRepository : EfWriteRepository<User, TaskDbContext>, IUserWriteRepository
    {
        public EfUserWriteRepository(TaskDbContext context) : base(context)
        {
        }
    }
}
