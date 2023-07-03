using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderContainer
    {
        private OrderContainer()
        {
            OrderProducts = new List<OrderProduct>();
            Errors = new Dictionary<OrderProduct, string>();
        }

        public OrderContainer(List<Product> products) : this()
        {
         
            Products = products;

        }

        public bool IsValid { get; private set; }
        public List<OrderProduct> OrderProducts { get; private set; } = new List<OrderProduct>();
  
        public List<Product> Products { get; private set; } = new List<Product>();
        public Dictionary<OrderProduct, string> Errors { get; private set; } 

        public void AddOrderItem(int productId, int quantity)
        {
            OrderProduct orderProduct = new OrderProduct( productId, quantity);
            OrderProducts.Add(orderProduct);
        }

        
        
        public void Validate()
        {
            if(OrderProducts.Count == 0) {
                return;
            }
            foreach (OrderProduct orderProduct in OrderProducts)
            {
                Product? stock = Products.FirstOrDefault(x => x.ProductId == orderProduct.ProductId);

                if (stock == null)
                {

                    Errors.Add(orderProduct, $"No matching product in the stock list for {orderProduct.ProductId}");
                    continue;

                }
                if (orderProduct.Quantity < 1)
                {
                   
                   Errors.Add(orderProduct, $"The asking quantity for {orderProduct.ProductId} is 0 or negative");
                   
                }

                if (stock.StockQuantity < orderProduct.Quantity)
                {
                   Errors.Add(orderProduct, $"Quantity in the stock is too low for {orderProduct.ProductId}");
                    
                }
            }
            IsValid = Errors.Count == 0;
        }

    }
}
