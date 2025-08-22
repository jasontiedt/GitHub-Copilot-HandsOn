# Exercise 3: Complete CI/CD Pipelines (60 minutes)

🟡 **Advanced Independent Learning** - Master end-to-end deployment automation through strategic AI collaboration

## 🎯 Learning Objectives

Develop expertise in comprehensive CI/CD through AI-assisted learning:
- ✅ **Strategic deployment planning** using AI for architecture decisions
- ✅ **Independent problem-solving** for complex deployment challenges
- ✅ **Advanced prompting techniques** for cloud deployment scenarios
- ✅ **Risk management** and deployment strategy selection
- ✅ **Monitoring and observability** integration through AI guidance

## 📚 **Foundational Analysis**

### **Think About Complete CI/CD Strategy**
Before implementation, analyze the full deployment lifecycle:
- What does "production ready" mean for your application architecture?
- How do environment promotion strategies impact development velocity?
- What are the trade-offs between deployment speed and safety?
- How do you balance automation with manual oversight?

### **Deployment Strategy Decision Framework**
| Strategy | **Your Analysis Challenge** | **When to Choose** |
|----------|----------------------------|-------------------|
| **Rolling Update** | What are the risks of gradual instance replacement? | Standard applications with stateless architecture |
| **Blue-Green** | How do you handle data consistency between environments? | Zero-downtime critical applications |
| **Canary** | What metrics determine successful canary validation? | Risk-sensitive or high-traffic applications |
| **Feature Flags** | How do you manage complexity of flag-driven deployments? | A/B testing and gradual feature rollouts |

## 🛠️ Technical Prerequisites

### Required Foundation
- [ ] Mastered **Exercises 1 & 2** with confidence in CI fundamentals
- [ ] **Cloud account** access (Azure, AWS, or GCP) for deployment targets
- [ ] **Service connections** understanding for secure cloud integration
- [ ] **Containerization concepts** and infrastructure as code basics
- [ ] **Sample application** ready for production deployment

### **Your Architecture Analysis Challenge**
Before building pipelines, research and understand:

```
┌─────────────┐    ┌─────────────┐    ┌─────────────┐
│ Development │───▶│   Staging   │───▶│ Production  │
│Environment  │    │Environment  │    │Environment  │
└─────────────┘    └─────────────┘    └─────────────┘
      ▲                    ▲                    ▲
      │                    │                    │
   Auto Deploy      Approval Gate       Manual Gate
```

**Analyze Each Stage:**
- What validation occurs at each environment transition?
- How do you handle configuration differences between environments?
- What rollback strategies are needed at each stage?
- How do you implement progressive deployment with safety gates?

## 🚀 **Your AI Challenge: Complete CI/CD Mastery**

### **Think First: End-to-End Strategy** 🤔

**Comprehensive Analysis:**
- What does a production-ready deployment pipeline require beyond basic CI?
- How do you balance deployment speed with safety and compliance?
- What monitoring and observability must be integrated from the start?
- How do environment-specific configurations impact your architecture?

### **Your Challenge**: GitHub Actions Complete CI/CD (20 minutes)

**Your Strategic Planning Challenge:**
End-to-end CI/CD pipelines are complex systems with many moving parts:

- What are the essential stages from code commit to production?
- How do you handle secrets and environment-specific configuration securely?
- What approval processes balance automation with human oversight?
- How do you implement safe deployment strategies with rollback capabilities?

<details>
<summary>💡 Click for Advanced CI/CD Strategy Prompting</summary>

**Enterprise-Grade Pipeline Development:**

1. **Comprehensive Architecture Planning:**
   ```
   "I need to design a complete CI/CD pipeline for a .NET 8 Web API that will be 
   deployed to Azure App Service across development, staging, and production environments. 
   Help me architect a pipeline that includes security scanning, environment promotion 
   with approval gates, zero-downtime deployment strategies, and automated rollback 
   capabilities. What would be a production-ready architecture?"
   ```

2. **Security and Compliance Integration:**
   ```
   "Design a CI/CD pipeline that integrates comprehensive security practices including 
   secret management, vulnerability scanning, compliance validation, and access control. 
   The pipeline needs to meet enterprise security requirements while maintaining 
   developer productivity. What are the essential security gates and how should they 
   be implemented?"
   ```

3. **Advanced Deployment Strategies:**
   ```
   "Implement a sophisticated deployment strategy that includes blue-green deployments 
   with Azure App Service slots, automated health checks, progressive traffic routing, 
   and intelligent rollback triggers. Explain the trade-offs and implementation 
   considerations for each approach."
   ```

4. **Infrastructure as Code Integration:**
   ```
   "Integrate Infrastructure as Code (Bicep/ARM templates) into my CI/CD pipeline 
   so that infrastructure changes are versioned, tested, and deployed alongside 
   application code. Include environment-specific parameter management and 
   infrastructure validation strategies."
   ```

5. **Monitoring and Observability:**
   ```
   "Design comprehensive monitoring and observability integration for my CI/CD pipeline 
   that includes deployment tracking, application health monitoring, performance 
   baselines, and automated alerting. How should monitoring influence deployment 
   decisions and rollback triggers?"
   ```

**Pro Tip**: Ask AI to explain the reasoning behind each architectural decision and alternative approaches!

</details>

2. **Configure GitHub environments**:
   ```yaml
   # In repository settings → Environments
   - Development (auto-deploy)
   - Staging (auto-deploy after CI)
   - Production (manual approval required)
   ```

3. **Create deployment workflow**:
   ```yaml
   name: CI/CD Pipeline
   
   on:
     push:
       branches: [main]
     pull_request:
       branches: [main]
   
   jobs:
     ci:
       # Build, test, security scan
     
     deploy-dev:
       needs: ci
       environment: development
       # Deploy to dev environment
     
     deploy-staging:
       needs: deploy-dev
       environment: staging
       # Deploy to staging environment
     
     deploy-production:
       needs: deploy-staging
       environment: production
       # Deploy to production with approval
   ```

**✅ Success Criteria**:
- [ ] CI pipeline completes successfully with all quality gates
- [ ] Automated deployment to development environment
- [ ] Approval-gated deployment to production
- [ ] Environment-specific configuration applied correctly
- [ ] Rollback mechanism tested and working

### Task 2: Azure Pipelines Multi-Stage CD (20 minutes)

**🎯 Goal**: Implement equivalent CD pipeline in Azure DevOps

**🤖 AI Prompt Strategy**:
```
Convert this GitHub Actions CI/CD pipeline to Azure Pipelines with:
- Multi-stage pipeline structure (CI, dev, staging, production)
- Azure Resource Manager template deployments
- Service connections for secure cloud authentication
- Variable groups for environment-specific configuration
- Approval and gate configurations
- Release quality gates with automated testing
- Deployment job strategies and health checks

Include Azure-specific best practices for enterprise deployment patterns.
```

**📋 Implementation Steps**:

1. **Create multi-stage pipeline**:
   ```yaml
   # azure-pipelines.yml
   trigger:
     branches:
       include: [main]
   
   stages:
   - stage: CI
     displayName: 'Continuous Integration'
     jobs:
     # Build and test jobs
   
   - stage: DeployDev
     displayName: 'Deploy to Development'
     dependsOn: CI
     jobs:
     # Development deployment
   
   - stage: DeployStaging
     displayName: 'Deploy to Staging'
     dependsOn: DeployDev
     jobs:
     # Staging deployment with validation
   
   - stage: DeployProduction
     displayName: 'Deploy to Production'
     dependsOn: DeployStaging
     jobs:
     # Production deployment with approvals
   ```

2. **Configure service connections**:
   - Azure Resource Manager connection
   - Container registry connections
   - Secret management integration

3. **Set up variable groups**:
   ```yaml
   variables:
   - group: 'development-vars'
   - group: 'staging-vars'  
   - group: 'production-vars'
   ```

**✅ Success Criteria**:
- [ ] Multi-stage pipeline executes in correct sequence
- [ ] Service connections work securely
- [ ] Variable groups provide environment-specific config
- [ ] Approval gates function correctly
- [ ] Deployment strategies work as expected

### Task 3: Cloud Infrastructure Deployment (15 minutes)

**🎯 Goal**: Implement Infrastructure as Code for your deployment targets

**🤖 AI Prompt Strategy**:
```
Create Infrastructure as Code templates for deploying a .NET 8 Web API to Azure with:
- Azure App Service with staging slots for blue-green deployment
- Azure SQL Database with connection string management
- Application Insights for monitoring and logging
- Azure Key Vault for secrets management
- Storage account for application data and backups
- Network security groups and application gateway
- Auto-scaling configuration and health check endpoints

Include both ARM templates and Bicep alternatives, with parameter files for different environments.
```

**📋 Implementation Steps**:

1. **Create infrastructure templates**:
   ```bash
   # Infrastructure structure
   infrastructure/
   ├── main.bicep
   ├── modules/
   │   ├── appservice.bicep
   │   ├── database.bicep
   │   └── monitoring.bicep
   └── parameters/
       ├── dev.parameters.json
       ├── staging.parameters.json
       └── prod.parameters.json
   ```

2. **Deploy infrastructure in pipeline**:
   ```yaml
   - name: Deploy Infrastructure
     uses: azure/arm-deploy@v1
     with:
       subscriptionId: ${{ secrets.AZURE_SUBSCRIPTION_ID }}
       resourceGroupName: ${{ env.RESOURCE_GROUP }}
       template: ./infrastructure/main.bicep
       parameters: ./infrastructure/parameters/${{ env.ENVIRONMENT }}.parameters.json
   ```

3. **Configure application deployment**:
   - Use deployment slots for zero-downtime deployment
   - Implement health checks and readiness probes
   - Configure auto-scaling based on metrics

**✅ Success Criteria**:
- [ ] Infrastructure deploys consistently across environments
- [ ] Zero-downtime deployment working with slots
- [ ] Health checks and monitoring configured
- [ ] Auto-scaling responds to load appropriately
- [ ] Secrets and configuration managed securely

### Task 4: Advanced Deployment Strategies (5 minutes)

**🎯 Goal**: Implement sophisticated deployment patterns

**🤖 AI Prompt Strategy**:
```
Enhance my deployment pipeline with advanced deployment strategies including:
- Blue-green deployment with automatic traffic switching
- Canary releases with gradual traffic shifting (10%, 50%, 100%)
- Feature flag integration for controlled feature rollouts
- Automated rollback triggers based on health metrics
- A/B testing integration with deployment pipelines
- Database migration strategies that support rollbacks
- Cross-region deployment with disaster recovery

Provide examples for both Kubernetes and traditional cloud platforms.
```

**📋 Implementation Steps**:

1. **Implement blue-green deployment**:
   ```yaml
   - name: Deploy to Blue Slot
     # Deploy to staging slot
   
   - name: Validate Deployment
     # Run health checks and smoke tests
   
   - name: Swap Slots
     # Switch traffic to new version
   
   - name: Monitor and Rollback
     # Watch metrics and rollback if needed
   ```

2. **Configure canary releases**:
   ```yaml
   - name: Deploy Canary (10%)
     # Deploy to small percentage of traffic
   
   - name: Monitor Metrics
     # Check error rates, performance metrics
   
   - name: Promote to 50%
     # Increase traffic if metrics are healthy
   
   - name: Full Rollout
     # Complete deployment if all checks pass
   ```

3. **Set up automated rollback**:
   ```yaml
   - name: Monitor Health
     # Check application health metrics
   
   - name: Trigger Rollback
     # Automatic rollback on health failures
     if: failure()
   ```

**✅ Success Criteria**:
- [ ] Blue-green deployment working smoothly
- [ ] Canary releases with traffic shifting implemented
- [ ] Automated rollback triggers tested
- [ ] Monitoring and alerting integrated
- [ ] Zero-downtime deployment achieved

## 🔍 Testing and Validation

### Deployment Testing Strategy

1. **Smoke Tests**:
   ```bash
   # Basic application functionality
   curl -f https://myapp-staging.azurewebsites.net/health
   curl -f https://myapp-staging.azurewebsites.net/api/weather
   ```

2. **Load Testing**:
   ```bash
   # Use tools like Azure Load Testing or k6
   # Validate performance under load
   ```

3. **Security Testing**:
   ```bash
   # OWASP ZAP integration
   # Security scanning of deployed application
   ```

### Monitoring and Observability

1. **Application Metrics**:
   - Response times and throughput
   - Error rates and success rates
   - Resource utilization (CPU, memory)
   - Custom business metrics

2. **Infrastructure Metrics**:
   - Service health and availability
   - Database performance
   - Network latency and connectivity
   - Storage and backup status

3. **Alerting Configuration**:
   ```yaml
   alerts:
     - name: High Error Rate
       condition: error_rate > 5%
       action: trigger_rollback
     
     - name: High Response Time
       condition: avg_response_time > 2s
       action: scale_up
   ```

## 🎯 Success Validation

### Completion Checklist
- [ ] **Complete CI/CD pipeline** from source to production
- [ ] **Environment promotion** with appropriate gates
- [ ] **Cloud deployment** working correctly
- [ ] **Zero-downtime deployment** achieved
- [ ] **Monitoring and alerting** configured
- [ ] **Rollback mechanism** tested successfully

### Performance Benchmarks
| Metric | Target | Your Result |
|--------|--------|-------------|
| Deployment Time | <10 minutes | ____min |
| Downtime | 0 seconds | ____sec |
| Rollback Time | <2 minutes | ____min |
| Success Rate | >99% | ___% |

## 💡 Key Learnings and Best Practices

### Deployment Pipeline Design
- **Environment Parity**: Keep environments as similar as possible
- **Automated Testing**: Include comprehensive testing at each stage
- **Security Integration**: Scan for vulnerabilities before deployment
- **Configuration Management**: Use environment-specific configuration

### Risk Management
- **Gradual Rollouts**: Use canary or blue-green strategies for risk reduction
- **Monitoring**: Implement comprehensive monitoring and alerting
- **Rollback Planning**: Always have a tested rollback strategy
- **Change Management**: Document and communicate deployment changes

### Performance Optimization
- **Parallel Processing**: Deploy to multiple regions simultaneously when possible
- **Caching Strategies**: Implement appropriate caching at application and infrastructure levels
- **Resource Scaling**: Use auto-scaling to handle load variations
- **Health Checks**: Implement robust health and readiness probes

## 🔄 Next Steps

### Immediate Actions
1. **Document deployment procedures** and troubleshooting guides
2. **Create incident response** procedures for deployment failures
3. **Set up monitoring dashboards** for deployment and application health
4. **Train team members** on deployment procedures and rollback processes

### Advanced Exploration
- **Multi-region deployments** for high availability and disaster recovery
- **Database deployment strategies** including schema migrations and data seeding
- **Container orchestration** with Kubernetes for microservices
- **GitOps patterns** for declarative application deployment

### Preparation for Exercise 4
- **Review security scanning tools** and integration approaches
- **Understand compliance requirements** for your organization
- **Plan quality gates** and testing strategies
- **Consider governance** and policy enforcement needs

## 🤖 AI Prompting Tips for This Exercise

### Effective Prompts
✅ **Good**: "Create a CI/CD pipeline for .NET 8 with Azure deployment and approval gates"

✅ **Better**: "Design a multi-environment CI/CD pipeline with blue-green deployment to Azure App Service, including infrastructure as code and automated rollback"

✅ **Best**: "Build a comprehensive CI/CD strategy for .NET 8 Web API with environment promotion (dev→staging→prod), zero-downtime blue-green deployment to Azure App Service using slots, Infrastructure as Code with Bicep, automated rollback based on health metrics, and integration with monitoring and alerting systems"

### Troubleshooting Prompts
- "My Azure deployment is failing with [specific error] - how do I fix this?"
- "Implement automated rollback for my deployment pipeline when health checks fail"
- "Optimize my deployment pipeline for faster feedback and reduced deployment time"

**Ready for security and quality integration? Continue to Exercise 4! 🚀🔐**
