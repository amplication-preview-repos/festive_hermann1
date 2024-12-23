using Microsoft.EntityFrameworkCore;
using WebsiteScannerService.APIs;
using WebsiteScannerService.APIs.Common;
using WebsiteScannerService.APIs.Dtos;
using WebsiteScannerService.APIs.Errors;
using WebsiteScannerService.APIs.Extensions;
using WebsiteScannerService.Infrastructure;
using WebsiteScannerService.Infrastructure.Models;

namespace WebsiteScannerService.APIs;

public abstract class ScanResultsServiceBase : IScanResultsService
{
    protected readonly WebsiteScannerServiceDbContext _context;

    public ScanResultsServiceBase(WebsiteScannerServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ScanResult
    /// </summary>
    public async Task<ScanResult> CreateScanResult(ScanResultCreateInput createDto)
    {
        var scanResult = new ScanResultDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            scanResult.Id = createDto.Id;
        }

        _context.ScanResults.Add(scanResult);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ScanResultDbModel>(scanResult.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ScanResult
    /// </summary>
    public async Task DeleteScanResult(ScanResultWhereUniqueInput uniqueId)
    {
        var scanResult = await _context.ScanResults.FindAsync(uniqueId.Id);
        if (scanResult == null)
        {
            throw new NotFoundException();
        }

        _context.ScanResults.Remove(scanResult);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ScanResults
    /// </summary>
    public async Task<List<ScanResult>> ScanResults(ScanResultFindManyArgs findManyArgs)
    {
        var scanResults = await _context
            .ScanResults.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return scanResults.ConvertAll(scanResult => scanResult.ToDto());
    }

    /// <summary>
    /// Meta data about ScanResult records
    /// </summary>
    public async Task<MetadataDto> ScanResultsMeta(ScanResultFindManyArgs findManyArgs)
    {
        var count = await _context.ScanResults.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ScanResult
    /// </summary>
    public async Task<ScanResult> ScanResult(ScanResultWhereUniqueInput uniqueId)
    {
        var scanResults = await this.ScanResults(
            new ScanResultFindManyArgs { Where = new ScanResultWhereInput { Id = uniqueId.Id } }
        );
        var scanResult = scanResults.FirstOrDefault();
        if (scanResult == null)
        {
            throw new NotFoundException();
        }

        return scanResult;
    }

    /// <summary>
    /// Update one ScanResult
    /// </summary>
    public async Task UpdateScanResult(
        ScanResultWhereUniqueInput uniqueId,
        ScanResultUpdateInput updateDto
    )
    {
        var scanResult = updateDto.ToModel(uniqueId);

        _context.Entry(scanResult).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ScanResults.Any(e => e.Id == scanResult.Id))
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
