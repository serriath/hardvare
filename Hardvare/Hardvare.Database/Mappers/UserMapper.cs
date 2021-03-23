using Hardvare.Common.DataTransferObjects;
using Hardvare.Common.Enums;
using Hardvare.Database.Interfaces;
using Hardvare.Database.Models;

namespace Hardvare.Database.Mappers
{
    public class UserMapper : IMapper<UserDto, User>
    {
        public UserDto Map(User value)
        {
            return new UserDto()
            {
                EmailAddress = value.Email,
                FirstName = value.FirstName,
                LastName = value.LastName,
                Id = value.Id,
                IsActive = value.IsActive,
                Password = value.Password,
                UserRole = (UserRoleEnum)value.UserRoleId,
                Salt = value.Salt
            };
        }

        public User Map(UserDto value)
        {
            return new User()
            {
                Id = value.Id,
                Email = value.EmailAddress,
                FirstName = value.FirstName,
                LastName = value.LastName,
                IsActive = value.IsActive,
                Password = value.Password,
                UserRoleId = (int)value.UserRole,
                Salt = value.Salt
            };
        }
    }
}