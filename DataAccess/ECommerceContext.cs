using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using DataAccess.Mapping;
using static System.Formats.Asn1.AsnWriter;
using Domain;


namespace DataAccess;

public partial class ECommerceContext : DbContext
{
    public ECommerceContext()
    {
    }

    public ECommerceContext(DbContextOptions<ECommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerMap());
        modelBuilder.ApplyConfiguration(new OrderMap());
        modelBuilder.ApplyConfiguration(new OrderProductMap());
        modelBuilder.ApplyConfiguration(new ProductMap());

    }
    
}
