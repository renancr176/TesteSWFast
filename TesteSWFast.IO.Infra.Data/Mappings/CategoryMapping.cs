using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteSWFast.IO.Domain.Products;
using TesteSWFast.IO.Infra.Data.Extensions;

namespace TesteSWFast.IO.Infra.Data.Mappings
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public override void Map(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .IsRequired(false);

            builder.Ignore(c => c.ValidationResult);

            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Categorias");
        }
    }
}
