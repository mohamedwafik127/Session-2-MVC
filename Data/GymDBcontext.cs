using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Server=.;Database=GYM Management System;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}