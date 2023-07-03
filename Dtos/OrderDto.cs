using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class OrderDto
    {
        public string CustomerName { get; set; }
        public string CustomerCity { get; set; }

        public List<OrderProductDto>? Products { get; set; }
    }
}
