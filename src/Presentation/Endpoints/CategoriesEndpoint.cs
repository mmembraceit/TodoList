using Application.Features.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Endpoints.Requests;

namespace Presentation.Controllers;

[Authorize]
public sealed class CategoriesController(ICategoryUseCase categoryUseCase) : BaseApiController
{
    [HttpGet]
    public Task<IReadOnlyList<CategoryDto>> GetAll(CancellationToken cancellationToken)
        => categoryUseCase.GetAllAsync(cancellationToken);

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoryDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var category = await categoryUseCase.GetByIdAsync(id, cancellationToken);

        return category is null ? NotFound() : Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create(UpsertCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await categoryUseCase.CreateAsync(new CreateCategoryCommand(request.Name), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CategoryDto>> Update(Guid id, UpsertCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await categoryUseCase.UpdateAsync(id, new UpdateCategoryCommand(request.Name), cancellationToken);

        return Ok(category);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await categoryUseCase.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}