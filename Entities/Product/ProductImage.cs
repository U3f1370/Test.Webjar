using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class ProductImage : BaseEntity, IEntityApp
    {
        public string Path { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public ProductImage(string path)
        {
            Path = path;
        }
    }

    internal class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable(nameof(ProductImage), nameof(SchemaEnum.product));
        }
    }
}
