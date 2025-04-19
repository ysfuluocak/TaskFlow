using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Interfaces.Repositories.TaskRepositories
{
    public interface ITaskReadRepository : IReadRepository<TaskItem>
    {
        Task<IEnumerable<TaskItem>> GetTaskItemsFilteredAsync(string? title, string? assignedTo, Guid? taskCategoryId, TaskItemStatus? status);
        Task<IEnumerable<TaskItem>> GetTaskItemsPagedAsync(string? search, int page, int pageSize);
    }
}
