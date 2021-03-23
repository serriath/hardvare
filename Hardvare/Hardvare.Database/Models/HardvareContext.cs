using Microsoft.EntityFrameworkCore;
using System;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedLookupData(modelBuilder);
        }

        private void SeedLookupData(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserRole>()
                .HasData(
                    new UserRole { Id = 1, RoleName = "Admin" },
                    new UserRole { Id = 2, RoleName = "Customer" });
        }
    }
}
