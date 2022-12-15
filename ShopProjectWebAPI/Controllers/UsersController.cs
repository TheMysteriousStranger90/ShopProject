using BLL.Interfaces;
using Microsoft.Extensions.Logging;

namespace ShopProjectWebAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }
        
        
    }
}