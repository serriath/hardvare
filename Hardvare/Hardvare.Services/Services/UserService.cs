using Hardvare.Common.DataTransferObjects;
using Hardvare.Database.Interfaces;
using Hardvare.Services.Interfaces;
using System.Threading.Tasks;
using System.Threading;

namespace Hardvare.Services.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserById(int UserId, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(UserId, cancellationToken);
        }
    }
}
