using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;
namespace WebApplication1.Configs
{
    public class MemberShipConfig : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
            builder.Property(t => t.StartDate)
                        .HasDefaultValueSql("GETDATE()");
        }
    }
}
