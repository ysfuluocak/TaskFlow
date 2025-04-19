using MediatR;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Features.Tasks.Queries;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;

namespace TaskFlow.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Result<TaskDto>>
    {
        private readonly ITaskWriteRepository _writeRepository;
        private readonly ITaskReadRepository _readRepository;

        public UpdateTaskCommandHandler(ITaskWriteRepository writeRepository, ITaskReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Result<TaskDto>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _readRepository.GetAsync(
                predicate : t=>t.Id == request.Id,
                cancellationToken : cancellationToken);

            if (entity == null)
                return Result<TaskDto>.Failure("Task not found");

            entity.Title = request.Title;
            entity.Description = request.Description;
            if (request.DueDate.HasValue)
                entity.DueDate = request.DueDate.Value;

            _writeRepository.Update(entity);
            await _writeRepository.CommitAsync(cancellationToken);

            return Result<TaskDto>.Success(new TaskDto
            {
                Id = entity.Id,
                Description = entity.Description,
                DuaDate = entity.DueDate,
                AssignedTo = request.AssignedTo,
                TaskCategoryId = request.TaskCategoryId,
                Title = entity.Title,
                FilePath = entity.FilePath
            });
        }
    }
}
