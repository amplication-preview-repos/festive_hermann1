using WebsiteScannerService.APIs.Dtos;
using WebsiteScannerService.Infrastructure.Models;

namespace WebsiteScannerService.APIs.Extensions;

public static class PaymentTransactionsExtensions
{
    public static PaymentTransaction ToDto(this PaymentTransactionDbModel model)
    {
        return new PaymentTransaction
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PaymentTransactionDbModel ToModel(
        this PaymentTransactionUpdateInput updateDto,
        PaymentTransactionWhereUniqueInput uniqueId
    )
    {
        var paymentTransaction = new PaymentTransactionDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            paymentTransaction.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            paymentTransaction.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return paymentTransaction;
    }
}
