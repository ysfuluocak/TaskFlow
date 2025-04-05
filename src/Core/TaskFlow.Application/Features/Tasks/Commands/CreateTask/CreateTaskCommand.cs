using MediatR;
using TaskFlow.Application.Common.Results;

namespace TaskFlow.Application.Features.Tasks.Commands.CreateTask;

public record CreateTaskCommand(string Title, string Description, DateTime DueDate) : IRequest<Result<Guid>>;