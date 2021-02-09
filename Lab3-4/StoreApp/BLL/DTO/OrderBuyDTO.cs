using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class OrderBuyDTO : OrderBaseDTO
    {
        public string SupplierName { get; set; }
        public int? OrderSellId { get; set; }
    }
}
