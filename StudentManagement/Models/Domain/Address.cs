namespace StudentManagement.Models.Domain
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }

        //Navigation Properites
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
