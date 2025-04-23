using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities;

public class TaskEntity : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }

    public TaskType Type { get; set; }
    public TaskPriority Priority { get; set; }
    public DateTime? DueDate { get; set; }

    public Guid BoardId { get; set; }
    public Board Board { get; set; }

    public Guid StatusStepId { get; set; }
    public BoardStep StatusStep { get; set; }

    public Guid AssignedToId { get; set; }
    public User AssignedTo { get; set; }

    public Guid AssignedById { get; set; }
    public User AssignedBy { get; set; }

    public ICollection<Comment> Comments { get; set; }
    public ICollection<Attachment> Attachments { get; set; }

}