using Application.Features.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Endpoints.Requests;

namespace Presentation.Controllers;

[Authorize]
public sealed class TasksController(ITaskUseCase taskUseCase) : BaseApiController
{
    [HttpGet]
    public Task<IReadOnlyList<TaskDto>> GetAll(CancellationToken cancellationToken)
        => taskUseCase.GetAllAsync(cancellationToken);

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var task = await taskUseCase.GetByIdAsync(id, cancellationToken);

        return task is null ? NotFound() : Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> Create(CreateTaskRequest request, CancellationToken cancellationToken)
    {
        var task = await taskUseCase.CreateAsync(MapCreateCommand(request), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<TaskDto>> Update(Guid id, UpdateTaskRequest request, CancellationToken cancellationToken)
    {
        var task = await taskUseCase.UpdateAsync(id, MapUpdateCommand(request), cancellationToken);

        return Ok(task);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await taskUseCase.DeleteAsync(id, cancellationToken);

        return NoContent();
    }

    private static CreateTaskCommand MapCreateCommand(CreateTaskRequest request)
    {
        return new CreateTaskCommand(
            request.Title,
            request.Description,
            request.DueDateUtc,
            request.CompletedAtUtc,
            request.Status,
            request.CategoryIds ?? Array.Empty<Guid>(),
            request.TagIds ?? Array.Empty<Guid>(),
            MapSubtasks(request.Subtasks));
    }

    private static UpdateTaskCommand MapUpdateCommand(UpdateTaskRequest request)
    {
        return new UpdateTaskCommand(
            request.Title,
            request.Description,
            request.DueDateUtc,
            request.CompletedAtUtc,
            request.Status,
            request.CategoryIds ?? Array.Empty<Guid>(),
            request.TagIds ?? Array.Empty<Guid>(),
            MapSubtasks(request.Subtasks));
    }

    private static IReadOnlyCollection<TaskSubtaskInput> MapSubtasks(IReadOnlyCollection<TaskSubtaskRequest>? subtasks)
    {
        if (subtasks is null || subtasks.Count == 0)
        {
            return Array.Empty<TaskSubtaskInput>();
        }

        return subtasks.Select(subtask => new TaskSubtaskInput(subtask.Id, subtask.Title, subtask.IsCompleted)).ToArray();
    }
}