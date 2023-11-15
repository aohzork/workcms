namespace API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string LinkedInProfile { get; set; }
        public List<JobApplication> JobApplications { get; set; }
        public bool isDeleted { get; set; }
    }
}
