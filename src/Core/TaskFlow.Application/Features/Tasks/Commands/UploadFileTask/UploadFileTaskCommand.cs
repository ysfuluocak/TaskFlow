using MediatR;
using Microsoft.AspNetCore.Http;
using TaskFlow.Application.Common.Results;
using TaskFlow.Application.Features.Tasks.Queries;

namespace TaskFlow.Application.Features.Tasks.Commands.UploadFileTask
{
    public record UploadFileTaskCommand(Guid Id, IFormFile File) : IRequest<Result<TaskDto>>;
}
