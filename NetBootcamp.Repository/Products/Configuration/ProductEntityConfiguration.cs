using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetBootcamp.Repository.Products.Configuration
{
    public  class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Name).IsRequired().HasMaxLength(100);
            builder.Property(product => product.Stock).IsRequired().HasMaxLength(100);
            builder.Property(product => product.Price).IsRequired().HasPrecision(18, 2);
            builder.Property(product => product.Created).IsRequired();
            builder.Property(product => product.Barcode).IsRequired().HasMaxLength(100);
        }
    }
}
