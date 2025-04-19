using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities;

public class TaskItem : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? FilePath { get; set; }
    public DateTime? DueDate { get; set; }
    public string? AssignedTo { get; set; }
    public TaskItemStatus Status { get; set; } = TaskItemStatus.Todo;
    public Guid TaskCategoryId { get; set; }
    public TaskCategory TaskCategory { get; set; }

}