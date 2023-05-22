using FactoryMethodExample.Application.Implementations.Services;
using FactoryMethodExample.Domain.Contracts.Interfaces;

namespace FactoryMethodExample.Application.Implementations.Factories;

public class PaymentServiceFactory : IPaymentServiceFactory
{
    public IPaymentService CreatePaymentService(decimal amount)
    {
        return amount switch
        {
            <= 50 => new StripePaymentService(),
            <= 100 => new PayPalPaymentService(),
            _ => new DefaultPaymentService()
        };
    }
}