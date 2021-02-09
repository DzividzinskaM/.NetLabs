using System;
using System.Collections.Generic;
using System.Text;

namespace StoreAppConsoleClient.Model
{
    public class OrderSell : OrderBase
    {
        public string Customer { get; set; }

        public int? OrderBuyId { get; set; }
    }
}
