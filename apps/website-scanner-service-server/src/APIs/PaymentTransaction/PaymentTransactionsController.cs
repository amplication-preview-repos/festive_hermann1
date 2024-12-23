using Microsoft.AspNetCore.Mvc;

namespace WebsiteScannerService.APIs;

[ApiController()]
public class PaymentTransactionsController : PaymentTransactionsControllerBase
{
    public PaymentTransactionsController(IPaymentTransactionsService service)
        : base(service) { }
}
