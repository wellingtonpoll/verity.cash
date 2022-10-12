namespace Verity.Cash.Api.Models
{
    public class PaymentModel
    {
        public Guid Id { get; private set; }
        public double Amount { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public PaymentTypeModel PaymentType { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }

    public enum PaymentTypeModel
    {
        Debit = 0,
        Credit = 1
    }
}