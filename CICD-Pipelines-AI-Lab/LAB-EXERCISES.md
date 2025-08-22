# LAB EXERCISES - CI/CD Pipelines AI Lab

Complete hands-on exercises to master DevOps automation with AI assistance for both GitHub Actions and Azure Pipelines.

## 🎯 Exercise Progression

Work through these exercises in order to build your CI/CD and AI skills progressively:

### 🟢 **Exercise 1: Basic CI Pipeline** (20 minutes)
**Objective**: Learn pipeline fundamentals with AI assistance
- Create simple build and test workflows
- Master YAML syntax and pipeline structure  
- Compare GitHub Actions vs Azure Pipelines
- Practice effective AI prompting for DevOps

**Skills Learned**: Pipeline fundamentals, YAML structure, AI-assisted development

### � **Exercise 2: Multi-Platform Builds** (25 minutes)
**Objective**: Build applications across multiple environments
- Implement matrix builds for cross-platform testing
- Add intelligent caching for performance
- Configure artifact management and publishing
- Learn parallel execution strategies

**Skills Learned**: Cross-platform CI, build optimization, artifact management

### � **Exercise 3: Complete CI/CD with Security** (35 minutes)
**Objective**: Create production-ready workflows
- Build CD pipelines with environment promotion
- Integrate security scanning and code quality checks
- Deploy to cloud services with approval gates
- Add automated testing strategies and monitoring

**Skills Learned**: Deployment strategies, DevSecOps, quality assurance

**⏱️ Total Duration**: 1-1.5 hours | **📊 Difficulty**: Intermediate

## 🚀 Getting Started

### Prerequisites Checklist
Before starting any exercise, ensure you have:
- [ ] **Git** installed and configured
- [ ] **GitHub account** (for GitHub Actions exercises)
- [ ] **Azure DevOps account** (for Azure Pipelines - optional)
- [ ] **VS Code** with recommended extensions installed
- [ ] **GitHub Copilot** active and working
- [ ] **Basic understanding** of CI/CD concepts

### Environment Setup
1. **Install recommended VS Code extensions**:
   - GitHub Actions (GitHub.vscode-github-actions)
   - Azure Pipelines (ms-azure-devops.azure-pipelines)  
   - YAML (redhat.vscode-yaml)
   
2. **Choose your platform focus**:
   - **GitHub Actions**: Great for open source and GitHub-native projects
   - **Azure Pipelines**: Excellent for enterprise and Microsoft ecosystem
   - **Both**: Learn cross-platform DevOps skills

3. **Verify your setup**:
   ```bash
   git --version
   code --version
   ```

## 💡 AI-Assisted Learning Philosophy

### 🧠 **Develop Your DevOps AI Skills**
This lab focuses on building **your own AI prompting expertise** for DevOps automation:

- **🤔 Analyze First**: Understand what you need before asking AI
- **🤖 Experiment**: Try different ways to describe your pipeline requirements
- **🔄 Iterate**: Refine your prompts based on AI responses
- **🎯 Build Expertise**: Develop personal DevOps AI strategies

### 🎯 **AI as Your DevOps Partner**
- **Context Building**: Learn to provide clear requirements to AI
- **Solution Exploration**: Discover multiple approaches to pipeline problems
- **Best Practice Learning**: Ask AI about DevOps standards and patterns
- **Troubleshooting**: Use AI to understand and fix pipeline issues

### Effective Prompting Development
Learn to build context-rich prompts:

1. **Start with your goal**: "I need a pipeline that..."
2. **Add technical specifics**: "Using .NET 8, targeting Azure..."
3. **Include constraints**: "Following security best practices..."
4. **Request explanations**: "Explain why you chose these approaches..."

### Learning Workflow
1. **📖 Understand** the exercise requirements completely
2. **� Think** about what you need to ask AI
3. **🤖 Experiment** with different prompting approaches
4. **� Review** and improve AI suggestions
5. **✅ Test** pipeline execution and validate results
6. **📝 Reflect** on successful prompting patterns

## 🔍 Validation and Testing

### For Each Exercise
1. **Validate syntax**:
   ```bash
   # For GitHub Actions
   # Use VS Code extension for real-time validation
   
   # For Azure Pipelines
   az pipelines runs list --organization https://dev.azure.com/yourorg
   ```

2. **Test pipeline execution**:
   - Commit pipeline files to repository
   - Monitor execution in platform UI
   - Review logs and identify issues
   - Verify artifacts and deployment results

3. **Measure success**:
   - Pipeline completes without errors
   - All quality gates pass
   - Artifacts are published correctly
   - Deployments succeed and are accessible

### Success Criteria
Each exercise includes specific success criteria. You've completed an exercise when:
- [ ] Pipeline executes successfully end-to-end
- [ ] All quality gates and tests pass
- [ ] Security scans complete without critical issues  
- [ ] Artifacts are published and deployments succeed
- [ ] You can explain the pipeline structure and decisions
- [ ] Pipeline follows platform best practices

## 🆘 Troubleshooting Guide

### Common Issues and Solutions

**🔧 YAML Syntax Errors**
- Use VS Code YAML extension for validation
- Check indentation (spaces vs tabs)
- Verify quotes and special characters
- Ask AI: "Fix this YAML syntax error: [paste error]"

**⚠️ Pipeline Execution Failures**
- Check runner/agent compatibility
- Verify permissions and service connections
- Review dependency and package issues
- Examine log outputs for specific errors

**🔐 Permission and Access Issues**
- Verify repository permissions
- Check service connection configuration
- Validate secret and variable access
- Ensure proper authentication setup

**📦 Artifact and Deployment Issues**
- Verify artifact paths and naming
- Check deployment target configuration
- Validate environment-specific settings
- Review networking and firewall rules

### Getting Help
1. **Check exercise README** for specific guidance and examples
2. **Use AI assistance**: "I'm getting this pipeline error: [describe issue]"
3. **Review platform documentation** for specific features
4. **Validate configuration** using platform-specific tools

## 📊 Progress Tracking

### Learning Milestones
Track your progress through the lab:

- [ ] **Pipeline Basics** - Can create simple CI workflows with AI help
- [ ] **Multi-Platform Builds** - Can implement cross-platform build strategies
- [ ] **Deployment Automation** - Can create complete CI/CD workflows
- [ ] **Security Integration** - Can implement DevSecOps practices
- [ ] **Advanced Patterns** - Can create enterprise-grade automation

### Competency Levels

**🟢 Beginner**: 
- Understands basic pipeline structure and YAML syntax
- Can use AI to generate simple CI workflows
- Successfully executes basic build and test pipelines

**🟡 Intermediate**:
- Implements multi-environment deployment strategies
- Integrates security and quality gates effectively
- Creates optimized, reliable pipeline workflows

**🔴 Advanced**:
- Develops reusable pipeline templates and components
- Implements enterprise DevOps patterns and governance
- Mentors others in AI-assisted DevOps practices

## 🎯 Learning Outcomes

Upon completing all exercises, you will be able to:

### Technical Skills
- ✅ **Design and implement** complete CI/CD pipelines for various technology stacks
- ✅ **Integrate security and quality** gates into automated workflows
- ✅ **Deploy applications** to multiple cloud platforms and environments
- ✅ **Optimize pipeline performance** and reduce build times
- ✅ **Troubleshoot pipeline issues** efficiently and systematically

### AI Integration Skills
- ✅ **Generate pipeline code** using effective AI prompts and strategies
- ✅ **Review and customize** AI-generated workflows for specific requirements
- ✅ **Use AI for troubleshooting** and optimization recommendations
- ✅ **Create reusable components** with AI assistance for team collaboration
- ✅ **Apply best practices** consistently across different pipeline platforms

### DevOps Expertise
- ✅ **Implement DevSecOps** practices in automated workflows
- ✅ **Design deployment strategies** for different environments and requirements
- ✅ **Create monitoring and alerting** for pipeline health and application performance
- ✅ **Establish governance** and compliance in automated processes

## 🔄 Next Steps

After completing the lab:

1. **Apply to real projects**: Implement CI/CD pipelines for your team's applications
2. **Create organization templates**: Build reusable pipeline templates for consistent practices
3. **Establish governance**: Implement pipeline standards and best practices
4. **Train team members**: Share AI-assisted DevOps techniques with colleagues
5. **Stay current**: Keep up with platform updates and new automation capabilities

## 📚 Sample Applications

The lab includes sample applications for testing your pipelines:

### **📁 dotnet-api/**
- **.NET 8 Web API** with comprehensive test suite
- **Entity Framework** integration examples
- **Health checks** and monitoring endpoints
- **Container deployment** ready

### **📁 react-app/**
- **React TypeScript** application with modern tooling
- **Jest testing** and code coverage
- **ESLint and Prettier** configuration
- **Performance optimization** examples

### **📁 python-service/**
- **FastAPI** microservice with async capabilities
- **Pytest** testing framework integration
- **Code quality** tools (Black, isort, Flake8)
- **Container and serverless** deployment options

### **📁 microservices/**
- **Multi-service** architecture example
- **Service communication** patterns
- **Distributed testing** strategies
- **Orchestrated deployment** examples

## 💭 Reflection Questions

After each exercise, consider:
1. How did AI assistance improve your DevOps productivity?
2. What pipeline patterns would you apply to your current projects?
3. How do the different platforms (GitHub Actions vs Azure Pipelines) suit different use cases?
4. What security and quality practices are most important for your organization?
5. How would you structure reusable pipeline components for team collaboration?

**Ready to automate everything? Start with Exercise 1! 🚀⚙️**
