using FactoryMethodExample.Domain.Contracts.Interfaces;

namespace FactoryMethodExample.Application.Implementations.Services;

public class DefaultPaymentService : IPaymentService
{
    public string ProcessPayment(decimal amount)
    {
        return $"Payment processed for amount {amount:C2} with the default payment gateway";
    }
}