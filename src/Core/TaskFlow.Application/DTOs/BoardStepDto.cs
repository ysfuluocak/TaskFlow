namespace TaskFlow.Application.DTOs;

public class BoardStepDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public Guid BoardId { get; set; }
}