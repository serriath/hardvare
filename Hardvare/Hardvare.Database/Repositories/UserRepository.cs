using Hardvare.Common.DataTransferObjects;
using Hardvare.Database.Interfaces;
using Hardvare.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hardvare.Database.Queries
{
    public class UserRepository : IUserRepository
    {
        private readonly HardvareContext _context;
        private readonly IMapper<UserDto, User> _userMapper;

        public UserRepository(
            HardvareContext context, 
            IMapper<UserDto, User> userMapper)
        {
            _context = context;
            _userMapper = userMapper;
        }
       
        public async Task<UserDto?> GetUserById(int UserId, CancellationToken cancellationToken)
        {
            var user = await _context.User
                                     .Where(u => u.IsActive)
                                     .FirstOrDefaultAsync(u => u.Id == UserId, cancellationToken);

            return user != null ? _userMapper.Map(user) : null;
        }

        public async Task<int> CreateUser(UserDto newUser, CancellationToken cancellationToken)
        {
            var user = _userMapper.Map(newUser);

            await _context.User.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;

        }

        public async Task<UserDto?> GetUserByEmail(string Email, CancellationToken cancellationToken)
        {
            var user = await _context.User
                                     .Where(u => u.IsActive)
                                     .FirstOrDefaultAsync(u => u.Email.Contains(Email));

            return user != null ? _userMapper.Map(user) : null;
        }

        public async Task<bool> UpdateUser(UserDto updateUser, CancellationToken cancellationToken)
        {
            var user = await _context.User
                                     .Where(u => u.IsActive)
                                     .FirstOrDefaultAsync(u => u.Id == updateUser.Id, cancellationToken);

            if(user == null)
            {
                return false;
            }

            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.UserRoleId = (int)updateUser.UserRole;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeactivateUser(int UserId, CancellationToken cancellationToken)
        {
            var user = await _context.User
                                     .Where(u => u.IsActive)
                                     .FirstOrDefaultAsync(u => u.Id == UserId, cancellationToken);

            if (user == null)
            {
                return false;
            }

            user.IsActive = false;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
