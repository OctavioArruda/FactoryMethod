using FactoryMethodExample.Domain.Contracts.Interfaces;
using FactoryMethodExample.Domain.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace FactoryMethodExample.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public IActionResult ProcessPayment(Payment payment)
    {
        string result = _paymentService.ProcessPayment(payment.Amount);
        return Ok(result);
    }
}