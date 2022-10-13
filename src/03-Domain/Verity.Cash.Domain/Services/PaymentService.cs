using Verity.Cash.Domain.Interfaces;
using Verity.Cash.Domain.Entities;

namespace Verity.Cash.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> AddAsync(Payment payment)
        {
            await _paymentRepository.AddAsync(payment);
            return payment;
        }

        public async Task<DailyConsolidatedPayment> GetDailyConsolidatedAsync(DateTime date)
        {
            var payments = await _paymentRepository.GetDailyConsolidatedAsync(date);

            var cashInPayments = payments.Where(c => c.PaymentType == Enums.PaymentType.CashIn);
            var cashOutPayments = payments.Where(c => c.PaymentType == Enums.PaymentType.CashOut);

            var dailyConsolidatedPayments = new DailyConsolidatedPayment(
                    date, 
                    cashInPayments.Count(), 
                    cashInPayments.Sum(c => c.Amount), 
                    cashOutPayments.Count(), 
                    cashOutPayments.Sum(c => c.Amount));

            return dailyConsolidatedPayments;
        }   

        public void Dispose()
            => GC.SuppressFinalize(this);
    }
}