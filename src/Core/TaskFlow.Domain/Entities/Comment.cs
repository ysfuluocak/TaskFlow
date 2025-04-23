using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public Guid TaskId { get; set; }
        public TaskEntity Task { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
