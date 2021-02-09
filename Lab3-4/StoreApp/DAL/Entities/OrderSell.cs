namespace DAL.Entities
{
    public class OrderSell : OrderBase
    {
        public string Customer { get; set; }
        public int? OrderBuyId { get; set; }
        public OrderBuy? OrderBuy { get; set; }

    }
}