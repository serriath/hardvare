using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hardvare.Database.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        [MaxLength(255)]
        public string RoleName { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
