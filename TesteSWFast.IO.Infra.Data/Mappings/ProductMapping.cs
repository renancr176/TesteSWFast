using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteSWFast.IO.Domain.Products;
using TesteSWFast.IO.Infra.Data.Extensions;

namespace TesteSWFast.IO.Infra.Data.Mappings
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public override void Map(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.IdCategory)
                .HasColumnName("IdCategoria")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(c => c.Preco)
                .HasColumnType("MONEY")
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.IdCategory)
                .IsRequired();

            builder.Ignore(c => c.ValidationResult);

            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Produtos");
        }
    }
}
