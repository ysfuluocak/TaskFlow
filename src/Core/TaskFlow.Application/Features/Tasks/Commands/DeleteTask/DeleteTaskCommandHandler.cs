using MediatR;
using TaskFlow.Application.Common.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskRepositories;

namespace TaskFlow.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Result<Guid>>
    {
        private readonly ITaskWriteRepository _writeRepository;

        public DeleteTaskCommandHandler(ITaskWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Result<Guid>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.DeleteByIdAsync(request.Id, cancellationToken);
            await _writeRepository.CommitAsync(cancellationToken);

            return Result<Guid>.Success(request.Id);
        }
    }
}
