using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public  class OrderBaseDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        public int ProductId { get; set; }
        public int Number { get; set; }
        public bool isClosed { get; set; }
    }
}
