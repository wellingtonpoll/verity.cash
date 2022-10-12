using Microsoft.AspNetCore.Mvc;

namespace Verity.Cash.Api.Controllers;

[ApiController]
[Route("[controller]")]
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
        return await Task.FromResult(Ok("cash in created"));
    }

    [HttpPost("out")]
    public async Task<IActionResult> PostCashOutAsync()
    {
        return await Task.FromResult(Ok("cash out created"));
    }
}
