using Microsoft.AspNetCore.Mvc;

namespace Verity.Cash.Api.Controllers.v2.Cash;

[ApiController]
[ApiVersion("2", Deprecated = true)]
[Produces("application/json")]
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
        return await Task.FromResult(Ok("cash in created v2"));
    }

    [HttpPost("out")]
    public async Task<IActionResult> PostCashOutAsync()
    {
        return await Task.FromResult(Ok("cash out created v2"));
    }
}
