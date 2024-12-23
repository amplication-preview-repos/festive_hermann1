using WebsiteScannerService.Infrastructure;

namespace WebsiteScannerService.APIs;

public class PaymentTransactionsService : PaymentTransactionsServiceBase
{
    public PaymentTransactionsService(WebsiteScannerServiceDbContext context)
        : base(context) { }
}
