using MediatR;

namespace TaskFlow.Application.Features.Tasks.Commands;

public class CreateTaskCommand: IRequest<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
}