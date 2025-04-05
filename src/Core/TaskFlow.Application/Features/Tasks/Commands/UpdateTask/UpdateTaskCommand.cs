using MediatR;
using TaskFlow.Application.Common.Results;
using TaskFlow.Application.Features.Tasks.Queries;

namespace TaskFlow.Application.Features.Tasks.Commands.UpdateTask
{
    public record UpdateTaskCommand(Guid Id,string Title, string Description, DateTime? DueDate) : IRequest<Result<TaskDto>>;
}
