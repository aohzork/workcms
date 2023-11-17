namespace API.DTOs
{
    public class JobApplicationUpdateRequestDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Company {  get; set; }
        public string Notes { get; set; }
        public string ApplicationURL { get; set; }
    }
}
