using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppConsoleClient.Model
{
    public class OrderBuy : OrderBase
    {
        public string SupplierName { get; set; }
        public int? OrderSellId { get;  set; }
    }
}
