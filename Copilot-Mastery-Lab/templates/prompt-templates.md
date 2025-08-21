# Reusable Prompt Templates

## Code Generation Templates

### 1. API Controller Template
```
// Template: REST API Controller
// Resource: [RESOURCE_NAME]
// Base Route: api/[ROUTE]
// Operations: [GET, POST, PUT, DELETE - specify which ones]
// Authentication: [Required/Optional - specify requirements]
// Authorization: [Role-based/Policy-based - specify rules]
// Validation: [Input validation requirements]
// Error Handling: [Standard/Custom - specify approach]
// Documentation: [Swagger annotations required: Yes/No]
// Additional Requirements: [Any specific requirements]

Example Usage:
// Template: REST API Controller
// Resource: Product
// Base Route: api/products
// Operations: GET (all, by id), POST, PUT, DELETE
// Authentication: Required (JWT Bearer token)
// Authorization: Admin role for POST/PUT/DELETE, any authenticated user for GET
// Validation: Model validation attributes, custom business rule validation
// Error Handling: Custom error responses with problem details
// Documentation: Swagger annotations with examples
// Additional Requirements: Include caching for GET operations, soft delete for DELETE
```

### 2. Service Class Template
```
// Template: Service Implementation
// Interface: [INTERFACE_NAME]
// Purpose: [Brief description of service responsibility]
// Dependencies: [List of injected dependencies]
// Business Logic: [Key business rules and operations]
// Error Handling: [Exception strategy - throw, return Result<T>, etc.]
// Logging: [What to log - entry/exit, errors, business events]
// Async: [Required/Optional - specify async requirements]
// Testing: [Testability requirements - interfaces, dependency injection]
// Additional Requirements: [Caching, validation, etc.]

Example Usage:
// Template: Service Implementation
// Interface: IUserManagementService
// Purpose: Handle user lifecycle operations and business rules
// Dependencies: IUserRepository, IEmailService, ILogger<UserManagementService>
// Business Logic: User registration, email verification, password policies, account lockout
// Error Handling: Return Result<T> pattern, never throw exceptions to controllers
// Logging: Log user actions, failed login attempts, registration events
// Async: Required for all database and external service operations
// Testing: Fully mockable dependencies, unit testable business logic
// Additional Requirements: Rate limiting for registration, audit trail for changes
```

### 3. Data Model Template
```
// Template: Data Entity/Model
// Domain: [Business domain context]
// Type: [Entity, DTO, ViewModel, Request, Response]
// Properties: [List of properties with types and descriptions]
// Relationships: [Foreign keys, navigation properties]
// Validation: [Data annotations, custom validation rules]
// Persistence: [Entity Framework, Dapper, etc. - specific requirements]
// Serialization: [JSON settings, property naming, ignored fields]
// Additional Features: [Auditing, soft delete, versioning]

Example Usage:
// Template: Data Entity/Model
// Domain: E-commerce Order Management
// Type: Entity (EF Core)
// Properties: Id (int), CustomerId (int), OrderDate (DateTime), Status (enum), TotalAmount (decimal), ShippingAddress (Address), BillingAddress (Address)
// Relationships: Customer (many-to-one), OrderItems (one-to-many), Payments (one-to-many)
// Validation: Required fields, positive amounts, valid email in addresses
// Persistence: Entity Framework Core with SQL Server, include indexes on CustomerId and OrderDate
// Serialization: Camel case JSON, exclude internal tracking fields
// Additional Features: Audit trail (CreatedDate, UpdatedDate), soft delete support
```

## Problem-Solving Templates

### 4. Performance Optimization Template
```
// Template: Performance Analysis and Optimization
// Problem: [Describe the performance issue]
// Current Performance: [Metrics - response time, throughput, etc.]
// Target Performance: [Desired metrics]
// Constraints: [Cannot change X, must maintain Y]
// Environment: [Technology stack, infrastructure]
// Suspected Bottlenecks: [Database, network, CPU, memory]
// Profiling Data: [Include any profiling information]
// Business Impact: [How performance affects users/business]

Example Usage:
// Template: Performance Analysis and Optimization
// Problem: API endpoint responding slowly under load
// Current Performance: 2-3 second response time, max 50 concurrent users
// Target Performance: <500ms response time, support 500+ concurrent users
// Constraints: Cannot change database schema, must maintain backward compatibility
// Environment: ASP.NET Core 8, Entity Framework, SQL Server, Azure App Service
// Suspected Bottlenecks: N+1 queries, lack of caching, inefficient LINQ queries
// Profiling Data: 80% time spent in database operations, high memory allocation
// Business Impact: User complaints, abandoned shopping carts, revenue loss
```

### 5. Debug Analysis Template
```
// Template: Bug Analysis and Resolution
// Problem: [Clear description of the issue]
// Symptoms: [What users/systems experience]
// Frequency: [Always, intermittent, under specific conditions]
// Environment: [Where it occurs - dev, staging, production]
// Error Messages: [Exact error messages or stack traces]
// Reproduction Steps: [How to reproduce the issue]
// Recent Changes: [Code changes, deployments, configuration changes]
// Impact: [Who is affected, severity level]
// Logs/Data: [Relevant log entries, error data]

Example Usage:
// Template: Bug Analysis and Resolution
// Problem: Users cannot complete checkout process
// Symptoms: Payment processing fails with "Invalid transaction" error
// Frequency: Intermittent, approximately 15% of transactions
// Environment: Production only, not reproducible in staging
// Error Messages: "Payment gateway timeout" followed by "Transaction state invalid"
// Reproduction Steps: Add items to cart, proceed to checkout, enter payment info, submit
// Recent Changes: Updated payment service integration 3 days ago
// Impact: All customers affected, direct revenue impact, customer satisfaction issues
// Logs/Data: [Include relevant log entries showing payment gateway communication]
```

## Architecture and Design Templates

### 6. Architecture Decision Template
```
// Template: Architecture Decision
// Context: [Project context, current situation]
// Problem: [What needs to be decided]
// Options: [List of possible approaches]
// Criteria: [What factors are important for decision]
// Constraints: [Technical, budget, timeline, team constraints]
// Trade-offs: [Performance vs complexity, cost vs features, etc.]
// Recommendation: [Preferred approach with reasoning]

Example Usage:
// Template: Architecture Decision
// Context: Growing e-commerce platform, 50k daily users, 10-person development team
// Problem: Choose between microservices architecture vs modular monolith
// Options: 1) Full microservices, 2) Modular monolith, 3) Hybrid approach
// Criteria: Development velocity, deployment complexity, scalability, maintainability
// Constraints: 6-month timeline, limited DevOps expertise, budget restrictions
// Trade-offs: Microservices offer better scalability but higher complexity; monolith simpler but potential scaling limits
// Recommendation: Start with modular monolith, design for future microservices extraction
```

### 7. Code Review Template
```
// Template: Code Review
// Code: [Paste the code to review]
// Context: [What this code is supposed to do]
// Focus Areas: [Security, Performance, Maintainability, Best Practices, etc.]
// Standards: [Coding standards, frameworks, patterns to follow]
// Constraints: [Any limitations or requirements]
// Review Type: [Quick review, thorough analysis, security audit, etc.]

Example Usage:
// Template: Code Review
// Code: [UserController implementation]
// Context: REST API controller for user management in enterprise application
// Focus Areas: Security vulnerabilities, input validation, error handling, logging
// Standards: Follow company C# coding standards, use Result<T> pattern, proper HTTP status codes
// Constraints: Must maintain backward compatibility with existing API clients
// Review Type: Security-focused review before production deployment
```

## Learning and Exploration Templates

### 8. Technology Learning Template
```
// Template: Technology Learning
// Technology: [What you want to learn]
// Current Knowledge: [Your current experience level]
// Goal: [What you want to accomplish]
// Context: [Project context where you'll use this]
// Learning Style: [Examples, step-by-step, theory first, hands-on]
// Time Constraints: [How much time you have]
// Focus Areas: [Specific aspects you need to understand]

Example Usage:
// Template: Technology Learning
// Technology: GraphQL with .NET
// Current Knowledge: Experienced with REST APIs, new to GraphQL
// Goal: Implement GraphQL API for existing user management system
// Context: ASP.NET Core web API with Entity Framework, need to support mobile app with different data requirements
// Learning Style: Hands-on with practical examples, prefer working code over theory
// Time Constraints: Need working implementation within 2 weeks
// Focus Areas: Query/mutation implementation, authentication integration, performance considerations
```

### 9. Refactoring Template
```
// Template: Code Refactoring
// Current Code: [Paste the code to refactor]
// Issues: [What's wrong with current code]
// Goals: [What you want to achieve]
// Constraints: [What cannot be changed]
// Patterns: [Design patterns to apply]
// Quality Targets: [Maintainability, testability, performance, etc.]
// Testing: [How to ensure refactoring doesn't break functionality]

Example Usage:
// Template: Code Refactoring
// Current Code: [Legacy OrderProcessing class with multiple responsibilities]
// Issues: Violates SRP, hard to test, tight coupling, no error handling
// Goals: Apply SOLID principles, improve testability, add proper error handling
// Constraints: Cannot change public API, must maintain backward compatibility
// Patterns: Strategy pattern for discounts, Factory pattern for order types
// Quality Targets: 90%+ test coverage, reduced cyclomatic complexity, dependency injection
// Testing: Comprehensive unit tests before and after refactoring, integration tests for API compatibility
```

## Quick Reference Templates

### 10. Unit Test Template
```
// Template: Unit Test Suite
// Class Under Test: [ClassName]
// Method: [MethodName] (or "All methods" for complete suite)
// Test Framework: [xUnit, NUnit, MSTest]
// Mocking: [Moq, NSubstitute, etc.]
// Test Categories: [Happy path, edge cases, error conditions]
// Coverage Goal: [Percentage or specific scenarios]
// Dependencies: [What needs to be mocked]

Example:
// Template: Unit Test Suite
// Class Under Test: UserService
// Method: All methods
// Test Framework: xUnit with AutoFixture
// Mocking: Moq for dependencies
// Test Categories: Valid inputs, null/empty inputs, business rule violations, repository exceptions
// Coverage Goal: 95%+ line coverage, all business scenarios
// Dependencies: Mock IUserRepository, IEmailService, ILogger
```

### 11. Database Query Template
```
// Template: Database Query Optimization
// Current Query: [SQL or LINQ query]
// Purpose: [What the query accomplishes]
// Performance Issue: [Slow execution, high resource usage, etc.]
// Data Volume: [Table sizes, expected result sizes]
// Requirements: [Sorting, filtering, paging, etc.]
// Database: [SQL Server, PostgreSQL, etc.]
// ORM: [Entity Framework, Dapper, etc.]

Example:
// Template: Database Query Optimization
// Current Query: [Complex LINQ with multiple joins]
// Purpose: Get orders with customer details and order items for reporting
// Performance Issue: 30+ second execution time with 100k+ orders
// Data Volume: 500k orders, 2M order items, 10k customers
// Requirements: Filter by date range, sort by order date, page results (50 per page)
// Database: SQL Server 2019
// ORM: Entity Framework Core 8
```

## Usage Tips

### How to Use Templates
1. **Copy the template** that matches your scenario
2. **Fill in the bracketed placeholders** with your specific information
3. **Customize** the template for your exact needs
4. **Add additional context** if needed
5. **Use with any Copilot mode** (Chat, Edit, or Agent)

### Template Customization
- **Add your own sections** for team-specific requirements
- **Modify examples** to match your technology stack
- **Create variations** for different complexity levels
- **Build template libraries** for common project patterns

### Best Practices
- **Be specific** when filling in template fields
- **Provide context** about your project and constraints
- **Include examples** when helpful
- **Iterate and refine** templates based on results
- **Share successful templates** with your team

## Creating Your Own Templates

### Template Creation Process
1. **Identify patterns** in your prompting
2. **Extract common elements** across similar requests
3. **Create reusable structure** with placeholders
4. **Test with multiple scenarios** to ensure flexibility
5. **Refine based on results** and feedback

### Template Structure Guidelines
- **Clear purpose** - what the template is for
- **Required fields** - essential information needed
- **Optional fields** - additional context that might help
- **Examples** - show how to use the template effectively
- **Variations** - different ways to apply the template

Start building your personal template library and watch your Copilot effectiveness soar! 🚀
