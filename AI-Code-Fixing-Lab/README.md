# AI Code Fixing Lab

## 🎯 Learning Objectives
By the end of this lab, you will:
- Identify common code quality issues and anti-patterns
- Use AI effectively to diagnose and fix code problems
- Understand performance implications of different algorithms
- Learn to modernize legacy code using AI assistance
- Practice refactoring techniques with AI guidance
- Recognize security vulnerabilities and fix them

## 📋 Prerequisites
- Basic C# knowledge
- .NET 8.0 SDK installed
- Visual Studio Code with C# extension
- GitHub Copilot or similar AI assistant enabled

## 🏗️ Lab Structure

### Part 1: Algorithm Problems (30 minutes)
- Inefficient sorting algorithms
- Poor time complexity solutions
- Memory leaks and resource management

### Part 2: Syntax and Style Issues (25 minutes)
- Deprecated methods and APIs
- Code style violations
- Improper exception handling

### Part 3: Security Vulnerabilities (25 minutes)
- SQL injection risks
- Input validation issues
- Insecure data handling

### Part 4: Performance and Maintainability (30 minutes)
- N+1 query problems
- Code duplication
- Poor separation of concerns

### Part 5: Legacy Code Modernization (20 minutes)
- Outdated patterns
- Missing async/await
- Framework upgrades

## 🚀 Getting Started

1. Navigate to the lab directory:
   ```bash
   cd AI-Code-Fixing-Lab
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Build the project (expect warnings and errors):
   ```bash
   dotnet build
   ```

4. Run the problematic code:
   ```bash
   dotnet run
   ```

## 📁 Project Structure
```
AI-Code-Fixing-Lab/
├── src/
│   ├── BadCode/
│   │   ├── AlgorithmProblems.cs      # Inefficient algorithms
│   │   ├── SyntaxIssues.cs           # Deprecated/poor syntax
│   │   ├── SecurityVulns.cs          # Security issues
│   │   ├── PerformanceIssues.cs      # Performance problems
│   │   ├── LegacyCode.cs             # Outdated patterns
│   │   └── Program.cs                # Entry point with issues
├── tests/
│   ├── FixedCode.Tests/
│   │   └── FixValidationTests.cs     # Tests to verify fixes
├── docs/
│   ├── problem-scenarios.md          # Detailed problem descriptions
│   ├── ai-prompting-guide.md         # Effective AI prompts for fixing
│   └── solution-examples.md          # Example fixes (for instructors)
├── .vscode/
│   ├── settings.json                 # VS Code configuration
│   └── tasks.json                    # Build and analysis tasks
├── AI-Code-Fixing-Lab.sln
└── README.md
```

## 🤖 AI Fixing Process

For each problematic code file, follow this process:

1. **Analyze**: Use AI to identify problems
2. **Prioritize**: Determine which issues to fix first
3. **Fix**: Apply AI-suggested solutions
4. **Validate**: Test that fixes work correctly
5. **Optimize**: Further improve the code

## 📝 Lab Exercises

### Exercise 1: Algorithm Optimization
Open `AlgorithmProblems.cs` and use AI to:
- Identify inefficient sorting algorithms
- Fix time complexity issues
- Optimize memory usage
- Add proper error handling

### Exercise 2: Syntax Modernization
In `SyntaxIssues.cs`, fix:
- Deprecated method calls
- Improper exception handling
- Code style violations
- Missing null checks

### Exercise 3: Security Hardening
Review `SecurityVulns.cs` for:
- SQL injection vulnerabilities
- Input validation gaps
- Insecure data storage
- Authentication weaknesses

### Exercise 4: Performance Enhancement
Optimize `PerformanceIssues.cs`:
- Database query efficiency
- Memory allocation patterns
- Async/await usage
- Caching strategies

### Exercise 5: Legacy Modernization
Update `LegacyCode.cs`:
- Replace obsolete patterns
- Add modern C# features
- Improve testability
- Update to current frameworks

## 🎯 Success Criteria
- [ ] All compiler errors resolved
- [ ] Code analysis warnings addressed
- [ ] Performance improvements verified
- [ ] Security issues mitigated
- [ ] Tests pass for all fixed code
- [ ] Code follows modern best practices

## 📚 Additional Resources
- [.NET Code Analysis Rules](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/)
- [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/)
- [OWASP Security Guidelines](https://owasp.org/)
- [Performance Best Practices](https://docs.microsoft.com/en-us/dotnet/core/tutorials/benchmarking)

## 🏁 Next Steps
After completing this lab, try:
- Static analysis tools (SonarQube, CodeQL)
- Performance profiling
- Security scanning tools
- Automated refactoring techniques
