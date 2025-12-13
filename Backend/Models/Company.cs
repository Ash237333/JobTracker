namespace Backend.Models
{
    public class Company
    {
        public int Id { get; set; }
        public required string CompanyName { get; set; }
        public required string CompanyDescription { get; set; }
    }
}
