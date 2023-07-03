using System;
using System.Collections.Generic;

namespace Domain;

public class Product
{
    public Product()
    {

    }
    public int ProductId { get; private set; }

   public decimal Price { get; private set; }

    public string Name { get; private set; }

    public int StockQuantity { get; private set; }
    public virtual ICollection<OrderProduct> OrderProducts { get; private set; } = new List<OrderProduct>();

    public void TakeProduct (int quantity)
    {
        StockQuantity -= quantity;

    }
}
