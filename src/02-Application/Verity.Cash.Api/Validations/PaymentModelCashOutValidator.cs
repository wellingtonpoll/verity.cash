using FluentValidation;
using Verity.Cash.Api.Models;

namespace Verity.Cash.Api.Validations
{
    public class PaymentModelCashOutValidator: AbstractValidator<PaymentModel>
    {
        public PaymentModelCashOutValidator()
        {
            RuleFor(c => c.Amount).GreaterThan(0);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.PaymentType).Equal(PaymentTypeModel.CashOut);
        }
    }
}