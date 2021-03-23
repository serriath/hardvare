using Hardvare.Common.DataTransferObjects;
using Hardvare.Common.Requests;
using Hardvare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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

        [HttpGet("GetUserById")]
        public async Task<UserDto> GetUserById(int UserId, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserById(UserId, cancellationToken);

            //security and all that
            user.Salt = new byte[0];
            user.Password = new byte[0];

            return user;
        }

        [HttpPost("CreateUser")]
        public async Task<int> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return await _userService.CreateUser(request, cancellationToken);
        }

        [HttpPut("UpdateUser")]
        public async Task<bool> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateUser(request, cancellationToken);
        }

        [HttpPut("DeactivateUser")]
        public async Task<bool> DeactivateUser(int UserId, CancellationToken cancellationToken)
        {
            return await _userService.DeactivateUser(UserId, cancellationToken);
        }
    }
}
