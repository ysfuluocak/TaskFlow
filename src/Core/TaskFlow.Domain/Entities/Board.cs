using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Board : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public ICollection<BoardStep> Steps { get; set; }
        public ICollection<TaskEntity> Tasks { get; set; }
    }
}
