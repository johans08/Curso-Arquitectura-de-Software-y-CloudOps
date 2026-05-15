namespace TaskFlow.Api.Modules.Tasks;

public sealed class TaskItem
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
    public required string Owner { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}

public sealed record CreateTaskRequest(string Title, string Description);
