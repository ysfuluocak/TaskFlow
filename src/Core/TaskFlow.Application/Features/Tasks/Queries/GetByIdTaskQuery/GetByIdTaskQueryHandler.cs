using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;

namespace TaskFlow.Application.Features.Tasks.Queries.GetByIdTaskQuery
{
    public class GetByIdTaskQueryHandler : IRequestHandler<GetByIdTaskQuery, Result<TaskDto>>
    {
        private readonly ITaskReadRepository _repository;

        public GetByIdTaskQueryHandler(ITaskReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<TaskDto>> Handle(GetByIdTaskQuery request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetAsync(
                predicate:t=>t.Id == request.Id,
                include : t=>t.Include(x=>x.TaskCategory),
                cancellationToken : cancellationToken);

            if (task == null)
                return Result<TaskDto>.Failure("Task not found");

            var result = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                AssignedTo = task.AssignedTo,
                TaskCategoryId = task.TaskCategoryId,
                TaskCategoryName = task.TaskCategory.Name,
                TaskItemStatus = task.Status,
                DuaDate = task.DueDate,
                FilePath = task.FilePath
            };
            return Result<TaskDto>.Success(result);
        }
    }
}
