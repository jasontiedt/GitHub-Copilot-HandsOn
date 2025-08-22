# Exercise 1: Basic CI Pipeline 🔧

Master the fundamentals of CI pipeline creation by developing your own AI prompting strategies for both GitHub Actions and Azure Pipelines.

## 🎯 Learning Objectives

- Develop effective AI prompting techniques for DevOps automation
- Create comprehensive CI pipelines through guided experimentation
- Build personal expertise in pipeline structure and best practices
- Master independent problem-solving for build and test workflows

## 📋 Prerequisites

- GitHub account (for GitHub Actions)
- Azure DevOps account (for Azure Pipelines - optional)
- VS Code with pipeline extensions installed
- Basic understanding of YAML syntax

## 🚀 **Your AI Challenge**

### **Think First** 🤔
Before reaching for AI assistance, analyze the requirements:

- What does a basic CI pipeline need to accomplish?
- What are the essential stages: build, test, artifacts?
- How should the pipeline respond to different triggers?
- What quality gates are most important?

### Part A: GitHub Actions Pipeline (15 minutes)

#### **Your Challenge**: Create Your First Workflow

**Analyze the Problem:**
You need to create `.github/workflows/basic-ci.yml` that provides automated validation for every code change.

**Think About:**
- What events should trigger this pipeline?
- What steps are essential for validating .NET code?
- How should test results be preserved and reported?
- What artifacts need to be created for future use?

<details>
<summary>💡 Click for AI Prompting Strategies</summary>

**Effective Prompting Approach:**

1. **Context-Rich Opening:**
   ```
   "I need to create a GitHub Actions CI workflow for a .NET 8 Web API application. 
   The pipeline should implement standard CI practices including automated builds, 
   comprehensive testing, and artifact generation. What would be a robust workflow 
   structure that follows GitHub Actions best practices?"
   ```

2. **Enhancement Questions:**
   - "What are the essential components every .NET CI pipeline should include?"
   - "How should I structure jobs for optimal performance and readability?"
   - "What GitHub Actions are recommended for .NET development workflows?"
   - "How can I ensure proper error handling and meaningful status reporting?"

3. **Deep Dive Prompts:**
   - "Explain the purpose and configuration of each action you recommended"
   - "How would you modify this workflow for better caching and performance?"
   - "What security considerations should I include in this CI pipeline?"

</details>

#### **Your Challenge**: Enhance with Advanced Features

**Think About What Makes Pipelines Production-Ready:**
- How can you validate code quality beyond just compilation?
- What security scans should be integrated early in the process?
- How do you handle multiple operating systems efficiently?
- What metrics and reporting enhance team visibility?

<details>
<summary>💡 Click for Enhancement Prompting Ideas</summary>

**Advanced Feature Development:**

1. **Multi-OS Strategy:**
   ```
   "I want to enhance my GitHub Actions workflow to run on multiple operating systems 
   for better compatibility validation. How should I implement a matrix strategy that 
   efficiently tests across Windows, Ubuntu, and macOS while avoiding redundant work?"
   ```

2. **Quality Integration:**
   ```
   "Add comprehensive code quality checks to my CI pipeline including static analysis, 
   dependency vulnerability scanning, and code formatting validation. What tools and 
   GitHub Actions would you recommend for a .NET project?"
   ```

3. **Performance Optimization:**
   ```
   "How can I optimize this GitHub Actions workflow for faster execution times? 
   Include caching strategies, parallel execution, and conditional logic."
   ```

</details>
# Add steps for:
# - Code formatting validation (dotnet format)
# - Static code analysis
# - Dependency vulnerability scanning
```

### Part B: Azure Pipelines (15 minutes)

#### **Your Challenge**: Create Azure DevOps Pipeline

**Analyze the Different Platform:**
Azure Pipelines offers different capabilities than GitHub Actions. Consider:
- How do Azure Pipeline stages differ from GitHub Actions jobs?
- What are the advantages of multi-stage pipelines?
- How does agent selection impact performance and cost?
- What Azure-specific integrations could add value?

<details>
<summary>💡 Click for Azure Pipeline Prompting Strategies</summary>

**Azure-Specific Development:**

1. **Platform Comparison Prompt:**
   ```
   "I need to create an Azure DevOps pipeline equivalent to my GitHub Actions workflow. 
   Help me understand the key differences in structure, syntax, and capabilities between 
   Azure Pipelines and GitHub Actions for .NET development. What would be the optimal 
   Azure Pipeline implementation?"
   ```

2. **Multi-Stage Architecture:**
   ```
   "Design a multi-stage Azure Pipeline for a .NET application that separates concerns 
   into distinct stages: Build, Test, Quality Gates, and Artifact Publishing. Explain 
   the benefits of this approach and how to implement proper stage dependencies."
   ```

3. **Enterprise Features:**
   ```
   "What enterprise-grade features can I implement in Azure Pipelines that enhance 
   security, compliance, and governance for a production .NET application? Include 
   service connections, variable groups, and approval processes."
   ```

</details>

## 💡 **AI Prompting Development Guide**

### **Building Context-Rich Prompts**
Learn to create prompts that generate higher-quality pipeline code:

#### Level 1 - Basic Request:
❌ "Create a CI pipeline"

#### Level 2 - Context-Aware:
✅ "Create a GitHub Actions CI pipeline for a .NET 8 Web API with unit testing"

#### Level 3 - Comprehensive:
✅ "Create a GitHub Actions CI pipeline for a .NET 8 Web API that includes automated testing, code quality analysis, security scanning, and artifact generation following DevOps best practices"

### **Effective Follow-Up Questions**
After getting initial AI response, ask:
- "Can you explain why you chose these specific actions/tasks?"
- "How would you modify this for better performance and security?"
- "What would you add for enterprise production readiness?"
- "How does this compare to industry standard practices?"

### **Quality Validation Prompts**
- "Review this pipeline for potential security vulnerabilities"
- "Suggest optimizations for faster execution times"
- "Identify missing error handling and monitoring"
- "Recommend additional quality gates for production use"

## 🧪 **Sample Applications for Testing**

Choose one of these sample applications to build your pipeline skills:

### **Option 1: .NET Web API** 🎯
**Recommended for CI fundamentals**
```bash
# Navigate to sample-apps/dotnet-api/
# Contains: ASP.NET Core API with comprehensive unit tests
```

**Your Analysis Challenge:**
- Examine the project structure and dependencies
- Identify what testing frameworks are configured
- Determine what build outputs need to be created
- Consider what quality gates would add value

### **Option 2: React TypeScript Application** ⚛️
**Great for frontend CI patterns**
```bash
# Navigate to sample-apps/react-app/
# Contains: Modern React app with Jest testing and ESLint
```

**Your Analysis Challenge:**
- Understand the npm script configuration
- Identify testing and code quality tools
- Consider browser compatibility testing needs
- Think about artifact optimization for web deployment

### **Option 3: Python FastAPI Service** 🐍
**Excellent for microservice CI patterns**
```bash
# Navigate to sample-apps/python-service/
# Contains: FastAPI microservice with pytest and quality tools
```

**Your Analysis Challenge:**
- Explore Python dependency management approach
- Understand testing and coverage configuration
- Consider containerization and security scanning needs
- Think about package distribution requirements
```

### Option 2: React TypeScript App
```bash
# Navigate to sample-apps/react-app/
# Contains: React app with Jest tests and TypeScript
```

### Option 3: Python FastAPI Service
```bash
# Navigate to sample-apps/python-service/
# Contains: FastAPI service with pytest
```

## 🔍 **Validation and Testing**

### **Your Learning Verification Process**

#### **For GitHub Actions:**
**Think About Validation:**
- How can you verify your workflow syntax before committing?
- What feedback mechanisms does GitHub provide during execution?
- How should you interpret build logs and error messages?
- What constitutes successful artifact creation and publishing?

<details>
<summary>💡 Click for Validation Strategies</summary>

**Systematic Testing Approach:**
1. **Pre-commit Validation**: Use VS Code GitHub Actions extension for syntax checking
2. **Incremental Testing**: Start with basic workflow, add features gradually
3. **Log Analysis**: Learn to read GitHub Actions logs effectively
4. **Artifact Verification**: Confirm artifacts are created with correct content
5. **Troubleshooting**: Ask AI "Why might this GitHub Actions step be failing: [error message]"

</details>

#### **For Azure Pipelines:**
**Think About Platform Differences:**
- How does Azure DevOps provide feedback during pipeline execution?
- What are the key differences in error reporting between platforms?
- How do you verify service connections and permissions?
- What makes artifact publishing successful in Azure context?

<details>
<summary>💡 Click for Azure Validation Approach</summary>

**Azure-Specific Testing:**
1. **Pipeline Validation**: Use Azure DevOps YAML validator
2. **Agent Compatibility**: Understand hosted vs. self-hosted agent implications
3. **Permission Verification**: Test service connections and artifact feeds
4. **Multi-stage Dependencies**: Verify stage progression and dependencies
5. **Enterprise Integration**: Test with organizational policies and approvals

</details>

## 📊 **Success Criteria & Learning Outcomes**

### **Technical Achievements**
After completing this exercise, validate your success:

- [ ] **Pipeline Fundamentals**: Can create CI workflows independently with AI assistance
- [ ] **Platform Understanding**: Can explain differences between GitHub Actions and Azure Pipelines
- [ ] **Quality Integration**: Successfully integrated testing and code quality checks
- [ ] **Artifact Management**: Created and published build artifacts correctly
- [ ] **Troubleshooting Skills**: Can diagnose and fix common pipeline issues with AI help

### **AI Collaboration Skills Developed**
- [ ] **Contextual Prompting**: Can provide rich context to get better AI responses
- [ ] **Iterative Improvement**: Can refine prompts based on AI feedback
- [ ] **Best Practice Learning**: Can ask AI for explanations and best practices
- [ ] **Platform Comparison**: Can use AI to understand platform-specific differences
- [ ] **Independent Problem-Solving**: Can troubleshoot issues by asking targeted AI questions

## 🛠️ **Independent Troubleshooting**

### **Your Problem-Solving Process**
When issues arise, develop your diagnostic skills:

1. **Analyze the Error**: What is the exact error message telling you?
2. **Research Context**: What component or step is failing?
3. **Form Hypotheses**: What might be causing this specific issue?
4. **Ask Targeted AI Questions**: "This GitHub Actions step fails with [error], what are the most likely causes?"

<details>
<summary>💡 Common Issue Resolution Strategies</summary>

**Typical CI Pipeline Issues & AI Prompting Approaches:**

1. **Syntax Errors:**
   - Prompt: "Fix this YAML syntax error in my GitHub Actions workflow: [paste error and relevant section]"

2. **Permission Issues:**
   - Prompt: "I'm getting a permission denied error when publishing artifacts in Azure Pipelines. What are the common causes and solutions?"

3. **Test Failures:**
   - Prompt: "My unit tests pass locally but fail in the CI pipeline. What environmental differences should I investigate?"

4. **Performance Issues:**
   - Prompt: "My pipeline is running slowly. What are effective caching and optimization strategies for [specific platform and language]?"

</details>

## 🔄 **Platform Comparison Learning**

### **Your Analysis Challenge**
Compare your experience with both platforms:

**Think About:**
- Which platform felt more intuitive for your workflow needs?
- What are the learning curve differences between the platforms?
- When would you choose one platform over the other?
- How do the enterprise features compare for organizational use?

<details>
<summary>💡 Platform Decision Framework</summary>

**Ask AI to Help You Analyze:**
```
"Based on my experience with both GitHub Actions and Azure Pipelines for .NET development, 
help me understand when to choose each platform. Consider factors like:
- Team size and organizational structure
- Integration with existing tools
- Cost and licensing models
- Enterprise features and compliance requirements
- Ease of maintenance and scaling"
```

</details>

## 🎯 **Reflection and Next Steps**

### **Your Learning Journey**
Consider your development as a DevOps practitioner:

1. **Skill Assessment**: What pipeline concepts do you now understand confidently?
2. **AI Partnership**: How has AI assistance changed your approach to DevOps automation?
3. **Knowledge Gaps**: What areas need more exploration and practice?
4. **Real-World Application**: How would you apply these skills to your current projects?

### **Preparing for Exercise 2**
Ready to advance your CI/CD skills? Next we'll explore:
- **Matrix build strategies** for comprehensive testing
- **Advanced caching** and performance optimization
- **Cross-platform compatibility** validation
- **Reusable pipeline components** for team collaboration

**Congratulations on mastering CI fundamentals! 🎉 Your AI-assisted DevOps journey is off to a strong start!**
