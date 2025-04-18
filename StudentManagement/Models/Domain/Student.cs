namespace StudentManagement.Models.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string? Email { get; set; }
        
        //Navigation Properties
        public Department Department { get; set; }
        public Address Address { get; set; }

    }
}
