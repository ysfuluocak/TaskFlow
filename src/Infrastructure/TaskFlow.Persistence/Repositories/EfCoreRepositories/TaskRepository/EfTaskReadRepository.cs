using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;
using TaskFlow.Persistence.Context;

namespace TaskFlow.Persistence.Repositories.EfCoreRepositories.TaskRepository
{
    public class EfTaskReadRepository : EfReadRepository<TaskItem>, ITaskReadRepository
    {
        public EfTaskReadRepository(TaskDbContext context) : base(context) { }

        public async Task<IEnumerable<TaskItem>> GetTaskItemsFilteredAsync(string? title, string? assignedTo, Guid? taskCategoryId, TaskItemStatus? status)
        {
            IQueryable<TaskItem> query = _dbSet;


            if (!string.IsNullOrWhiteSpace(title))
                query = query.Where(t => t.Title.Contains(title));

            if (!string.IsNullOrEmpty(assignedTo))
                query = query.Where(t => t.AssignedTo == assignedTo);

            if (taskCategoryId.HasValue)
                query = query.Where(t => t.TaskCategoryId == taskCategoryId);

            if (status.HasValue)
                query = query.Where(t => t.Status == status);

            query = query.Include(t => t.TaskCategory);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetTaskItemsPagedAsync(string? search, int page, int pageSize)
        {
            IQueryable<TaskItem> query = _dbSet;
            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(t =>
                t.Title.ToLower().Contains(search.ToLower()) ||
                t.Description.Contains(search.ToLower())
                );

            var tasks = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(t => t.TaskCategory)
                .ToListAsync();

            return tasks;
        }
    }
}
