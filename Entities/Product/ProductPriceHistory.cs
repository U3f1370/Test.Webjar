using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class ProductPriceHistory:BaseEntity, IEntityApp
    {
        public decimal Price { get; private set; }
        public int Inventory { get; private set; }
        public decimal? DiscountPrice { get; private set; }
        public DateTime? DiscountPriceExpireAt { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public ICollection<ProductPriceHistoryToOptionValues> ProductPriceHistoryToOptionValues { get; private set; }
    }
    internal class ProductPriceHistoryConfiguration : IEntityTypeConfiguration<ProductPriceHistory>
    {
        public void Configure(EntityTypeBuilder<ProductPriceHistory> builder)
        {
            builder.ToTable(nameof(ProductPriceHistory), nameof(SchemaEnum.product));
            builder.HasMany(p => p.ProductPriceHistoryToOptionValues).WithOne(p => p.ProductPriceHistory).HasForeignKey(p=>p.ProductPriceHistoryId);
        }
    }
}
