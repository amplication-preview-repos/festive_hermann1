using WebsiteScannerService.APIs.Dtos;
using WebsiteScannerService.Infrastructure.Models;

namespace WebsiteScannerService.APIs.Extensions;

public static class ScanResultsExtensions
{
    public static ScanResult ToDto(this ScanResultDbModel model)
    {
        return new ScanResult
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ScanResultDbModel ToModel(
        this ScanResultUpdateInput updateDto,
        ScanResultWhereUniqueInput uniqueId
    )
    {
        var scanResult = new ScanResultDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            scanResult.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            scanResult.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return scanResult;
    }
}
