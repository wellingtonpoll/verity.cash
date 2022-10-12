using Verity.Cash.Domain.Enums;

namespace Verity.Cash.Domain.Entities
{
    public class Payment
    {
        public Payment(
            Guid id,
            double amount,
            string description,
            string category,
            PaymentType paymentType,
            DateTime createAt)
        {
            Id = id;
            Amount = amount;
            Description = description;
            Category = category;
            PaymentType = paymentType;
            CreatedAt = createAt;
        }

        public Guid Id { get; private set; }
        public double Amount { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public PaymentType PaymentType { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}