using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskEntityRepositories;

namespace TaskFlow.Application.Features.TaskEntities.Queries.GetAllTasksQuery;

public class GetAllTaskEntitiesQueryHandler : IRequestHandler<GetAllTaskEntitiesQuery, Result<Paginate<TaskEntityDto>>>
{
    private readonly ITaskEntityReadRepository _taskRepository;

    public GetAllTaskEntitiesQueryHandler(ITaskEntityReadRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Result<Paginate<TaskEntityDto>>> Handle(GetAllTaskEntitiesQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetListAsync(
            predicate: null,
            orderBy: t => t.OrderByDescending(x => x.CreatedDate),
            include: null,
            index: request.PageIndex,
            size: request.PageSize,
            cancellationToken: cancellationToken);

        if (tasks == null)
            return Result<Paginate<TaskEntityDto>>.Failure("Tasks not found");

        List<TaskEntityDto> list = tasks.Select(t => new TaskEntityDto
        {
            Id = t.Id,
            Description = t.Description,
            DuaDate = t.DueDate,
            AssignedById = t.AssignedById,
            AssignedToId = t.AssignedToId,
            Title = t.Title,
            StatusStepId = t.StatusStepId,
            BoardId = t.BoardId,
            Priority = t.Priority.ToString(),
            TaskType = t.Type.ToString()
        }).ToList();

        int totalCount = await _taskRepository.CountAsync(cancellationToken: cancellationToken);

        Paginate<TaskEntityDto> paginate = new Paginate<TaskEntityDto>(list, totalCount, new PaginationParams() { PageNumber = request.PageIndex, PageSize = request.PageSize });

        return Result<Paginate<TaskEntityDto>>.Success(paginate);
    }
}