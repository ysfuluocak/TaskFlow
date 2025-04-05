using MediatR;
using TaskFlow.Application.Common.Results;

namespace TaskFlow.Application.Features.Tasks.Queries.GetAllTasksQuery;

public class GetAllTasksQuery : IRequest<Result<List<TaskDto>>>
{
    
}