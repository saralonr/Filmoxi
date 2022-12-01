using Catalog.Domain.Models;
using Catalog.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Configurations
{
    public class FilmPartConfiguration : IEntityTypeConfiguration<FilmPart>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<FilmPart> builder)
        {
            builder.ToTable("FilmParts");

            builder.HasKey(q => q.Id);

            builder.HasOne<Film>(q => q.Film).WithMany(q => q.FilmParts).HasForeignKey(q => q.FilmId);
            builder.HasOne<Part>(q => q.Part).WithMany(q => q.FilmParts).HasForeignKey(q => q.PartId);
        }
    }
}
