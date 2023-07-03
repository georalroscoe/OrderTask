using System;
using System.Collections.Generic;

namespace OrderTask.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int Name { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
