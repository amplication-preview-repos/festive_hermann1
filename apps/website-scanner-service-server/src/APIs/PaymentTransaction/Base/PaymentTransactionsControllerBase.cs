using Microsoft.AspNetCore.Mvc;
using WebsiteScannerService.APIs;
using WebsiteScannerService.APIs.Common;
using WebsiteScannerService.APIs.Dtos;
using WebsiteScannerService.APIs.Errors;

namespace WebsiteScannerService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PaymentTransactionsControllerBase : ControllerBase
{
    protected readonly IPaymentTransactionsService _service;

    public PaymentTransactionsControllerBase(IPaymentTransactionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PaymentTransaction
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PaymentTransaction>> CreatePaymentTransaction(
        PaymentTransactionCreateInput input
    )
    {
        var paymentTransaction = await _service.CreatePaymentTransaction(input);

        return CreatedAtAction(
            nameof(PaymentTransaction),
            new { id = paymentTransaction.Id },
            paymentTransaction
        );
    }

    /// <summary>
    /// Delete one PaymentTransaction
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePaymentTransaction(
        [FromRoute()] PaymentTransactionWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePaymentTransaction(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PaymentTransactions
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PaymentTransaction>>> PaymentTransactions(
        [FromQuery()] PaymentTransactionFindManyArgs filter
    )
    {
        return Ok(await _service.PaymentTransactions(filter));
    }

    /// <summary>
    /// Meta data about PaymentTransaction records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PaymentTransactionsMeta(
        [FromQuery()] PaymentTransactionFindManyArgs filter
    )
    {
        return Ok(await _service.PaymentTransactionsMeta(filter));
    }

    /// <summary>
    /// Get one PaymentTransaction
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PaymentTransaction>> PaymentTransaction(
        [FromRoute()] PaymentTransactionWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PaymentTransaction(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PaymentTransaction
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePaymentTransaction(
        [FromRoute()] PaymentTransactionWhereUniqueInput uniqueId,
        [FromQuery()] PaymentTransactionUpdateInput paymentTransactionUpdateDto
    )
    {
        try
        {
            await _service.UpdatePaymentTransaction(uniqueId, paymentTransactionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
