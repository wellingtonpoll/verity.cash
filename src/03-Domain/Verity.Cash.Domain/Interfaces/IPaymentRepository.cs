using Verity.Cash.Domain.Entities;

namespace Verity.Cash.Domain.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> AddAsync(Payment payment);
        Task<IEnumerable<Payment>> GetDailyConsolidatedAsync(DateTime date);
    }
}