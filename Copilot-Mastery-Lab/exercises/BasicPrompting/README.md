# Basic Prompting Exercises

## Exercise 1: Prompt Clarity Comparison

### Objective
Learn how prompt clarity affects the quality of Copilot responses.

### Instructions
1. Try each prompt below with GitHub Copilot
2. Compare the responses you get
3. Note the differences in quality, specificity, and usefulness

### Prompts to Try

#### Poor Prompt Examples
```csharp
// Make a function
```

```csharp
// Add some validation
```

```csharp
// Fix this code
public string ProcessData(string input) {
    return input;
}
```

#### Good Prompt Examples
```csharp
// Create a function that validates email addresses using regex
// Return true if valid, false if invalid
// Include validation for: @ symbol, domain, and basic format
```

```csharp
// Add input validation to this method:
// - Check for null or empty strings
// - Ensure minimum length of 3 characters
// - Throw ArgumentException with descriptive message if invalid
public string ProcessUserName(string username) {
    return username.Trim().ToLower();
}
```

```csharp
// Optimize this method for performance:
// - Use StringBuilder for string concatenation
// - Add null checking
// - Return early if input is empty
public string ProcessData(string input) {
    string result = "";
    for (int i = 0; i < input.Length; i++) {
        result += input[i].ToString().ToUpper();
    }
    return result;
}
```

### What to Observe
- **Response Completeness**: Does the AI provide complete solutions?
- **Code Quality**: Is the generated code following best practices?
- **Explanation**: Does the AI explain its choices?
- **Error Handling**: Are edge cases considered?

### Your Analysis
Create a file called `prompt-analysis.md` and document:
1. Which prompts gave better results and why
2. Patterns you notice in effective prompts
3. Your own examples of good vs poor prompts

---

## Exercise 2: Context Optimization

### Objective
Understand how providing context improves Copilot responses.

### Setup
You're building a web API for a bookstore. Try the same prompt with different levels of context.

### Scenario: Creating a Book Model

#### Minimal Context
```csharp
// Create a Book class
```

#### Basic Context
```csharp
// Create a Book class for a bookstore API
// Properties: Title, Author, ISBN, Price
```

#### Rich Context
```csharp
// Project: Bookstore Management System API (.NET 8, Entity Framework Core)
// Create a Book entity class with the following requirements:
// - Properties: Title, Author, ISBN, Price, PublicationDate, Category, StockQuantity
// - ISBN should be validated (13 digits)
// - Price should be positive decimal with 2 decimal places
// - Include data annotations for Entity Framework
// - Add validation attributes for API model binding
// - Implement IEquatable<Book> for comparison
```

#### Domain-Specific Context
```csharp
// Bookstore Management System - Domain Model
// 
// Business Rules:
// - Books must have unique ISBN-13 format
// - Price includes tax calculation capability
// - Stock tracking with low-stock alerts at quantity < 5
// - Publication date cannot be in the future
// - Categories from predefined enum: Fiction, NonFiction, Science, History, Biography
// 
// Technical Requirements:
// - Entity Framework Core entity with proper navigation properties
// - JSON serialization support for API responses
// - Validation attributes for input validation
// - Audit fields: CreatedDate, UpdatedDate, CreatedBy, UpdatedBy
// 
// Create the Book entity class following these specifications:
```

### Instructions
1. Try each prompt level with Copilot
2. Compare the generated code quality and completeness
3. Note how context affects the AI's understanding

### Analysis Questions
1. At what point does additional context stop providing value?
2. Which types of context are most helpful?
3. How does business context vs technical context affect results?

---

## Exercise 3: Iterative Refinement

### Objective
Learn to refine prompts based on initial results.

### Scenario
You need to create a user authentication service.

### Round 1: Initial Prompt
```csharp
// Create a user authentication service
```

### Round 2: Refine Based on Results
Based on what you got in Round 1, refine your prompt. For example:
```csharp
// Create a user authentication service with these methods:
// - AuthenticateUser(username, password) -> returns JWT token
// - ValidateToken(token) -> returns user claims
// - RefreshToken(refreshToken) -> returns new token pair
```

### Round 3: Add Specifics
```csharp
// Create an IUserAuthenticationService interface and implementation with:
// - JWT token generation using HS256 algorithm
// - Password hashing using BCrypt
// - Token expiration: 15 minutes for access token, 7 days for refresh token
// - Include proper error handling and logging
// - Use dependency injection pattern
```

### Round 4: Technical Details
```csharp
// UserAuthenticationService implementation requirements:
// - Dependencies: IUserRepository, IConfiguration, ILogger<UserAuthenticationService>
// - JWT settings from appsettings.json: SecretKey, Issuer, Audience
// - Password validation: minimum 8 chars, 1 uppercase, 1 lowercase, 1 digit
// - Rate limiting: max 5 failed attempts per user per hour
// - Security: constant-time password comparison, secure token generation
// - Return custom Result<T> type instead of throwing exceptions
```

### Instructions
1. Start with the basic prompt
2. Analyze the result and identify what's missing
3. Create a refined prompt addressing the gaps
4. Repeat until you get a satisfactory result
5. Document the evolution of your prompts

### Reflection
- How many iterations did it take to get what you wanted?
- What types of refinements were most effective?
- Could you have achieved the same result with fewer iterations?

---

## Exercise 4: Prompt Template Development

### Objective
Create reusable prompt templates for common scenarios.

### Your Task
Create templates for these common development tasks:

#### Template 1: API Controller
```
// Template: REST API Controller
// Resource: [RESOURCE_NAME]
// Operations: [CRUD_OPERATIONS]
// Authentication: [AUTH_REQUIREMENTS]
// Validation: [VALIDATION_RULES]
// Error Handling: [ERROR_STRATEGY]
// Documentation: [SWAGGER_REQUIREMENTS]
```

#### Template 2: Service Class
```
// Template: Service Implementation
// Interface: [INTERFACE_NAME]
// Dependencies: [DEPENDENCY_LIST]
// Business Logic: [BUSINESS_RULES]
// Error Handling: [ERROR_STRATEGY]
// Logging: [LOGGING_REQUIREMENTS]
// Testing: [TESTABILITY_REQUIREMENTS]
```

#### Template 3: Data Model
```
// Template: Data Entity
// Domain: [BUSINESS_DOMAIN]
// Properties: [PROPERTY_LIST]
// Relationships: [ENTITY_RELATIONSHIPS]
// Validation: [VALIDATION_RULES]
// Persistence: [DATABASE_REQUIREMENTS]
// Serialization: [JSON_REQUIREMENTS]
```

### Instructions
1. Use each template with different scenarios
2. Test how well they work with various inputs
3. Refine the templates based on results
4. Create additional templates for patterns you use frequently

### Save Your Templates
Create `my-prompt-templates.md` with your refined templates for future use.

---

## Exercise 5: Problem-Solution Prompting

### Objective
Practice describing problems effectively to get better solutions.

### Scenarios

#### Scenario 1: Performance Problem
```
// Problem: API endpoint responding slowly
// Current Implementation: [PASTE_YOUR_SLOW_CODE]
// Performance Target: < 100ms response time
// Current Performance: 2-3 seconds average
// Constraints: Cannot change database schema
// Resources: SQL Server, Entity Framework Core
// Request: Analyze and optimize for performance
```

#### Scenario 2: Architecture Decision
```
// Problem: Choosing between microservices vs monolith
// Context: E-commerce platform, 10-person team, rapid growth expected
// Current: Monolithic .NET application, 50k daily users
// Challenges: Deployment bottlenecks, scaling difficulties
// Constraints: 6-month timeline, limited DevOps experience
// Request: Recommend architecture approach with pros/cons
```

#### Scenario 3: Technology Selection
```
// Problem: Real-time features for chat application
// Requirements: 1000+ concurrent users, message delivery, typing indicators
// Current Stack: ASP.NET Core, React frontend
// Constraints: Azure hosting, budget limitations
// Options Considered: SignalR, WebSockets, Server-Sent Events
// Request: Recommend best approach with implementation guidance
```

### Instructions
1. Try each scenario with different levels of detail
2. Ask follow-up questions based on the responses
3. Compare how problem framing affects solution quality

---

## Completion Checklist

- [ ] Completed all 5 exercises
- [ ] Created `prompt-analysis.md` with observations
- [ ] Developed personal prompt templates
- [ ] Documented iterative refinement process
- [ ] Practiced problem-solution prompting

## Next Steps
Move on to `AdvancedPrompting` exercises to learn more sophisticated techniques!
