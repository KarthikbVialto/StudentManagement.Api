using StudentManagement.Models.Domain;

namespace StudentManagement.Models.Dto
{
    public class AddStudentRequestDto
    {
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string? Email { get; set; }

        public DepartmentDto Department { get; set; }
        public AddressDto Address { get; set; }
    }
}
