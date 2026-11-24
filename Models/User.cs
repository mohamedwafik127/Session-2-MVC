namespace WebApplication1.Models
{
    public abstract class User
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; } = null!;
        public Gender Gender { get; set; }

    }
}
