using MediatR;
using TaskFlow.Application.Wrappers.Results;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Features.Tasks.Queries.GetTasksQuery
{
    public record GetTasksQuery : IRequest<Result<Paginate<TaskDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Title { get; set; }           // Başlık filtresi
        public string? AssignedTo { get; set; }        // Kime atandığı
        public Guid? CategoryId { get; set; }        // Kategori
        public TaskItemStatus? Status { get; set; }      // Durum
    }
}
