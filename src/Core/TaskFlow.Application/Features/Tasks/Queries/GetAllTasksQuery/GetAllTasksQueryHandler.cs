using MediatR;
using TaskFlow.Application.Common.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;

namespace TaskFlow.Application.Features.Tasks.Queries.GetAllTasksQuery;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, Result<List<TaskDto>>>
{
    private readonly ITaskReadRepository _taskRepository;

    public GetAllTasksQueryHandler(ITaskReadRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<List<TaskDto>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAllAsync();

        if (tasks == null)
            return Result<List<TaskDto>>.Failure("Tasks not found");

        var result = tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            DuaDate = t.DueDate,
            FilePath = t.FilePath
        }).ToList();
        return Result<List<TaskDto>>.Success(result);
    }
}