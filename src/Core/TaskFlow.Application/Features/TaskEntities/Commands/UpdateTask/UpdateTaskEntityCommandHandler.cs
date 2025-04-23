using MediatR;
using TaskFlow.Domain.Enums;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskEntityRepositories;

namespace TaskFlow.Application.Features.TaskEntities.Commands.UpdateTask
{
    public class UpdateTaskEntityCommandHandler : IRequestHandler<UpdateTaskEntityCommand, Result<TaskEntityDto>>
    {
        private readonly ITaskEntityWriteRepository _writeRepository;
        private readonly ITaskEntityReadRepository _readRepository;

        public UpdateTaskEntityCommandHandler(ITaskEntityWriteRepository writeRepository, ITaskEntityReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Result<TaskEntityDto>> Handle(UpdateTaskEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _readRepository.GetAsync(
                predicate: t => t.Id == request.Id,
                cancellationToken: cancellationToken);

            if (entity == null)
                return Result<TaskEntityDto>.Failure("Task not found");

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Priority = Enum.Parse<TaskPriority>(request.Priority, true);
            entity.Type = Enum.Parse<TaskType>(request.Type, true);
            entity.DueDate = request.DueDate;
            entity.UpdatedDate = DateTime.Now;
            entity.AssignedById = request.AssignedById;
            entity.AssignedToId = request.AssignedToId;
            entity.StatusStepId = request.StatusStepId;
            entity.BoardId = request.BoardId;

            _writeRepository.Update(entity);
            await _writeRepository.CommitAsync(cancellationToken);

            return Result<TaskEntityDto>.Success(
                new TaskEntityDto
                {
                    Id = entity.Id,
                    Description = entity.Description,
                    DuaDate = entity.DueDate,
                    AssignedById = entity.AssignedById,
                    AssignedToId = entity.AssignedToId,
                    Title = entity.Title,
                    StatusStepId = entity.StatusStepId,
                    BoardId = entity.BoardId,
                    Priority = entity.Priority.ToString(),
                    TaskType = entity.Type.ToString()
                });
        }
    }
}
