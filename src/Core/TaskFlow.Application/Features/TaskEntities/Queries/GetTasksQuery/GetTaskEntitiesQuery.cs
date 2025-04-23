using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.TaskEntities.Queries.GetTasksQuery
{
    public record GetTaskEntitiesQuery : IRequest<Result<Paginate<TaskEntityDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Title { get; set; }
    }
}
