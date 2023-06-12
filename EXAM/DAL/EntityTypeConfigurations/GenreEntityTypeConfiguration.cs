using EXAM.DAL.Constants;
using EXAM.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EXAM.DAL.EntityTypeConfigurations
{
    public class GenreEntityTypeConfiguration: IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Genre");

            entityTypeBuilder.HasKey(k => k.Id).HasName("PK_Genre");

            entityTypeBuilder.Property(p => p.Id).HasColumnType(StringConstants.Int).UseMySqlIdentityColumn();
            entityTypeBuilder.Property(p => p.Name).HasColumnType(StringConstants.Varchar20).IsRequired();

            entityTypeBuilder.HasMany(p => p.Movies).WithMany(k => k.Genres);
        }
    }
}
