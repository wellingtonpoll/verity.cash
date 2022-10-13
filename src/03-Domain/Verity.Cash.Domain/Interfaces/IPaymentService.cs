using Verity.Cash.Domain.Entities;

namespace Verity.Cash.Domain.Interfaces
{
    public interface IPaymentService : IDisposable
    {
        Task<Payment> AddAsync(Payment payment);
        Task<DailyConsolidatedPayment> GetDailyConsolidatedAsync(DateTime date);
    }
}