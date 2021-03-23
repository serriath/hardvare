using Hardvare.Common.DataTransferObjects;
using Hardvare.Database.Interfaces;
using Hardvare.Services.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Hardvare.Common.Requests;
using Hardvare.Common.Exceptions;
using System.Text;
using Hardvare.Services.Utilities;
using Hardvare.Common.Enums;

namespace Hardvare.Services.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserById(int UserId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(UserId, cancellationToken);

            if (user == null)
            {
                throw new EntityNotFoundException($"Unable to find user with id {UserId}");
            }

            return user;
        }

        public async Task<int> CreateUser(CreateUserRequest Request, CancellationToken cancellationToken)
        {
            await ValidateCreateUserRequest(Request, cancellationToken);

            var salt = CryptoUtilities.CreateSalt();
            var hashedPassword = CryptoUtilities.HashPassword(Encoding.UTF8.GetBytes(Request.Password), salt);

            return await _userRepository.CreateUser(new UserDto
            {
                EmailAddress = Request.EmailAddress,
                FirstName = Request.FirstName,
                LastName = Request.LastName,
                IsActive = true,
                Password = hashedPassword,
                Salt = salt,
                UserRole = (UserRoleEnum)Request.UserRoleId
            }, cancellationToken);
        }

        public async Task<bool> UpdateUser(UpdateUserRequest Request, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateUser(new UserDto
            {
                Id = Request.UserId,
                FirstName = Request.FirstName,
                LastName = Request.LastName,
                UserRole = (UserRoleEnum)Request.UserRoleId
            }, cancellationToken);
        }

        public async Task<bool> DeactivateUser(int UserId, CancellationToken cancellationToken)
        {
            return await _userRepository.DeactivateUser(UserId, cancellationToken);
        }

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

            var existingUser = await _userRepository.GetUserByEmail(request.EmailAddress, cancellationToken);

            if(existingUser != null)
            {
                throw new InvalidEntityException($"User already exists.");
            }

            //email validation regex
        }
    }
}
