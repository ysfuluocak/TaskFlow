namespace TaskFlow.Application.DTOs;
public record TaskEntityDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string TaskType { get; set; }
    public string Priority { get; set; }
    public DateTime? DuaDate { get; set; }


    public Guid BoardId { get; set; }
    public Guid StatusStepId { get; set; }
    public Guid AssignedToId { get; set; }
    public Guid AssignedById { get; set; }
}
