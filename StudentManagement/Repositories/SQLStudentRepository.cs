using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using StudentManagement.Data;
using StudentManagement.Models.Domain;

namespace StudentManagement.Repositories
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly StudentManagementDbContext dbContext;

        public SQLStudentRepository(StudentManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> DeleteAsync(int id)
        {
            var existingStudent = await dbContext.Students.Include(a=>a.Address).Include(d=>d.Department).FirstOrDefaultAsync(s => s.Id == id);
            if(existingStudent == null)
            {
                return null;
            }
            dbContext.Students.Remove(existingStudent);
            await dbContext.SaveChangesAsync();
            return existingStudent;
        }

        public async Task<List<Student>> GetAllAsync()
        { 
            return await dbContext.Students.Include(a=>a.Address).Include(d=>d.Department).ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await dbContext.Students.Include(a=>a.Address).Include(d=>d.Department).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student?> UpdateAsync(int id, Student student)
        {
            var existingStudent = await dbContext.Students.Include(a=>a.Address).Include(d=>d.Department).FirstOrDefaultAsync(s => s.Id == id);
            if (existingStudent == null)
            {
                return null;
            }
            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.RollNo = student.RollNo;
            existingStudent.Address.Country = student.Address.Country;
            existingStudent.Address.State= student.Address.State;
            existingStudent.Address.City = student.Address.City;
            existingStudent.Address.Zip = student.Address.Zip;
            existingStudent.Department.Name = student.Department.Name;
            existingStudent.Department.Specialisation = student.Department.Specialisation;
            await dbContext.SaveChangesAsync();
            return existingStudent;
        }
    }
}
