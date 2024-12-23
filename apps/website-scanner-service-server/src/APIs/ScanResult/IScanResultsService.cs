using WebsiteScannerService.APIs.Common;
using WebsiteScannerService.APIs.Dtos;

namespace WebsiteScannerService.APIs;

public interface IScanResultsService
{
    /// <summary>
    /// Create one ScanResult
    /// </summary>
    public Task<ScanResult> CreateScanResult(ScanResultCreateInput scanresult);

    /// <summary>
    /// Delete one ScanResult
    /// </summary>
    public Task DeleteScanResult(ScanResultWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ScanResults
    /// </summary>
    public Task<List<ScanResult>> ScanResults(ScanResultFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about ScanResult records
    /// </summary>
    public Task<MetadataDto> ScanResultsMeta(ScanResultFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ScanResult
    /// </summary>
    public Task<ScanResult> ScanResult(ScanResultWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ScanResult
    /// </summary>
    public Task UpdateScanResult(
        ScanResultWhereUniqueInput uniqueId,
        ScanResultUpdateInput updateDto
    );
}
