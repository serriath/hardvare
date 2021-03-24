using Hardvare.Common.Enums;

namespace Hardvare.Common.Requests
{
    public class GetPagedUsersByFilterRequest
    {
        public UserRoleEnum UserRole { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
