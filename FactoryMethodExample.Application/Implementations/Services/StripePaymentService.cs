using FactoryMethodExample.Domain.Contracts.Interfaces;

namespace FactoryMethodExample.Application.Implementations.Services;

public class StripePaymentService : IPaymentService
{
    public string ProcessPayment(decimal amount)
    {
        return $"Stripe payment processed for amount {amount:C2}";
    }
}