using EXAM.DAL.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EXAM.DAL.Models;

namespace EXAM.DAL.EntityTypeConfigurations
{
    public class ActorEntityTypeConfiguration: IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Actor");

            entityTypeBuilder.HasKey(k => k.Id).HasName("PK_Actor");
            entityTypeBuilder.HasIndex(k => k.MovieId).IsUnique();


            entityTypeBuilder.Property(p => p.Id).HasColumnType(StringConstants.Int).UseMySqlIdentityColumn();
            entityTypeBuilder.Property(p => p.Name).HasColumnType(StringConstants.Varchar20).IsRequired();
            entityTypeBuilder.Property(p => p.DateOfBirth).HasColumnType(StringConstants.DateTime).IsRequired();
            entityTypeBuilder.Property(p => p.CountryOfBirth).HasColumnType(StringConstants.Varchar20).IsRequired();
            entityTypeBuilder.Property(p => p.About).HasColumnType(StringConstants.Varchar20).IsRequired();

            entityTypeBuilder.HasMany(k => k.Movies).WithMany(p => p.Actors);
        }
    }
}
