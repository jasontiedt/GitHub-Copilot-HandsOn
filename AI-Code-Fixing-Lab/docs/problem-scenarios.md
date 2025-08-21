# Problem Scenarios Guide

This document details all the problematic code patterns included in this lab and what students should learn to identify and fix.

## 🚨 Algorithm Problems (`AlgorithmProblems.cs`)

### Issue #1: Inefficient Sorting Algorithm
**Problem**: Bubble sort with O(n²) complexity
**AI Prompt Example**:
```
"Analyze this sorting algorithm and suggest a more efficient approach. What's the time complexity of this code and how can it be improved?"
```
**Expected Fix**: Use Array.Sort() or implement QuickSort/MergeSort

### Issue #2: Linear Search on Unsorted Data
**Problem**: O(n) search when could be O(log n)
**AI Prompt Example**:
```
"This search function is inefficient. How can I optimize it for better performance, especially for repeated searches?"
```
**Expected Fix**: Sort data first, then use binary search, or use HashSet for O(1) lookups

### Issue #3: Recursive Factorial Without Memoization
**Problem**: Stack overflow risk and exponential time complexity
**AI Prompt Example**:
```
"This recursive factorial function will crash for large numbers. How can I make it safer and more efficient?"
```
**Expected Fix**: Iterative approach or memoization, add input validation

### Issue #4: Inefficient Prime Checking
**Problem**: Checking all numbers up to n instead of √n
**AI Prompt Example**:
```
"This prime checking algorithm is slow for large numbers. What mathematical optimization can I apply?"
```
**Expected Fix**: Only check up to √n, handle even numbers separately

### Issue #5: String Concatenation in Loop
**Problem**: Creates new string objects on each iteration
**AI Prompt Example**:
```
"This string building is very slow. What's a more efficient way to concatenate many strings?"
```
**Expected Fix**: Use StringBuilder

### Issue #6: Resource Leaks
**Problem**: Not disposing FileStream and StreamReader
**AI Prompt Example**:
```
"This file reading code might leak resources. How should I properly manage file handles in C#?"
```
**Expected Fix**: Use `using` statements

### Issue #7: Poor Data Structure Choice
**Problem**: O(n²) duplicate detection instead of O(n)
**AI Prompt Example**:
```
"This duplicate detection is slow for large arrays. What data structure would make this more efficient?"
```
**Expected Fix**: Use HashSet for O(n) complexity

### Issue #8: Boxing/Unboxing with ArrayList
**Problem**: Performance hit from object boxing
**AI Prompt Example**:
```
"This code uses ArrayList which causes performance issues. What modern alternative should I use?"
```
**Expected Fix**: Use generic List<T>

---

## 🔧 Syntax Issues (`SyntaxIssues.cs`)

### Issue #1: Deprecated Methods
**Problem**: Using obsolete Environment.GetEnvironmentVariable
**AI Prompt Example**:
```
"I'm getting warnings about obsolete methods. What's the modern way to access environment paths?"
```
**Expected Fix**: Use Environment.GetFolderPath(Environment.SpecialFolder.Temp)

### Issue #2: Poor Exception Handling
**Problem**: Using int.Parse instead of TryParse, rethrowing exceptions incorrectly
**AI Prompt Example**:
```
"This parsing code throws exceptions for invalid input. How can I handle this more gracefully?"
```
**Expected Fix**: Use int.TryParse, proper exception handling

### Issue #3: Missing Null Checks
**Problem**: No defensive programming
**AI Prompt Example**:
```
"This method will crash if passed null values. How should I add proper input validation?"
```
**Expected Fix**: Add null checks, use ArgumentNullException

### Issue #4: Outdated Loop Patterns
**Problem**: Manual loops instead of LINQ
**AI Prompt Example**:
```
"This filtering and sorting code is verbose. How can I make it more concise and readable using modern C#?"
```
**Expected Fix**: Use LINQ Where(), Select(), OrderBy()

### Issue #5: Poor Async Usage
**Problem**: Blocking on async methods with .Result
**AI Prompt Example**:
```
"This async code is blocking the thread. What's the proper way to call async methods?"
```
**Expected Fix**: Use async/await pattern properly

### Issue #6: Obsolete DateTime Methods
**Problem**: Using DateTime.Now instead of DateTimeOffset
**AI Prompt Example**:
```
"This date formatting code has timezone issues. What's the modern approach for date handling?"
```
**Expected Fix**: Use DateTimeOffset, modern formatting

---

## 🔒 Security Vulnerabilities (`SecurityVulnerabilities.cs`)

⚠️ **WARNING**: These are real security vulnerabilities included for educational purposes only!

### Issue #1: SQL Injection
**Problem**: Direct string concatenation in SQL queries
**AI Prompt Example**:
```
"This database code is vulnerable to SQL injection. How should I safely handle user input in SQL queries?"
```
**Expected Fix**: Use parameterized queries

### Issue #2: Weak Password Hashing
**Problem**: Using MD5 without salt
**AI Prompt Example**:
```
"This password hashing is insecure. What's the current best practice for storing passwords?"
```
**Expected Fix**: Use bcrypt, Argon2, or PBKDF2 with salt

### Issue #3: Information Disclosure
**Problem**: Exposing stack traces and internal details
**AI Prompt Example**:
```
"This error handling exposes too much information. How should I handle exceptions securely?"
```
**Expected Fix**: Log details internally, return generic error messages

### Issue #4: Insecure File Upload
**Problem**: No validation, path traversal vulnerability
**AI Prompt Example**:
```
"This file upload code is dangerous. What security checks should I implement?"
```
**Expected Fix**: Validate file types, sanitize paths, size limits

### Issue #5: Weak Random Numbers
**Problem**: Using System.Random for security tokens
**AI Prompt Example**:
```
"This token generation might be predictable. What should I use for cryptographically secure random numbers?"
```
**Expected Fix**: Use RNGCryptoServiceProvider or RandomNumberGenerator

---

## ⚡ Performance Issues (`PerformanceIssues.cs`)

### Issue #1: N+1 Query Problem
**Problem**: One query per item instead of batch query
**AI Prompt Example**:
```
"This database code makes too many queries. How can I optimize it to reduce database round trips?"
```
**Expected Fix**: Use JOIN queries or batch operations

### Issue #2: Blocking Async Methods
**Problem**: Using .Result on async methods
**AI Prompt Example**:
```
"This async code is blocking threads. How can I make it truly asynchronous?"
```
**Expected Fix**: Use await, make calling method async

### Issue #3: Memory Inefficient Processing
**Problem**: Loading entire dataset into memory
**AI Prompt Example**:
```
"This code uses too much memory for large datasets. How can I process data in chunks?"
```
**Expected Fix**: Stream processing, pagination

### Issue #4: Multiple Collection Iterations
**Problem**: Filtering data in multiple passes
**AI Prompt Example**:
```
"This filtering code iterates multiple times. How can I optimize it to single pass?"
```
**Expected Fix**: Chain LINQ operations

### Issue #5: No Caching
**Problem**: Repeating expensive calculations
**AI Prompt Example**:
```
"This calculation is expensive and called frequently. How can I implement caching?"
```
**Expected Fix**: Use MemoryCache or simple dictionary caching

---

## 📜 Legacy Code (`LegacyCode.cs`)

### Issue #1: Old Threading Model
**Problem**: Using Thread class instead of Task
**AI Prompt Example**:
```
"This threading code is outdated. What's the modern way to handle background work?"
```
**Expected Fix**: Use Task.Run() or async/await

### Issue #2: Non-Generic Collections
**Problem**: Using ArrayList, Hashtable
**AI Prompt Example**:
```
"These collections cause boxing/unboxing. What modern alternatives should I use?"
```
**Expected Fix**: Use List<T>, Dictionary<K,V>

### Issue #3: Manual Resource Management
**Problem**: Try/finally instead of using statements
**AI Prompt Example**:
```
"This resource cleanup is verbose and error-prone. How can I simplify it?"
```
**Expected Fix**: Use `using` statements or `using` declarations

### Issue #4: Old Property Patterns
**Problem**: Get/Set methods instead of properties
**AI Prompt Example**:
```
"These getter/setter methods are old-fashioned. How should I implement properties in modern C#?"
```
**Expected Fix**: Use auto-properties or property syntax

### Issue #5: Manual String Formatting
**Problem**: String concatenation instead of interpolation
**AI Prompt Example**:
```
"This string formatting is hard to read. What's the modern approach?"
```
**Expected Fix**: Use string interpolation `$""`

---

## 🎯 Learning Objectives by Category

### Algorithm Optimization
- Understand Big O notation
- Choose appropriate data structures
- Recognize common algorithmic anti-patterns
- Apply mathematical optimizations

### Modern C# Syntax
- Use latest language features
- Follow current best practices
- Replace deprecated methods
- Implement proper error handling

### Security Awareness
- Recognize common vulnerabilities
- Apply secure coding practices
- Understand input validation
- Implement proper authentication

### Performance Optimization
- Identify performance bottlenecks
- Use async/await effectively
- Implement efficient data access patterns
- Apply caching strategies

### Code Modernization
- Replace legacy patterns
- Use modern frameworks and libraries
- Implement proper resource management
- Follow current coding standards

## 🚀 AI Prompting Strategies

### Effective Prompts for Code Analysis
```
"Analyze this code for performance issues and suggest optimizations"
"What security vulnerabilities exist in this code and how can I fix them?"
"This code follows old patterns. How can I modernize it using current C# features?"
"What are the potential problems with this algorithm and how can I improve it?"
```

### Specific Problem-Solving Prompts
```
"This method is slow for large inputs. What's the time complexity and how can I optimize it?"
"I'm getting compiler warnings about deprecated methods. What are the modern alternatives?"
"This code might have security issues. Please review and suggest secure alternatives."
"How can I refactor this to use async/await properly?"
```

### Best Practices Prompts
```
"Please review this code for best practices and suggest improvements"
"What design patterns would improve this code structure?"
"How can I make this code more testable and maintainable?"
"What are the SOLID principle violations in this code?"
```
