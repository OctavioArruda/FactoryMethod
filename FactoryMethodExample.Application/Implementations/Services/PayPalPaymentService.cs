using FactoryMethodExample.Domain.Contracts.Interfaces;

namespace FactoryMethodExample.Application.Implementations.Services;

public class PayPalPaymentService : IPaymentService
{
    public string ProcessPayment(decimal amount)
    {
        return $"PayPal payment processed for amount {amount:C2}";
    }
}