using MediatR;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.Tasks.Queries.GetByIdTaskQuery
{
    public record GetByIdTaskQuery(Guid Id) : IRequest<Result<TaskDto>>;
}
