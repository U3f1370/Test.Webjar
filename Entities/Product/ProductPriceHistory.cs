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
        public ICollection<ProductPriceOptionValue> ProductPriceOptionValues { get; set; }

        public ProductPriceHistory(decimal price, int inventory, decimal? discountPrice, DateTime? discountPriceExpireAt, int productId)
        {
            Price = price;
            Inventory = inventory;
            DiscountPrice = discountPrice;
            DiscountPriceExpireAt = discountPriceExpireAt;
            ProductId = productId;
        }
    }
    internal class ProductPriceHistoryConfiguration : IEntityTypeConfiguration<ProductPriceHistory>
    {
        public void Configure(EntityTypeBuilder<ProductPriceHistory> builder)
        {
            builder.ToTable(nameof(ProductPriceHistory), nameof(SchemaEnum.product));
        }
    }
}
