using Domain.Common;
using Domain.Enums;
using TaskItemStatus = Domain.Enums.TaskStatus;

namespace Domain.Entities;

public sealed class TaskItemEntity : BaseEntity
{
    public Guid UserId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTimeOffset? DueDateUtc { get; set; }

    public DateTimeOffset? CompletedAtUtc { get; set; }

    public TaskItemStatus Status { get; set; } = TaskItemStatus.NonStarted;

    public List<global::Domain.Entities.SubtaskEntity> Subtasks { get; set; } = [];

    public List<global::Domain.Entities.TaskCategoryEntity> TaskCategories { get; set; } = [];

    public List<global::Domain.Entities.TaskTagEntity> TaskTags { get; set; } = [];
}