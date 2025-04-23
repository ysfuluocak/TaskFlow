using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Attachment : BaseEntity
    {
        public string FileUrl { get; set; }

        public Guid TaskId { get; set; }
        public TaskEntity Task { get; set; }

        public Guid UploadedById { get; set; }
        public User UploadedBy { get; set; }
    }
}
