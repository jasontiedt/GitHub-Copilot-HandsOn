# The Complete Guide to GitHub Copilot Prompting

## Table of Contents
1. [Prompting Fundamentals](#prompting-fundamentals)
2. [Prompting Styles](#prompting-styles)
3. [Context Optimization](#context-optimization)
4. [Model-Specific Strategies](#model-specific-strategies)
5. [Advanced Techniques](#advanced-techniques)
6. [Common Patterns](#common-patterns)

## Prompting Fundamentals

### The Anatomy of a Good Prompt

A well-crafted prompt includes:
1. **Clear Intent**: What you want to accomplish
2. **Specific Context**: Relevant information for the task
3. **Constraints**: Limitations, requirements, or preferences
4. **Examples**: Sample inputs/outputs when helpful
5. **Format Specification**: How you want the response structured

### Basic Prompting Principles

1. **Be Specific**: Vague prompts yield vague results
2. **Provide Context**: Include relevant background information
3. **Set Constraints**: Specify language, framework, patterns to use/avoid
4. **Iterate and Refine**: Start broad, then narrow down
5. **Use Examples**: Show rather than tell when possible

## Prompting Styles

### 1. Instructional Prompting
Direct, command-style prompts that tell Copilot exactly what to do.

**Example**:
```
// Create a REST API controller for user management with CRUD operations
// Use ASP.NET Core, include input validation, and return appropriate HTTP status codes
```

**Best for**: 
- Specific implementation tasks
- When you know exactly what you want
- Standard patterns and boilerplate code

### 2. Conversational Prompting
Natural language prompts that feel like talking to a colleague.

**Example**:
```
// I need help building a shopping cart feature. The cart should store items temporarily,
// calculate totals including tax, and handle quantity updates. What's the best approach?
```

**Best for**:
- Exploratory development
- Getting design suggestions
- Understanding complex problems

### 3. Example-Driven Prompting
Show Copilot examples of what you want, then ask for similar implementations.

**Example**:
```
// Here's how I handle user authentication:
// public async Task<bool> AuthenticateAsync(string email, string password) { ... }
// 
// Now create a similar method for password reset functionality
```

**Best for**:
- Maintaining consistency with existing code
- Complex patterns that are hard to describe
- API design and interface implementation

### 4. Problem-Solution Prompting
Describe a problem and let Copilot propose solutions.

**Example**:
```
// Problem: Our API responses are slow because we're making multiple database calls
// Requirements: Reduce database round trips, maintain data accuracy
// Current approach: Individual queries for each related entity
// Looking for: Optimization strategies
```

**Best for**:
- Performance optimization
- Architecture decisions
- Debugging and troubleshooting

### 5. Step-by-Step Prompting
Break complex tasks into smaller, sequential steps.

**Example**:
```
// Step 1: Create a data model for blog posts
// Step 2: Add repository pattern for data access
// Step 3: Implement caching layer
// Step 4: Add API endpoints
// Let's start with Step 1:
```

**Best for**:
- Complex features with multiple components
- Learning new technologies
- Maintaining focus on specific aspects

### 6. Template-Based Prompting
Use predefined templates for common scenarios.

**Example**:
```
// Template: Unit Test
// Class Under Test: UserService
// Method: CreateUser
// Test Cases: Valid user, duplicate email, invalid data
// Framework: xUnit
// Generate comprehensive test suite:
```

**Best for**:
- Repetitive tasks
- Standard patterns (tests, DTOs, configs)
- Team consistency

## Context Optimization

### Providing Effective Context

1. **File Context**: Include relevant file contents or structure
2. **Project Context**: Mention frameworks, libraries, patterns in use
3. **Business Context**: Explain the domain and requirements
4. **Technical Context**: Specify constraints, performance needs, security requirements

### Context Examples

**Good Context**:
```
// Project: E-commerce platform using ASP.NET Core 8, Entity Framework, PostgreSQL
// Current file: OrderService.cs - handles order processing
// Need: Add method to calculate shipping cost based on weight, distance, and shipping method
// Business rules: Free shipping over $100, express shipping 2x cost, international shipping requires customs handling
```

**Poor Context**:
```
// Add shipping calculation
```

### Managing Context Size

- **Focus on Relevance**: Include only what's necessary for the current task
- **Use Summaries**: Summarize large codebases rather than including everything
- **Reference Patterns**: Point to existing patterns rather than repeating code
- **Progressive Disclosure**: Start with high-level context, add details as needed

## Model-Specific Strategies

### GPT-4 (Optimized for)
- **Complex reasoning tasks**
- **Architecture decisions**
- **Code reviews and optimization**
- **Multi-step problem solving**

**Prompting Strategy**:
- Provide comprehensive context
- Ask for reasoning behind suggestions
- Request multiple approaches
- Include performance and security considerations

### Claude (Optimized for)
- **Code analysis and refactoring**
- **Documentation and explanation**
- **Safety and security review**
- **Detailed technical writing**

**Prompting Strategy**:
- Request detailed explanations
- Ask for security considerations
- Seek code quality improvements
- Request comprehensive documentation

### Codex/GitHub Copilot (Optimized for)
- **Code completion and generation**
- **Pattern recognition**
- **Rapid prototyping**
- **Boilerplate generation**

**Prompting Strategy**:
- Use code comments as prompts
- Provide function signatures
- Show existing patterns
- Use descriptive variable/method names

## Advanced Techniques

### 1. Chain of Thought Prompting
Guide Copilot through reasoning steps.

```
// Let me think through this step by step:
// 1. Identify the performance bottleneck in this query
// 2. Analyze the execution plan
// 3. Propose indexing strategy
// 4. Suggest query optimization
// 5. Provide alternative approaches
```

### 2. Role-Based Prompting
Ask Copilot to take on specific expert roles.

```
// Act as a senior security engineer reviewing this authentication code.
// Focus on potential vulnerabilities, best practices, and compliance requirements.
```

### 3. Constraint-Based Prompting
Specify detailed constraints and requirements.

```
// Requirements:
// - Must be compatible with .NET 6+
// - No external dependencies beyond standard library
// - Thread-safe implementation required
// - Performance: <10ms for 1000 operations
// - Memory efficient: minimal allocations
```

### 4. Iterative Refinement
Build up complexity through multiple interactions.

```
// Start simple:
// Create basic user class with name and email

// Iteration 2:
// Add validation and password handling

// Iteration 3:
// Add role-based authorization
```

## Common Patterns

### Code Generation Patterns

1. **API Endpoint**:
```
// Create [HTTP_METHOD] endpoint for [RESOURCE]
// Include [VALIDATION], [AUTHORIZATION], [ERROR_HANDLING]
// Return [RESPONSE_FORMAT] with [STATUS_CODES]
```

2. **Data Model**:
```
// Create [ENTITY] model for [DOMAIN]
// Properties: [LIST_PROPERTIES]
// Relationships: [RELATIONSHIPS]
// Constraints: [VALIDATION_RULES]
```

3. **Service Class**:
```
// Create [SERVICE_NAME] service implementing [INTERFACE]
// Dependencies: [DEPENDENCIES]
// Methods: [METHOD_LIST]
// Error handling: [ERROR_STRATEGY]
```

### Debugging Patterns

1. **Issue Analysis**:
```
// Problem: [DESCRIPTION]
// Expected: [EXPECTED_BEHAVIOR]
// Actual: [ACTUAL_BEHAVIOR]
// Context: [RELEVANT_CODE/CONFIG]
// Help me debug this issue
```

2. **Performance Analysis**:
```
// Analyze this code for performance issues:
// [CODE_BLOCK]
// Focus on: [SPECIFIC_CONCERNS]
// Constraints: [PERFORMANCE_REQUIREMENTS]
```

### Refactoring Patterns

1. **Code Improvement**:
```
// Refactor this code to improve:
// - Readability
// - Performance
// - Maintainability
// - Testability
// Apply SOLID principles and modern C# features
```

2. **Pattern Application**:
```
// Apply [DESIGN_PATTERN] to this code:
// [EXISTING_CODE]
// Maintain existing functionality while improving structure
```

## Tips for Maximum Effectiveness

1. **Start with Clear Goals**: Know what you want before prompting
2. **Provide Rich Context**: Include relevant code, requirements, constraints
3. **Be Specific About Output**: Specify format, style, framework preferences
4. **Iterate and Refine**: Use follow-up prompts to improve results
5. **Combine Techniques**: Mix different prompting styles for complex tasks
6. **Learn from Results**: Analyze what works best for different scenarios
7. **Document Successful Patterns**: Build your own prompt library

## Next Steps

1. Practice with the exercises in `/exercises/`
2. Try different prompting styles with the same problem
3. Compare results across different models
4. Build your personal prompt template library
5. Experiment with combining multiple techniques

Remember: Effective prompting is a skill that improves with practice. Start simple, experiment often, and gradually build complexity!
