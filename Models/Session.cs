namespace WebApplication1.Models
{
    public class Session
    {
        public int ID { get; set; }
        public string Description { get; set; } = null!;
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TrainerID { get; set; }
        public Trainer Trainer { get; set; } = null!;
    }
}
