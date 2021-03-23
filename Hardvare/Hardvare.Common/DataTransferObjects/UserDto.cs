using Hardvare.Common.Enums;

namespace Hardvare.Common.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; } = string.Empty;

        public byte[] Password { get; set; } = null!;

        public byte[] Salt { get; set; } = null!;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public UserRoleEnum UserRole { get; set; }

    }
}
