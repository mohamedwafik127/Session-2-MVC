namespace WebApplication1.Models
{
    public class Plan
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
        public int DurationInDays { get; set; }
        public string Description { get; set; } = null!;
        public ICollection<MemberShip> MemberShips { get; set; } = new HashSet<MemberShip>();
    }
}
