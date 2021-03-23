using System.ComponentModel.DataAnnotations;

namespace Hardvare.Database.Models
{
    public partial class User
    {
        public int Id { get; set; }

        public int UserRoleId { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public byte[] Password { get; set; }

        public byte[] Salt { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
