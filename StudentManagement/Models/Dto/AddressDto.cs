using StudentManagement.Models.Domain;

namespace StudentManagement.Models.Dto
{
    public class AddressDto
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
    }
}
