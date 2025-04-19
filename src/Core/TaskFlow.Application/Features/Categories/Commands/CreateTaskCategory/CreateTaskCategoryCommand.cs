using MediatR;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.Categories.Commands.CreateTaskCategory
{
    public class CreateTaskCategoryCommand : IRequest<Result<Guid>>
    {
        public string Name { get; set; }
    }
}
