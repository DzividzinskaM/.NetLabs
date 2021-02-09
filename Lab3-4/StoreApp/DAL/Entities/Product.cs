using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Cost { get; set; }

        public int Number { get; set; }

        public ICollection<OrderSell> OrdersSell { get; set; }

        public ICollection<OrderBuy> OrdersBuy { get; set; }
    }
}
