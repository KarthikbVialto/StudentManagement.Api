namespace StudentManagement.Models.Dto
{
    public class UpdateStudentRequestDto
    {
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string? Email { get; set; }

        public DepartmentDto Department { get; set; }
        public AddressDto Address { get; set; }
    }
}
