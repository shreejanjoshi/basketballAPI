using Basketball.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Basketball.Data
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName(nameof(Country.Id));
            builder.Property(x => x.Name)
                   .HasColumnName(nameof(Country.Name))
                   .IsRequired()
                   .HasMaxLength(32)
                   .HasColumnType("varchar(32)");
        }
    }
}
