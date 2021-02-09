using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{

    public class StoreService : IStoreService
    {
        IUnitOfWork db { get; set; }

        public StoreService(IUnitOfWork uow)
        {
            db = uow;
        }

        public void MakeOrderSell(OrderSellDTO orderSell)
        {
            var product = db.Products.Get(orderSell.ProductId);

            int availableNumber = product.Number;

            decimal orderSum = orderSell.Number * product.Cost;
            bool isClosed = false;

            OrderSell order = new OrderSell
            {
                //   OrderId = orderSell.OrderId,
                Date = DateTime.Now,
                Customer = orderSell.Customer,
                Sum = orderSum,
                ProductId = orderSell.ProductId,
                Number = orderSell.Number
            };


            if (availableNumber >= orderSell.Number)
            {
                isClosed = true;
                product.Number = product.Number - orderSell.Number;
                db.Products.Update(product);
            }
            else
            {

                OrderBuy currentOrderBuy = new OrderBuy
                {
                    Date = DateTime.Now,
                    Sum = orderSum,
                    ProductId = orderSell.ProductId,
                    Number = orderSell.Number,
                    isClosed = false
                };

                db.OrdersBuy.Create(currentOrderBuy);

                order.OrderBuy = currentOrderBuy;
            }

            order.isClosed = isClosed;
            
            
            db.OrdersSell.Create(order);

            db.Save();

        }

        public void MakeOrderBuy(OrderBuyDTO orderBuy)
        {
            var product = db.Products.Get(orderBuy.ProductId);
            //var orderBuyLast = db.OrdersBuy.GetAll().OrderBy(o => o.Id)
                   // .Last();
            decimal orderSum = product.Cost * orderBuy.Number;

            OrderBuy currentOrderBuy = new OrderBuy
            {
                Date = DateTime.Now,
                Sum = orderSum,
                ProductId = orderBuy.ProductId,
                Number = orderBuy.Number,
                isClosed = false
            };

            db.OrdersBuy.Create(currentOrderBuy);
            db.Save();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(db.Products.GetAll());
        }

        public IEnumerable<OrderSellDTO> GetOrderSells()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderSell, OrderSellDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<OrderSell>, List<OrderSellDTO>>(db.OrdersSell.GetAll());
        }

        public IEnumerable<OrderBuyDTO> GetOrderBuys()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderBuy, OrderBuyDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<OrderBuy>, List<OrderBuyDTO>>(db.OrdersBuy.GetAll());
        }

       /* public void CloseOrderSell(int id)
        {
            var order = db.OrdersSell.Get(id);

            order.isClosed = true;
            db.OrdersSell.Update(order);
            db.Save();
        }*/

        public void CloseOrderBuy(int id, string supplier)
        {
            var order = db.OrdersBuy.Get(id);
            if (order == null)
                return;

           
            order.SupplierName = supplier;

            order.isClosed = true;

            if (order.OrderSell != null)
            {
                order.OrderSell.isClosed = true;
            }  
            else
            {
                var product = db.Products.Get(order.ProductId);
                if (product == null)
                    return;
                else
                {
                    product.Number += order.Number;
                    /*var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
                    var updatedProduct = mapper.Map<ProductDTO, Product>(product);*/
                    db.Products.Update(product);
                }
            }

            db.OrdersBuy.Update(order);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

      /*  public IEnumerable<ProductDTO> GetAvailableProducts()
        {
            var products = db.Products.Find(p => p.Number > 0);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(products);
        }
*/
      /*  public IEnumerable<OrderSellDTO> GetOpenOrderSells()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderBuyDTO> GetOpenOrderBuys()
        {
            throw new NotImplementedException();
        }
*/
        public OrderSellDTO GetOrderSell(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderSell, OrderSellDTO>()).CreateMapper();
            return mapper.Map<OrderSell, OrderSellDTO>(db.OrdersSell.Get(id));

        }

        public OrderBuyDTO GetOrderBuy(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderBuy, OrderBuyDTO>()).CreateMapper();
            return mapper.Map<OrderBuy, OrderBuyDTO>(db.OrdersBuy.Get(id));

        }

        public ProductDTO GetProduct(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<Product, ProductDTO>(db.Products.Get(id));
        }

        public void CreateProduct(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()).CreateMapper();
            var product = mapper.Map<ProductDTO, Product>(productDTO);

            db.Products.Create(product);
            db.Save();
        }
    }
}
