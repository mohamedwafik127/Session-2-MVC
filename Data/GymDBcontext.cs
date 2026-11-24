using Microsoft.EntityFrameworkCore;
using WebApplication1.Configs;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class GymDBcontext : DbContext
    {
        public DbSet<Member> Members { get; set; } = null!;
        public DbSet<Plan> Plans { get; set; } = null!;
        public DbSet<Session> Sessions { get; set; } = null!;
        public DbSet<Trainer> Trainers { get; set; } = null!;
        public DbSet<MemberShip> MemberShips { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MemberShipConfig());
            modelBuilder.ApplyConfiguration(new MemberConfig());
            modelBuilder.ApplyConfiguration(new PlanConfig());
            modelBuilder.ApplyConfiguration(new SessionConfig());
            modelBuilder.ApplyConfiguration(new TrainerConfig());
        }
    }
}