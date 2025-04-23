using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskEntityRepositories;

namespace TaskFlow.Application.Features.TaskEntities.Queries.GetTasksQuery
{
    public class GetTaskEntitiesQueryHandler : IRequestHandler<GetTaskEntitiesQuery, Result<Paginate<TaskEntityDto>>>
    {
        private readonly ITaskEntityReadRepository _readRepository;

        public GetTaskEntitiesQueryHandler(ITaskEntityReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Result<Paginate<TaskEntityDto>>> Handle(GetTaskEntitiesQuery request, CancellationToken cancellationToken)
        {
            var filteredTasks = await _readRepository.GetListAsync(
                predicate: t => t.Title == request.Title,
                include: null,
                orderBy: t => t.OrderByDescending(t => t.CreatedDate),
                index: request.PageNumber,
                size: request.PageSize,
                cancellationToken: cancellationToken);

            if (filteredTasks is null)
            {
                return Result<Paginate<TaskEntityDto>>.Failure("Filterelemede hata");
            }

            List<TaskEntityDto> taskListDto = filteredTasks.Select(t => new TaskEntityDto
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


            int totalCount = await _readRepository.CountAsync(
                 predicate: t => t.Title == request.Title,
                 cancellationToken: cancellationToken);

            Paginate<TaskEntityDto> paginate = new Paginate<TaskEntityDto>(taskListDto, totalCount, new PaginationParams() { PageSize = request.PageSize, PageNumber = request.PageNumber });

            return Result<Paginate<TaskEntityDto>>.Success(paginate);
        }
    }
}
