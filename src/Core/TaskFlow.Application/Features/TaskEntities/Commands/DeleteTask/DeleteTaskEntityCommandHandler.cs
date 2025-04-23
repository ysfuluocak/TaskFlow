using MediatR;
using TaskFlow.Application.Interfaces.Repositories.TaskEntityRepositories;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.TaskEntities.Commands.DeleteTask
{
    public class DeleteTaskEntityCommandHandler : IRequestHandler<DeleteTaskEntityCommand, Result<Guid>>
    {
        private readonly ITaskEntityWriteRepository _writeRepository;
        private readonly ITaskEntityReadRepository _readRepository;

        public DeleteTaskEntityCommandHandler(ITaskEntityWriteRepository writeRepository, ITaskEntityReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Result<Guid>> Handle(DeleteTaskEntityCommand request, CancellationToken cancellationToken)
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
