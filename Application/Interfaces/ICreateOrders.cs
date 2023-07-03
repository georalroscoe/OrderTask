using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace Application.Interfaces
{
    public interface ICreateOrders
    {
        public void Create(OrderDto dto);
    }
}
