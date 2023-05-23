using FactoryMethodExample.Domain.Contracts.Interfaces;

namespace FactoryMethodExample.Application.Implementations.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentServiceFactory _paymentServiceFactory;

    public PaymentService(IPaymentServiceFactory paymentServiceFactory)
    {
        _paymentServiceFactory = paymentServiceFactory;
    }
    
    public string ProcessPayment(decimal amount)
    {
        var paymentService = _paymentServiceFactory.CreatePaymentService(amount);
        return paymentService.ProcessPayment(amount);
    }
}