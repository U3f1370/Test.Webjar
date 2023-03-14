using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class ProductToProductAdditive
    {
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int ProductAdditiveId { get; private set; }
        public ProductAdditive ProductAdditive { get; set; }
    }
    internal class ProductToProductAdditiveConfiguration : IEntityTypeConfiguration<ProductToProductAdditive>
    {
        public void Configure(EntityTypeBuilder<ProductToProductAdditive> builder)
        {
            builder.ToTable(nameof(ProductToProductAdditive), nameof(SchemaEnum.product));
            builder.HasKey(x => new { x.ProductId,x.ProductAdditiveId});
        }
    }
}
