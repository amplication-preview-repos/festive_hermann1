using WebsiteScannerService.Infrastructure;

namespace WebsiteScannerService.APIs;

public class ScanRequestsService : ScanRequestsServiceBase
{
    public ScanRequestsService(WebsiteScannerServiceDbContext context)
        : base(context) { }
}
