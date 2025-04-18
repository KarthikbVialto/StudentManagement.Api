using StudentManagement.Models.Domain;

namespace StudentManagement.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student student);
        Task<Student?> UpdateAsync(int id,Student student);
        Task<Student?> DeleteAsync(int id);

    }
}
