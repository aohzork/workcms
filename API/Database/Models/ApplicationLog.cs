using Microsoft.Identity.Client;

namespace API.Database.Models
{
    public class ApplicationLog
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public JobApplication JobApplication { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }
    }
}
