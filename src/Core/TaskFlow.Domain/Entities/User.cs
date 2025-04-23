using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

        public ICollection<Board> BoardsCreated { get; set; }
        public ICollection<TaskEntity> TasksAssigned { get; set; }
        public ICollection<TaskEntity> TasksCreated { get; set; }
        public ICollection<Comment> TaskComments { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}
