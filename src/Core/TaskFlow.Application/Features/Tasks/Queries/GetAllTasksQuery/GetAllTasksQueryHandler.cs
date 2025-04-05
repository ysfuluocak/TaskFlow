using MediatR;
using TaskFlow.Application.Interfaces.Repositories;
using System.Linq;

namespace TaskFlow.Application.Features.Tasks.Queries.GetAllTasksQuery;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery,List<TaskDto>>
{
    private readonly ITaskRepository _taskRepository;

    public GetAllTasksQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<List<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAllAsync();
        return tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description
        });
    }
}