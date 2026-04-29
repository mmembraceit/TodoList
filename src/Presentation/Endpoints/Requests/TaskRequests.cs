using TaskItemStatus = Domain.Enums.TaskStatus;

namespace Presentation.Endpoints.Requests;

public sealed record TaskSubtaskRequest(Guid? Id, string Title, bool IsCompleted);

public sealed record CreateTaskRequest(
    string Title,
    string? Description,
    DateTimeOffset? DueDateUtc,
    DateTimeOffset? CompletedAtUtc,
    TaskItemStatus Status,
    IReadOnlyCollection<Guid>? CategoryIds,
    IReadOnlyCollection<Guid>? TagIds,
    IReadOnlyCollection<TaskSubtaskRequest>? Subtasks);

public sealed record UpdateTaskRequest(
    string Title,
    string? Description,
    DateTimeOffset? DueDateUtc,
    DateTimeOffset? CompletedAtUtc,
    TaskItemStatus Status,
    IReadOnlyCollection<Guid>? CategoryIds,
    IReadOnlyCollection<Guid>? TagIds,
    IReadOnlyCollection<TaskSubtaskRequest>? Subtasks);