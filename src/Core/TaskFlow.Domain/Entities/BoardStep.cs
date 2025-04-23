using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class BoardStep : BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }

        public Guid BoardId { get; set; }
        public Board Board { get; set; }

        public ICollection<TaskEntity> Tasks { get; set; }
    }
}
