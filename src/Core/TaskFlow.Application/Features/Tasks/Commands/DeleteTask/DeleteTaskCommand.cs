using MediatR;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.Tasks.Commands.DeleteTask
{
    public record DeleteTaskCommand(Guid Id) : IRequest<Result<Guid>>;
}
