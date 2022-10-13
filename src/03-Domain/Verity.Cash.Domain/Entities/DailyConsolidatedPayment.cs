namespace Verity.Cash.Domain.Entities
{
    public class DailyConsolidatedPayment
    {
        public DailyConsolidatedPayment(
            DateTime date,
            int cashInPayments,
            double amountCashInPayments,
            int cashOutPayments,
            double amoutCashOutPayments)
        {
            Date = date;
            CashInPayments = cashInPayments;
            AmountCashInPayments = amountCashInPayments;
            CashOutPayments = cashOutPayments;
            AmoutCashOutPayments = amoutCashOutPayments;
        }

        public DateTime Date { get; private set; }
        public int CashInPayments { get; private set; }
        public double AmountCashInPayments { get; private set; }
        public int CashOutPayments { get; private set; }
        public double AmoutCashOutPayments { get; private set; }
        public double DailyBalance { get { return AmountCashInPayments - AmoutCashOutPayments; } }
    }
}