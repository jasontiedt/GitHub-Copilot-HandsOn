# xUnit Testing with AI - Instructor Guide

## 📚 Lab Overview

This comprehensive lab teaches xUnit testing fundamentals while demonstrating effective AI-assisted development practices. Students learn to write quality unit tests using GitHub Copilot and other AI tools.

**Duration**: 2-3 hours  
**Prerequisites**: Basic C# knowledge, .NET 8.0 SDK, VS Code with C# extension  
**Key Tools**: xUnit.net, Moq, GitHub Copilot

## 🎯 Learning Objectives

By completing this lab, students will:
1. **Master xUnit fundamentals**: Facts, Theories, Assertions, AAA pattern
2. **Learn AI prompting**: Effective techniques for test generation with AI
3. **Practice TDD**: Write tests first, implement code to pass
4. **Handle dependencies**: Mock external services using Moq framework
5. **Ensure quality**: Achieve high test coverage and maintainable code

## 🗂️ Project Structure Explained

### Source Code (`src/Library/`)
- **Calculator.cs**: Simple math operations (basic testing concepts)
- **BankAccount.cs**: Business logic with validation (complex scenarios)
- **ShoppingCart.cs**: E-commerce functionality (integration testing)
- **WeatherService.cs**: External API calls (mocking dependencies)

### Test Code (`tests/Library.Tests/`)
- **CalculatorTests.cs**: Complete examples (students extend)
- **BankAccountTests.cs**: Partial implementation (students complete)
- **ShoppingCartTests.cs**: Starter template (students build from scratch)
- **WeatherServiceTests.cs**: Mocking examples (students add scenarios)

### Supporting Files
- **`.vscode/custom-instructions.md`**: AI prompting guidelines
- **`LAB-EXERCISES.md`**: Step-by-step exercise guide
- **`README.md`**: Project overview and setup instructions

## 🚀 Setup Instructions

### For Instructors
1. **Clone/download** the lab files to a shared location
2. **Verify prerequisites** are installed on student machines:
   ```bash
   dotnet --version  # Should be 8.0 or higher
   code --version    # VS Code installed
   ```
3. **Test the lab** by running:
   ```bash
   cd xUnit-AI-Lab
   dotnet restore
   dotnet build
   dotnet test
   ```

### For Students
1. **Navigate** to the lab directory
2. **Open in VS Code**: `code .`
3. **Restore packages**: `dotnet restore`
4. **Verify setup**: `dotnet test` (should see 35 passing tests)

## 📋 Exercise Breakdown

### Exercise 1: Calculator Tests (15 min)
**Focus**: Basic xUnit patterns, parameterized tests  
**AI Skills**: Simple prompts, edge case generation  
**Expected Output**: 8-10 additional test methods

**Key Teaching Points**:
- AAA pattern consistency
- Theory vs Fact usage
- Exception testing best practices
- Descriptive test naming

### Exercise 2: Bank Account Tests (25 min)
**Focus**: Business logic validation, complex scenarios  
**AI Skills**: Detailed prompts, validation testing  
**Expected Output**: Complete test coverage for BankAccount

**Key Teaching Points**:
- Testing business rules
- Exception message validation
- State verification
- Transaction history testing

### Exercise 3: Shopping Cart TDD (30 min)
**Focus**: Test-driven development, comprehensive coverage  
**AI Skills**: Generating full test suites, helper methods  
**Expected Output**: 20+ test methods covering all functionality

**Key Teaching Points**:
- TDD workflow (Red-Green-Refactor)
- Test organization and structure
- Helper method patterns
- Integration-style testing

### Exercise 4: Weather Service Mocking (25 min)
**Focus**: External dependencies, async testing  
**AI Skills**: Complex mocking scenarios, HTTP simulation  
**Expected Output**: Advanced mock tests with retry logic

**Key Teaching Points**:
- Moq framework usage
- Async/await testing patterns
- HTTP client mocking
- Retry logic verification

### Exercise 5: Coverage Analysis (15 min)
**Focus**: Quality metrics, gap analysis  
**AI Skills**: Coverage improvement suggestions  
**Expected Output**: 90%+ code coverage

**Key Teaching Points**:
- Coverage tool usage
- Identifying test gaps
- Performance testing basics
- Integration test strategies

## 🔧 Troubleshooting Guide

### Common Issues

**Build Errors**:
- Ensure .NET 8.0 SDK is installed
- Check project references are correct
- Verify NuGet packages restored properly

**Test Failures**:
- Review assertion logic carefully
- Check for timing issues in async tests
- Verify mock setups match actual usage

**AI Not Helping**:
- Review custom instructions file
- Be more specific in prompts
- Include context about the class being tested

### Debugging Tips
```bash
# Detailed test output
dotnet test --logger "console;verbosity=detailed"

# Run specific test class
dotnet test --filter "ClassName=CalculatorTests"

# Generate coverage report
dotnet test --collect:"XPlat Code Coverage"
```

## 📊 Assessment Criteria

### Technical Skills (70%)
- [ ] Tests follow AAA pattern consistently
- [ ] Appropriate use of Facts vs Theories
- [ ] Exception testing implemented correctly
- [ ] Mock objects used properly for dependencies
- [ ] Async testing patterns applied correctly

### AI Usage (20%)
- [ ] Effective prompting techniques demonstrated
- [ ] Custom instructions utilized appropriately
- [ ] AI suggestions critically evaluated
- [ ] Code generated by AI is understood and modified

### Code Quality (10%)
- [ ] Test names are descriptive and clear
- [ ] No code duplication in tests
- [ ] Helper methods used effectively
- [ ] Test organization follows logical structure

## 🎓 Extension Activities

### For Fast Finishers
1. **Property-based testing** with FsCheck
2. **Mutation testing** with Stryker.NET
3. **Integration testing** with TestServer
4. **Performance benchmarking** with BenchmarkDotNet

### Real-world Applications
- Add database integration tests
- Test API endpoints with WebApplicationFactory
- Implement acceptance tests with SpecFlow
- Add load testing scenarios

## 📚 Additional Resources

### Documentation
- [xUnit.net Documentation](https://xunit.net/)
- [Moq Framework Guide](https://github.com/moq/moq4)
- [.NET Testing Best Practices](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)

### Advanced Topics
- [Test-Driven Development](https://docs.microsoft.com/en-us/visualstudio/test/quick-start-test-driven-development-with-test-explorer)
- [Integration Testing in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests)
- [Performance Testing](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-performance-tests)

## 📝 Instructor Notes

### Time Management
- **Demo** (10 min): Show AI prompting live
- **Exercises** (90 min): Students work through guided exercises  
- **Review** (20 min): Discuss solutions and best practices
- **Wrap-up** (10 min): Next steps and resources

### Discussion Points
- When to use AI vs manual coding
- Limitations of AI-generated tests
- Test maintenance strategies
- Performance considerations

### Common Questions
**Q**: "Should I trust AI-generated tests?"  
**A**: Always review and understand generated code. AI is a tool, not a replacement for critical thinking.

**Q**: "How do I know if my tests are good enough?"  
**A**: Look at coverage metrics, but focus on testing important behaviors and edge cases.

**Q**: "What if the AI generates wrong tests?"  
**A**: This is a learning opportunity! Debug together and discuss why the test was incorrect.

## 🔄 Continuous Improvement

### Feedback Collection
- Student survey on AI effectiveness
- Code review of submitted solutions
- Performance metrics (build times, test execution)

### Lab Updates
- Keep AI prompting examples current
- Update dependencies regularly
- Add new testing scenarios based on feedback

This lab provides a solid foundation in both xUnit testing and AI-assisted development, preparing students for modern software development practices.
