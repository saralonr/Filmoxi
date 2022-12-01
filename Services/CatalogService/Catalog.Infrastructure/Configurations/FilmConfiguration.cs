using Catalog.Domain.Models;
using Catalog.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Films");

            builder.HasKey(q => q.Id);

            builder.Property(q => q.FilmName).HasMaxLength(500).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.FilmYear).HasMaxLength(50).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.FilmDirector).HasMaxLength(500).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.FilmIMBDScore).HasMaxLength(50).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.FilmType).HasMaxLength(50).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.FilmTime).HasMaxLength(50).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.FilmLanguage).HasMaxLength(50).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.FilmCategory).HasMaxLength(50).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.FilmTags).HasMaxLength(500).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.FilmSummary).HasMaxLength(1500).HasColumnType(typeof(string).ConvertToDbType());

            builder.HasMany(q => q.FilmParts).WithOne(q => q.Film).HasForeignKey(q => q.FilmId);
        }
    }
}
