using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class ProductPriceHistoryToOptionValues
    {
        public int ProductPriceOptionValueId { get; private set; }
        public ProductPriceOptionValue ProductPriceOptionValue { get; private set; }
        public int ProductPriceHistoryId { get; private set; }
        public ProductPriceHistory ProductPriceHistory { get; private set; }
    }
    internal class ProductPriceHistoryToOptionValuesConfiguration : IEntityTypeConfiguration<ProductPriceHistoryToOptionValues>
    {
        public void Configure(EntityTypeBuilder<ProductPriceHistoryToOptionValues> builder)
        {
            builder.ToTable(nameof(ProductPriceHistoryToOptionValues), nameof(SchemaEnum.product));
            builder.HasKey(p => new { p.ProductPriceOptionValueId, p.ProductPriceHistoryId });
        }
    }
}
