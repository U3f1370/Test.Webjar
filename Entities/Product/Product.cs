using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Product
{
    public class Product: BaseEntity, IEntityApp
    {
        public string Title { get;private set; }
        public int ProductCategoryId { get; private set; }
        public ProductCategory ProductCategory { get; private set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<ProductPriceHistory> ProductPriceHistories { get; private set; }
        public ICollection<ProductToProductAdditive> ProductToProductAdditive { get; private set; }

        public Product(string title, int productCategoryId)
        {
            Title = title;
            ProductCategoryId = productCategoryId;
        }

    }
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product), nameof(SchemaEnum.product));
            builder.Property(p => p.Title).HasMaxLength(150).IsRequired();
            builder.HasMany(p => p.Images).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
            builder.HasMany(p => p.ProductPriceHistories).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
            builder.HasMany(p => p.ProductToProductAdditive).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
        }
    }
}
