using Hardvare.Common.Enums;

namespace Hardvare.Common.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public UserRoleEnum UserRole { get; set; }
    }
}
