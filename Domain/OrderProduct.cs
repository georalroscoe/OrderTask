using System;
using System.Collections.Generic;

namespace Domain;

public class OrderProduct
{

    public OrderProduct(int productId, int quantity) {
        ProductId = productId;
        Quantity = quantity;
    
    }
    public int OrderProductId { get; private set; }

    public int ProductId { get; private set; }

    public int OrderId { get; private set; }

    public int Quantity { get; private set; }

    public virtual Order Order { get; private set; }

    public virtual Product Product { get; private set; } 
}
