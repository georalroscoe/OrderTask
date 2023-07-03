using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccess.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder, string schema)
        {


            builder.ToTable("Product");

            builder.Property(e => e.ProductId).UseIdentityColumn();
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
