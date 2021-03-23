using Hardvare.Common.DataTransferObjects;
using Hardvare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Hardvare.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("GetUserById")]
        public async Task<UserDto> GetMessage(int UserId, CancellationToken cancellationToken)
        {
            return await _userService.GetUserById(UserId, cancellationToken);
        }
    }
}
