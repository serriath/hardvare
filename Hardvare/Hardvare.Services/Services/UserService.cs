using Hardvare.Common.DataTransferObjects;
using Hardvare.Database.Interfaces;
using Hardvare.Services.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Hardvare.Common.Requests;
using Hardvare.Common.Exceptions;
using System.Text;
using Hardvare.Common.Enums;
using Hardvare.Common.Utilities;
using System.Collections.Generic;
using System;

namespace Hardvare.Services.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserById(int userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(userId, cancellationToken);

            if (user == null)
            {
                throw new EntityNotFoundException($"Unable to find user with id {userId}");
            }

            await ScrubSensitiveData(new List<UserDto> { user });

            return user;
        }

        public async Task<int> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
        {
            await ValidateCreateUserRequest(request, cancellationToken);

            var salt = CryptoUtilities.CreateSalt();
            var hashedPassword = CryptoUtilities.HashPassword(Encoding.UTF8.GetBytes(request.Password), salt);

            return await _userRepository.CreateUser(new UserDto
            {
                EmailAddress = request.EmailAddress,
                FirstName = request.FirstName,
                LastName = request.LastName,
                IsActive = true,
                Password = hashedPassword,
                Salt = salt,
                UserRole = (UserRoleEnum)request.UserRoleId
            }, cancellationToken);
        }

        public async Task<bool> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateUser(new UserDto
            {
                Id = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserRole = (UserRoleEnum)request.UserRoleId
            }, cancellationToken);
        }

        public async Task<bool> DeactivateUser(int userId, CancellationToken cancellationToken)
        {
            return await _userRepository.DeactivateUser(userId, cancellationToken);
        }

        public async Task<PagedDto<IEnumerable<UserDto>>> GetPagedUsers(GetPagedUsersByFilterRequest request, CancellationToken cancellationToken)
        {
            var pagedUsers = await _userRepository.GetPagedUsers(request, cancellationToken);

            await ScrubSensitiveData(pagedUsers.Data);

            return pagedUsers;
        }

        public async Task<UserDto> Login(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(email, cancellationToken);

            if(user == null)
            {
                throw new EntityNotFoundException($"Invalid email or password, please try again.");
            }

            var hashedPassword = CryptoUtilities.HashPassword(Encoding.UTF8.GetBytes(password), user.Salt);

            if(!await CompareHashes(user.Password, hashedPassword))
            {
                throw new EntityNotFoundException($"Invalid email or password, please try again.");
            }

            await ScrubSensitiveData(new List<UserDto>() { user });

            return user;
        }

        public async Task<bool> ResetPassword(int userId, string newPassword, CancellationToken cancellationToken)
        {
            var salt = CryptoUtilities.CreateSalt();
            var hashedPassword = CryptoUtilities.HashPassword(Encoding.UTF8.GetBytes(newPassword), salt);

            return await _userRepository.ResetPassword(new UserDto()
            {
                Id = userId,
                Password = hashedPassword,
                Salt = salt
            }, cancellationToken);
        }

        #region private methods

        private async Task ValidateCreateUserRequest(CreateUserRequest request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.EmailAddress))
            {
                throw new InvalidEntityException($"Please provide an email address.");
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                throw new InvalidEntityException($"Please provide a password.");
            }

            if (request.UserRoleId == 0)
            {
                throw new InvalidEntityException($"Please provide a user role.");
            }

            if (!Enum.IsDefined(typeof(UserRoleEnum), request.UserRoleId))
            {
                throw new InvalidEntityException($"Invalid user role selected.");
            }

            var existingUser = await _userRepository.GetUserByEmail(request.EmailAddress, cancellationToken);

            if(existingUser != null)
            {
                throw new InvalidEntityException($"User already exists.");
            }
        }

        private Task ScrubSensitiveData(IEnumerable<UserDto> users)
        {
            foreach(var user in users)
            {
                user.Salt = new byte[0];
                user.Password = new byte[0];
            }

            return Task.CompletedTask;
        }

        private Task<bool> CompareHashes(byte[] firstHash, byte[] secondHash)
        {
            if (firstHash.Length != secondHash.Length)
            {
                return Task.FromResult(false);
            }

            var i = 0;

            while ((i < firstHash.Length) && (firstHash[i] == secondHash[i]))
            {
                i += 1;
            }

            if (i == firstHash.Length)
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        #endregion
    }
}
