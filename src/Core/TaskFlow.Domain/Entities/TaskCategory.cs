using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class TaskCategory : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<TaskItem> TaskItems { get; set; }
    }
}
