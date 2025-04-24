using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Data
{
    public class StudentManagementAuthDbContext:IdentityDbContext
    {
        public StudentManagementAuthDbContext(DbContextOptions<StudentManagementAuthDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerId = "9bab7272-9f4e-4af6-b68c-64bf72a354fa";

            var writerId = "2e81b633-f3ec-4812-a4ec-dd97e98c3dc1";

            var roles = new List<IdentityRole> {
                new IdentityRole{
                    Id = readerId,
                    ConcurrencyStamp = readerId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerId,
                    ConcurrencyStamp = writerId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
