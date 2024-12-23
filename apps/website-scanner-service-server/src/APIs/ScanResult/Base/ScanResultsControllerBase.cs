using Microsoft.AspNetCore.Mvc;
using WebsiteScannerService.APIs;
using WebsiteScannerService.APIs.Common;
using WebsiteScannerService.APIs.Dtos;
using WebsiteScannerService.APIs.Errors;

namespace WebsiteScannerService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ScanResultsControllerBase : ControllerBase
{
    protected readonly IScanResultsService _service;

    public ScanResultsControllerBase(IScanResultsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ScanResult
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ScanResult>> CreateScanResult(ScanResultCreateInput input)
    {
        var scanResult = await _service.CreateScanResult(input);

        return CreatedAtAction(nameof(ScanResult), new { id = scanResult.Id }, scanResult);
    }

    /// <summary>
    /// Delete one ScanResult
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteScanResult(
        [FromRoute()] ScanResultWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteScanResult(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ScanResults
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ScanResult>>> ScanResults(
        [FromQuery()] ScanResultFindManyArgs filter
    )
    {
        return Ok(await _service.ScanResults(filter));
    }

    /// <summary>
    /// Meta data about ScanResult records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ScanResultsMeta(
        [FromQuery()] ScanResultFindManyArgs filter
    )
    {
        return Ok(await _service.ScanResultsMeta(filter));
    }

    /// <summary>
    /// Get one ScanResult
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ScanResult>> ScanResult(
        [FromRoute()] ScanResultWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ScanResult(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ScanResult
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateScanResult(
        [FromRoute()] ScanResultWhereUniqueInput uniqueId,
        [FromQuery()] ScanResultUpdateInput scanResultUpdateDto
    )
    {
        try
        {
            await _service.UpdateScanResult(uniqueId, scanResultUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
