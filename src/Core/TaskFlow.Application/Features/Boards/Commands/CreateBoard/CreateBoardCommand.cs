using MediatR;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.Boards.Commands.CreateBoard
{
    public record CreateBoardCommand : IRequest<Result<Guid>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatedById { get; set; }
    }
}
