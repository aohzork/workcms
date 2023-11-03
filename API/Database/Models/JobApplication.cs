namespace API.Database.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Company {  get; set; }
        public string Notes { get; set; }
        public string ApplicationURL { get; set; }
        public bool isActive { get; set; }
        public List<ApplicationLog> ApplicationLogs { get; set; }
    }
}
