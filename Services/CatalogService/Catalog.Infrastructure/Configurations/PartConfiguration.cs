using Catalog.Domain.Models;
using Catalog.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Configurations
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.ToTable("Parts");

            builder.HasKey(q => q.Id);

            builder.Property(q => q.PartName).HasMaxLength(50).HasColumnType(typeof(string).ConvertToDbType());

            builder.HasMany(q => q.FilmParts).WithOne(q => q.Part).HasForeignKey(q => q.PartId);
        }
    }
}
