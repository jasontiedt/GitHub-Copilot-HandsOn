# Custom Instructions for xUnit Testing with AI

This file contains guidelines and examples for using AI effectively when developing xUnit tests. These instructions will help you get better results from AI assistants like GitHub Copilot.

## 🎯 General AI Prompting Principles

### Be Specific and Clear
- ✅ **Good**: "Generate xUnit tests for the Withdraw method that test insufficient funds scenarios"
- ❌ **Bad**: "Write some tests"

### Use Domain-Specific Language
- Include testing terminology: "unit test", "integration test", "mock", "AAA pattern"
- Mention xUnit-specific features: "Theory", "InlineData", "Fact", "Assert"

### Provide Context
- Mention the class/method you're testing
- Describe the expected behavior
- Include any constraints or edge cases

## 🧪 xUnit Testing Prompts

### Basic Test Generation
```
Generate xUnit tests for the Calculator.Add method that:
- Test normal positive numbers
- Test negative numbers
- Test zero values
- Use the AAA pattern
- Include descriptive test names
```

### Exception Testing
```
Create xUnit tests for the BankAccount.Withdraw method that verify:
- ArgumentException is thrown for negative amounts
- InvalidOperationException is thrown for insufficient funds
- Use Assert.Throws<T> pattern
- Test exception messages are correct
```

### Parameterized Tests
```
Write xUnit Theory tests for the Calculator.Divide method using:
- InlineData attribute for multiple test cases
- Include edge cases like dividing by 1, dividing 0
- Test both positive and negative scenarios
- Verify precision for decimal results
```

### Mocking External Dependencies
```
Generate xUnit tests for WeatherService.GetCurrentWeatherAsync that:
- Mock the HttpClient using Moq framework
- Test successful API responses
- Test network failure scenarios
- Verify retry logic is working
- Use async/await patterns correctly
```

### Test Organization
```
Help me organize tests for the ShoppingCart class by:
- Creating test classes for different functionalities
- Grouping related tests together
- Adding helpful comments explaining test scenarios
- Following consistent naming conventions
```

## 🛠️ Code Quality Prompts

### Improving Test Coverage
```
Analyze the existing tests for [ClassName] and suggest:
- Missing test scenarios
- Edge cases not covered
- Boundary value tests
- Error condition tests
```

### Refactoring Tests
```
Refactor these tests to:
- Remove code duplication
- Add helper methods for common setup
- Improve test readability
- Follow DRY principles
```

### Test Data Generation
```
Create test data builders for:
- Product objects with various properties
- BankAccount instances with different states
- Complex object graphs for integration tests
- Random test data generators
```

## 📋 Test Patterns and Examples

### AAA Pattern Template
```csharp
[Fact]
public void MethodName_Scenario_ExpectedBehavior()
{
    // Arrange - Set up test data and dependencies
    
    // Act - Execute the method under test
    
    // Assert - Verify the results
}
```

### Theory Test Template
```csharp
[Theory]
[InlineData(input1, input2, expectedResult)]
[InlineData(input1, input2, expectedResult)]
public void MethodName_WithVariousInputs_ReturnsExpectedResults(
    InputType param1, 
    InputType param2, 
    ExpectedType expected)
{
    // Arrange
    
    // Act
    
    // Assert
}
```

### Exception Test Template
```csharp
[Fact]
public void MethodName_InvalidCondition_ThrowsExpectedException()
{
    // Arrange
    
    // Act & Assert
    Assert.Throws<ExceptionType>(() => methodCall);
}
```

### Mock Setup Template
```csharp
[Fact]
public async Task AsyncMethod_MockedDependency_ReturnsExpectedResult()
{
    // Arrange
    var mockDependency = new Mock<IDependency>();
    mockDependency.Setup(x => x.Method(It.IsAny<Parameter>()))
              .ReturnsAsync(expectedValue);
    
    var sut = new SystemUnderTest(mockDependency.Object);
    
    // Act
    var result = await sut.MethodUnderTest();
    
    // Assert
    Assert.Equal(expectedResult, result);
    mockDependency.Verify(x => x.Method(It.IsAny<Parameter>()), Times.Once);
}
```

## 🚀 Advanced Prompting Techniques

### Behavior-Driven Prompts
```
Generate tests that verify the behavior:
"Given a bank account with $100 balance
When I withdraw $150
Then it should throw an insufficient funds exception
And the balance should remain $100"
```

### Performance Testing
```
Create xUnit tests that verify:
- Methods complete within acceptable time limits
- Memory usage stays within bounds
- No memory leaks in object creation
- Concurrent access scenarios work correctly
```

### Integration Testing
```
Write integration tests that:
- Test end-to-end workflows
- Verify component interactions
- Use real dependencies where appropriate
- Test configuration and startup scenarios
```

## 🔍 Debugging and Troubleshooting Prompts

### Test Failure Analysis
```
Help me debug why this test is failing:
[paste failing test code]
The error message is: [error message]
What could be causing this issue?
```

### Flaky Test Investigation
```
This test passes sometimes and fails other times:
[test code]
Help me identify potential causes:
- Timing issues
- Shared state problems
- Random data dependencies
- Async operation issues
```

## ✅ Best Practices Checklist

When working with AI for test generation, ensure:

- [ ] Tests follow the AAA pattern consistently
- [ ] Test names clearly describe the scenario and expected outcome
- [ ] Each test focuses on a single behavior
- [ ] Edge cases and boundary conditions are covered
- [ ] Exception scenarios are tested appropriately
- [ ] Mock objects are used for external dependencies
- [ ] Tests are deterministic and don't rely on external state
- [ ] Performance tests have appropriate timeouts
- [ ] Integration tests clean up after themselves

## 📚 Useful xUnit Assertions Reference

```csharp
// Equality
Assert.Equal(expected, actual);
Assert.NotEqual(expected, actual);

// Null checks
Assert.Null(value);
Assert.NotNull(value);

// Boolean assertions
Assert.True(condition);
Assert.False(condition);

// String assertions
Assert.Contains("substring", actualString);
Assert.StartsWith("prefix", actualString);
Assert.EndsWith("suffix", actualString);

// Collection assertions
Assert.Empty(collection);
Assert.NotEmpty(collection);
Assert.Single(collection);
Assert.Contains(item, collection);

// Exception assertions
Assert.Throws<ExceptionType>(() => methodCall);
var ex = Assert.Throws<ExceptionType>(() => methodCall);
Assert.Equal("expected message", ex.Message);

// Async assertions
await Assert.ThrowsAsync<ExceptionType>(() => asyncMethod());

// Numeric assertions (with tolerance)
Assert.Equal(expected, actual, precision: 2);
```

## 🎓 Learning Resources

- [xUnit Documentation](https://xunit.net/)
- [Moq Documentation](https://github.com/moq/moq4)
- [.NET Testing Best Practices](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
- [Test-Driven Development Guide](https://docs.microsoft.com/en-us/visualstudio/test/quick-start-test-driven-development-with-test-explorer)
