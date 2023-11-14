using API.Models;

namespace API.DTOs
{
    public class JobApplicationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Company { get; set; }
        public string Notes { get; set; }
        public string ApplicationURL { get; set; }
        public bool isActive { get; set; }
        public List<ApplicationLogDTO> ApplicationLogs { get; set; }
    }
}
