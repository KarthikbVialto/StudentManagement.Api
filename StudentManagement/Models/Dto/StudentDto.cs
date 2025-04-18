using StudentManagement.Models.Domain;

namespace StudentManagement.Models.Dto
{
    public class StudentDto
    {
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string? Email { get; set; }

        //Navigation Properties
        public DepartmentDto Department { get; set; }
        public AddressDto Address { get; set; }

    }
}
