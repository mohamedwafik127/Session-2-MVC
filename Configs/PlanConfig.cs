using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;
namespace WebApplication1.Configs
{
    public class PlanConfig : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(a => a.Name)
                    .HasMaxLength(50);

            builder.Property(a => a.Description)
                    .HasMaxLength(500);

            builder.Property(a => a.Price)
                    .HasPrecision(10, 2);

            builder.ToTable("Plans",
                a => a.HasCheckConstraint("DurationInDays",
                        "[DurationInDays] BETWEEN 1 AND 365"));

            builder.HasMany(m => m.MemberShips)
                   .WithOne(ms => ms.Plan)
                   .HasForeignKey(ms => ms.PlanID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
