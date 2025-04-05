using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces.Repositories.TaskRepositories
{
    public interface ITaskWriteRepository : IWriteRepository<TaskItem>
    {
    }
}
