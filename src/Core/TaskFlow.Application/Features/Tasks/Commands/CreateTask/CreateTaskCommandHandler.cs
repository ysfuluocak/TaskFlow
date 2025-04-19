using MediatR;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;


namespace TaskFlow.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Result<Guid>>
{
    private readonly ITaskWriteRepository _repository;
    private readonly ILogService _logger;

    public CreateTaskCommandHandler(ITaskWriteRepository repository, ILogService logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<Result<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate,
            AssignedTo = request.AssignedTo,
            TaskCategoryId = request.TaskCategoryId,
            CreatedDate = DateTime.UtcNow,
            Status = TaskItemStatus.Todo
        };

        await _repository.AddAsync(task, cancellationToken);
        await _repository.CommitAsync(cancellationToken);

        _logger.LogInfo("Task Eklendi");

        return Result<Guid>.Success(task.Id);
    }
}