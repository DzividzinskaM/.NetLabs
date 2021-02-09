using StoreAppConsoleClient.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace StoreAppConsoleClient
{
    class Program
    {
        private const string path = @"http://localhost:44367/";
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            OrderService orderService = new OrderService();

            while (true)
            {
                Console.WriteLine("1.show products");
                Console.WriteLine("2.show sell orders");
                Console.WriteLine("3.show buy orders");
                Console.WriteLine("4.add new product");
                Console.WriteLine("5.sell product");
                Console.WriteLine("6.buy product");
                Console.WriteLine("7.close order buy");
                Console.WriteLine("8. Exit");

                int action = Int32.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        ShowProductList(productService);
                        break;
                    case 2:
                        ShowOrderSell(orderService);
                        break;
                    case 3:
                        showOrderBuy(orderService);
                        break;
                    case 4:
                        Console.WriteLine("Enter product name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter cost");
                        decimal cost = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Enter start number on store");
                        int number = Int32.Parse(Console.ReadLine());
                        Product product = new Product()
                        {
                            ProductName = name,
                            Cost = cost,
                            Number = number
                        };
                        Console.WriteLine(productService.addNewProduct(product));
                        break;
                    case 5:
                        Console.WriteLine("Enter product id");
                        int productId = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter customer name");
                        string customer = Console.ReadLine();
                        Console.WriteLine("Enter number");
                        number = Int32.Parse(Console.ReadLine());
                        OrderSell sellOrder = new OrderSell()
                        {
                            ProductId = productId,
                            Customer = customer,
                            Number = number,
                        };
                        Console.WriteLine(orderService.SellProduct(sellOrder)); 
                        break;
                    case 6:
                        Console.WriteLine("Enter product id");
                        productId = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter number");
                        number = Int32.Parse(Console.ReadLine());
                        OrderBuy orderBuy = new OrderBuy() 
                        {
                            ProductId = productId,
                            Number = number 
                        };
                        Console.WriteLine(orderService.BuyProduct(orderBuy));
                        break;
                    case 7:
                        Console.WriteLine("Enter id of buy order");
                        int id = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter supplier name");
                        string supplierName = Console.ReadLine();
                        Supplier supplier = new Supplier()
                        {
                            name = supplierName
                        };
                        Console.WriteLine(orderService.CloseOrderBuy(id, supplier));
                        break;
                    case 8:
                        return;
                    default:
                        break;
                }
                Console.WriteLine();

            }

        }

        static void showOrderBuy(OrderService orderService)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Order buy");
            Console.ResetColor();

            foreach (var o in orderService.GetAllOrdersBuy())
            {
                Console.WriteLine($"Order buy id: {o.Id}");
                Console.WriteLine($"Product: {o.ProductId}");
                Console.WriteLine($"Product number: {o.Number}");
                Console.WriteLine($"Sum: {o.Sum}");
                Console.WriteLine($"Date: {o.Date}");
                Console.WriteLine($"Is closed: {o.isClosed}");
                if (o.SupplierName != null)
                    Console.WriteLine($"Supplier {o.SupplierName}");
                if (o.OrderSellId != 0)
                    Console.WriteLine($"Order buy id: {o.OrderSellId}");
                Console.WriteLine();
            }
        }

        private static void ShowOrderSell(OrderService orderService)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Order sell");
            Console.ResetColor();

            foreach (var o in orderService.GetAllOrdersSell())
            {
                Console.WriteLine($"Order sell id: {o.Id}");
                Console.WriteLine($"Customer: {o.Customer}");
                Console.WriteLine($"Product id: {o.ProductId}");
                Console.WriteLine($"Product number: {o.Number}");
                Console.WriteLine($"Sum: {o.Sum}");
                Console.WriteLine($"Date: {o.Date}");
                Console.WriteLine($"Is closed: {o.isClosed}");
                if (o.OrderBuyId != 0)
                    Console.WriteLine($"Order buy id: {o.OrderBuyId}");
                Console.WriteLine();
            }
        }

        static void ShowProductList(ProductService productService)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Products");
            Console.ResetColor();

            foreach (var p in productService.GetAllProducts())
            {
                Console.WriteLine($"{p.ProductId} {p.ProductName}, " +
                    $"{p.Cost}, {p.Number}");

            }
        }
    }
}
