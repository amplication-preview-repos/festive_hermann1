using Microsoft.EntityFrameworkCore;
using WebsiteScannerService.APIs;
using WebsiteScannerService.APIs.Common;
using WebsiteScannerService.APIs.Dtos;
using WebsiteScannerService.APIs.Errors;
using WebsiteScannerService.APIs.Extensions;
using WebsiteScannerService.Infrastructure;
using WebsiteScannerService.Infrastructure.Models;

namespace WebsiteScannerService.APIs;

public abstract class PaymentTransactionsServiceBase : IPaymentTransactionsService
{
    protected readonly WebsiteScannerServiceDbContext _context;

    public PaymentTransactionsServiceBase(WebsiteScannerServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PaymentTransaction
    /// </summary>
    public async Task<PaymentTransaction> CreatePaymentTransaction(
        PaymentTransactionCreateInput createDto
    )
    {
        var paymentTransaction = new PaymentTransactionDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            paymentTransaction.Id = createDto.Id;
        }

        _context.PaymentTransactions.Add(paymentTransaction);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PaymentTransactionDbModel>(paymentTransaction.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PaymentTransaction
    /// </summary>
    public async Task DeletePaymentTransaction(PaymentTransactionWhereUniqueInput uniqueId)
    {
        var paymentTransaction = await _context.PaymentTransactions.FindAsync(uniqueId.Id);
        if (paymentTransaction == null)
        {
            throw new NotFoundException();
        }

        _context.PaymentTransactions.Remove(paymentTransaction);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PaymentTransactions
    /// </summary>
    public async Task<List<PaymentTransaction>> PaymentTransactions(
        PaymentTransactionFindManyArgs findManyArgs
    )
    {
        var paymentTransactions = await _context
            .PaymentTransactions.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return paymentTransactions.ConvertAll(paymentTransaction => paymentTransaction.ToDto());
    }

    /// <summary>
    /// Meta data about PaymentTransaction records
    /// </summary>
    public async Task<MetadataDto> PaymentTransactionsMeta(
        PaymentTransactionFindManyArgs findManyArgs
    )
    {
        var count = await _context.PaymentTransactions.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PaymentTransaction
    /// </summary>
    public async Task<PaymentTransaction> PaymentTransaction(
        PaymentTransactionWhereUniqueInput uniqueId
    )
    {
        var paymentTransactions = await this.PaymentTransactions(
            new PaymentTransactionFindManyArgs
            {
                Where = new PaymentTransactionWhereInput { Id = uniqueId.Id }
            }
        );
        var paymentTransaction = paymentTransactions.FirstOrDefault();
        if (paymentTransaction == null)
        {
            throw new NotFoundException();
        }

        return paymentTransaction;
    }

    /// <summary>
    /// Update one PaymentTransaction
    /// </summary>
    public async Task UpdatePaymentTransaction(
        PaymentTransactionWhereUniqueInput uniqueId,
        PaymentTransactionUpdateInput updateDto
    )
    {
        var paymentTransaction = updateDto.ToModel(uniqueId);

        _context.Entry(paymentTransaction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PaymentTransactions.Any(e => e.Id == paymentTransaction.Id))
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
