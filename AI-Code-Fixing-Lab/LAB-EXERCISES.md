# AI Code Fixing Lab - Exercise Guide

## 🎯 Overview
This hands-on lab teaches students to identify and fix common code problems using AI assistance. Students will work through real-world problematic code and learn effective AI prompting techniques for code improvement.

**Duration**: 1-1.5 hours  
**Difficulty**: Beginner to Intermediate  
**Prerequisites**: Basic C# knowledge, GitHub Copilot or similar AI assistant

## 🚀 Setup Instructions

### 1. Navigate to Lab Directory
```bash
cd AI-Code-Fixing-Lab
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Build Project (Expect Issues!)
```bash
dotnet build
```
*Note: You should see compilation warnings and possibly errors - this is expected!*

### 4. Run the Problematic Code
```bash
dotnet run --project src/BadCode/BadCode.csproj
```
*Note: Some parts may crash or behave poorly - this is intentional!*

## 📋 Lab Exercises

### � Phase 1: Algorithm & Performance Issues (25 minutes)

#### Exercise 1.1: Sorting Algorithm Optimization
**File**: `src/BadCode/AlgorithmProblems.cs`  
**Method**: `SortNumbers`

**🤖 Your AI Challenge**: Analyze and fix the inefficient sorting algorithm

**Think First**: 
- Look at the current implementation - what's wrong with it?
- What questions should you ask about performance?
- How would you describe the problem to AI to get the best help?

**Your Mission**: 
- Identify the algorithmic issue using AI assistance
- Replace it with a more efficient approach
- Add proper error handling

💡 **Try developing your own prompts before looking at hints!**

   <details>
   <summary>💡 Click for prompting strategy hints</summary>
   
   **Analysis Approach**: Try asking AI to analyze existing code first
   **Performance Focus**: Ask about algorithmic complexity and alternatives
   **Implementation Help**: Request specific C# solutions with error handling
   **Best Practices**: Ask about modern C# patterns for the solution
   </details>

#### Exercise 1.2: String Processing Performance
**File**: `src/BadCode/AlgorithmProblems.cs`  
**Method**: `ProcessLargeText`

**🤖 Your AI Challenge**: Optimize string operations for large text processing

**Think First**:
- What's the performance issue with string concatenation?
- How would you explain the problem context to AI?
- What kind of solution are you looking for?

**Your Mission**: Use AI to help you replace inefficient string operations

   <details>
   <summary>💡 Click for prompting strategy hints</summary>
   
   **Problem Identification**: Ask AI to identify string performance issues
   **Solution Exploration**: Request alternatives for string concatenation
   **Best Practices**: Ask about memory efficiency in string operations
   </details>

### 🟡 Phase 2: Security & Error Handling (25 minutes)

#### Exercise 2.1: SQL Injection Prevention
**File**: `src/BadCode/SecurityProblems.cs`  
**Method**: `GetUserData`

**🤖 Your AI Challenge**: Identify and fix security vulnerabilities

**Think First**:
- Examine the SQL query construction - what's dangerous here?
- What security concepts should you ask AI about?
- How can you frame the problem to get comprehensive security advice?

**Your Mission**: Work with AI to eliminate SQL injection risks and add proper validation

   <details>
   <summary>💡 Click for security prompting hints</summary>
   
   **Security Analysis**: Ask AI to identify specific security vulnerabilities
   **Solution Approach**: Request secure alternatives for database queries
   **Best Practices**: Ask about input validation and parameterized queries
   **Verification**: Ask how to verify the fix prevents injection attacks
   </details>

#### Exercise 2.2: Exception Handling
**File**: `src/BadCode/ErrorHandling.cs`  
**Method**: `ProcessUserInput`

**🤖 Your AI Challenge**: Improve exception handling patterns

**Think First**:
- What's wrong with catching all exceptions?
- What specific scenarios should be handled differently?
- How can you ask AI for better error handling strategies?

**Your Mission**: Use AI guidance to create specific, helpful exception handling

   <details>
   <summary>💡 Click for error handling prompting hints</summary>
   
   **Problem Analysis**: Ask AI about issues with broad exception catching
   **Specific Scenarios**: Request handling for different error types
   **User Experience**: Ask about providing meaningful error messages
   **Logging**: Request guidance on proper error logging
   </details>

### 🔴 Phase 3: Code Modernization & Best Practices (30 minutes)

#### Exercise 3.1: Legacy Pattern Modernization
**File**: `src/BadCode/LegacyPatterns.cs`  
**Method**: `ProcessData`

**🤖 Your AI Challenge**: Modernize outdated code patterns

**Think First**:
- What patterns in this code seem outdated?
- What modern C# features might apply here?
- How can you ask AI about current best practices?

**Your Mission**: Transform legacy code using modern C# features with AI guidance

   <details>
   <summary>💡 Click for modernization prompting hints</summary>
   
   **Pattern Analysis**: Ask AI to identify outdated patterns
   **Modern Alternatives**: Request current C# best practices
   **Feature Usage**: Ask about LINQ, async/await, and other modern features
   **Migration Strategy**: Request step-by-step modernization approach
   </details>

#### Exercise 3.2: Memory Management
**File**: `src/BadCode/MemoryProblems.cs`  
**Method**: `ProcessFiles`

**🤖 Your AI Challenge**: Fix memory leaks and resource management

**Think First**:
- What resources need proper cleanup?
- How should you ask AI about memory management?
- What patterns ensure proper resource disposal?

**Your Mission**: Implement proper resource management with AI assistance

   <details>
   <summary>💡 Click for memory management prompting hints</summary>
   
   **Resource Analysis**: Ask AI to identify resource management issues
   **Disposal Patterns**: Request guidance on using statements and IDisposable
   **Memory Leaks**: Ask about common memory leak patterns to avoid
   **Best Practices**: Request modern resource management approaches
   </details>

#### Exercise 3.3: Code Quality & Readability
**File**: `src/BadCode/QualityIssues.cs`  
**Method**: `CalculateTotal`

**🤖 Your AI Challenge**: Improve code readability and maintainability

**Think First**:
- What makes this code hard to read and maintain?
- How can you ask AI for refactoring suggestions?
- What quality improvements would have the biggest impact?

**Your Mission**: Refactor for clarity and maintainability using AI insights

   <details>
   <summary>💡 Click for code quality prompting hints</summary>
   
   **Quality Analysis**: Ask AI to identify readability and maintainability issues
   **Refactoring Approach**: Request specific refactoring techniques
   **Method Extraction**: Ask about breaking down complex methods
   **Naming**: Request guidance on meaningful variable and method names
   </details>

**Success Criteria**:
- [ ] Algorithm uses efficient sorting (Array.Sort or similar)
- [ ] Proper null checking added
- [ ] Performance significantly improved

#### Exercise 1.2: Search Optimization
**Method**: `FindNumber`

**AI Prompts**:
```
"This linear search could be optimized. For frequently searched data, what would be better?"

"Add null checking and improve the search algorithm efficiency."
```

#### Exercise 1.3: Recursive to Iterative
**Method**: `CalculateFactorial`

**AI Prompts**:
```
"This recursive factorial will cause stack overflow for large numbers. Convert it to iterative and add validation."

"Add input validation to prevent negative numbers and overflow scenarios."
```

#### Exercise 1.4: Mathematical Optimization
**Method**: `IsPrime`

**AI Prompts**:
```
"This prime checking algorithm is inefficient. What mathematical optimization can reduce the time complexity?"

"Optimize this to only check up to the square root and handle even numbers separately."
```

### 🔧 Phase 2: Syntax & Modernization Issues (30 minutes)

#### Exercise 2.1: Exception Handling
**File**: `src/BadCode/SyntaxIssues.cs`  
**Method**: `ParseUserInput`

**AI Prompts**:
```
"This exception handling is problematic. Show me how to use TryParse instead of Parse and fix the exception rethrowing."

"Replace this with proper error handling that doesn't lose the stack trace."
```

#### Exercise 2.2: Null Safety
**Method**: `ProcessName`

**AI Prompts**:
```
"Add null checking and defensive programming to this string processing method."

"Modernize this string handling code with better null safety and culture-aware operations."
```

#### Exercise 2.3: LINQ Modernization
**Method**: `FilterNames`

**AI Prompts**:
```
"Replace this manual filtering and sorting with LINQ operations."

"Modernize this collection processing using LINQ methods."
```

#### Exercise 2.4: Async/Await Pattern
**Method**: `DownloadDataBadly`

**AI Prompts**:
```
"This async code is blocking threads. Convert it to proper async/await pattern."

"Fix the async antipattern here and add proper error handling."
```

### 🔒 Phase 3: Security Vulnerabilities (40 minutes)

⚠️ **WARNING**: These contain real security vulnerabilities! Handle carefully.

#### Exercise 3.1: SQL Injection Fix
**File**: `src/BadCode/SecurityVulnerabilities.cs`  
**Method**: `GetUsersByName`

**AI Prompts**:
```
"This code has SQL injection vulnerability. Show me how to fix it with parameterized queries."

"Replace this dangerous string concatenation with safe database access patterns."
```

#### Exercise 3.2: Secure Password Hashing
**Method**: `HashPassword`

**AI Prompts**:
```
"This password hashing is insecure (MD5 without salt). Implement proper secure hashing with salt."

"Replace MD5 with a secure hashing algorithm like bcrypt or PBKDF2."
```

#### Exercise 3.3: Input Validation
**Method**: `SaveUserData`

**AI Prompts**:
```
"Add comprehensive input validation to prevent malicious input."

"This method needs validation for XSS prevention and SQL injection protection."
```

#### Exercise 3.4: Secure Random Numbers
**Method**: `GenerateSessionToken`

**AI Prompts**:
```
"This random number generation is not cryptographically secure. Fix it for security token generation."

"Replace System.Random with cryptographically secure random number generation."
```

### ⚡ Phase 4: Performance Optimization (35 minutes)

#### Exercise 4.1: N+1 Query Problem
**File**: `src/BadCode/PerformanceIssues.cs`  
**Method**: `GetOrdersWithCustomers`

**AI Prompts**:
```
"This code has an N+1 query problem. How can I optimize it to use fewer database calls?"

"Combine these multiple database queries into a single efficient query using JOINs."
```

#### Exercise 4.2: Async Optimization
**Method**: `GetDataFromMultipleAPIs`

**AI Prompts**:
```
"This async code is inefficient because it waits for each call sequentially. Make it parallel."

"Convert this to run API calls concurrently and handle errors properly."
```

#### Exercise 4.3: Collection Optimization
**Method**: `FilterAndSortProducts`

**AI Prompts**:
```
"This collection processing is inefficient with multiple iterations. Optimize with LINQ."

"Replace this manual filtering and bubble sort with efficient LINQ operations."
```

#### Exercise 4.4: String Building Optimization
**Method**: `GenerateLargeReport`

**AI Prompts**:
```
"This string concatenation in a loop is very slow. Use StringBuilder for better performance."

"Optimize this string building for better memory efficiency."
```

### 📜 Phase 5: Legacy Code Modernization (30 minutes)

#### Exercise 5.1: Modern Threading
**File**: `src/BadCode/LegacyCode.cs`  
**Method**: `ProcessDataOldWay`

**AI Prompts**:
```
"Replace this old Thread-based code with modern Task-based async patterns."

"Modernize this threading code to use async/await instead of Thread.Sleep."
```

#### Exercise 5.2: Generic Collections
**Method**: `ManageEmployees`

**AI Prompts**:
```
"Replace these non-generic collections (ArrayList, Hashtable) with modern generic equivalents."

"Update this to use List<T> and Dictionary<K,V> to avoid boxing/unboxing."
```

#### Exercise 5.3: Property Modernization
**Methods**: `GetName`, `SetName`, etc.

**AI Prompts**:
```
"Replace these getter/setter methods with modern C# auto-properties."

"Modernize this property implementation using current C# syntax."
```

#### Exercise 5.4: String Interpolation
**Method**: `FormatUserInfo`

**AI Prompts**:
```
"Replace this string concatenation with modern string interpolation."

"Modernize this string formatting using string interpolation syntax."
```

## 🧪 Testing Your Fixes

### Run Tests to Validate Fixes
```bash
dotnet test tests/FixedCode.Tests/FixedCode.Tests.csproj -v normal
```

### Check Build Success
```bash
dotnet build --verbosity normal
```

### Performance Verification
```bash
# Run the fixed program
dotnet run --project src/BadCode/BadCode.csproj
```

## 📊 Progress Tracking

### Algorithm Issues ✅
- [ ] SortNumbers optimized
- [ ] FindNumber improved  
- [ ] CalculateFactorial made safe
- [ ] IsPrime optimized
- [ ] BuildLargeString uses StringBuilder
- [ ] Resource leaks fixed
- [ ] HasDuplicates uses HashSet

### Syntax Issues ✅
- [ ] Deprecated methods replaced
- [ ] Exception handling improved
- [ ] Null safety added
- [ ] LINQ operations used
- [ ] Async/await patterns fixed
- [ ] Modern DateTime usage

### Security Issues ✅
- [ ] SQL injection prevented
- [ ] Password hashing secured
- [ ] Input validation added
- [ ] File upload secured
- [ ] Secure random numbers used
- [ ] Information disclosure prevented

### Performance Issues ✅
- [ ] N+1 queries eliminated
- [ ] Async operations parallelized
- [ ] Collection operations optimized
- [ ] String building efficient
- [ ] Caching implemented
- [ ] Resource connections optimized

### Legacy Issues ✅
- [ ] Threading modernized
- [ ] Generic collections used
- [ ] Properties modernized
- [ ] String interpolation applied
- [ ] Resource management updated

## 🎯 Advanced Challenges

### Challenge 1: Comprehensive Security Review
Use AI to perform a complete security audit:
```
"Perform a comprehensive security review of all the code in this project. Identify any remaining vulnerabilities and provide fixes."
```

### Challenge 2: Performance Benchmarking
Create performance tests:
```
"Help me create benchmark tests to measure the performance improvements of my fixes."
```

### Challenge 3: Code Quality Analysis
Analyze overall code quality:
```
"Analyze the overall code quality, architecture, and suggest improvements for maintainability."
```

## 🔍 Debugging Tips

### If AI Suggestions Don't Work:
1. **Be more specific**: Add context about what you're trying to achieve
2. **Ask for alternatives**: "What are other ways to solve this problem?"
3. **Request explanations**: "Why is this approach better than the original?"
4. **Iterate**: "This solution has issue X, how can we fix it?"

### Common Issues:
- **Namespace problems**: Ask AI to add missing using statements
- **Compilation errors**: Share the exact error message with AI
- **Logic errors**: Describe the expected vs actual behavior

## 📚 Learning Resources

### After Completing This Lab:
- [.NET Performance Best Practices](https://docs.microsoft.com/en-us/dotnet/core/performance/)
- [C# Security Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/security/)
- [Async Programming Patterns](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)

### Code Analysis Tools:
- SonarQube for code quality analysis
- CodeQL for security scanning
- BenchmarkDotNet for performance testing

## 🏆 Success Criteria

You've successfully completed the lab when:
- [ ] All compiler errors and warnings resolved
- [ ] Tests pass successfully
- [ ] Program runs without crashes
- [ ] Performance significantly improved
- [ ] Security vulnerabilities fixed
- [ ] Code follows modern C# best practices

## 🎓 Next Steps

1. **Apply learnings**: Use these patterns in your own projects
2. **Explore static analysis**: Set up automated code quality checks
3. **Security testing**: Learn about penetration testing tools
4. **Performance monitoring**: Implement application performance monitoring
5. **Code reviews**: Practice identifying these issues in peer reviews

Remember: The goal isn't just to fix the code, but to understand **why** these problems occur and **how** to prevent them in future development!
