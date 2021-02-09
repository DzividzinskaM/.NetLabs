using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace StoreAppConsoleClient
{
    public class ProductService
    {
        public IEnumerable<Product> GetAllProducts()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(@"https://localhost:44367/api/products").Result;
                var result = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                return result;
            }

        }

        public Product getProduct(int id)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(@$"https://localhost:44367/api/products/{id}").Result;
                var product = response.Content.ReadAsAsync<Product>().Result;
                return product;

            }
        }


        public string addNewProduct(Product product)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(@"https://localhost:44367/api/products", product).Result;
                var statusCode = response.StatusCode.ToString();
                return statusCode.ToString();
            }
        }
    }
}
