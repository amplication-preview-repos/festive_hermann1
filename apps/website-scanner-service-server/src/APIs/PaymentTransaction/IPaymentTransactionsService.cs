using WebsiteScannerService.APIs.Common;
using WebsiteScannerService.APIs.Dtos;

namespace WebsiteScannerService.APIs;

public interface IPaymentTransactionsService
{
    /// <summary>
    /// Create one PaymentTransaction
    /// </summary>
    public Task<PaymentTransaction> CreatePaymentTransaction(
        PaymentTransactionCreateInput paymenttransaction
    );

    /// <summary>
    /// Delete one PaymentTransaction
    /// </summary>
    public Task DeletePaymentTransaction(PaymentTransactionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many PaymentTransactions
    /// </summary>
    public Task<List<PaymentTransaction>> PaymentTransactions(
        PaymentTransactionFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about PaymentTransaction records
    /// </summary>
    public Task<MetadataDto> PaymentTransactionsMeta(PaymentTransactionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one PaymentTransaction
    /// </summary>
    public Task<PaymentTransaction> PaymentTransaction(PaymentTransactionWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one PaymentTransaction
    /// </summary>
    public Task UpdatePaymentTransaction(
        PaymentTransactionWhereUniqueInput uniqueId,
        PaymentTransactionUpdateInput updateDto
    );
}
