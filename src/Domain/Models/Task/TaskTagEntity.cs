namespace Domain.Entities;

public sealed class TaskTagEntity
{
    public Guid TaskItemId { get; set; }

    public Guid TagId { get; set; }
}