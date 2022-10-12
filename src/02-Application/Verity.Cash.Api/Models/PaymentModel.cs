using Verity.Cash.Domain.Entities;

namespace Verity.Cash.Api.Models
{
    public class PaymentModel
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public PaymentTypeModel PaymentType { get; set; }
        public DateTime CreatedAt { get; set; }

        public static implicit operator PaymentModel(Payment payment)
            => new PaymentModel
            {
                Id = payment.Id,
                Amount = payment.Amount,
                Category = payment.Category,
                Description = payment.Description,
                PaymentType = (PaymentTypeModel)(int)payment.PaymentType,
                CreatedAt = payment.CreatedAt
            };
    }

    public enum PaymentTypeModel
    {
        CashOut = 0,
        CashIn = 1
    }
}