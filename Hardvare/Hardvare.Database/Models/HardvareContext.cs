using Microsoft.EntityFrameworkCore;

namespace Hardvare.Database.Models
{
    public partial class HardvareContext : DbContext
    {
        public HardvareContext(DbContextOptions<HardvareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
