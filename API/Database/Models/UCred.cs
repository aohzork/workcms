namespace API.Database.Models
{
    public class UCred
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
