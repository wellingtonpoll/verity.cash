using Verity.Cash.Domain.Interfaces;
using Verity.Cash.Domain.Entities;

namespace Verity.Cash.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private bool disposedValue;
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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}