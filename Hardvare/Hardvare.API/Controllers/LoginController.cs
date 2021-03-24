using Hardvare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Hardvare.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(int userId, string newPassword, CancellationToken cancellationToken)
        {
            var user = await _userService.ResetPassword(userId, newPassword, cancellationToken);

            return new OkObjectResult(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _userService.Login(email, password, cancellationToken);

            return new OkObjectResult(user);
        }
    }
}
