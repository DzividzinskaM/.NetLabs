using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class OrderBase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Number { get; set; }
        public bool isClosed { get; set; }
    }
}
