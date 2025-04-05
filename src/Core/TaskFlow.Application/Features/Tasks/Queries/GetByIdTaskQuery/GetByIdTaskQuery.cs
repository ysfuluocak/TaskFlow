using MediatR;
using TaskFlow.Application.Common.Results;

namespace TaskFlow.Application.Features.Tasks.Queries.GetByIdTaskQuery
{
    public record GetByIdTaskQuery(Guid Id) : IRequest<Result<TaskDto>>;
}
