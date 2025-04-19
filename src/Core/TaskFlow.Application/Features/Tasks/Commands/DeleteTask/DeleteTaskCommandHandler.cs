using MediatR;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;

namespace TaskFlow.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Result<Guid>>
    {
        private readonly ITaskWriteRepository _writeRepository;
        private readonly ITaskReadRepository _readRepository;

        public DeleteTaskCommandHandler(ITaskWriteRepository writeRepository, ITaskReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Result<Guid>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _readRepository.GetAsync(
                predicate: t => t.Id == request.Id,
                cancellationToken: cancellationToken);

            if (entity == null)
            {
                return Result<Guid>.Failure("Task not found.");
            }

            _writeRepository.Delete(entity);
            await _writeRepository.CommitAsync(cancellationToken);

            return Result<Guid>.Success(request.Id);
        }
    }
}
