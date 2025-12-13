namespace Backend.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public int CompanyId { get; set; }
        public required User User { get; set; }
        public required Company Company { get; set; }
        public required string JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public required string Status { get; set; }
        public int? Salary {  get; set; }
    }
}
