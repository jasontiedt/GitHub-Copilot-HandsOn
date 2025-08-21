# xUnit Testing with AI-Assisted Development Lab

## 🎯 Learning Objectives
By the end of this lab, you will:
- Understand xUnit testing principles and patterns
- Write effective unit tests using xUnit.net
- Learn to use AI prompts to generate and improve tests
- Practice test-driven development (TDD) with AI assistance
- Understand test coverage and quality metrics

## 📋 Prerequisites
- Basic C# knowledge
- .NET 8.0 SDK installed
- Visual Studio Code with C# extension
- GitHub Copilot enabled

## 🏗️ Lab Structure

### Part 1: Getting Started (15 minutes)
- Set up the project
- Understand the codebase
- Run existing tests

### Part 2: Basic xUnit Testing (30 minutes)
- Write simple unit tests
- Use AI to generate test cases
- Understand Arrange-Act-Assert pattern

### Part 3: Advanced Testing Scenarios (45 minutes)
- Test edge cases and exceptions
- Mock dependencies
- Parameterized tests
- Use AI for complex test scenarios

### Part 4: Test-Driven Development (30 minutes)
- Write failing tests first
- Implement code to make tests pass
- Refactor with confidence

## 🚀 Getting Started

1. Navigate to the lab directory:
   ```bash
   cd xUnit-AI-Lab
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the existing tests:
   ```bash
   dotnet test
   ```

## 📁 Project Structure
```
xUnit-AI-Lab/
├── src/
│   ├── Library/
│   │   ├── Calculator.cs           # Basic calculator
│   │   ├── BankAccount.cs          # Bank account with business logic
│   │   ├── ShoppingCart.cs         # E-commerce cart functionality
│   │   └── WeatherService.cs       # External API simulation
├── tests/
│   ├── Library.Tests/
│   │   ├── CalculatorTests.cs      # Basic test examples
│   │   ├── BankAccountTests.cs     # Partial tests (you complete)
│   │   ├── ShoppingCartTests.cs    # Empty (you create)
│   │   └── WeatherServiceTests.cs  # Mock examples
├── .vscode/
│   └── custom-instructions.md      # AI prompting guidelines
├── xUnit-AI-Lab.sln
└── README.md
```

## 🤖 AI Prompting Tips

Before starting, review the custom instructions in `.vscode/custom-instructions.md` to learn effective AI prompting for test development.

## 📝 Lab Exercises

### Exercise 1: Complete Basic Tests
Open `tests/Library.Tests/CalculatorTests.cs` and examine the existing tests. Use AI to help you add tests for:
- Division by zero scenarios
- Large number calculations
- Negative number operations

### Exercise 2: Business Logic Testing
In `tests/Library.Tests/BankAccountTests.cs`, complete the test suite for the bank account class:
- Account creation and initialization
- Deposit and withdrawal operations
- Overdraft scenarios
- Transaction history

### Exercise 3: E-commerce Cart Testing
Create comprehensive tests for `ShoppingCart.cs` in `tests/Library.Tests/ShoppingCartTests.cs`:
- Adding/removing items
- Calculating totals and discounts
- Handling empty cart scenarios
- Bulk operations

### Exercise 4: Mocking External Dependencies
In `tests/Library.Tests/WeatherServiceTests.cs`, learn to test code with external dependencies:
- Mock HTTP clients
- Test error handling
- Verify retry logic

## 🎯 Success Criteria
- [ ] All tests pass (`dotnet test`)
- [ ] Test coverage > 90% (`dotnet test --collect:"XPlat Code Coverage"`)
- [ ] No code smells in test files
- [ ] Tests follow AAA pattern
- [ ] Edge cases are covered

## 📚 Additional Resources
- [xUnit.net Documentation](https://xunit.net/)
- [.NET Testing Best Practices](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
- [Moq Framework Documentation](https://github.com/moq/moq4)

## 🏁 Next Steps
After completing this lab, try:
- Integration testing
- Performance testing
- Property-based testing with FsCheck
