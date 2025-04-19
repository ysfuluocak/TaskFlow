using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;

namespace TaskFlow.Application.Features.Tasks.Queries.GetAllTasksQuery;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, Result<Paginate<TaskDto>>>
{
    private readonly ITaskReadRepository _taskRepository;

    public GetAllTasksQueryHandler(ITaskReadRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<Paginate<TaskDto>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetListAsync(
            predicate: null,
            orderBy: c => c.OrderByDescending(x => x.CreatedDate),
            include: c => c.Include(x => x.TaskCategory),
            index: request.PageIndex,
            size: request.PageSize,
            cancellationToken: cancellationToken);

        if (tasks == null)
            return Result<Paginate<TaskDto>>.Failure("Tasks not found");

        List<TaskDto> list = tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            AssignedTo = t.AssignedTo,
            TaskCategoryId = t.TaskCategoryId,
            TaskItemStatus = t.Status,
            TaskCategoryName = t.TaskCategory.Name,
            DuaDate = t.DueDate,
            FilePath = t.FilePath
        }).ToList();

        int totalCount = await _taskRepository.CountAsync(cancellationToken: cancellationToken);

        Paginate<TaskDto> paginate = new Paginate<TaskDto>(list, totalCount, new PaginationParams() { PageNumber = request.PageIndex, PageSize = request.PageSize });

        return Result<Paginate<TaskDto>>.Success(paginate);
    }
}