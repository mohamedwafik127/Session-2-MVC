using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;
namespace WebApplication1.Configs
{
    public class SessionConfig : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions", a =>
            {
                a.HasCheckConstraint("Capacity",
                       "[Capacity] BETWEEN 1 AND 25");

                a.HasCheckConstraint("EndDate",
                       "[EndDate] > [StartDate]");
            }
            );

            builder.Property(a => a.Description)
                    .HasMaxLength(500);


        }
    }
}
