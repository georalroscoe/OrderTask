using System;
using Microsoft.AspNetCore.Mvc;
using Application;
using Application.Interfaces;
using Dtos;
using DataAccess.Repositories;
using DataAccess;
using Domain;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly ICreateOrders _createOrder;

        public OrdersController(ICreateOrders createOrder)
        {
            _createOrder = createOrder;
        }


        
        [HttpPost]
        public void Create([FromBody] OrderDto dto)
        {

            _createOrder.Create(dto);

        }

    }
}
