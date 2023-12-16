using Stark.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Playground
{
    internal class Playground
    {
        public Playground(
            List<Customer> customers,
            List<Product> products,
            List<Address> addresses,
            List<Order> orders,
            List<OrderItem> orderItems)
        {
            Customers = customers;
            Products = products;
            Addresses = addresses;
            Orders = orders;
            OrderItems = orderItems;
        }

        public List<Customer> Customers { get; }
        public List<Product> Products { get; }
        public List<Address> Addresses { get; }
        public List<Order> Orders { get; }
        public List<OrderItem> OrderItems { get; }

        internal void Run()
        {
            Console.WriteLine("Get Customers With Names starting with B");

            var customersThatStartWithB = Customers
                .Where(c => c.FullName.StartsWith("B"))
                .Select(c => new
                {
                    c.FullName,
                    c.Email,
                    c.CustomerId
                })
                .ToList();

            Console.WriteLine("Get Top 10 Addresses that contains a City with more than 1 word");

            var addressesLongCountry = Addresses
                .Where(a => a.City.Split(' ').Length > 1)
                .Select(a => new
                {
                    a.AddressId,
                    a.Country,
                    a.City,
                    a.PostalCode,
                    a.AddressLine1,
                    CityWords = a.City.Split(' ').Length,
                })
                .OrderBy(a => a.CityWords)
                .ThenBy(a => a.City)
                .Take(10)
                .ToList();

            Console.WriteLine("Get next top 10 Orders that have the most recent order date");
            var recentlyOrderedOrders = Orders
                .OrderByDescending(o => o.OrderDate)
                .Skip(10)
                .Take(10)
                .ToList();

            Console.WriteLine("Get the top and the bottom order items, by quantity and the price");
            var orderedItems = OrderItems
                .OrderByDescending(o => o.Quantity)
                .ThenBy(o => o.PurchasePrice);
            var topOrderItem = orderedItems.First();
            var bottomOrderItem = orderedItems.Last();

            Console.WriteLine("Get Customer Information from Orders");
            var ordersWithCusomers = Orders
                .Join(Customers,
                    o => o.CustomerId,
                    c => c.CustomerId,
                    (o, c) => new
                    {
                        o.OrderId,
                        c.CustomerId,
                        c.FullName,
                        c.Email,
                        o.OrderDate,
                        Items = o.OrderItems.Count
                    })
                .ToList();

            // Exercise 1
            Console.WriteLine("Get Total Current Price of Products starting with A, E, I or P");

            var totalCurrentPrice = Products
                .Where(p => p.ProductName.StartsWith("A") || p.ProductName.StartsWith("E") || p.ProductName.StartsWith("I") || p.ProductName.StartsWith("P"))
                .Sum(p => p.CurrentPrice);

            Console.WriteLine($"Total Current Price: {totalCurrentPrice}");

            // Exercise 3
            Console.WriteLine("Get Top 3 Customers with the most Orders");

            var topThreeCustomersWithMostOrders = Orders
                .GroupBy(o => o.CustomerId)
                .Select(group => new
                {
                    CustomerId = group.Key,
                    OrderCount = group.Count()
                })
                .OrderByDescending(g => g.OrderCount)
                .Take(3)
                .Join(Customers, g => g.CustomerId, c => c.CustomerId, (g, c) => new
                {
                    c.FullName,
                    c.Email,
                    Orders = Orders.Where(o => o.CustomerId == c.CustomerId).Select(o => new { o.OrderId, o.OrderDate })
                })
                .ToList();

            foreach (var customer in topThreeCustomersWithMostOrders)
            {
                Console.WriteLine($"Customer Name: {customer.FullName}, Email: {customer.Email}");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}, Product ID: {string.Join(", ", order.OrderId)}");
                }
                Console.WriteLine("-------------------------------------");
            }

            // Exercise 2
            Console.WriteLine("Get All Orders Made this Year");
            var currentYear = DateTime.Now.Year;
            var ordersThisYear = Orders
                .Where(o => o.OrderDate.Value.Year == currentYear)
                .OrderByDescending(o => o.OrderDate.Value)
                .ToList();

            foreach (var order in ordersThisYear)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate.Value.ToString("yyyy-MM-dd")}");
            }

            // Exercisa 4
            Console.WriteLine("Get Top 3 Products with the most Orders");
            var topProducts = OrderItems
                .GroupBy(oi => oi.ProductId)
                .Select(group => new
                {
                    ProductId = group.Key,
                    OrderItemCount = group.Count()
                })
                .OrderByDescending(g => g.OrderItemCount)
                .Take(3)
                .Join(Products, g => g.ProductId, p => p.ProductId, (g, p) => new
                {
                    p.ProductName,
                    p.Description,
                    Customers = OrderItems.Where(oi => oi.ProductId == p.ProductId)
                                          .Join(Orders, oi => oi.OrderId, o => o.OrderId, (oi, o) => o.CustomerId)
                                          .Distinct()
                                          .Join(Customers, id => id, c => c.CustomerId, (id, c) => new
                                          {
                                              c.FullName,
                                              c.Email
                                          }).ToList()
                })
                .ToList();

            foreach (var product in topProducts)
            {
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine("Customers who ordered this product:");

                foreach (var customer in product.Customers)
                {
                    Console.WriteLine($"  Customer Name: {customer.FullName}");
                    Console.WriteLine($"  Email: {customer.Email}");                  
                }

                Console.WriteLine("-------------------------------------");
            }
        }
    }
}
