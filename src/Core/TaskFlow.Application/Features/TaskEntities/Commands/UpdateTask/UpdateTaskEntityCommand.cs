using MediatR;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Wrappers.Results;

namespace TaskFlow.Application.Features.TaskEntities.Commands.UpdateTask
{
    public record UpdateTaskEntityCommand : IRequest<Result<TaskEntityDto>>
    {
        public Guid Id { get; set; } // Update'de ID şart

        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }

        public Guid BoardId { get; set; }
        public Guid StatusStepId { get; set; }
        public Guid AssignedToId { get; set; }
        public Guid AssignedById { get; set; }
    }
}
