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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder, string schema)
        {

            builder.ToTable("Customer");
            builder.Property(e => e.CustomerId)
                
            .UseIdentityColumn();
            builder.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            
        }
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
