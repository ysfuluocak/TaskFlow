using MediatR;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.DTOs;

namespace TaskFlow.Application.Features.Categories.Queries.GetAllTaskCategoriesQuery
{
    public record GetAllTaskCategoriesQuery : IRequest<Result<Paginate<TaskCategoryDto>>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
