namespace TaskFlow.Application.DTOs;

public class TaskAttachmentDto
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public string FileUrl { get; set; }
    public Guid UploadedById { get; set; }
}
