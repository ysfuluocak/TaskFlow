using MediatR;
using TaskFlow.Application.Common.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;
using TaskFlow.Domain.Entities;
using TaskStatus = TaskFlow.Domain.Enums.TaskStatus;


namespace TaskFlow.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler: IRequestHandler<CreateTaskCommand,Result<Guid>>
{
    private readonly ITaskWriteRepository _repository;

    public CreateTaskCommandHandler(ITaskWriteRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate,
            CreatedAt = DateTime.UtcNow,
            Status = TaskStatus.Todo
        };
        
        await _repository.AddAsync(task,cancellationToken);
        await _repository.CommitAsync(cancellationToken);
        return Result<Guid>.Success(task.Id);
    }
}