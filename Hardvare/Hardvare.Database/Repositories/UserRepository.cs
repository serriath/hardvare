using Hardvare.Common.DataTransferObjects;
using Hardvare.Common.Enums;
using Hardvare.Common.Requests;
using Hardvare.Database.Interfaces;
using Hardvare.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
       
        public async Task<UserDto?> GetUserById(int userId, CancellationToken cancellationToken)
        {
            var user = await _context.User
                                     .Where(u => u.IsActive)
                                     .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            return user != null ? _userMapper.Map(user) : null;
        }

        public async Task<int> CreateUser(UserDto newUser, CancellationToken cancellationToken)
        {
            var user = _userMapper.Map(newUser);

            await _context.User.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;

        }

        public async Task<UserDto?> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            var user = await _context.User
                                     .Where(u => u.IsActive)
                                     .FirstOrDefaultAsync(u => u.Email.Contains(email));

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

        public async Task<bool> DeactivateUser(int userId, CancellationToken cancellationToken)
        {
            var user = await _context.User
                                     .Where(u => u.IsActive)
                                     .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user == null)
            {
                return false;
            }

            user.IsActive = false;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<PagedDto<IEnumerable<UserDto>>> GetPagedUsers(GetPagedUsersByFilterRequest request, CancellationToken cancellationToken)
        {
            var usersQuery = _context.User.AsNoTracking();

            if (!string.IsNullOrEmpty(request.FirstName))
            {
                usersQuery = usersQuery.Where(u => u.FirstName.Contains(request.FirstName));
            }

            if (!string.IsNullOrEmpty(request.LastName))
            {
                usersQuery = usersQuery.Where(u => u.LastName.Contains(request.LastName));
            }

            if(Enum.IsDefined(typeof(UserRoleEnum), request.UserRole))
            {
                usersQuery = usersQuery.Where(u => u.UserRoleId == (int)request.UserRole);
            }

            var finalList = await usersQuery.Skip((request.PageNumber - 1) * request.PageSize)
                                            .Take(request.PageSize)
                                            .ToListAsync(cancellationToken);

            var count = await _context.User.CountAsync(cancellationToken);

            return new PagedDto<IEnumerable<UserDto>>()
            {
                Data = finalList.Select(u => _userMapper.Map(u)),
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalRecords = count
            };
        }

        public async Task<bool> ResetPassword(UserDto user, CancellationToken cancellationToken)
        {
            var currentUser = await _context.User
                                            .Where(u => u.IsActive)
                                            .FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken);

            if(currentUser == null)
            {
                return false;
            }

            currentUser.Salt = user.Salt;
            currentUser.Password = user.Password;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
