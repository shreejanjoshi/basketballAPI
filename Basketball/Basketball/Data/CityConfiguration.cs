using Basketball.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Basketball.Data
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName(nameof(City.Id));
            builder.Property(x => x.Name)
                   .HasColumnName(nameof(City.Name))
                   .IsRequired()
                   .HasMaxLength(32)
                   .HasColumnType("varchar(32)");
            builder.HasOne(x => x.Country)
                   .WithMany(x => x.Cities)
                   .HasForeignKey(x => x.CountryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
