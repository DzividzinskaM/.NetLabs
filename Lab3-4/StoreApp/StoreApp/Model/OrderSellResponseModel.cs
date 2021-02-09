using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class OrderSellResponseModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        public int ProductId { get; set; }
        public int Number { get; set; }
        public bool isClosed { get; set; }
        public string Customer { get; set; }
        public int? OrderBuyId { get; set; }
    }
}
