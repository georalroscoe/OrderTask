using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;
using DataAccess.Repositories;
using Domain;
using Application.Interfaces;

namespace Application
{
    public class OrderCreator : ICreateOrders
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Customer> _customerRepo;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<OrderProduct> _orderProductRepo;



        public OrderCreator(IUnitOfWork uow, IGenericRepository<Product> productRepo, IGenericRepository<Customer> customerRepo, IGenericRepository<Order> orderRepo, IGenericRepository<OrderProduct> orderProductRepo)
        {
            _uow = uow;
            _productRepo = productRepo;
            _customerRepo = customerRepo;
            _orderRepo = orderRepo;
            _orderProductRepo = orderProductRepo;
        }
        public void Create(OrderDto dto)
        {
            var products = _productRepo.Get().ToList(); 

            OrderContainer orderContainer = new OrderContainer(products);

            Customer customer = new Customer(dto.CustomerName, dto.CustomerCity);

            foreach (OrderProductDto orderProductDto in dto.Products) 
            {
                orderContainer.AddOrderProduct(orderProductDto.ProductId, orderProductDto.Quantity);
            }

            Order newOrder = customer.ProcessOrder(orderContainer);
            if (orderContainer.IsValid) {
                _customerRepo.Insert(customer);
                _orderRepo.Insert(newOrder);
            }
            _uow.Save();

            //var orderPrice = _orderProductRepo.Get(x => x.OrderId == 10)
            //    .Select(x => new
            //    {
            //        TotalPrice = x.Product.Price * x.Quantity
            //    })
            //            .ToList().Sum(x => x.TotalPrice);


        }

    }
}
