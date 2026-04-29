namespace Domain.Entities;

public sealed class TaskCategoryEntity
{
    public Guid TaskItemId { get; set; }

    public Guid CategoryId { get; set; }
}