using MediatR;
using System.Threading.Tasks;
using TaskFlow.Application.Common.Results;
using TaskFlow.Application.Features.Tasks.Queries;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;

namespace TaskFlow.Application.Features.Tasks.Commands.UploadFileTask
{
    public class UploadFileTaskCommandHandler : IRequestHandler<UploadFileTaskCommand, Result<TaskDto>>
    {
        private readonly IFileService _fileService;
        private readonly ITaskWriteRepository _taskWriteRepository;
        private readonly ITaskReadRepository _taskReadRepository;
        public UploadFileTaskCommandHandler(IFileService fileService, ITaskWriteRepository taskWriteRepository, ITaskReadRepository taskReadRepository)
        {
            _fileService = fileService;
            _taskWriteRepository = taskWriteRepository;
            _taskReadRepository = taskReadRepository;
        }

        public async Task<Result<TaskDto>> Handle(UploadFileTaskCommand request, CancellationToken cancellationToken)
        {

            var entity = await _taskReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
            {
                return Result<TaskDto>.Failure(new[] { "Task not found." });
            }

            string filePath = await _fileService.SaveFileAsync(request.Id, request.File);
            entity.FilePath = filePath;

            await _taskWriteRepository.UpdateAsync(entity, cancellationToken);
            await _taskWriteRepository.CommitAsync(cancellationToken);

            return Result<TaskDto>.Success(new TaskDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                FilePath = entity.FilePath,
                DuaDate = entity.DueDate
            });

        }
    }
}
