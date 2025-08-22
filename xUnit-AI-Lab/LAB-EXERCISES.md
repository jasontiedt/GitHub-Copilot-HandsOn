# xUnit Testing Lab Exercises - Step by Step Guide

**⏱️ Duration**: 1-1.5 hours | **📊 Difficulty**: Beginner to Intermediate

## 🚀 Exercise 1: Basic Calculator Tests (20 minutes)

### Goal
Learn basic xUnit testing patterns and develop your own AI prompting skills for test generation.

### Steps
1. **Examine existing tests** in `CalculatorTests.cs`
2. **Run the tests** to see current coverage:
   ```bash
   dotnet test --logger "console;verbosity=detailed"
   ```

3. **🤖 Your AI Challenge**: Use your own prompts to add missing tests
   - Look at the `Calculator.Divide` method - what edge cases need testing?
   - Think about the `Calculator.Multiply` method - what scenarios should be covered?
   - **Try writing your own prompts first** before looking at the hints below!
   
   💡 **Your Task**: Create tests for:
   - Division edge cases (large numbers, small decimals, zero scenarios)
   - Multiplication with different number combinations
   - Use both regular `[Fact]` tests and `[Theory]` tests with `[InlineData]`

4. **Verify your tests pass**:
   ```bash
   dotnet test tests/Library.Tests/CalculatorTests.cs
   ```

   <details>
   <summary>💡 Click here if you need prompting hints</summary>
   
   **Hint for Edge Cases**:
   Try asking AI: "What edge cases should I test for a calculator division method?"
   
   **Hint for Parameterized Tests**:
   Try asking AI: "Help me create Theory tests for multiplication with different scenarios"
   
   **Hint for Test Structure**:
   Try asking AI: "Show me how to write xUnit tests using the AAA pattern"
   </details>

### Success Criteria
- [ ] All tests pass
- [ ] Added at least 3 new test methods using your own AI prompts
- [ ] Covered edge cases for division
- [ ] Used Theory tests with multiple scenarios
- [ ] Demonstrated understanding of effective AI prompting

---

## 🏦 Exercise 2: Bank Account Business Logic (25 minutes)

### Goal
Complete comprehensive tests for business logic with validation rules using your own AI prompting skills.

### Steps
1. **Review the BankAccount class** in `src/Library/BankAccount.cs`
2. **Examine partial tests** in `BankAccountTests.cs`

3. **🤖 Your AI Challenge**: Create comprehensive tests using your own prompts
   
   **Think about these scenarios first**:
   - What should happen when creating a BankAccount with invalid parameters?
   - How should withdrawals behave with insufficient funds?
   - What edge cases exist for transfers between accounts?
   
   💡 **Your Task**: Write AI prompts to generate tests for:
   - Constructor validation (null names, negative balances, etc.)
   - Withdrawal edge cases (insufficient funds, invalid amounts)
   - Transfer functionality (null accounts, insufficient funds, transaction records)

4. **Experiment with different prompt styles**:
   - Try asking for specific test categories
   - Request tests that cover both success and failure scenarios
   - Ask for tests that verify transaction history

5. **Run tests and fix any issues**:
   ```bash
   dotnet test tests/Library.Tests/BankAccountTests.cs -v normal
   ```

   <details>
   <summary>💡 Click here if you need prompting guidance</summary>
   
   **Constructor Testing Hint**:
   Try asking: "What validation should I test for a BankAccount constructor?"
   
   **Business Logic Hint**:
   Try asking: "Help me create tests for withdrawal methods that handle business rules"
   
   **Transfer Testing Hint**:
   Try asking: "What scenarios should I test when transferring money between bank accounts?"
   
   **Exception Testing Hint**:
   Try asking: "Show me how to test that specific exceptions are thrown in xUnit"
   </details>

### Success Criteria
- [ ] All constructor validation tests pass
- [ ] Withdrawal logic fully tested using your own AI prompts
- [ ] Transfer functionality verified
- [ ] Transaction history tests included
- [ ] Demonstrated creative and effective AI prompting

---

## 🛒 Exercise 3: E-commerce Shopping Cart TDD (25 minutes)

### Goal
Practice test-driven development by implementing tests first using your own AI prompting strategies.

### Steps
1. **Start with an empty test file** (`ShoppingCartTests.cs` has minimal content)

2. **🤖 Your AI Challenge**: Create a complete test suite using TDD principles
   
   **Think about the ShoppingCart functionality**:
   - How should an empty cart behave?
   - What happens when you add/remove items?
   - How should calculations work (subtotal, tax, total)?
   - What edge cases exist?

3. **Develop your own prompting strategy**:
   - Start by asking AI to help you understand what to test
   - Request test structure and organization advice
   - Ask for specific test scenarios based on your analysis
   - Experiment with different ways to phrase your requests

   💡 **Your Task**: Create comprehensive tests for:
   - Cart initialization and properties
   - Adding items (valid products, duplicates, invalid inputs)
   - Removing items (existing, non-existent, partial removal)
   - Price calculations (empty cart, multiple items, edge cases)

4. **Practice different prompting techniques**:
   - Ask for test categories first, then specific tests
   - Request both positive and negative test scenarios
   - Try asking for helper methods to make tests cleaner
   - Experiment with asking for Theory tests vs individual Facts

5. **Verify against the existing implementation**:
   ```bash
   dotnet test tests/Library.Tests/ShoppingCartTests.cs -v normal
   ```

   <details>
   <summary>💡 Click here for prompting strategy hints</summary>
   
   **Getting Started Hint**:
   Try asking: "What should I test for an e-commerce shopping cart class?"
   
   **Test Organization Hint**:
   Try asking: "How should I organize xUnit tests for a shopping cart with multiple methods?"
   
   **Edge Cases Hint**:
   Try asking: "What edge cases should I consider when testing shopping cart functionality?"
   
   **TDD Approach Hint**:
   Try asking: "Help me write tests first for shopping cart functionality using TDD approach"
   
   </details>

### Success Criteria
- [ ] All tests pass using your own AI-generated prompts
- [ ] Created comprehensive test structure through TDD approach
- [ ] Covered all major shopping cart functionality
- [ ] Used effective helper methods and test organization
- [ ] Demonstrated mastery of AI prompting for testing scenarios
- [ ] Successfully applied test-driven development principles

---

## � Bonus Challenge: Advanced Testing Scenarios (Optional)

### Goal
For students who finish early - explore advanced testing concepts with AI assistance.

### Your AI Exploration Challenge
**Pick one area to explore using your own AI prompts**:

1. **Async Testing**: How would you test async methods in the codebase?
2. **Exception Testing**: What's the best way to verify specific exceptions are thrown?
3. **Performance Testing**: How could you write tests that verify performance requirements?
4. **Integration Testing**: How would you test multiple components working together?

**🤖 Your Mission**: 
- Formulate your own questions about advanced testing scenarios
- Use AI to learn about xUnit features you haven't used yet
- Try implementing one advanced testing pattern you discover
- Experiment with different ways to ask AI for testing advice

   <details>
   <summary>💡 Click here for exploration ideas</summary>
   
   **Async Testing Ideas**:
   - "How do I test async methods in xUnit?"
   - "Show me best practices for testing async/await code"
   
   **Exception Testing Ideas**:
   - "What's the difference between Assert.Throws and Assert.ThrowsAsync?"
   - "How can I verify exception messages in xUnit tests?"
   
   **Performance Testing Ideas**:
   - "How can I write tests that verify method execution time?"
   - "Show me how to test memory usage in xUnit"
   
   **Integration Testing Ideas**:
   - "How do I test multiple classes working together in xUnit?"
   - "What's the difference between unit tests and integration tests?"
   </details>

---

## 📈 Success Metrics

After completing all exercises, you should have:
- ✅ Mastered AI prompting for test generation
- ✅ Created comprehensive test coverage using your own prompts
- ✅ Applied TDD principles with AI assistance
- ✅ Developed confidence in xUnit testing patterns
- ✅ Demonstrated creative problem-solving with AI
- ✅ Built well-organized, maintainable test code

## 🎓 What You've Learned

### Core Testing Skills:
- **xUnit Fundamentals**: Facts, Theories, Assertions, Test Organization
- **Test-Driven Development**: Red-Green-Refactor cycle with AI assistance
- **Edge Case Testing**: Comprehensive scenario coverage
- **Business Logic Validation**: Testing complex rules and workflows

### AI Integration Skills:
- **Effective Prompting**: How to ask AI for testing help
- **Independent Problem-Solving**: Developing your own prompting strategies
- **AI-Assisted TDD**: Using AI as a testing partner, not a crutch
- **Critical Thinking**: Evaluating and improving AI-generated code

### Next Steps:
1. **Apply these skills** to your own projects
2. **Experiment** with more advanced xUnit features
3. **Share your prompting strategies** with your team
4. **Continue practicing** AI-assisted development workflows

## 🎯 Exercise 5: Test Coverage Analysis (15 minutes)

### Goal
Analyze test coverage and identify gaps using AI assistance.

### Steps
1. **Generate coverage report**:
   ```bash
   dotnet test --collect:"XPlat Code Coverage"
   ```

2. **Use AI to analyze coverage gaps**:
   ```
   I want to analyze test coverage for my xUnit test suite. 
   Here are the classes I'm testing:
   - Calculator (basic math operations)
   - BankAccount (financial transactions)  
   - ShoppingCart (e-commerce functionality)
   - WeatherService (external API calls)
   
   What additional test scenarios should I consider to improve coverage?
   Focus on boundary conditions, error cases, and integration scenarios.
   ```

3. **Add integration tests** with this prompt:
   ```
   Generate integration tests that combine multiple classes:
   - Shopping scenario: Create account, add money, make purchases
   - Error handling: Network failures during weather-dependent shopping
   - Bulk operations: Multiple transactions, large cart operations
   Use real objects instead of mocks where appropriate
   ```

4. **Performance testing** with AI help:
   ```
   Create xUnit tests that verify performance characteristics:
   - ShoppingCart operations complete within reasonable time
   - BankAccount handles many transactions efficiently  
   - Memory usage doesn't grow excessively
   Use Assert with timeout values and measure execution time
   ```

### Success Criteria
- [ ] Coverage report generated and analyzed
- [ ] Integration tests added
- [ ] Performance characteristics verified
- [ ] Additional edge cases identified and tested

---

## 🏆 Bonus Challenges

### Challenge 1: Custom Assertions
```
Create custom xUnit assertion methods for:
- Verifying BankAccount balance within tolerance
- Checking ShoppingCart contains specific products
- Validating WeatherInfo data completeness
Make them reusable across test classes
```

### Challenge 2: Test Data Builders
```
Generate test data builder classes that:
- Create realistic Product objects with various properties
- Build BankAccount instances in different states
- Generate WeatherInfo objects for different scenarios
Use fluent APIs for easy test setup
```

### Challenge 3: Property-Based Testing
```
Research and implement property-based tests using FsCheck:
- Calculator operations maintain mathematical properties
- ShoppingCart operations preserve invariants
- BankAccount balance always reflects transaction history
Generate random test data automatically
```

## 📈 Success Metrics

After completing all exercises, you should have:
- ✅ 95%+ code coverage
- ✅ All tests passing consistently
- ✅ Comprehensive edge case testing
- ✅ Proper mocking of external dependencies
- ✅ Performance and integration tests
- ✅ Well-organized, maintainable test code

## 🎓 Next Steps

1. **Explore advanced xUnit features**: Custom attributes, test collections, fixtures
2. **Learn integration testing**: TestServer, WebApplicationFactory
3. **Try behavior-driven development**: SpecFlow, NBehave
4. **Performance testing**: BenchmarkDotNet, load testing
5. **Mutation testing**: Verify test quality with Stryker.NET
