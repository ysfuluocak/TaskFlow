using MediatR;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces.Repositories.BoardRepositories;

namespace TaskFlow.Application.Features.Boards.Queries.GetAllBoardsQuery
{
    public class GetAllBoardsQueryHandler : IRequestHandler<GetAllBoardsQuery, Result<Paginate<BoardDto>>>
    {
        private readonly IBoardReadRepository _readRepository;

        public GetAllBoardsQueryHandler(IBoardReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Result<Paginate<BoardDto>>> Handle(GetAllBoardsQuery request, CancellationToken cancellationToken)
        {
            var boards = await _readRepository.GetListAsync(
                predicate: null,
                orderBy: c => c.OrderByDescending(x => x.CreatedDate),
                include: null,
                index: request.PageIndex,
                size: request.PageSize,
                cancellationToken: cancellationToken);

            if (boards == null) return Result<Paginate<BoardDto>>.Failure("Boardlar bos");

            List<BoardDto> boardDtos = boards.Select(b => new BoardDto
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                CreatedById = b.CreatedById,
                CreatedDate = b.CreatedDate
            }).ToList();

            int totalCount = await _readRepository.CountAsync(cancellationToken: cancellationToken);

            Paginate<BoardDto> paginate = new Paginate<BoardDto>(boardDtos, totalCount, new PaginationParams { PageSize = request.PageSize, PageNumber = request.PageIndex });

            return Result<Paginate<BoardDto>>.Success(paginate);
        }
    }
}
