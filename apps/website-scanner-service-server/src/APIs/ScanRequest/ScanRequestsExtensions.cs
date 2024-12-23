using WebsiteScannerService.APIs.Dtos;
using WebsiteScannerService.Infrastructure.Models;

namespace WebsiteScannerService.APIs.Extensions;

public static class ScanRequestsExtensions
{
    public static ScanRequest ToDto(this ScanRequestDbModel model)
    {
        return new ScanRequest
        {
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
            Website = model.Website,
        };
    }

    public static ScanRequestDbModel ToModel(
        this ScanRequestUpdateInput updateDto,
        ScanRequestWhereUniqueInput uniqueId
    )
    {
        var scanRequest = new ScanRequestDbModel
        {
            Id = uniqueId.Id,
            Email = updateDto.Email,
            Website = updateDto.Website
        };

        if (updateDto.CreatedAt != null)
        {
            scanRequest.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            scanRequest.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return scanRequest;
    }
}
