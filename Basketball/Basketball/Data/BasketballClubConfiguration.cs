using Basketball.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basketball.Data
{
    public class BasketballClubConfiguration : IEntityTypeConfiguration<BasketballClub>
    {
        public void Configure(EntityTypeBuilder<BasketballClub> builder)
        {
            builder.ToTable("BasketballClubs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName(nameof(BasketballClub.Id));
            builder.Property(x => x.Name)
                   .HasColumnName(nameof(BasketballClub.Name))
                   .IsRequired()
                   .HasMaxLength(32)
                   .HasColumnType("varchar(32)");
            builder.HasOne(x => x.City)
                   .WithMany(x => x.BasketballClubs)
                   .HasForeignKey(x => x.CityId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
