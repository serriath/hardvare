using Hardvare.Common.Requests;
using Hardvare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Hardvare.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-user/{userId}")]
        public async Task<IActionResult> GetUserById(int userId, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserById(userId, cancellationToken);

            return new OkObjectResult(user);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var userId = await _userService.CreateUser(request, cancellationToken);

            return new OkObjectResult(userId);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var success = await _userService.UpdateUser(request, cancellationToken);

            return new OkObjectResult(success);
        }

        [HttpPut("deactivate")]
        public async Task<IActionResult> DeactivateUser(int userId, CancellationToken cancellationToken)
        {
            var success = await _userService.DeactivateUser(userId, cancellationToken);
            return new OkObjectResult(success);
        }

        [HttpPost("get-paged")]
        public async Task<IActionResult> GetPagedUsers(GetPagedUsersByFilterRequest request, CancellationToken cancellationToken)
        {
            var pagedResults = await _userService.GetPagedUsers(request, cancellationToken);

            return new OkObjectResult(pagedResults);
        }
    }
}
