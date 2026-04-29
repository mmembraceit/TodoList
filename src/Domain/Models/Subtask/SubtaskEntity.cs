using Domain.Common;

namespace Domain.Entities;

public sealed class Subtask : BaseEntity
{
    public Guid TaskItemId { get; set; }

    public string Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}