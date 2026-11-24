namespace WebApplication1.Models
{
    public class Trainer : User
    {
        public int ID { get; set; }
        public DateTime HireDate { get; set; }
        public string Specialty { get; set; } = null!;
        public ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
    }
}
