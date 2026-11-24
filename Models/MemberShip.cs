namespace WebApplication1.Models
{
    public class MemberShip
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MemberID { get; set; }
        public Member Member { get; set; } = null!;
        public int PlanID { get; set; }
        public Plan Plan { get; set; } = null!;
    }
}
