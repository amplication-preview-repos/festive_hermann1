using WebsiteScannerService.APIs;

namespace WebsiteScannerService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IPaymentTransactionsService, PaymentTransactionsService>();
        services.AddScoped<IScanRequestsService, ScanRequestsService>();
        services.AddScoped<IScanResultsService, ScanResultsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
