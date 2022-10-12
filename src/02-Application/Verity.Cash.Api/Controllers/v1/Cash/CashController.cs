using Microsoft.AspNetCore.Mvc;

namespace Verity.Cash.Api.Controllers.v1.Cash;

[ApiController]
[Produces("application/json")]
[ApiVersion("1", Deprecated = true)]
[Route("api/v{version:apiVersion}/cash")]
public class CashController : ControllerBase
{
    private readonly ILogger<CashController> _logger;

    public CashController(ILogger<CashController> logger)
    {
        _logger = logger;
    }

    [HttpPost("in")]
    public async Task<IActionResult> PostCashInAsync()
    {
        return await Task.FromResult(Ok("cash in created v1"));
    }

    [HttpPost("out")]
    public async Task<IActionResult> PostCashOutAsync()
    {
        return await Task.FromResult(Ok("cash out created v1"));
    }
}
