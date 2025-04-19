using MediatR;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.Tasks.Queries.GetAllTasksQuery;

public record GetAllTasksQuery : IRequest<Result<Paginate<TaskDto>>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;

}