using WebsiteScannerService.APIs.Common;
using WebsiteScannerService.APIs.Dtos;

namespace WebsiteScannerService.APIs;

public interface IScanRequestsService
{
    /// <summary>
    /// Create one ScanRequest
    /// </summary>
    public Task<ScanRequest> CreateScanRequest(ScanRequestCreateInput scanrequest);

    /// <summary>
    /// Delete one ScanRequest
    /// </summary>
    public Task DeleteScanRequest(ScanRequestWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ScanRequests
    /// </summary>
    public Task<List<ScanRequest>> ScanRequests(ScanRequestFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about ScanRequest records
    /// </summary>
    public Task<MetadataDto> ScanRequestsMeta(ScanRequestFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ScanRequest
    /// </summary>
    public Task<ScanRequest> ScanRequest(ScanRequestWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ScanRequest
    /// </summary>
    public Task UpdateScanRequest(
        ScanRequestWhereUniqueInput uniqueId,
        ScanRequestUpdateInput updateDto
    );
}
