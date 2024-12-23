using WebsiteScannerService.Infrastructure;

namespace WebsiteScannerService.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(WebsiteScannerServiceDbContext context)
        : base(context) { }
}
