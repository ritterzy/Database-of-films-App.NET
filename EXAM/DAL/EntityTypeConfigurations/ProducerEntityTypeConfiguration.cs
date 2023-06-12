using EXAM.DAL.Constants;
using EXAM.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXAM.DAL.EntityTypeConfigurations
{
    public class ProducerEntityTypeConfiguration: IEntityTypeConfiguration<Producer> 
    {
        public void Configure(EntityTypeBuilder<Producer> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Producer");

            entityTypeBuilder.HasKey(k => k.Id).HasName("PK_Producer");

            entityTypeBuilder.Property(p => p.Id).HasColumnType(StringConstants.Int).UseMySqlIdentityColumn();
            entityTypeBuilder.Property(p => p.Name).HasColumnType(StringConstants.Varchar20).IsRequired();
            entityTypeBuilder.Property(p => p.DateOfBirth).HasColumnType(StringConstants.DateTime).IsRequired();
            entityTypeBuilder.Property(p => p.CountryOfBirth).HasColumnType(StringConstants.Varchar20).IsRequired();
            entityTypeBuilder.Property(p => p.About).HasColumnType(StringConstants.Varchar20).IsRequired();

            entityTypeBuilder.HasMany(p => p.Movies).WithMany(k => k.Producers);
        }
    }
}
