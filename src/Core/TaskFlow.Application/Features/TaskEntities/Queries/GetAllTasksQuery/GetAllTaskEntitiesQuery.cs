using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.TaskEntities.Queries.GetAllTasksQuery;

public record GetAllTaskEntitiesQuery : IRequest<Result<Paginate<TaskEntityDto>>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;

}