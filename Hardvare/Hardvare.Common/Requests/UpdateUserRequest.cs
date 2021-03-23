namespace Hardvare.Common.Requests
{
    public class UpdateUserRequest
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int UserRoleId { get; set; }
    }
}
