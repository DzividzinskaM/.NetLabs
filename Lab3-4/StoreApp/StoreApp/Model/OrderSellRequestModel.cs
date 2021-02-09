using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class OrderSellRequestModel
    {
        public string Customer { get; set; }


        public int ProductId { get; set; }

        public int Number { get; set; }
    }
}
