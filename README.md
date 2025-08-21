# GitHub Copilot Hands-On Labs

This repository contains comprehensive hands-on lab exercises designed to teach developers how to effectively use AI (specifically GitHub Copilot) for software development, testing, and code quality improvement.

## Available Labs

### 1. xUnit Testing with AI (`xUnit-AI-Lab/`)

**Objective**: Learn xUnit testing fundamentals while leveraging AI assistance for test creation and development.

**What you'll learn**:
- xUnit.net framework basics and advanced patterns
- Test-Driven Development (TDD) with AI assistance
- Mocking and dependency injection testing
- AI-powered test generation and completion
- Custom AI prompting strategies for testing

**Key Features**:
- Progressive difficulty: 4 complexity levels from basic to advanced
- 35 passing tests demonstrating best practices
- Complete examples: Calculator, BankAccount, ShoppingCart, WeatherService
- Custom AI instructions for optimal Copilot usage
- Comprehensive documentation and exercises

**Technologies**: 
- .NET 8.0, xUnit.net 2.6.2, Moq 4.20.70
- GitHub Copilot integration

### 2. AI-Assisted Code Fixing (`AI-Code-Fixing-Lab/`)

**Objective**: Master the art of identifying and fixing problematic code using AI assistance across multiple quality dimensions.

**What you'll learn**:
- Identifying algorithm inefficiencies and performance bottlenecks
- Fixing syntax issues and adopting modern C# patterns
- Addressing security vulnerabilities and best practices
- Resolving performance anti-patterns
- Modernizing legacy code patterns
- Effective AI prompting for code quality improvement

**Problem Categories**:
1. **Algorithm Problems** (15+ issues)
   - Inefficient sorting algorithms (bubble sort → optimized)
   - Linear search → binary search optimization
   - Recursive inefficiencies → iterative solutions

2. **Syntax Issues** (12+ issues)
   - Deprecated methods and patterns
   - Poor exception handling
   - Outdated language constructs

3. **Security Vulnerabilities** (15+ issues)
   - SQL injection prevention
   - Weak password hashing → bcrypt
   - Input validation and sanitization
   - Insecure deserialization

4. **Performance Issues** (12+ issues)
   - N+1 query problems
   - Blocking async operations
   - Memory inefficiencies and leaks

5. **Legacy Code Patterns** (15+ issues)
   - Old threading models → modern async/await
   - Non-generic collections → generic types
   - Manual resource management → using statements

### 3. Copilot Mastery Lab (`Copilot-Mastery-Lab/`)

**Objective**: Master GitHub Copilot's different models, interaction modes, and advanced prompting strategies for maximum development effectiveness.

**What you'll learn**:
- Advanced prompting techniques and strategies
- When and how to use different Copilot models (GPT-4, Claude, Base Copilot)
- Effective use of Chat, Edit, and Agent interaction modes
- Context optimization for better AI responses
- Workflow integration and productivity optimization
- Team collaboration strategies with AI assistance

**Key Features**:
- Comprehensive prompting guide with 6+ different styles
- Model comparison exercises and decision frameworks
- Interaction mode mastery with hands-on examples
- Reusable prompt templates for common scenarios
- Real-world code examples and playgrounds
- Quick-start guide with 5-minute to 1-hour learning paths

**Technologies**: 
- GitHub Copilot (all models and modes)
- .NET 8.0 for practical examples
- Comprehensive documentation and templates

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- Visual Studio Code with C# extension
- GitHub Copilot (for AI assistance)

### Setup Instructions

1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   cd aaGitHub-Copilot-HandsOn
   ```

2. **Start with xUnit Testing Lab**:
   ```bash
   cd xUnit-AI-Lab
   dotnet restore
   dotnet build
   dotnet test
   ```

3. **Progress to Code Fixing Lab**:
   ```bash
   cd ../AI-Code-Fixing-Lab
   dotnet restore
   dotnet build
   # Note: Expect warnings - they're intentional for the learning experience!
   ```

4. **Master Copilot Usage**:
   ```bash
   cd ../Copilot-Mastery-Lab
   cd src && dotnet restore && dotnet build
   # Follow the QUICK-START.md guide for learning paths
   ```

### Lab Progression Recommendation

1. **Begin with xUnit-AI-Lab**: Master AI-assisted testing
2. **Advance to AI-Code-Fixing-Lab**: Apply AI to code quality improvement  
3. **Master with Copilot-Mastery-Lab**: Become an expert at using Copilot effectively
4. **Practice integration**: Use all skills together in real projects

## Key Learning Outcomes

After completing these labs, you will be able to:

- ✅ Write comprehensive unit tests using xUnit with AI assistance
- ✅ Identify and fix algorithm inefficiencies using AI prompts
- ✅ Recognize and remediate security vulnerabilities
- ✅ Optimize performance bottlenecks with AI guidance
- ✅ Modernize legacy code patterns effectively
- ✅ Create effective AI prompts for code quality improvement
- ✅ Master different Copilot models and when to use each
- ✅ Effectively use Chat, Edit, and Agent interaction modes
- ✅ Optimize context and prompting for maximum AI effectiveness
- ✅ Integrate AI tools seamlessly into your development workflow
- ✅ Collaborate effectively with team members using AI assistance

## Educational Philosophy

These labs are designed around the principle of **"AI-Augmented Learning"**:
- Real-world problems with intentional issues
- Guided discovery through AI interaction
- Progressive complexity building
- Hands-on practice with immediate feedback
- Best practices demonstrated through working examples

## Support and Feedback

Each lab includes:
- 📖 Comprehensive documentation
- 🧪 Working examples and test cases
- 🎯 Specific exercise guides
- 💡 AI prompting strategies
- ✅ Validation tests to confirm fixes

## Next Steps

After completing these labs:
1. Apply these techniques to your existing projects
2. Create custom AI instructions for your specific domains
3. Share your improved AI prompting strategies with your team
4. Contribute additional problem scenarios to the labs

---

**Happy Learning with AI! 🚀🤖**