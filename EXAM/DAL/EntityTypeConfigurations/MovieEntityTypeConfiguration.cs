using EXAM.DAL.Constants;
using EXAM.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXAM.DAL.EntityTypeConfigurations
{
    public class MovieEntityTypeConfiguration: IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Movie");

            entityTypeBuilder.HasKey(k => k.Id).HasName("PK_Movie");
            entityTypeBuilder.HasIndex(k => k.CountryId).IsUnique();
            entityTypeBuilder.HasIndex(k => k.ActorId).IsUnique();
            entityTypeBuilder.HasIndex(k => k.ProducerId).IsUnique();

            entityTypeBuilder.Property(p => p.Id).HasColumnType(StringConstants.Int).UseMySqlIdentityColumn();
            entityTypeBuilder.Property(p => p.Title).HasColumnType(StringConstants.Varchar20).IsRequired();
            entityTypeBuilder.Property(p => p.Description).HasColumnType(StringConstants.Varchar20).IsRequired();   
            entityTypeBuilder.Property(p => p.ReleaseDate).HasColumnType(StringConstants.DateTime).UseMySqlIdentityColumn();
            entityTypeBuilder.Property(p => p.Rating).HasColumnType(StringConstants.Float).IsRequired();

            entityTypeBuilder.HasMany(k => k.Actors).WithMany(p => p.Movies);
            entityTypeBuilder.HasMany(k => k.Genres).WithMany(p => p.Movies);
            entityTypeBuilder.HasOne(p => p.Country).WithMany(p => p.Movies).HasForeignKey(i => i.CountryId).IsRequired();
            entityTypeBuilder.HasMany(l => l.Producers).WithMany(p => p.Movies);
        }
    }
}
