using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IStoreService
    {
        public void MakeOrderSell(OrderSellDTO orderSell);

        public void MakeOrderBuy(OrderBuyDTO orderBuy);

        public IEnumerable<ProductDTO> GetProducts();

        public ProductDTO GetProduct(int id);

        public void CreateProduct(ProductDTO productDTO);


        public IEnumerable<OrderSellDTO> GetOrderSells();

        public IEnumerable<OrderBuyDTO> GetOrderBuys();

        public OrderSellDTO GetOrderSell(int id);

        public OrderBuyDTO GetOrderBuy(int id);

      //  public void CloseOrderSell(int id);

        public void CloseOrderBuy(int id, string supplier);

        void Dispose();
    }
}
