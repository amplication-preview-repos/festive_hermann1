using Microsoft.EntityFrameworkCore;
using WebsiteScannerService.Infrastructure.Models;

namespace WebsiteScannerService.Infrastructure;

public class WebsiteScannerServiceDbContext : DbContext
{
    public WebsiteScannerServiceDbContext(DbContextOptions<WebsiteScannerServiceDbContext> options)
        : base(options) { }

    public DbSet<PaymentTransactionDbModel> PaymentTransactions { get; set; }

    public DbSet<ScanResultDbModel> ScanResults { get; set; }

    public DbSet<ScanRequestDbModel> ScanRequests { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
