using MediatR;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces.Repositories.TaskCategoryRepositories;

namespace TaskFlow.Application.Features.Categories.Queries.GetAllTaskCategoriesQuery
{
    public class GetAllTaskCategoriesQueryHandler : IRequestHandler<GetAllTaskCategoriesQuery, Result<Paginate<TaskCategoryDto>>>
    {
        private readonly ITaskCategoryReadRepository _readRepository;

        public GetAllTaskCategoriesQueryHandler(ITaskCategoryReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Result<Paginate<TaskCategoryDto>>> Handle(GetAllTaskCategoriesQuery request, CancellationToken cancellationToken)
        {
            var taskCategories = await _readRepository.GetListAsync(
                predicate: null,
                orderBy: c => c.OrderByDescending(x => x.CreatedDate),
                include: null,
                index: request.PageIndex,
                size: request.PageSize,
                cancellationToken: cancellationToken);

            if (taskCategories == null) return Result<Paginate<TaskCategoryDto>>.Failure("Kategoriler bos");

            List<TaskCategoryDto> taskCategoriesDto = taskCategories.Select(c => new TaskCategoryDto
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            int totalCount = await _readRepository.CountAsync(cancellationToken: cancellationToken);

            Paginate<TaskCategoryDto> paginate = new Paginate<TaskCategoryDto>(taskCategoriesDto, totalCount, new PaginationParams { PageSize = request.PageSize, PageNumber = request.PageIndex });

            return Result<Paginate<TaskCategoryDto>>.Success(paginate);
        }
    }
}
