using MediatR;
using TaskFlow.Application.Interfaces.Repositories.BoardRepositories;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Features.Boards.Commands.CreateBoard
{
    public class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand, Result<Guid>>
    {
        private readonly IBoardWriteRepository _writeRepository;

        public CreateBoardCommandHandler(IBoardWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Result<Guid>> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = new Board
            {
                Name = request.Name,
                Description = request.Description,
                CreatedById = request.CreatedById
            };
            await _writeRepository.AddAsync(board, cancellationToken);
            await _writeRepository.CommitAsync(cancellationToken);

            return Result<Guid>.Success(board.Id);
        }
    }
}
