using Microsoft.AspNetCore.Mvc;

namespace WebsiteScannerService.APIs;

[ApiController()]
public class ScanResultsController : ScanResultsControllerBase
{
    public ScanResultsController(IScanResultsService service)
        : base(service) { }
}
