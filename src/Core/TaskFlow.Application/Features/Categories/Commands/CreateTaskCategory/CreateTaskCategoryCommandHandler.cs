using MediatR;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.Interfaces.Repositories.TaskCategoryRepositories;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Features.Categories.Commands.CreateTaskCategory
{
    public class CreateTaskCategoryCommandHandler : IRequestHandler<CreateTaskCategoryCommand, Result<Guid>>
    {
        private readonly ITaskCategoryWriteRepository _writeRepository;

        public CreateTaskCategoryCommandHandler(ITaskCategoryWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Result<Guid>> Handle(CreateTaskCategoryCommand request, CancellationToken cancellationToken)
        {
            var taskCategory = new TaskCategory
            {
                Name = request.Name,
            };
            await _writeRepository.AddAsync(taskCategory, cancellationToken);
            await _writeRepository.CommitAsync(cancellationToken);

            return Result<Guid>.Success(taskCategory.Id);
        }
    }
}
