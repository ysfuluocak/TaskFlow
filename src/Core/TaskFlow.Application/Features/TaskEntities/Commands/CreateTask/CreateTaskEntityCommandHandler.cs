using MediatR;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Application.Interfaces.Repositories.TaskEntityRepositories;
using TaskFlow.Domain.Enums;


namespace TaskFlow.Application.Features.TaskEntities.Commands.CreateTask;

public class CreateTaskEntityCommandHandler : IRequestHandler<CreateTaskEntityCommand, Result<Guid>>
{
    private readonly ITaskEntityWriteRepository _repository;
    private readonly ILogService _logger;

    public CreateTaskEntityCommandHandler(ITaskEntityWriteRepository repository, ILogService logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<Result<Guid>> Handle(CreateTaskEntityCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskEntity
        {
            Title = request.Title,
            Description = request.Description,
            Type = Enum.Parse<TaskType>(request.Type, true),
            Priority = Enum.Parse<TaskPriority>(request.Priority, true),
            DueDate = request.DueDate,
            BoardId = request.BoardId,
            StatusStepId = request.StatusStepId,
            AssignedToId = request.AssignedToId,
            AssignedById = request.AssignedById,
        };

        await _repository.AddAsync(task, cancellationToken);
        await _repository.CommitAsync(cancellationToken);

        _logger.LogInfo("Task Eklendi");

        return Result<Guid>.Success(task.Id);
    }
}