namespace WebApplication1.Models
{
    public class Member : User
    {
        public int ID { get; set; }
        public DateTime JoinDate { get; set; }
        public string? Photo { get; set; }
        public ICollection<MemberShip> MemberShips { get; set; } = new HashSet<MemberShip>();
    }
}
