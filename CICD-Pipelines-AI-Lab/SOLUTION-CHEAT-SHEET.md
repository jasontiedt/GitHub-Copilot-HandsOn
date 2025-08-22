# CI/CD Pipelines AI Lab - Solution Cheat Sheet ⚙️

**For Instructors & Advanced Learners**

This cheat sheet provides example solutions and effective DevOps prompting strategies while maintaining the lab's independent learning philosophy.

## 🎯 **Learning Objectives Validation**

Students should demonstrate:
- **Strategic pipeline architecture** planning with AI assistance
- **Independent analysis** of DevOps requirements before implementation
- **Iterative improvement** of CI/CD strategies based on AI feedback
- **Cross-platform thinking** for pipeline design and optimization

## 📚 **Exercise 1: Basic CI Pipeline (25 minutes)**

### **Effective GitHub Actions Prompts**

#### **Comprehensive CI Strategy**
```
"I need to design a GitHub Actions CI pipeline for a .NET 8 Web API that implements 
industry-standard practices. The pipeline should include automated builds, comprehensive 
testing with coverage reporting, security scanning, and artifact management. Help me 
understand the essential components and their optimal organization for maintainability 
and performance."
```

#### **Cross-Platform Considerations**
```
"Design a CI workflow that efficiently tests across Windows, Linux, and macOS while 
minimizing build time and resource usage. Include intelligent caching strategies and 
conditional execution. Explain the trade-offs between comprehensive testing and 
build performance."
```

### **Sample GitHub Actions Solution**

```yaml
name: CI Pipeline

on:
  push:
    branches: [ main, develop ]
  pull_request:
    branches: [ main ]

env:
  DOTNET_VERSION: '8.0.x'
  SOLUTION_PATH: './src/WebApi.sln'

jobs:
  build-and-test:
    runs-on: ${{ matrix.os }}
    strategy:
      matrix:
        os: [ubuntu-latest, windows-latest, macos-latest]
        
    steps:
    - name: Checkout code
      uses: actions/checkout@v4
      
    - name: Setup .NET
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: ${{ env.DOTNET_VERSION }}
        
    - name: Cache NuGet packages
      uses: actions/cache@v4
      with:
        path: ~/.nuget/packages
        key: ${{ runner.os }}-nuget-${{ hashFiles('**/*.csproj') }}
        restore-keys: |
          ${{ runner.os }}-nuget-
          
    - name: Restore dependencies
      run: dotnet restore ${{ env.SOLUTION_PATH }}
      
    - name: Build solution
      run: dotnet build ${{ env.SOLUTION_PATH }} --no-restore --configuration Release
      
    - name: Run tests
      run: |
        dotnet test ${{ env.SOLUTION_PATH }} \
          --no-build \
          --configuration Release \
          --collect:"XPlat Code Coverage" \
          --logger "trx;LogFileName=test-results.trx"
          
    - name: Upload test results
      uses: actions/upload-artifact@v4
      if: always()
      with:
        name: test-results-${{ matrix.os }}
        path: '**/test-results.trx'
        
    - name: Upload coverage reports
      uses: actions/upload-artifact@v4
      with:
        name: coverage-${{ matrix.os }}
        path: '**/coverage.cobertura.xml'

  security-scan:
    runs-on: ubuntu-latest
    steps:
    - name: Checkout code
      uses: actions/checkout@v4
      
    - name: Run CodeQL Analysis
      uses: github/codeql-action/init@v3
      with:
        languages: csharp
        
    - name: Autobuild
      uses: github/codeql-action/autobuild@v3
      
    - name: Perform CodeQL Analysis
      uses: github/codeql-action/analyze@v3

  package:
    needs: [build-and-test, security-scan]
    runs-on: ubuntu-latest
    if: github.ref == 'refs/heads/main'
    
    steps:
    - name: Checkout code
      uses: actions/checkout@v4
      
    - name: Setup .NET
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: ${{ env.DOTNET_VERSION }}
        
    - name: Create deployment package
      run: |
        dotnet publish ${{ env.SOLUTION_PATH }} \
          --configuration Release \
          --output ./publish \
          --no-restore
          
    - name: Upload deployment artifact
      uses: actions/upload-artifact@v4
      with:
        name: deployment-package
        path: ./publish
```

### **Key Teaching Points**

**✅ Strong Student Approaches:**
- Analyzes application requirements before designing pipeline
- Asks about industry best practices and reasoning behind choices
- Considers performance optimization through caching and parallelization
- Requests explanation of security scanning integration

**❌ Missed Learning Opportunities:**
- Copying template workflows without understanding the components
- Not considering cross-platform compatibility requirements
- Ignoring security and quality gates in favor of speed
- Failing to think about artifact management and deployment preparation

## 📚 **Exercise 2: Multi-Platform Builds (25 minutes)**

### **Advanced Matrix Strategy Prompts**

#### **Intelligent Matrix Design**
```
"Help me design a matrix build strategy that balances comprehensive platform coverage 
with cost efficiency. I need to test across multiple .NET versions and operating 
systems, but I want to avoid redundant testing. What criteria should I use to 
determine the optimal matrix configuration?"
```

#### **Performance Optimization Focus**
```
"Create a sophisticated caching and optimization strategy for my multi-platform CI 
pipeline. Include dependency caching, build output caching, and strategies for 
sharing cache data between matrix jobs. Explain how to measure and validate 
caching effectiveness."
```

### **Sample Azure Pipelines Solution**

```yaml
trigger:
  branches:
    include:
    - main
    - develop

variables:
  buildConfiguration: 'Release'
  dotnetVersion: '8.0.x'

stages:
- stage: BuildAndTest
  displayName: 'Build and Test'
  jobs:
  - job: MultiPlatformBuild
    displayName: 'Multi-Platform Build'
    strategy:
      matrix:
        linux_net8:
          imageName: 'ubuntu-latest'
          dotnetVersion: '8.0.x'
          displayName: 'Linux .NET 8'
        windows_net8:
          imageName: 'windows-latest'
          dotnetVersion: '8.0.x'
          displayName: 'Windows .NET 8'
        macos_net8:
          imageName: 'macos-latest'
          dotnetVersion: '8.0.x'
          displayName: 'macOS .NET 8'
    
    pool:
      vmImage: $(imageName)
    
    steps:
    - task: UseDotNet@2
      displayName: 'Use .NET $(dotnetVersion)'
      inputs:
        packageType: 'sdk'
        version: $(dotnetVersion)
    
    - task: Cache@2
      displayName: 'Cache NuGet packages'
      inputs:
        key: 'nuget | "$(Agent.OS)" | **/packages.lock.json'
        restoreKeys: |
          nuget | "$(Agent.OS)"
          nuget
        path: '$(Pipeline.Workspace)/.nuget/packages'
    
    - task: DotNetCoreCLI@2
      displayName: 'Restore packages'
      inputs:
        command: 'restore'
        projects: '**/*.csproj'
    
    - task: DotNetCoreCLI@2
      displayName: 'Build solution'
      inputs:
        command: 'build'
        projects: '**/*.csproj'
        arguments: '--configuration $(buildConfiguration) --no-restore'
    
    - task: DotNetCoreCLI@2
      displayName: 'Run tests'
      inputs:
        command: 'test'
        projects: '**/*Tests.csproj'
        arguments: |
          --configuration $(buildConfiguration) 
          --no-build 
          --collect:"XPlat Code Coverage"
          --logger trx
          --results-directory $(Agent.TempDirectory)
    
    - task: PublishTestResults@2
      displayName: 'Publish test results'
      condition: always()
      inputs:
        testResultsFormat: 'VSTest'
        testResultsFiles: '**/*.trx'
        searchFolder: '$(Agent.TempDirectory)'
        testRunTitle: 'Tests - $(displayName)'
    
    - task: PublishCodeCoverageResults@1
      displayName: 'Publish code coverage'
      inputs:
        codeCoverageTool: 'Cobertura'
        summaryFileLocation: '$(Agent.TempDirectory)/**/coverage.cobertura.xml'
```

## 📚 **Exercise 3: Complete CI/CD with Security (35 minutes)**

### **Enterprise-Grade Pipeline Prompts**

#### **Security Integration Strategy**
```
"Design a comprehensive CI/CD pipeline that integrates security scanning throughout 
the development lifecycle. Include static code analysis, dependency vulnerability 
scanning, container security, and compliance validation. Explain how to implement 
security gates that don't slow development velocity."
```

#### **Deployment Automation**
```
"Create a complete CI/CD workflow that includes environment promotion with approval 
gates, blue-green deployment capabilities, automated rollback triggers, and 
comprehensive monitoring integration. Include Infrastructure as Code management 
and environment-specific configuration strategies."
```

### **Sample Complete CI/CD Solution**

```yaml
name: Complete CI/CD Pipeline

on:
  push:
    branches: [ main, develop ]
  pull_request:
    branches: [ main ]

env:
  AZURE_WEBAPP_NAME: 'my-web-app'
  AZURE_WEBAPP_PACKAGE_PATH: './publish'
  DOTNET_VERSION: '8.0.x'

jobs:
  # Comprehensive CI Stage
  continuous-integration:
    runs-on: ubuntu-latest
    
    steps:
    - name: Checkout
      uses: actions/checkout@v4
      
    - name: Setup .NET
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: ${{ env.DOTNET_VERSION }}
    
    # Security scanning first
    - name: Run security scan
      uses: securecodewarrior/github-action-add-sarif@v1
      with:
        sarif-file: 'security-scan-results.sarif'
    
    # Build and test
    - name: Restore and build
      run: |
        dotnet restore
        dotnet build --no-restore --configuration Release
    
    - name: Run tests with coverage
      run: |
        dotnet test --no-build --configuration Release \
          --collect:"XPlat Code Coverage" \
          --logger "trx;LogFileName=test-results.trx"
    
    # Package for deployment
    - name: Create deployment package
      run: |
        dotnet publish --no-build --configuration Release \
          --output ${{ env.AZURE_WEBAPP_PACKAGE_PATH }}
    
    - name: Upload deployment artifact
      uses: actions/upload-artifact@v4
      with:
        name: webapp-package
        path: ${{ env.AZURE_WEBAPP_PACKAGE_PATH }}

  # Development deployment
  deploy-dev:
    needs: continuous-integration
    runs-on: ubuntu-latest
    if: github.ref == 'refs/heads/develop'
    environment: development
    
    steps:
    - name: Download artifact
      uses: actions/download-artifact@v4
      with:
        name: webapp-package
        path: ${{ env.AZURE_WEBAPP_PACKAGE_PATH }}
    
    - name: Deploy to Azure Web App (Dev)
      uses: azure/webapps-deploy@v2
      with:
        app-name: '${{ env.AZURE_WEBAPP_NAME }}-dev'
        publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE_DEV }}
        package: ${{ env.AZURE_WEBAPP_PACKAGE_PATH }}

  # Production deployment with approval
  deploy-production:
    needs: continuous-integration
    runs-on: ubuntu-latest
    if: github.ref == 'refs/heads/main'
    environment: 
      name: production
      url: https://${{ env.AZURE_WEBAPP_NAME }}.azurewebsites.net
    
    steps:
    - name: Download artifact
      uses: actions/download-artifact@v4
      with:
        name: webapp-package
        path: ${{ env.AZURE_WEBAPP_PACKAGE_PATH }}
    
    # Blue-green deployment with slots
    - name: Deploy to staging slot
      uses: azure/webapps-deploy@v2
      with:
        app-name: ${{ env.AZURE_WEBAPP_NAME }}
        slot-name: 'staging'
        publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
        package: ${{ env.AZURE_WEBAPP_PACKAGE_PATH }}
    
    - name: Run health checks on staging
      run: |
        # Custom health check script
        ./scripts/health-check.sh https://${{ env.AZURE_WEBAPP_NAME }}-staging.azurewebsites.net
    
    - name: Swap staging to production
      uses: azure/CLI@v1
      with:
        azcliversion: 2.30.0
        inlineScript: |
          az webapp deployment slot swap \
            --resource-group ${{ secrets.AZURE_RESOURCE_GROUP }} \
            --name ${{ env.AZURE_WEBAPP_NAME }} \
            --slot staging \
            --target-slot production
```

## 🎯 **Assessment Criteria**

### **Technical Competency**
- [ ] Designs appropriate pipeline architecture for application requirements
- [ ] Implements effective caching and optimization strategies
- [ ] Integrates security scanning and quality gates appropriately
- [ ] Creates environment promotion workflows with proper gates

### **AI Collaboration Skills**
- [ ] Asks strategic questions about DevOps best practices
- [ ] Iterates on pipeline design based on AI feedback
- [ ] Explains reasoning behind architectural decisions
- [ ] Uses AI to validate and optimize pipeline performance

### **DevOps Understanding**
- [ ] Balances automation with necessary manual checkpoints
- [ ] Considers security and compliance throughout the pipeline
- [ ] Designs for maintainability and team collaboration
- [ ] Implements proper monitoring and observability

## 🚀 **Common Challenges & Solutions**

### **Challenge: "My pipeline is too slow"**
**Coaching Approach:**
- Guide analysis of pipeline bottlenecks
- Explore parallelization opportunities
- Discuss caching strategies and their trade-offs
- Consider selective execution based on changed files

### **Challenge: "Security scanning breaks my workflow"**
**Learning Opportunity:**
- Discuss shift-left security principles
- Explore security scanning tool options and configurations
- Balance security with developer productivity
- Implement security gates that provide value

### **Challenge: "Environment promotions are complicated"**
**Strategic Teaching:**
- Start with simple promotion workflows
- Gradually add approval gates and validations
- Discuss environment parity and configuration management
- Explore blue-green and canary deployment patterns

## 📝 **Instructor Notes**

### **Platform Considerations**
- **GitHub Actions**: Better for open source and GitHub-native workflows
- **Azure Pipelines**: Superior for enterprise and Microsoft ecosystem
- **Cross-Platform**: Discuss when to use cloud vs. self-hosted runners

### **Time Management**
- **Exercise 1**: Basic CI concepts need solid foundation
- **Exercise 2**: Matrix builds often require additional explanation
- **Exercise 3**: Complete CI/CD can be overwhelming - focus on key concepts

### **Extension Opportunities**
- Infrastructure as Code integration
- Advanced deployment strategies (canary, feature flags)
- Monitoring and observability integration
- Cost optimization for CI/CD pipelines

**Remember: Focus on developing strategic DevOps thinking with AI assistance, not just pipeline creation! 🎯**
