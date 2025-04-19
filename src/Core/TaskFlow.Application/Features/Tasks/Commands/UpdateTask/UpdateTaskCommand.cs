using MediatR;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Features.Tasks.Queries;

namespace TaskFlow.Application.Features.Tasks.Commands.UpdateTask
{
    public record UpdateTaskCommand(Guid Id, string Title, string Description, string? AssignedTo, DateTime? DueDate, Guid TaskCategoryId) : IRequest<Result<TaskDto>>;
}
