using Hardvare.Common.DataTransferObjects;
using System.Threading;
using System.Threading.Tasks;

namespace Hardvare.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(int UserId, CancellationToken cancellationToken);
    }
}
