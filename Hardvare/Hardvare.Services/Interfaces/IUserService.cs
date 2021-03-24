using Hardvare.Common.DataTransferObjects;
using Hardvare.Common.Requests;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hardvare.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(int userId, CancellationToken cancellationToken);

        Task<int> CreateUser(CreateUserRequest request, CancellationToken cancellationToken);

        Task<bool> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken);

        Task<bool> DeactivateUser(int userId, CancellationToken cancellationToken);

        Task<PagedDto<IEnumerable<UserDto>>> GetPagedUsers(GetPagedUsersByFilterRequest request, CancellationToken cancellationToken);

        Task<bool> ResetPassword(int userId, string newPassword, CancellationToken cancellationToken);

        Task<UserDto> Login(string email, string password, CancellationToken cancellationToken);
    }
}
