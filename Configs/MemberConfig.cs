using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configs
{
    public class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.Name)
                   .HasMaxLength(50);

            builder.Property(m => m.Email)
                   .IsUnicode(false)
                   .HasMaxLength(100);

            builder.Property(m => m.Phone)
                   .IsUnicode(false)
                   .HasMaxLength(11);

            builder.Property(m => m.Photo)
                   .HasMaxLength(255);

            builder.Property(m => m.JoinDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.HasIndex(m => m.Email)
                   .IsUnique();

            builder.HasIndex(m => m.Phone)
                   .IsUnique();

            builder.ToTable("Members", t =>
            {
                t.HasCheckConstraint("CK_Member_Email",
                    "[Email] LIKE '%_@_%._%'");

                t.HasCheckConstraint("CK_Member_Phone",
                    "[Phone] LIKE '01[0125][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");
            });

            builder.OwnsOne(m => m.Address, a =>
            {
                a.Property(x => x.Street).HasMaxLength(100);
                a.Property(x => x.City).HasMaxLength(50);
            });

            builder.HasMany(m => m.MemberShips)
                   .WithOne(ms => ms.Member)
                   .HasForeignKey(ms => ms.MemberID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}