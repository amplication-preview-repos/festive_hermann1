using Microsoft.EntityFrameworkCore;
using WebsiteScannerService.APIs;
using WebsiteScannerService.APIs.Common;
using WebsiteScannerService.APIs.Dtos;
using WebsiteScannerService.APIs.Errors;
using WebsiteScannerService.APIs.Extensions;
using WebsiteScannerService.Infrastructure;
using WebsiteScannerService.Infrastructure.Models;

namespace WebsiteScannerService.APIs;

public abstract class ScanRequestsServiceBase : IScanRequestsService
{
    protected readonly WebsiteScannerServiceDbContext _context;

    public ScanRequestsServiceBase(WebsiteScannerServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ScanRequest
    /// </summary>
    public async Task<ScanRequest> CreateScanRequest(ScanRequestCreateInput createDto)
    {
        var scanRequest = new ScanRequestDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Email = createDto.Email,
            UpdatedAt = createDto.UpdatedAt,
            Website = createDto.Website
        };

        if (createDto.Id != null)
        {
            scanRequest.Id = createDto.Id;
        }

        _context.ScanRequests.Add(scanRequest);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ScanRequestDbModel>(scanRequest.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ScanRequest
    /// </summary>
    public async Task DeleteScanRequest(ScanRequestWhereUniqueInput uniqueId)
    {
        var scanRequest = await _context.ScanRequests.FindAsync(uniqueId.Id);
        if (scanRequest == null)
        {
            throw new NotFoundException();
        }

        _context.ScanRequests.Remove(scanRequest);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ScanRequests
    /// </summary>
    public async Task<List<ScanRequest>> ScanRequests(ScanRequestFindManyArgs findManyArgs)
    {
        var scanRequests = await _context
            .ScanRequests.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return scanRequests.ConvertAll(scanRequest => scanRequest.ToDto());
    }

    /// <summary>
    /// Meta data about ScanRequest records
    /// </summary>
    public async Task<MetadataDto> ScanRequestsMeta(ScanRequestFindManyArgs findManyArgs)
    {
        var count = await _context.ScanRequests.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ScanRequest
    /// </summary>
    public async Task<ScanRequest> ScanRequest(ScanRequestWhereUniqueInput uniqueId)
    {
        var scanRequests = await this.ScanRequests(
            new ScanRequestFindManyArgs { Where = new ScanRequestWhereInput { Id = uniqueId.Id } }
        );
        var scanRequest = scanRequests.FirstOrDefault();
        if (scanRequest == null)
        {
            throw new NotFoundException();
        }

        return scanRequest;
    }

    /// <summary>
    /// Update one ScanRequest
    /// </summary>
    public async Task UpdateScanRequest(
        ScanRequestWhereUniqueInput uniqueId,
        ScanRequestUpdateInput updateDto
    )
    {
        var scanRequest = updateDto.ToModel(uniqueId);

        _context.Entry(scanRequest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ScanRequests.Any(e => e.Id == scanRequest.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
