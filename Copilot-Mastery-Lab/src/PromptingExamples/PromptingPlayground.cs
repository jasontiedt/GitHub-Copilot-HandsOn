using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopilotMastery.PromptingExamples
{
    /// <summary>
    /// Example class demonstrating different prompting styles for code generation.
    /// Use this as a playground to test various prompting techniques.
    /// </summary>
    public class PromptingPlayground
    {
        // EXERCISE 1: Instructional Prompting
        // Try these prompts with Copilot and observe the different responses:

        // Poor Prompt Example:
        // "Make a method"
        
        // Good Prompt Example:
        // "Create a method that validates email addresses using regex. 
        // Return true if valid, false if invalid. Include validation for @ symbol, domain, and basic format."
        
        // YOUR TURN: Use the good prompt above and let Copilot generate the method here:
        // [Generated method will appear here]

        // EXERCISE 2: Context-Rich Prompting
        // Project Context: This is part of a user management system for an enterprise application
        // Business Rules: Email must be unique, passwords must meet complexity requirements
        // Technical Context: Using .NET 8, Entity Framework Core, and custom validation attributes
        
        // Prompt: "Create a User class for our enterprise user management system with the following requirements:
        // - Properties: Id, FirstName, LastName, Email, PasswordHash, CreatedDate, LastLoginDate, IsActive
        // - Email validation using data annotations and custom validation
        // - Password complexity requirements: min 8 chars, 1 uppercase, 1 lowercase, 1 digit, 1 special char
        // - Include Entity Framework configuration attributes
        // - Implement IValidatableObject for custom business rule validation"
        
        // YOUR TURN: Use the prompt above here:
        // [Generated User class will appear here]

        // EXERCISE 3: Example-Driven Prompting
        // Show Copilot how you handle one scenario, then ask for similar implementations
        
        // Example: Here's how I handle user authentication:
        public async Task<AuthResult> AuthenticateUserAsync(string email, string password)
        {
            try
            {
                // Note: In a real implementation, these would be injected dependencies
                // var user = await _userRepository.GetUserByEmailAsync(email);
                // This is example code for prompting exercises
                
                // Simulated logic for demonstration
                await Task.Delay(10); // Simulate async operation
                
                // Example authentication logic
                var isValidUser = !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password);
                
                if (!isValidUser)
                {
                    // await _auditService.LogFailedLoginAsync(email);
                    return AuthResult.Failed("Invalid credentials");
                }

                // var token = _tokenService.GenerateToken(user);
                // await _auditService.LogSuccessfulLoginAsync(user.Id);
                
                return AuthResult.Success("sample-jwt-token", new { Id = 1, Email = email });
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "Authentication failed for user {Email}", email);
                Console.WriteLine($"Authentication failed: {ex.Message}");
                return AuthResult.Failed("Authentication error");
            }
        }

        // Now prompt: "Using the same pattern as AuthenticateUserAsync, create a method for password reset functionality
        // that generates a reset token, stores it temporarily, and sends an email to the user."
        
        // YOUR TURN: Use the prompt above here:
        // [Generated password reset method will appear here]

        // EXERCISE 4: Problem-Solution Prompting
        // Describe a problem and let Copilot propose solutions
        
        // Prompt: "I have a performance problem with this method. It's making multiple database calls in a loop
        // and causing N+1 query issues. The method loads user data and their associated orders.
        // Current implementation is slow with 1000+ users. Suggest optimization strategies."
        
        public async Task<List<UserWithOrders>> GetUsersWithOrdersSlowAsync()
        {
            // Note: This is example code demonstrating performance issues for prompting exercises
            // In a real implementation, these would be proper repository calls
            
            // Simulated slow implementation with N+1 queries
            var users = await Task.FromResult(new List<object> { new { Id = 1 }, new { Id = 2 } });
            var result = new List<UserWithOrders>();
            
            foreach (var user in users)
            {
                // This simulates the N+1 query problem
                await Task.Delay(10); // Simulate database call delay
                var orders = new List<object> { new { Id = 1, Total = 100.0m }, new { Id = 2, Total = 200.0m } };
                
                result.Add(new UserWithOrders 
                { 
                    User = user, 
                    Orders = orders,
                    TotalOrderValue = 300.0m // Simulated calculation
                });
            }
            
            return result;
        }
        
        // YOUR TURN: Ask Copilot to optimize the method above:
        // [Optimized method will appear here]

        // EXERCISE 5: Step-by-Step Prompting
        // Break complex tasks into smaller steps
        
        // Prompt: "I need to implement a complete order processing system. Let's break this into steps:
        // Step 1: Create an Order domain model with validation
        // Step 2: Add business logic for order calculation (items, tax, discounts)
        // Step 3: Implement order status management with state transitions
        // Step 4: Add inventory checking and reservation
        // Step 5: Create order persistence with repository pattern
        // 
        // Let's start with Step 1 - create the Order domain model:"
        
        // YOUR TURN: Work through each step with Copilot:
        // Step 1 result:
        // [Order model will appear here]
        
        // Step 2 result:
        // [Order calculation logic will appear here]
        
        // Continue with remaining steps...

        // EXERCISE 6: Template-Based Prompting
        // Use predefined templates for consistency
        
        // Template: Create a [ENTITY_TYPE] with CRUD operations
        // Entity: Product
        // Properties: Id, Name, Description, Price, CategoryId, StockQuantity, IsActive
        // Business Rules: Price must be positive, stock cannot be negative, name is required
        // Patterns: Repository pattern, async/await, proper error handling
        
        // YOUR TURN: Apply the template above:
        // [Product entity and CRUD operations will appear here]

        // EXERCISE 7: Conversational Prompting
        // Natural language exploration
        
        // Start with: "I'm designing a caching strategy for my web API. The API serves product catalog data
        // that changes infrequently but is accessed very frequently. What caching approaches would you recommend?"
        
        // Follow up based on response: "Tell me more about distributed caching with Redis vs in-memory caching"
        
        // Continue the conversation: "How would I implement cache invalidation when products are updated?"
        
        // YOUR TURN: Have this conversation with Copilot and document insights:
        // [Conversation insights will be documented here]

        // REFLECTION EXERCISE:
        // After trying different prompting styles, answer these questions:
        // 1. Which prompting style felt most natural to you?
        // 2. Which style produced the highest quality code?
        // 3. Which style was most efficient for different types of tasks?
        // 4. How did providing more context affect the results?
        // 5. When would you use each style in real development?
        
        // Document your findings here:
        // [Your reflection notes]
    }

    // Supporting classes for the exercises
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public object? User { get; set; }

        public static AuthResult Success(string token, object user) => 
            new AuthResult { IsSuccess = true, Token = token, User = user };
        
        public static AuthResult Failed(string error) => 
            new AuthResult { IsSuccess = false, ErrorMessage = error };
    }

    public class UserWithOrders
    {
        public object? User { get; set; }
        public List<object>? Orders { get; set; }
        public decimal TotalOrderValue { get; set; }
    }
}
