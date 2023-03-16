using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class ProductPriceOptionValue : BaseEntity,IEntityApp
    {
        public string Value { get; private set; }
        public int ProductPriceOptionId { get; private set; }
        public ProductPriceOption ProductPriceOption { get; private set; }
        public ICollection<ProductPriceHistory> ProductPriceHistories { get;private set; }

        public ProductPriceOptionValue(string value, int productPriceOptionId)
        {
            Value = value;
            ProductPriceOptionId = productPriceOptionId;
        }
    }
    internal class ProductPriceOptionValueConfiguration : IEntityTypeConfiguration<ProductPriceOptionValue>
    {
        public void Configure(EntityTypeBuilder<ProductPriceOptionValue> builder)
        {
            builder.ToTable(nameof(ProductPriceOptionValue), nameof(SchemaEnum.product));
            builder.Property(p => p.Value).HasMaxLength(150).IsRequired();
        }
    }
}
