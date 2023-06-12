using EXAM.DAL.Constants;
using EXAM.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXAM.DAL.EntityTypeConfigurations
{
    public class CountyrEntiytTypeConfiguration: IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Country");

            entityTypeBuilder.HasKey(k => k.Id).HasName("PK_Country");

            entityTypeBuilder.Property(p => p.Id).HasColumnType(StringConstants.Int).UseMySqlIdentityColumn();
            entityTypeBuilder.Property(p => p.Name).HasColumnType(StringConstants.Varchar20).IsRequired();

            entityTypeBuilder.HasMany(k => k.Movies).WithOne(p => p.Country).HasForeignKey(p => p.CountryId).IsRequired();
        }
    }
}
