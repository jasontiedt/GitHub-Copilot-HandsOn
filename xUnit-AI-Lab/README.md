# xUnit Testing with AI Lab 🧪

Master test-driven development with AI assistance! Learn to write comprehensive, effective unit tests using xUnit and GitHub Copilot for professional software development.

## 🎯 What You'll Learn

- **xUnit Testing Fundamentals** - Master the essential testing framework for .NET
- **AI-Assisted Test Generation** - Use Copilot to write comprehensive test suites quickly
- **Test-Driven Development (TDD)** - Practice TDD workflows with AI guidance
- **Test Quality and Coverage** - Create thorough, maintainable tests with AI help
- **Professional Testing Patterns** - Learn industry-standard testing approaches
- **Advanced Testing Scenarios** - Handle mocking, async code, and edge cases

**⏱️ Duration**: 1-1.5 hours | **📊 Difficulty**: Beginner to Intermediate

## 🏁 Quick Start (5 minutes)

### Prerequisites Check ✅
- **.NET 8 SDK** installed
- **VS Code** with **C# extension**
- **GitHub Copilot** active and working
- **Basic C# knowledge** (classes, methods, properties)

### Get Your Testing Environment Ready
1. **Navigate to** `xUnit-AI-Lab/`
2. **Open** `xUnit-AI-Lab.sln` in VS Code
3. **Restore packages**: Press `Ctrl+Shift+P` → "Tasks: Run Task" → "build"
4. **Run existing tests**: Press `Ctrl+Shift+P` → "Tasks: Run Task" → "test"

### Your First AI-Generated Test (3 minutes)
1. **Open** `tests/Library.Tests/CalculatorTests.cs`
2. **Find** the empty test method for division
3. **Try your own prompt**: Think about what you want to test, then ask AI to help
4. **Example approach**: "I need to test a calculator division method. What scenarios should I cover?"
5. **Watch** as AI helps you think through the testing approach
6. **Run tests** to see them pass ✅

## 📚 Learning Philosophy

### 🧠 **Learn by Doing, Not Following**
This lab emphasizes **developing your own AI prompting skills** rather than following pre-written prompts. You'll:

- **🤔 Think First**: Analyze what needs testing before asking AI
- **🤖 Experiment**: Try different ways to ask AI for help
- **🔄 Iterate**: Improve your prompts based on results
- **🎯 Build Independence**: Develop your own testing strategies

### 🎯 **AI as a Partner, Not a Crutch**
- **Guidance Available**: Hints provided when you're stuck
- **Self-Discovery Encouraged**: Try your own approaches first
- **Critical Thinking**: Evaluate and improve AI suggestions
- **Pattern Recognition**: Learn to spot good vs. poor AI responses

## 📚 Learning Path

### 🎯 Focused Track (1-1.5 hours)
**Perfect for developers wanting practical unit testing skills with AI assistance**

**Exercise 1: Calculator Tests** (20 minutes)
- Learn basic xUnit attributes and assertions
- Develop your own AI prompting strategies for testing
- Practice analyzing what needs to be tested before asking AI
- **Skills**: Test fundamentals, independent AI prompting

**Exercise 2: Business Logic Tests** (25 minutes)
- Create comprehensive tests for complex business rules using your own prompts
- Learn to think through edge cases before consulting AI
- Practice different approaches to asking AI for testing help
- **Skills**: Business logic testing, prompting experimentation

**Exercise 3: TDD with AI** (25 minutes)
- Practice test-driven development with AI as a collaborator
- Create tests first using your own analysis and AI guidance
- Learn advanced testing patterns through exploration
- **Skills**: TDD workflow, independent problem-solving, AI partnership

**⏱️ Total Duration**: 1-1.5 hours | **📊 Difficulty**: Beginner to Intermediate

### 🟡 Intermediate Track (2-2.5 hours)
**Continue after mastering basic testing**

**Advanced Testing Patterns** (45 minutes)
- Learn parameterized tests and test fixtures
- Handle async code and exception testing
- Use test data and theory attributes effectively
- **Skills**: Advanced xUnit features, complex scenarios

**Test-Driven Development** (45 minutes)
- Practice Red-Green-Refactor cycle with AI
- Write tests first, then implement functionality
- Use AI to guide both test and production code
- **Skills**: TDD methodology, design through testing

### 🔴 Advanced Track (3-4 hours)
**Master-level testing techniques**

## 🚀 Exercise Overview

| Exercise Area | Focus | Difficulty | Time | Skills Learned |
|---------------|-------|------------|------|----------------|
| **Calculator Tests** | Basic xUnit & AI | 🟢 Beginner | 30 min | Fundamentals, assertions |
| **BankAccount Tests** | State-based Testing | 🟢 Beginner | 30 min | Object state, validation |
| **ShoppingCart Tests** | Complex Scenarios | 🟡 Intermediate | 45 min | Collections, business logic |
| **WeatherService Tests** | Async & Mocking | 🔴 Advanced | 60 min | Async testing, dependencies |

## 💡 AI Testing Strategies

### Effective Prompting for Test Generation
- **Be specific about scenarios**: "Generate tests for the Add method including null inputs, negative numbers, and overflow cases"
- **Request comprehensive coverage**: "Create xUnit tests that cover all edge cases for this shopping cart functionality"
- **Ask for test patterns**: "Show me how to write parameterized tests for this validation method"
- **Seek explanation**: "Explain why this test approach is better than that one"

### AI-Assisted TDD Workflow
1. **📝 Describe requirements** - "I need a method that calculates compound interest"
2. **🤖 Generate test first** - Ask AI to create failing tests based on requirements
3. **🔴 Run tests (RED)** - Verify tests fail as expected
4. **🤖 Implement code** - Use AI to suggest minimal implementation to pass tests
5. **🟢 Run tests (GREEN)** - Verify tests now pass
6. **🔄 Refactor with AI** - Ask AI to improve code while keeping tests green

## 🗂️ Test Scenarios by Component

### 📂 Calculator (`CalculatorTests.cs`)
**Perfect starting point for testing fundamentals**
- **➕ Basic Operations** - Add, subtract, multiply, divide
- **🚫 Edge Cases** - Division by zero, overflow scenarios
- **✅ Validation** - Input parameter validation
- **🎯 Learning Focus**: Basic assertions, exception testing

### 📂 BankAccount (`BankAccountTests.cs`)
**Learn state-based testing and business rules**
- **💰 Account Operations** - Deposit, withdraw, balance checking
- **🛡️ Business Rules** - Overdraft protection, minimum balances
- **📊 State Validation** - Account status changes
- **🎯 Learning Focus**: Object state testing, business logic validation

### 📂 ShoppingCart (`ShoppingCartTests.cs`)
**Master complex object interactions**
- **🛒 Cart Operations** - Add items, remove items, calculate totals
- **💳 Discount Logic** - Coupons, bulk discounts, pricing rules
- **📦 Complex Scenarios** - Multiple items, quantity changes
- **🎯 Learning Focus**: Collection testing, complex business scenarios

### 📂 WeatherService (`WeatherServiceTests.cs`)
**Advanced testing with external dependencies**
- **🌐 Async Operations** - API calls, timeout handling
- **🎭 Mocking Dependencies** - External service simulation
- **⚠️ Error Scenarios** - Network failures, invalid responses
- **🎯 Learning Focus**: Async testing, mocking, integration patterns

## 🎯 Professional Testing Best Practices

### Test Organization and Naming
- **Use descriptive test names**: `CalculateTotal_WithValidItems_ReturnsCorrectSum()`
- **Follow AAA pattern**: Arrange, Act, Assert
- **Group related tests**: Use test classes and nested classes effectively
- **Use meaningful assertions**: Clear, specific assertion messages

### AI-Enhanced Test Quality
- **Ask for edge cases**: "What edge cases should I test for this method?"
- **Request test reviews**: "How can I improve the quality of these tests?"
- **Get coverage guidance**: "What test scenarios am I missing for complete coverage?"
- **Seek maintainability tips**: "How can I make these tests more maintainable?"

## 🆘 Need Help?

- **xUnit Questions?** → Check `LAB-EXERCISES.md` for detailed instructions
- **AI Prompting for Tests?** → Read the prompting examples in each test file
- **Stuck on Advanced Topics?** → See `INSTRUCTOR-GUIDE.md` for additional guidance
- **Want More Practice?** → Try creating tests for additional scenarios

## 🎯 Learning Outcomes

By completing this lab, you'll be able to:
- ✅ **Write comprehensive unit tests** using xUnit framework
- ✅ **Generate effective tests with AI** using proper prompting techniques
- ✅ **Practice test-driven development** with AI as your pair programming partner
- ✅ **Handle complex testing scenarios** including async code and mocking
- ✅ **Apply professional testing patterns** and best practices
- ✅ **Achieve high test coverage** with meaningful, maintainable tests
- ✅ **Use AI to improve test quality** and identify missing test cases

## 🚀 Ready to Start Testing?

**Begin your journey to testing mastery!**

1. **Open** `LAB-EXERCISES.md` for step-by-step instructions
2. **Start with** `CalculatorTests.cs` to learn the fundamentals
3. **Progress systematically** through each component
4. **Remember**: Good tests are as important as good code - let AI help you write both!

**Happy testing! 🧪✅**
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
- **Recommended Next Lab**: `../AI-Code-Fixing-Lab` - Apply your AI and testing skills to fix problematic code
- Integration testing
- Performance testing
- Property-based testing with FsCheck
