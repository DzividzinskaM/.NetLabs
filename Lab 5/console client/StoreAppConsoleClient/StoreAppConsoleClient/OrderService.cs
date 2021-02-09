using StoreAppConsoleClient.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace StoreAppConsoleClient
{
    public class OrderService
    { 
        public IEnumerable<OrderBuy> GetAllOrdersBuy()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(@"https://localhost:44367/api/buy/orders").Result;
                var result = response.Content.ReadAsAsync<IEnumerable<OrderBuy>>().Result;
                return result;
            }
        }

        public IEnumerable<OrderSell> GetAllOrdersSell()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(@"https://localhost:44367/api/sell/orders").Result;
                var result = response.Content.ReadAsAsync<IEnumerable<OrderSell>>().Result;
                return result;
            }
        }

        public OrderBuy GetOrderBuy(int id)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(@$"https://localhost:44367/api/buy/orders/{id}").Result;
                var result = response.Content.ReadAsAsync<OrderBuy>().Result;
                return result;
            }
        }

        public OrderSell GetOrderSell(int id)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(@$"https://localhost:44367/api/sell/orders/{id}").Result;
                var result = response.Content.ReadAsAsync<OrderSell>().Result;
                return result;
            }
        }

        public string SellProduct(OrderSell order)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(@"https://localhost:44367/api/sell/orders", order).Result;
                var statusCode = response.StatusCode.ToString();
                return statusCode.ToString();
            }
        }

        public string BuyProduct(OrderBuy order)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(@"https://localhost:44367/api/buy/orders", order).Result;
                var statusCode = response.StatusCode.ToString();
                return statusCode.ToString();
            }
        }

        public string CloseOrderBuy(int id, Supplier supplier)
        {
            using (var client = new HttpClient())
            {
                var response = client.PutAsJsonAsync(@$"https://localhost:44367/api/buy/orders/{id}", supplier).Result;
                var statusCode = response.StatusCode.ToString();
                return statusCode.ToString();
            }
        }

        

        
    }
    
}
