using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopilotMastery.ModelComparison
{
    /// <summary>
    /// Playground for testing different Copilot models with the same prompts.
    /// Use this to understand how GPT-4, Claude, and base Copilot respond differently.
    /// </summary>
    public class ModelComparisonPlayground
    {
        // COMPARISON EXERCISE 1: Architecture Decision
        // Ask each model the same question and compare responses
        
        /*
         * PROMPT FOR ALL MODELS:
         * "I'm building a real-time chat application that needs to support 10,000+ concurrent users.
         * I need to choose between WebSockets, Server-Sent Events, and polling.
         * My backend is ASP.NET Core, frontend is React, and I'm hosting on Azure.
         * What would you recommend and why?"
         * 
         * Test with:
         * - GPT-4 (expect detailed analysis with trade-offs)
         * - Claude (expect comprehensive pros/cons with safety considerations)  
         * - Base Copilot (expect practical implementation suggestions)
         */
        
        // Document responses here:
        // GPT-4 Response Summary:
        // [Record key points from GPT-4's response]
        
        // Claude Response Summary:
        // [Record key points from Claude's response]
        
        // Base Copilot Response Summary:
        // [Record key points from Base Copilot's response]
        
        // Which response was most helpful for your scenario?
        // [Your analysis]

        // COMPARISON EXERCISE 2: Code Implementation
        // Same implementation request to all models
        
        /*
         * PROMPT FOR ALL MODELS:
         * "Create a rate limiting service that prevents abuse of API endpoints.
         * Requirements:
         * - Support different rate limits per endpoint
         * - Use sliding window algorithm
         * - Store data in Redis for scalability
         * - Include proper error handling and logging
         * - Return appropriate HTTP status codes
         * - Be thread-safe and performant"
         */
        
        // GPT-4 Implementation:
        // [Paste GPT-4's implementation here]
        
        // Claude Implementation:
        // [Paste Claude's implementation here]
        
        // Base Copilot Implementation:
        // [Paste Base Copilot's implementation here]
        
        // Analysis:
        // Which implementation was most complete?
        // Which followed best practices better?
        // Which would you choose for production?
        // [Your comparison notes]

        // COMPARISON EXERCISE 3: Code Review
        // Ask each model to review the same problematic code
        
        public class ProblematicUserService
        {
            public string CreateUser(string name, string email, string password)
            {
                // Problematic code for models to review - this is intentionally bad for educational purposes
                if (name == null) return "error";
                
                var user = new User();
                user.Name = name;
                user.Email = email;
                user.Password = password; // Storing plain text password!
                
                // Simulated direct database access without error handling (unsafe in real apps)
                // Note: This is example code showing anti-patterns for educational purposes
                var connectionString = "Server=localhost;Database=Users;";
                // var connection = new SqlConnection(connectionString);
                // connection.Open();
                // var command = new SqlCommand($"INSERT INTO Users VALUES ('{name}', '{email}', '{password}')", connection);
                // command.ExecuteNonQuery();
                // connection.Close();
                
                // Simulated for compilation purposes
                Console.WriteLine($"Would execute unsafe SQL: INSERT INTO Users VALUES ('{name}', '{email}', '{password}')");
                
                return "success";
            }
        }
        
        /*
         * PROMPT FOR ALL MODELS:
         * "Review this CreateUser method for security issues, bugs, and best practice violations.
         * Provide specific recommendations for improvement."
         */
        
        // GPT-4 Review:
        // [Record GPT-4's code review feedback]
        
        // Claude Review:
        // [Record Claude's code review feedback]
        
        // Base Copilot Review:
        // [Record Base Copilot's code review feedback]
        
        // Review Comparison:
        // Which model identified the most issues?
        // Which provided the most actionable feedback?
        // Which model's review would be most helpful to a junior developer?
        // [Your analysis]

        // COMPARISON EXERCISE 4: Performance Optimization
        // Same optimization challenge for all models
        
        public async Task<List<OrderSummary>> GetOrderSummariesSlowAsync()
        {
            // Intentionally inefficient code for optimization challenge
            var orders = await GetAllOrdersAsync();
            var summaries = new List<OrderSummary>();
            
            foreach (var order in orders)
            {
                var customer = await GetCustomerAsync(order.CustomerId); // N+1 problem
                var items = await GetOrderItemsAsync(order.Id); // Another N+1 problem
                
                var summary = new OrderSummary
                {
                    OrderId = order.Id,
                    CustomerName = customer.Name,
                    ItemCount = items.Count,
                    Total = items.Sum(i => i.Price * i.Quantity),
                    OrderDate = order.CreatedDate
                };
                
                summaries.Add(summary);
            }
            
            return summaries.OrderBy(s => s.OrderDate).ToList();
        }
        
        /*
         * PROMPT FOR ALL MODELS:
         * "This method is performing poorly with large datasets due to N+1 queries.
         * Optimize it for better performance while maintaining the same functionality.
         * Explain your optimization strategy."
         */
        
        // GPT-4 Optimization:
        // [Paste optimized version from GPT-4]
        // Explanation: [GPT-4's optimization strategy]
        
        // Claude Optimization:
        // [Paste optimized version from Claude]
        // Explanation: [Claude's optimization strategy]
        
        // Base Copilot Optimization:
        // [Paste optimized version from Base Copilot]
        // Explanation: [Base Copilot's optimization strategy]
        
        // Performance Comparison:
        // Which optimization strategy was most effective?
        // Which explanation was clearest?
        // Which solution would scale best?
        // [Your analysis]

        // COMPARISON EXERCISE 5: Learning New Technology
        // Test how each model helps with learning
        
        /*
         * PROMPT FOR ALL MODELS:
         * "I'm new to gRPC and need to add it to my existing ASP.NET Core application.
         * Explain the key concepts, show me how to set it up, and provide a simple example
         * of a service with both unary and streaming methods."
         */
        
        // GPT-4 Learning Response:
        // [Summarize GPT-4's teaching approach and examples]
        
        // Claude Learning Response:
        // [Summarize Claude's teaching approach and examples]
        
        // Base Copilot Learning Response:
        // [Summarize Base Copilot's teaching approach and examples]
        
        // Learning Effectiveness:
        // Which model explained concepts most clearly?
        // Which provided the most practical examples?
        // Which would be best for a beginner vs experienced developer?
        // [Your analysis]

        // OVERALL MODEL ASSESSMENT
        
        /*
         * After completing all exercises, rate each model (1-5) on:
         * 
         * Code Quality:
         * - GPT-4: [1-5]
         * - Claude: [1-5]
         * - Base Copilot: [1-5]
         * 
         * Explanation Depth:
         * - GPT-4: [1-5]
         * - Claude: [1-5]
         * - Base Copilot: [1-5]
         * 
         * Practical Applicability:
         * - GPT-4: [1-5]
         * - Claude: [1-5]
         * - Base Copilot: [1-5]
         * 
         * Security Awareness:
         * - GPT-4: [1-5]
         * - Claude: [1-5]
         * - Base Copilot: [1-5]
         * 
         * Performance Considerations:
         * - GPT-4: [1-5]
         * - Claude: [1-5]
         * - Base Copilot: [1-5]
         */

        // YOUR PERSONAL MODEL SELECTION STRATEGY
        /*
         * Based on your experience, document when you would choose each model:
         * 
         * Use GPT-4 when:
         * - [Your criteria]
         * 
         * Use Claude when:
         * - [Your criteria]
         * 
         * Use Base Copilot when:
         * - [Your criteria]
         * 
         * Workflow Integration:
         * - [How you would combine models in a typical project]
         */

        // Supporting classes and methods for the exercises
        private async Task<List<Order>> GetAllOrdersAsync() => new List<Order>();
        private async Task<Customer> GetCustomerAsync(int customerId) => new Customer();
        private async Task<List<OrderItem>> GetOrderItemsAsync(int orderId) => new List<OrderItem>();
    }

    // Supporting classes for exercises
    public class User
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderSummary
    {
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public int ItemCount { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
