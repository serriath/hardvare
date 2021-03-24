using Hardvare.Common.DataTransferObjects;
using Hardvare.Common.Requests;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hardvare.Database.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto?> GetUserById(int userId, CancellationToken cancellationToken);

        Task<int> CreateUser(UserDto newUser, CancellationToken cancellationToken);

        Task<UserDto?> GetUserByEmail(string email, CancellationToken cancellationToken);

        Task<bool> UpdateUser(UserDto updateUser, CancellationToken cancellationToken);

        Task<bool> DeactivateUser(int userId, CancellationToken cancellationToken);

        Task<PagedDto<IEnumerable<UserDto>>> GetPagedUsers(GetPagedUsersByFilterRequest request, CancellationToken cancellationToken);

        Task<bool> ResetPassword(UserDto user, CancellationToken cancellationToken);
    }
}
