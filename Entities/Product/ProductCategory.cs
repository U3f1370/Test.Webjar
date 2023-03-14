using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class ProductCategory:BaseEntity, IEntityApp
    {
        public string Title { get; private set; }
        public ICollection<Product> Products { get; private set; }
        public ICollection<ProductAdditive> ProductAdditives { get; private set; }

        public ProductCategory(string title)
        {
            Title = title;
        }
    }
    internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable(nameof(ProductCategory), nameof(SchemaEnum.product));
            builder.Property(p => p.Title).HasMaxLength(150).IsRequired();
            builder.HasMany(p=> p.Products).WithOne(p=>p.ProductCategory).HasForeignKey(p=>p.ProductCategoryId);
            builder.HasMany(p => p.ProductAdditives).WithOne(p => p.ProductCategory).HasForeignKey(p=>p.ProductCategoryId);
        }
    }
}
