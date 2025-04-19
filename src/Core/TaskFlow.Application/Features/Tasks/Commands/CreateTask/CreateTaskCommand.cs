using MediatR;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.Tasks.Commands.CreateTask;

public record CreateTaskCommand(string Title, string Description, string? AssignedTo, DateTime DueDate, Guid TaskCategoryId) : IRequest<Result<Guid>>;