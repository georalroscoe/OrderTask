using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain;

public class Order
{

    public Order()
    {
        
    }
    public int OrderId { get; private set; }

    public int CustomerId { get; private set; }

    public virtual Customer Customer { get; private set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; private set; } = new List<OrderProduct>();

    public void FillOrder(List<OrderProduct> orderProducts, List<Product> products)
    {
       foreach(OrderProduct orderProduct in orderProducts)
        {
            var product = products.Where(x => x.ProductId == orderProduct.ProductId && x.StockQuantity >= orderProduct.Quantity).FirstOrDefault();
            product.TakeProduct(orderProduct.Quantity);
            OrderProducts.Add(orderProduct);
        }
    }
}
