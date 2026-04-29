using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers;

public sealed class HealthController(TodoListDbContext dbContext) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var canConnect = await dbContext.Database.CanConnectAsync(cancellationToken);

        return Ok(new
        {
            status = canConnect ? "ok" : "degraded",
            database = canConnect ? "reachable" : "unreachable",
            timestampUtc = DateTime.UtcNow
        });
    }
}