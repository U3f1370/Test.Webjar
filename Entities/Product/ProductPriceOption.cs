using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entities.Product
{
    public class ProductPriceOption:BaseEntity,IEntityApp
    {
        public int ProductCategoryId { get;private set; }
        public ProductCategory ProductCategory { get; private set; }
        public string Name { get; private set; }
        public ICollection<ProductPriceOptionValue> OptionValues { get; private set; }

        public ProductPriceOption(int productCategoryId, string name)
        {
            ProductCategoryId = productCategoryId;
            Name = name;
        }
    }
    internal class ProductPriceOptionConfiguration : IEntityTypeConfiguration<ProductPriceOption>
    {
        public void Configure(EntityTypeBuilder<ProductPriceOption> builder)
        {
            builder.ToTable(nameof(ProductPriceOption), nameof(SchemaEnum.product));
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.HasMany(p => p.OptionValues).WithOne(p => p.ProductPriceOption).HasForeignKey(p => p.ProductPriceOptionId);
        }
    }
}
