using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.TaskEntities.Queries.GetByIdTaskQuery
{
    public record GetByIdTaskEntityQuery(Guid Id) : IRequest<Result<TaskEntityDto>>;
}
