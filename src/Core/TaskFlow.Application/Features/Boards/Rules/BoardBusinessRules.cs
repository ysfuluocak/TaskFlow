using TaskFlow.Application.Interfaces.Repositories.BoardRepositories;

namespace TaskFlow.Application.Features.Boards.Rules
{
    public class BoardBusinessRules
    {
        private readonly IBoardReadRepository _readRepository;

        public BoardBusinessRules(IBoardReadRepository readRepository)
        {
            _readRepository = readRepository;
        }
    }
}
