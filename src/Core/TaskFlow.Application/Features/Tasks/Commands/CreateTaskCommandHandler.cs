using MediatR;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Domain.Entities;
using TaskStatus = TaskFlow.Domain.Enums.TaskStatus;


namespace TaskFlow.Application.Features.Tasks.Commands;

public class CreateTaskCommandHandler: IRequestHandler<CreateTaskCommand,Guid>
{
    private readonly ITaskRepository _repository;

    public CreateTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }
    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
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
        
        await _repository.AddAsync(task);
        return task.Id;
    }
}