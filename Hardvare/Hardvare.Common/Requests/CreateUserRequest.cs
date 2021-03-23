namespace Hardvare.Common.Requests
{
    public class CreateUserRequest
    {
        public string EmailAddress { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int UserRoleId { get; set; }
    }
}
