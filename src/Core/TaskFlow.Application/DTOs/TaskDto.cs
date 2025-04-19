using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Features.Tasks.Queries;

public record TaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? FilePath { get; set; }
    public DateTime? DuaDate { get; set; }
    public string? AssignedTo { get; set; }
    public string? TaskCategoryName { get; set; }
    public TaskItemStatus TaskItemStatus { get; set; }
    public Guid TaskCategoryId { get; set; }

}
