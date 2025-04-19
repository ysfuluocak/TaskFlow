using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;

namespace TaskFlow.Application.Features.Tasks.Queries.GetTasksQuery
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, Result<Paginate<TaskDto>>>
    {
        private readonly ITaskReadRepository _readRepository;

        public GetTasksQueryHandler(ITaskReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Result<Paginate<TaskDto>>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _readRepository.GetTaskItemsFilteredAsync(request.Title, request.AssignedTo, request.CategoryId, request.Status);

            await _readRepository.GetListAsync(
                predicate: t => t.Title == request.Title && t.AssignedTo == request.AssignedTo && t.TaskCategoryId == request.CategoryId && t.Status == request.Status,
                include: t => t.Include(x => x.TaskCategory),
                orderBy: t => t.OrderByDescending(t => t.CreatedDate),
                index: request.PageNumber,
                size: request.PageSize,
                cancellationToken: cancellationToken);

            if (tasks is null)
            {
                return Result<Paginate<TaskDto>>.Failure("Filterelemede hata");
            }

            List<TaskDto> taskListDto = tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                AssignedTo = t.AssignedTo,
                Description = t.Description,
                FilePath = t.FilePath,
                DuaDate = t.DueDate,
                TaskCategoryId = t.TaskCategoryId,
                TaskCategoryName = t.TaskCategory.Name,
                TaskItemStatus = t.Status
            }).ToList();


            int totalCount = await _readRepository.CountAsync(
                 predicate: t => t.Title == request.Title && t.AssignedTo == request.AssignedTo && t.TaskCategoryId == request.CategoryId && t.Status == request.Status,
                 cancellationToken: cancellationToken);

            Paginate<TaskDto> paginate = new Paginate<TaskDto>(taskListDto, totalCount, new PaginationParams() { PageSize = request.PageSize, PageNumber = request.PageNumber });

            return Result<Paginate<TaskDto>>.Success(paginate);
        }
    }
}
