using Hardvare.Common.DataTransferObjects;
using Hardvare.Common.Enums;
using Hardvare.Common.Exceptions;
using Hardvare.Database.Interfaces;
using Hardvare.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Hardvare.Database.Queries
{
    public class UserRepository : IUserRepository
    {
        private readonly HardvareContext _context;
        public UserRepository(HardvareContext context)
        {
            _context = context;
        }

        public async Task<UserDto> GetUserById(int UserId, CancellationToken cancellationToken)
        {
            var data = await _context.User.FirstOrDefaultAsync(u => u.Id == UserId, cancellationToken);

            if (data == null)
            {
                throw new EntityNotFoundException($"Unable to find user with id {UserId}");
            }

            return new UserDto()
            {
                Id = data.Id,
                EmailAddress = data.Email,
                FirstName = data.FirstName,
                IsActive = data.IsActive,
                LastName = data.LastName,
                Password = data.Password,
                UserRole = (UserRoleEnum)data.UserRoleId
            };
        }
    }
}
