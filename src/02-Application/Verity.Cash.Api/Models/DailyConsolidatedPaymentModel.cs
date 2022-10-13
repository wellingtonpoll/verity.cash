using Verity.Cash.Domain.Entities;

namespace Verity.Cash.Api.Models
{
    public class DailyConsolidatedPaymentModel
    {
        public DateTime Date { get; set; }
        public int CashInPayments { get; set; }
        public double AmountCashInPayments { get; set; }
        public int CashOutPayments { get; set; }
        public double AmoutCashOutPayments { get; set; }
        public double DailyBalance { get; set; }

        public static implicit operator DailyConsolidatedPaymentModel(DailyConsolidatedPayment dailyConsolidatedPayment)
            => new DailyConsolidatedPaymentModel
            {
                Date = dailyConsolidatedPayment.Date,
                CashInPayments = dailyConsolidatedPayment.CashInPayments,
                AmountCashInPayments = dailyConsolidatedPayment.AmountCashInPayments,
                CashOutPayments = dailyConsolidatedPayment.CashOutPayments,
                AmoutCashOutPayments = dailyConsolidatedPayment.AmoutCashOutPayments,
                DailyBalance = dailyConsolidatedPayment.DailyBalance
            };
    }
}