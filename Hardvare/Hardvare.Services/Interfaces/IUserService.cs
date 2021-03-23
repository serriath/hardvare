using Hardvare.Common.DataTransferObjects;
using Hardvare.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Hardvare.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(int UserId, CancellationToken cancellationToken);

        Task<int> CreateUser(CreateUserRequest Request, CancellationToken cancellationToken);

        Task<bool> UpdateUser(UpdateUserRequest Request, CancellationToken cancellationToken);

        Task<bool> DeactivateUser(int userId, CancellationToken cancellationToken);
    }
}
