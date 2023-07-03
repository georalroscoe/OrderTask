using System;
using System.Collections.Generic;

namespace Domain;

public class Customer
{
    public Customer(string name, string city) {
        Name = name;
        City = city;
    
    }
    public int CustomerId { get; private set; }

    public string Name { get; private set; } 

    public string City { get; private set; } 

    public virtual ICollection<Order> Orders { get; private set; } = new List<Order>();

    public Order ProcessOrder(OrderContainer orderContainer)
    {
        orderContainer.Validate();
        if (!orderContainer.IsValid)
        {
            //not valid, return
            return null;
        }
        Order newOrder = new Order();
        newOrder.FillOrder(orderContainer.OrderProducts, orderContainer.Products);
        Orders.Add(newOrder);
        return newOrder;


    }
}
