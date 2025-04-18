namespace StudentManagement.Models.Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Specialisation { get; set; }
        
        //Navigation Properties
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
