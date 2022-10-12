using System.Net;
using Microsoft.AspNetCore.Mvc;
using Verity.Cash.Api.Models;
using Verity.Cash.Api.Models.Extensions;
using Verity.Cash.Api.Validations;
using Verity.Cash.Domain.Interfaces;

namespace Verity.Cash.Api.Controllers.v2.Payments;

[ApiController]
[ApiVersion("2")]
[Produces("application/json")]
[Route("api/v{version:apiVersion}/payment")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly ILogger<PaymentController> _logger;
    
    public PaymentController(
        IPaymentService paymentService,
        ILogger<PaymentController> logger)
    {
        _logger = logger;
        _paymentService = paymentService;
    }

    [HttpPost("cash-in")]
    [ProducesResponseType(typeof(PaymentModel), 201)]
    [ProducesResponseType(typeof(ErrorModel), 400)]
    [ProducesResponseType(typeof(ErrorModel), 500)]
    public async Task<IActionResult> PostPaymentCashInAsync([FromBody] PaymentModel model)
    {
        var validationResult = await new PaymentModelCashInValidator().ValidateAsync(model);

        if (!validationResult.IsValid)
            return BadRequest(new ErrorModel((int)HttpStatusCode.BadRequest, validationResult.Errors));
            
        PaymentModel responseModel = await _paymentService.AddAsync(model.ToPaymentCashIn());

        return Created(nameof(PostPaymentCashInAsync), responseModel);
    }

    [HttpPost("cash-out")]
    [ProducesResponseType(typeof(PaymentModel), 201)]
    [ProducesResponseType(typeof(ErrorModel), 400)]
    [ProducesResponseType(typeof(ErrorModel), 500)]
    public async Task<IActionResult> PostPaymentCashOutAsync([FromBody] PaymentModel model)
    {
        var validationResult = await new PaymentModelCashOutValidator().ValidateAsync(model);

        if (!validationResult.IsValid)
            return BadRequest(new ErrorModel((int)HttpStatusCode.BadRequest, validationResult.Errors));

        PaymentModel responseModel = await _paymentService.AddAsync(model.ToPaymentCashOut());

        return Created(nameof(PostPaymentCashInAsync), responseModel);
    }
}