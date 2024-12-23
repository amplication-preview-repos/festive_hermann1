using Microsoft.AspNetCore.Mvc;
using WebsiteScannerService.APIs.Common;
using WebsiteScannerService.Infrastructure.Models;

namespace WebsiteScannerService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ScanRequestFindManyArgs : FindManyInput<ScanRequest, ScanRequestWhereInput> { }
