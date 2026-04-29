namespace Domain.Entities;

public sealed class TaskCategory
{
    public Guid TaskItemId { get; set; }

    public Guid CategoryId { get; set; }
}