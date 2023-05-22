namespace FactoryMethodExample.Domain.Contracts.Interfaces;

public interface IPaymentServiceFactory
{
    IPaymentService CreatePaymentService(decimal amount);
}