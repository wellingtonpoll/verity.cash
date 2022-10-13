using Verity.Cash.Domain.Entities;

namespace Verity.Cash.Domain.Interfaces
{
    public interface IPaymentRepository
    {
        Task AddAsync(Payment payment);
    }
}