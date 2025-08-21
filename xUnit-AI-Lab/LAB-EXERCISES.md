# xUnit Testing Lab Exercises - Step by Step Guide

## 🚀 Exercise 1: Basic Calculator Tests (15 minutes)

### Goal
Learn basic xUnit testing patterns and use AI to extend test coverage.

### Steps
1. **Examine existing tests** in `CalculatorTests.cs`
2. **Run the tests** to see current coverage:
   ```bash
   dotnet test --logger "console;verbosity=detailed"
   ```

3. **Use AI to add missing tests**. Try these prompts:

   **Prompt 1: Edge Cases**
   ```
   Generate xUnit tests for Calculator.Divide that cover these edge cases:
   - Very large numbers
   - Very small decimal numbers
   - Dividing zero by a number
   - Dividing by very small numbers close to zero
   Use descriptive test names and the AAA pattern
   ```

   **Prompt 2: Parameterized Tests**
   ```
   Create Theory tests for Calculator.Multiply using InlineData that test:
   - Positive × Positive
   - Negative × Negative  
   - Positive × Negative
   - Zero scenarios
   - Decimal precision
   Include at least 8 test cases
   ```

4. **Verify your tests pass**:
   ```bash
   dotnet test tests/Library.Tests/CalculatorTests.cs
   ```

### Success Criteria
- [ ] All tests pass
- [ ] Added at least 5 new test methods
- [ ] Covered edge cases for division
- [ ] Used Theory tests with multiple scenarios

---

## 🏦 Exercise 2: Bank Account Business Logic (25 minutes)

### Goal
Complete comprehensive tests for business logic with validation rules.

### Steps
1. **Review the BankAccount class** in `src/Library/BankAccount.cs`
2. **Examine partial tests** in `BankAccountTests.cs`

3. **Complete constructor tests** using this prompt:
   ```
   Generate xUnit tests for BankAccount constructor that verify:
   - Empty/null account holder throws ArgumentException
   - Negative initial balance throws ArgumentException  
   - Zero initial balance creates account with no transactions
   - Valid parameters create account correctly
   Test both the exception message and exception type
   ```

4. **Add withdrawal tests** with this prompt:
   ```
   Create comprehensive xUnit tests for BankAccount.Withdraw method:
   - Valid withdrawal decreases balance correctly
   - Insufficient funds throws InvalidOperationException
   - Zero/negative amounts throw ArgumentException
   - Overdraft scenarios when IsOverdraftAllowed = true
   - Exceeding overdraft limit throws exception
   - Withdrawal creates correct transaction record
   Include edge cases and verify transaction history
   ```

5. **Add transfer tests** using AI:
   ```
   Generate xUnit tests for BankAccount.Transfer method that verify:
   - Successful transfer updates both account balances
   - Transfer to null account throws ArgumentNullException
   - Insufficient funds in source account throws exception
   - Transaction descriptions include account numbers
   - Transfer amount validation
   Use helper methods to create test accounts
   ```

6. **Run tests and fix any issues**:
   ```bash
   dotnet test tests/Library.Tests/BankAccountTests.cs -v normal
   ```

### Success Criteria
- [ ] All constructor validation tests pass
- [ ] Withdrawal logic fully tested
- [ ] Transfer functionality verified
- [ ] Transaction history tests included
- [ ] Overdraft scenarios covered

---

## 🛒 Exercise 3: E-commerce Shopping Cart TDD (30 minutes)

### Goal
Practice test-driven development by implementing tests first, then verifying against existing code.

### Steps
1. **Start with an empty test file** (`ShoppingCartTests.cs` has minimal content)

2. **Generate comprehensive test structure** with this prompt:
   ```
   Generate a complete xUnit test class for ShoppingCart with these test categories:
   
   1. Constructor & Properties Tests:
      - New cart is empty, has zero items
      - IsEmpty property works correctly
   
   2. Add Item Tests:
      - Adding valid product increases item count
      - Adding null product throws ArgumentNullException
      - Adding existing product increases quantity
      - Zero/negative quantity throws ArgumentException
   
   3. Remove Item Tests:
      - Removing existing item works
      - Removing non-existent item returns false
      - Partial quantity removal
      - Complete item removal
   
   4. Calculation Tests:
      - Subtotal calculation with multiple items
      - Discount application with valid/invalid codes
      - Total calculation with tax
      - Empty cart calculations return zero
   
   Use helper methods to create test products. Include Theory tests where appropriate.
   ```

3. **Add advanced scenarios** with this prompt:
   ```
   Add xUnit tests for ShoppingCart edge cases:
   - Products with zero price
   - Very large quantities
   - Decimal precision in price calculations
   - Multiple products same category
   - Cart summary functionality
   - Clearing cart operations
   Use parameterized tests for discount codes
   ```

4. **Run your tests** to verify they work with the existing implementation:
   ```bash
   dotnet test tests/Library.Tests/ShoppingCartTests.cs
   ```

5. **If tests fail**, use AI to debug:
   ```
   My ShoppingCart test is failing with this error: [paste error]
   Here's my test code: [paste test]
   Help me fix the test to match the actual ShoppingCart implementation
   ```

### Success Criteria
- [ ] Complete test coverage for all public methods
- [ ] Tests verify business rules (discounts, tax calculation)
- [ ] Edge cases handled properly
- [ ] Helper methods reduce code duplication
- [ ] All tests pass with existing implementation

---

## 🌤️ Exercise 4: Mocking External Dependencies (25 minutes)

### Goal
Learn to test code with external dependencies using Moq framework.

### Steps
1. **Study the existing WeatherService tests** to understand mocking patterns

2. **Add HTTP timeout tests** with this prompt:
   ```
   Generate xUnit tests for WeatherService that test timeout scenarios:
   - HTTP request timeout throws WeatherServiceException
   - Cancelled operations handle CancellationToken properly
   - Long-running requests are cancelled appropriately
   Use Moq to simulate network delays and timeouts
   ```

3. **Test retry logic thoroughly** using this prompt:
   ```
   Create xUnit tests that verify WeatherService retry behavior:
   - Verify exact number of retry attempts (should be 3)
   - Test exponential backoff timing between retries
   - Ensure successful request on retry stops further attempts
   - Verify different HTTP status codes trigger appropriate behavior
   Use Mock.Verify to check call counts and timing
   ```

4. **Add malformed response tests**:
   ```
   Generate tests for WeatherService handling invalid responses:
   - Malformed JSON throws appropriate exception
   - Empty response body handling
   - Missing required fields in JSON
   - Invalid data types in response
   Mock HttpClient to return various malformed responses
   ```

5. **Verify HTTP request details**:
   ```
   Create tests that verify WeatherService makes correct HTTP requests:
   - Correct URL format with API key and city
   - Proper URL encoding for city names with spaces/special chars
   - Request headers are set correctly
   - HTTP method is GET
   Use ItExpr.Is<HttpRequestMessage> to verify request properties
   ```

6. **Run and validate your tests**:
   ```bash
   dotnet test tests/Library.Tests/WeatherServiceTests.cs -v normal
   ```

### Success Criteria
- [ ] Mock setup correctly simulates HTTP responses
- [ ] Retry logic thoroughly tested
- [ ] Exception scenarios covered
- [ ] HTTP request verification included
- [ ] Async patterns handled properly

---

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
