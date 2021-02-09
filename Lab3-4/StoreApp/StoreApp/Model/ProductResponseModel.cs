using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class ProductResponseModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal Cost { get; set; }

        public int Number { get; set; }
    }
}
