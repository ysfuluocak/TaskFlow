namespace TaskFlow.Application.Features.Tasks.Queries;

public record TaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public DateTime? DuaDate { get; set; }
}
