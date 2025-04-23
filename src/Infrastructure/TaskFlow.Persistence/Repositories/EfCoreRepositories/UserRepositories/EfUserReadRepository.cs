using TaskFlow.Domain.Entities;
using TaskFlow.Persistence.Context;
using TaskFlow.Application.Interfaces.Repositories.UserRepositories;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.UserRepositories
{
    public class EfUserReadRepository : EfReadRepository<User, TaskDbContext>, IUserReadRepository
    {
        public EfUserReadRepository(TaskDbContext context) : base(context)
        {
        }
    }
}
