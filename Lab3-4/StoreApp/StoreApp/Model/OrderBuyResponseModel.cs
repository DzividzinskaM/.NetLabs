using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class OrderBuyResponseModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        public int ProductId { get; set; }
        public int Number { get; set; }
        public bool isClosed { get; set; }
        public string SupplierName { get; set; }
        public int? OrderSellId { get; set; }
    }
}
