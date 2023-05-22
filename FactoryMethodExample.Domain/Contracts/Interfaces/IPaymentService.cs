namespace FactoryMethodExample.Domain.Contracts.Interfaces;

public interface IPaymentService
{
    string ProcessPayment(decimal amount);
}
