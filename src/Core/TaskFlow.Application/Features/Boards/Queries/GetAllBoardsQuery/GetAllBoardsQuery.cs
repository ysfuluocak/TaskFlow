using MediatR;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.DTOs;

namespace TaskFlow.Application.Features.Boards.Queries.GetAllBoardsQuery
{
    public record GetAllBoardsQuery : IRequest<Result<Paginate<BoardDto>>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
