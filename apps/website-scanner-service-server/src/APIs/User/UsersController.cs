using Microsoft.AspNetCore.Mvc;

namespace WebsiteScannerService.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
