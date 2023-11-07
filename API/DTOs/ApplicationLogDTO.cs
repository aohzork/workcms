using API.Models;

namespace API.DTOs
{
    public class ApplicationLogDTO
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }
    }
}
