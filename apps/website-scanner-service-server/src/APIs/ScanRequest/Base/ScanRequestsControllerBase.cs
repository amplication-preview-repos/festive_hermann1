using Microsoft.AspNetCore.Mvc;
using WebsiteScannerService.APIs;
using WebsiteScannerService.APIs.Common;
using WebsiteScannerService.APIs.Dtos;
using WebsiteScannerService.APIs.Errors;

namespace WebsiteScannerService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ScanRequestsControllerBase : ControllerBase
{
    protected readonly IScanRequestsService _service;

    public ScanRequestsControllerBase(IScanRequestsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one ScanRequest
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ScanRequest>> CreateScanRequest(ScanRequestCreateInput input)
    {
        var scanRequest = await _service.CreateScanRequest(input);

        return CreatedAtAction(nameof(ScanRequest), new { id = scanRequest.Id }, scanRequest);
    }

    /// <summary>
    /// Delete one ScanRequest
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteScanRequest(
        [FromRoute()] ScanRequestWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteScanRequest(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ScanRequests
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ScanRequest>>> ScanRequests(
        [FromQuery()] ScanRequestFindManyArgs filter
    )
    {
        return Ok(await _service.ScanRequests(filter));
    }

    /// <summary>
    /// Meta data about ScanRequest records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ScanRequestsMeta(
        [FromQuery()] ScanRequestFindManyArgs filter
    )
    {
        return Ok(await _service.ScanRequestsMeta(filter));
    }

    /// <summary>
    /// Get one ScanRequest
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ScanRequest>> ScanRequest(
        [FromRoute()] ScanRequestWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ScanRequest(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one ScanRequest
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateScanRequest(
        [FromRoute()] ScanRequestWhereUniqueInput uniqueId,
        [FromQuery()] ScanRequestUpdateInput scanRequestUpdateDto
    )
    {
        try
        {
            await _service.UpdateScanRequest(uniqueId, scanRequestUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
