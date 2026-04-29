using Application.Features.Tags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Endpoints.Requests;

namespace Presentation.Controllers;

[Authorize]
public sealed class TagsController(ITagUseCase tagUseCase) : BaseApiController
{
    [HttpGet]
    public Task<IReadOnlyList<TagDto>> GetAll(CancellationToken cancellationToken)
        => tagUseCase.GetAllAsync(cancellationToken);

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TagDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var tag = await tagUseCase.GetByIdAsync(id, cancellationToken);

        return tag is null ? NotFound() : Ok(tag);
    }

    [HttpPost]
    public async Task<ActionResult<TagDto>> Create(UpsertTagRequest request, CancellationToken cancellationToken)
    {
        var tag = await tagUseCase.CreateAsync(new CreateTagCommand(request.Name), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = tag.Id }, tag);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<TagDto>> Update(Guid id, UpsertTagRequest request, CancellationToken cancellationToken)
    {
        var tag = await tagUseCase.UpdateAsync(id, new UpdateTagCommand(request.Name), cancellationToken);

        return Ok(tag);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await tagUseCase.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}