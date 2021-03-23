
using Hardvare.Common.DataTransferObjects;
using System.Threading;
using System.Threading.Tasks;

namespace Hardvare.Database.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserById(int UserId, CancellationToken cancellationToken);
    }
}
