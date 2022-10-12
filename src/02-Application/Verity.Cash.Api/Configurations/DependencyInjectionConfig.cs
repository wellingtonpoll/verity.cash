using Verity.Cash.Domain.Interfaces;
using Verity.Cash.Domain.Services;

namespace Verity.Cash.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}