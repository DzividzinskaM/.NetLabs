using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class OrderSellDTO : OrderBaseDTO
    {
        public string Customer { get; set; }
        public int? OrderBuyId { get; set; }
    }
}
