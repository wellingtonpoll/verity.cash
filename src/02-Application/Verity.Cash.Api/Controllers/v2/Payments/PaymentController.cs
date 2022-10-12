using Microsoft.AspNetCore.Mvc;

namespace Verity.Cash.Api.Controllers.v2.Payments;

[ApiController]
[ApiVersion("2")]
[Produces("application/json")]
[Route("api/v{version:apiVersion}/payment")]
public class PaymentController : ControllerBase
{
    private readonly ILogger<PaymentController> _logger;

    public PaymentController(ILogger<PaymentController> logger)
    {
        _logger = logger;
    }

    [HttpPost("cash-in")]
    public async Task<IActionResult> PostPaymentCashInAsync()
    {
        return await Task.FromResult(Ok("cash in created v2"));
    }

    [HttpPost("cash-out")]
    public async Task<IActionResult> PostPaymentCashOutAsync()
    {
        return await Task.FromResult(Ok("cash out created v2"));
    }
}