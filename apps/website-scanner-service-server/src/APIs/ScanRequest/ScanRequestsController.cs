using Microsoft.AspNetCore.Mvc;

namespace WebsiteScannerService.APIs;

[ApiController()]
public class ScanRequestsController : ScanRequestsControllerBase
{
    public ScanRequestsController(IScanRequestsService service)
        : base(service) { }
}
