namespace DAL.Entities
{
    public class OrderBuy : OrderBase
    {
        public string SupplierName { get; set; }
        public OrderSell? OrderSell { get; set; }
    }
}