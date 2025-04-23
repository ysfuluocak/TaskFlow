using MediatR;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.TaskEntities.Commands.DeleteTask
{
    public record DeleteTaskEntityCommand(Guid Id) : IRequest<Result<Guid>>;
}
