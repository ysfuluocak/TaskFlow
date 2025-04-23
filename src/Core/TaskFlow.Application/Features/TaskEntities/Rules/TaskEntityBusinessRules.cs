using TaskFlow.Application.Interfaces.Repositories.TaskEntityRepositories;

namespace TaskFlow.Application.Features.TaskEntities.Rules
{
    public class TaskEntityBusinessRules
    {
        private readonly ITaskEntityReadRepository _readRepository;

        public TaskEntityBusinessRules(ITaskEntityReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

    }
}
