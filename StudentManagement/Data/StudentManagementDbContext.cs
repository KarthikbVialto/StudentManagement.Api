using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StudentManagement.Models.Domain;

namespace StudentManagement.Data
{
    public class StudentManagementDbContext:DbContext
    {
        public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Address>()
                        .HasOne(s => s.Student)
                        .WithOne(a => a.Address)
                        .HasForeignKey<Address>(s => s.StudentId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Department>()
                        .HasOne(s => s.Student)
                        .WithOne(d => d.Department)
                        .HasForeignKey<Department>(s => s.StudentId)
                        .OnDelete(DeleteBehavior.Cascade);

            var address = new List<Address>
            {
               new Address
               {
                        Id = -1,
                        Country = "India",
                        State = "Telangana",
                        City = "Hyderabad",
                        Zip = 500072,
                        StudentId = -1

               },
               new Address
               {
                        Id = -2,
                        Country = "India",
                        State = "Telangana",
                        City = "Hyderabad",
                        Zip = 500043,
                        StudentId = -2
               },
               new Address
                    {
                        Id = -3,
                        Country = "India",
                        State = "Telangana",
                        City = "Hyderabad",
                        Zip = 500043,
                        StudentId = -3
               }

            };
            modelBuilder.Entity<Address>().HasData(address);

            var departments = new List<Department>
            {
                new Department
                {
                        Id = -1,
                        Name = "ComputerScience",
                        Specialisation = "cyberSecurity",
                        StudentId = -1
                },
                new Department
                {
                        Id = -2,
                        Name = "ComputerScience",
                        Specialisation = "cyberSecurity",
                        StudentId = -2
                },
                new Department
                {
                        Id = -3,
                        Name = "ComputerScience",
                        Specialisation = "cyberSecurity",
                        StudentId = -3
                },

            };
            modelBuilder.Entity<Department>().HasData(departments);

            var students = new List<Student>
            {
                new Student
                {
                    Id = -1,
                    Name = "Karthik Balabathula",
                    RollNo = "21r21a6273",
                    Email = "21r21a6273@mlrinstitutions.ac.in"
                },

                new Student
                {
                    Id = -2,
                    Name = "Vemula Abhiram",
                    RollNo = "21r21a62C0",
                    Email = "21r21a62C0@mlrinstitutions.ac.in"
                    
                },

                 new Student
                {
                     Id = -3,
                    Name = "Dineah Palapothula",
                    RollNo = "21r21a62A9",
                    Email = "21r21a62A9@mlrinstitutions.ac.in" 
                }

            };
            modelBuilder.Entity<Student>().HasData(students);
        }
    }
}
