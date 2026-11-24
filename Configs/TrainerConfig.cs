using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configs
{
  public class TrainerConfig : IEntityTypeConfiguration<Trainer>
        {
            public void Configure(EntityTypeBuilder<Trainer> builder)
            {
                builder.Property(t => t.Name)
                       .HasMaxLength(50);

                builder.Property(t => t.Email)
                       .IsUnicode(false)
                       .HasMaxLength(100);

                builder.Property(t => t.Phone)
                       .IsUnicode(false)
                       .HasMaxLength(11);

                builder.Property(t => t.Specialty)
                       .IsRequired()
                       .HasMaxLength(50);

                builder.Property(t => t.HireDate)
                       .HasDefaultValueSql("GETDATE()");

                builder.HasIndex(t => t.Email)
                       .IsUnique();

                builder.HasIndex(t => t.Phone)
                       .IsUnique();

                builder.ToTable("Trainers", t =>
                {
                    t.HasCheckConstraint("CK_Trainer_Email",
                        "[Email] LIKE '%_@_%._%'");

                    t.HasCheckConstraint("CK_Trainer_Phone",
                        "[Phone] LIKE '01[0125][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");
                });

                builder.OwnsOne(t => t.Address, a =>
                {
                    a.Property(x => x.Street).HasMaxLength(100);
                    a.Property(x => x.City).HasMaxLength(50);
                });

                builder.HasMany(t => t.Sessions)
                       .WithOne(s => s.Trainer)
                       .HasForeignKey(s => s.TrainerID)
                       .OnDelete(DeleteBehavior.Restrict);
            }
        }
}
