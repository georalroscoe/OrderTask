using System;
using System.Collections.Generic;

namespace OrderTask.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
