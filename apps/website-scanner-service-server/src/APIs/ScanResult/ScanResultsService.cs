using WebsiteScannerService.Infrastructure;

namespace WebsiteScannerService.APIs;

public class ScanResultsService : ScanResultsServiceBase
{
    public ScanResultsService(WebsiteScannerServiceDbContext context)
        : base(context) { }
}
