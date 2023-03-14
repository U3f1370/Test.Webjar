using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entities.Product
{
    public class ProductAdditive:BaseEntity,IEntityApp
    {
        public string Title { get;private set; }
        public decimal Price { get;private set; } 
        public int ProductCategoryId { get; private set; }
        public ProductCategory ProductCategory { get;private set; }
        public ICollection<ProductToProductAdditive> ProductToProductAdditive { get; private set;}

        public ProductAdditive(string title, decimal price, int productCategoryId)
        {
            Title = title;
            Price = price;
            ProductCategoryId = productCategoryId;
        }
    }
    internal class ProductAdditiveConfiguration : IEntityTypeConfiguration<ProductAdditive>
    {
        public void Configure(EntityTypeBuilder<ProductAdditive> builder)
        {
            builder.ToTable(nameof(ProductAdditive), nameof(SchemaEnum.product));
            builder.Property(p => p.Title).HasMaxLength(150).IsRequired();
            builder.Property(p=>p.Price).IsRequired();
            builder.HasMany(p => p.ProductToProductAdditive).WithOne(p => p.ProductAdditive).HasForeignKey(p => p.ProductAdditiveId);
        }
    }
}
