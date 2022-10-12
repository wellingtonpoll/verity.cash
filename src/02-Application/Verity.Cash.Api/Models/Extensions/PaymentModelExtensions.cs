using Verity.Cash.Domain.Entities;
using Verity.Cash.Domain.Enums;

namespace Verity.Cash.Api.Models.Extensions
{
    public static class PaymentModelExtensions
    {
        public static Payment ToPaymentCashIn(this PaymentModel model)
            => new Payment(model.Id, model.Amount, model.Description, model.Category, PaymentType.CashIn, DateTime.UtcNow);

        public static Payment ToPaymentCashOut(this PaymentModel model)
            => new Payment(model.Id, model.Amount, model.Description, model.Category, PaymentType.CashOut, DateTime.UtcNow);
    }
}