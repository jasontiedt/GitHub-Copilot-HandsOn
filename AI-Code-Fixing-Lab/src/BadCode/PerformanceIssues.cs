using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Net.Http;

namespace BadCode
{
    // PROBLEM CATEGORY: Performance Issues
    // This class demonstrates various performance anti-patterns that AI should help optimize
    
    public class PerformanceIssues
    {
        private string connectionString = "Server=localhost;Database=TestDB;Integrated Security=true;";
        private static HttpClient httpClient = new HttpClient(); // Static but not disposed properly

        // ISSUE #1: N+1 Query Problem
        public async Task<List<OrderInfo>> GetOrdersWithCustomers()
        {
            var orders = new List<OrderInfo>();
            
            // First query to get all orders
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var orderCommand = new SqlCommand("SELECT OrderId, CustomerId, OrderDate FROM Orders", connection);
                using (var reader = orderCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new OrderInfo
                        {
                            OrderId = reader.GetInt32("OrderId"),
                            CustomerId = reader.GetInt32("CustomerId"),
                            OrderDate = reader.GetDateTime("OrderDate")
                        });
                    }
                }
            }
            
            // N+1 Problem: One query per order to get customer details
            foreach (var order in orders)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var customerCommand = new SqlCommand($"SELECT Name FROM Customers WHERE Id = {order.CustomerId}", connection);
                    order.CustomerName = customerCommand.ExecuteScalar()?.ToString();
                }
            }
            
            return orders;
        }

        // ISSUE #2: Synchronous operations blocking threads
        public List<string> GetDataFromMultipleAPIs()
        {
            var results = new List<string>();
            var urls = new[]
            {
                "https://api1.example.com/data",
                "https://api2.example.com/data",
                "https://api3.example.com/data"
            };
            
            // Blocking synchronous calls instead of async
            foreach (var url in urls)
            {
                try
                {
                    var response = httpClient.GetAsync(url).Result; // Blocking!
                    var content = response.Content.ReadAsStringAsync().Result; // Blocking!
                    results.Add(content);
                }
                catch
                {
                    results.Add("Error");
                }
            }
            
            return results;
        }

        // ISSUE #3: Memory inefficient large data processing
        public void ProcessLargeDataset()
        {
            // Loading entire dataset into memory at once
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM LargeTable", connection); // Could be millions of rows
                using (var reader = command.ExecuteReader())
                {
                    var allData = new List<DataRow>();
                    
                    // Loading everything into memory
                    while (reader.Read())
                    {
                        var row = new DataRow
                        {
                            Id = reader.GetInt32("Id"),
                            Data = reader.GetString("Data"),
                            CreatedDate = reader.GetDateTime("CreatedDate")
                        };
                        allData.Add(row);
                    }
                    
                    // Processing all at once instead of streaming
                    foreach (var row in allData)
                    {
                        ProcessSingleRow(row);
                    }
                }
            }
        }

        // ISSUE #4: Inefficient collection operations
        public List<Product> FilterAndSortProducts(List<Product> products, string category, decimal minPrice)
        {
            var filtered = new List<Product>();
            
            // Multiple iterations instead of single LINQ chain
            foreach (var product in products)
            {
                if (product.Category == category)
                {
                    filtered.Add(product);
                }
            }
            
            var priceFiltered = new List<Product>();
            foreach (var product in filtered)
            {
                if (product.Price >= minPrice)
                {
                    priceFiltered.Add(product);
                }
            }
            
            // Inefficient sorting using bubble sort
            for (int i = 0; i < priceFiltered.Count - 1; i++)
            {
                for (int j = 0; j < priceFiltered.Count - i - 1; j++)
                {
                    if (priceFiltered[j].Price > priceFiltered[j + 1].Price)
                    {
                        var temp = priceFiltered[j];
                        priceFiltered[j] = priceFiltered[j + 1];
                        priceFiltered[j + 1] = temp;
                    }
                }
            }
            
            return priceFiltered;
        }

        // ISSUE #5: No caching - repeated expensive calculations
        public decimal CalculateComplexMetric(int productId)
        {
            // Same calculation performed every time without caching
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                // Multiple expensive database queries
                var salesCommand = new SqlCommand($"SELECT SUM(Amount) FROM Sales WHERE ProductId = {productId}", connection);
                var totalSales = (decimal?)salesCommand.ExecuteScalar() ?? 0;
                
                var reviewCommand = new SqlCommand($"SELECT AVG(Rating) FROM Reviews WHERE ProductId = {productId}", connection);
                var avgRating = (decimal?)reviewCommand.ExecuteScalar() ?? 0;
                
                var inventoryCommand = new SqlCommand($"SELECT StockLevel FROM Inventory WHERE ProductId = {productId}", connection);
                var stockLevel = (int?)inventoryCommand.ExecuteScalar() ?? 0;
                
                // Complex calculation that could be cached
                return (totalSales * avgRating) / Math.Max(stockLevel, 1);
            }
        }

        // ISSUE #6: String concatenation in loop
        public string GenerateLargeReport(List<ReportItem> items)
        {
            string report = "<html><body>";
            
            // Inefficient string concatenation
            foreach (var item in items)
            {
                report += "<div>";
                report += "<h3>" + item.Title + "</h3>";
                report += "<p>" + item.Description + "</p>";
                report += "<span>Value: " + item.Value.ToString() + "</span>";
                report += "</div>";
            }
            
            report += "</body></html>";
            return report;
        }

        // ISSUE #7: Inefficient database connection management
        public void ProcessManySmallOperations()
        {
            var operations = Enumerable.Range(1, 1000);
            
            // Opening/closing connection for each operation
            foreach (var op in operations)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Expensive operation repeated 1000 times
                    var command = new SqlCommand($"INSERT INTO Operations (Value) VALUES ({op})", connection);
                    command.ExecuteNonQuery();
                } // Connection closed and disposed
            }
        }

        // ISSUE #8: Blocking async methods
        public void CallAsyncMethodsPoorly()
        {
            // Blocking on async methods
            var task1 = DoAsyncWork("Task1");
            var task2 = DoAsyncWork("Task2");
            var task3 = DoAsyncWork("Task3");
            
            // Waiting synchronously instead of using await
            var result1 = task1.Result;
            var result2 = task2.Result;
            var result3 = task3.Result;
            
            Console.WriteLine($"Results: {result1}, {result2}, {result3}");
        }

        // ISSUE #9: Memory leaks with event handlers
        public class EventPublisher
        {
            public event Action<string> DataProcessed;
            
            public void ProcessData(string data)
            {
                // Processing data...
                DataProcessed?.Invoke(data);
            }
        }

        private static EventPublisher publisher = new EventPublisher();
        
        public void SubscribeToEvents()
        {
            // Event handler not unsubscribed - potential memory leak
            publisher.DataProcessed += OnDataProcessed;
            
            // Object might not be garbage collected due to event reference
        }

        // ISSUE #10: Inefficient exception handling in loops
        public void ProcessItemsWithBadErrorHandling(List<string> items)
        {
            foreach (var item in items)
            {
                try
                {
                    // Exception handling inside tight loop - performance impact
                    ProcessItem(item);
                }
                catch (Exception ex)
                {
                    // Creating exception objects is expensive
                    Console.WriteLine($"Error processing {item}: {ex.Message}");
                }
            }
        }

        // ISSUE #11: Redundant database queries
        public ProductStats GetProductStatistics(int productId)
        {
            var stats = new ProductStats();
            
            // Multiple round trips to database for same product
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                var cmd1 = new SqlCommand($"SELECT COUNT(*) FROM Sales WHERE ProductId = {productId}", connection);
                stats.SaleCount = (int)cmd1.ExecuteScalar();
                
                var cmd2 = new SqlCommand($"SELECT AVG(Amount) FROM Sales WHERE ProductId = {productId}", connection);
                stats.AveragePrice = (decimal?)cmd2.ExecuteScalar() ?? 0;
                
                var cmd3 = new SqlCommand($"SELECT MAX(Amount) FROM Sales WHERE ProductId = {productId}", connection);
                stats.MaxPrice = (decimal?)cmd3.ExecuteScalar() ?? 0;
                
                var cmd4 = new SqlCommand($"SELECT MIN(Amount) FROM Sales WHERE ProductId = {productId}", connection);
                stats.MinPrice = (decimal?)cmd4.ExecuteScalar() ?? 0;
            }
            
            return stats;
        }

        // ISSUE #12: Poor regex performance
        public List<string> ExtractEmailsInefficiently(string text)
        {
            var emails = new List<string>();
            var emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            
            // Creating new Regex object each time instead of compiling once
            var words = text.Split(' ');
            foreach (var word in words)
            {
                var regex = new System.Text.RegularExpressions.Regex(emailPattern); // Inefficient!
                if (regex.IsMatch(word))
                {
                    emails.Add(word);
                }
            }
            
            return emails;
        }

        // Helper methods
        private void ProcessSingleRow(DataRow row) { /* Processing logic */ }
        private async Task<string> DoAsyncWork(string input) { await Task.Delay(100); return input; }
        private void OnDataProcessed(string data) { Console.WriteLine($"Processed: {data}"); }
        private void ProcessItem(string item) { /* Processing logic */ }
    }

    // Supporting classes
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
    }

    public class DataRow
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public class ReportItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }

    public class ProductStats
    {
        public int SaleCount { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
    }
}
