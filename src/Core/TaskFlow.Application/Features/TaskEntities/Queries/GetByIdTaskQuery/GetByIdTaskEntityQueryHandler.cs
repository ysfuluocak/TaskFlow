using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskEntityRepositories;

namespace TaskFlow.Application.Features.TaskEntities.Queries.GetByIdTaskQuery
{
    public class GetByIdTaskEntityQueryHandler : IRequestHandler<GetByIdTaskEntityQuery, Result<TaskEntityDto>>
    {
        private readonly ITaskEntityReadRepository _repository;

        public GetByIdTaskEntityQueryHandler(ITaskEntityReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<TaskEntityDto>> Handle(GetByIdTaskEntityQuery request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetAsync(
                predicate: t => t.Id == request.Id,
                include: null,
                cancellationToken: cancellationToken);

            if (task == null)
                return Result<TaskEntityDto>.Failure("Task not found");

            var result = new TaskEntityDto
            {
                Id = task.Id,
                Description = task.Description,
                DuaDate = task.DueDate,
                AssignedById = task.AssignedById,
                AssignedToId = task.AssignedToId,
                Title = task.Title,
                StatusStepId = task.StatusStepId,
                BoardId = task.BoardId,
                Priority = task.Priority.ToString(),
                TaskType = task.Type.ToString()
            };
            return Result<TaskEntityDto>.Success(result);
        }
    }
}
