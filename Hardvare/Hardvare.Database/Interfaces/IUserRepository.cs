using Hardvare.Common.DataTransferObjects;
using System.Threading;
using System.Threading.Tasks;

namespace Hardvare.Database.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto?> GetUserById(int UserId, CancellationToken cancellationToken);

        Task<int> CreateUser(UserDto NewUser, CancellationToken cancellationToken);

        Task<UserDto?> GetUserByEmail(string Email, CancellationToken cancellationToken);

        Task<bool> UpdateUser(UserDto UpdateUser, CancellationToken cancellationToken);

        Task<bool> DeactivateUser(int UserId, CancellationToken cancellationToken);
    }
}
