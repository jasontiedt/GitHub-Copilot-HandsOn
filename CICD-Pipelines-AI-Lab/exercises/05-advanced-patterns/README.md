# Exercise 5: Advanced Patterns (90+ minutes)

🔴 **Advanced Level** - Master enterprise DevOps automation with templates, GitOps, and orchestration

## 🎯 Learning Objectives

By the end of this exercise, you will:
- ✅ **Create reusable pipeline templates** and custom actions for team standardization
- ✅ **Implement GitOps workflows** for declarative infrastructure and application management
- ✅ **Orchestrate complex deployments** across multiple services and environments
- ✅ **Design monitoring and observability** systems with automated alerting and self-healing
- ✅ **Build enterprise governance** frameworks with policy as code and compliance automation

## 📚 Pre-Exercise Knowledge

### Enterprise DevOps Concepts
- **GitOps**: Declarative infrastructure and application management using Git as source of truth
- **Pipeline Templates**: Reusable workflow components that enforce standards across teams
- **Policy as Code**: Automated enforcement of governance and compliance requirements
- **Service Orchestration**: Coordinated deployment and management of microservices
- **Self-Healing Systems**: Automated detection and remediation of system issues

### Advanced Patterns Architecture
```
┌─────────────┐    ┌─────────────┐    ┌─────────────┐
│   GitOps    │    │  Template   │    │ Monitoring  │
│ Repository  │────│  Pipeline   │────│ & Alerting  │
└─────────────┘    └─────────────┘    └─────────────┘
       │                    │                    │
       │            ┌─────────────┐               │
       └────────────│  Policy     │───────────────┘
                    │ Enforcement │
                    └─────────────┘
                           │
                  ┌─────────────┐
                  │ Service     │
                  │Orchestration│
                  └─────────────┘
```

## 🛠️ Technical Prerequisites

### Required Setup
- [ ] Completed **Exercises 1-4** successfully
- [ ] **Advanced Git knowledge** (branching strategies, hooks, workflows)
- [ ] **Kubernetes basics** or container orchestration experience
- [ ] **Infrastructure as Code** experience (Terraform, ARM, Bicep)
- [ ] **Monitoring tools** access (Prometheus, Grafana, Application Insights)

### Enterprise Architecture Context
- **Multi-team collaboration** with shared standards and templates
- **Microservices architecture** with service dependencies and communication
- **Multi-environment management** across development, staging, and production
- **Compliance requirements** for security, audit, and governance
- **Disaster recovery** and business continuity planning

## 🚀 Exercise Tasks

### Task 1: Reusable Pipeline Templates (25 minutes)

**🎯 Goal**: Create standardized, reusable pipeline templates for enterprise use

**🤖 AI Prompt Strategy**:
```
Create a comprehensive pipeline template system for an enterprise DevOps organization including:
- GitHub Actions reusable workflows for different application types (.NET, Node.js, Python)
- Azure DevOps template library with parameterized stages and jobs
- Custom actions/tasks for organization-specific requirements
- Template versioning and lifecycle management
- Parameter validation and default value handling
- Documentation and examples for template consumers
- Template testing and validation frameworks
- Governance policies for template usage and compliance

Design templates that balance standardization with flexibility, allowing teams to customize while maintaining compliance.
```

**📋 Implementation Steps**:

1. **GitHub Actions Reusable Workflows**:
   ```yaml
   # .github/workflows/templates/dotnet-ci-cd.yml
   name: .NET CI/CD Template
   
   on:
     workflow_call:
       inputs:
         dotnet-version:
           required: false
           type: string
           default: '8.0.x'
         environment:
           required: true
           type: string
         run-tests:
           required: false
           type: boolean
           default: true
       secrets:
         AZURE_CREDENTIALS:
           required: true
         SONAR_TOKEN:
           required: false
   
   jobs:
     ci:
       uses: ./.github/workflows/templates/ci-template.yml
       with:
         dotnet-version: ${{ inputs.dotnet-version }}
         run-tests: ${{ inputs.run-tests }}
       secrets: inherit
     
     cd:
       needs: ci
       uses: ./.github/workflows/templates/cd-template.yml
       with:
         environment: ${{ inputs.environment }}
       secrets: inherit
   ```

2. **Azure DevOps Template Library**:
   ```yaml
   # templates/stages/dotnet-build-stage.yml
   parameters:
   - name: dotnetVersion
     type: string
     default: '8.0.x'
   - name: buildConfiguration
     type: string
     default: 'Release'
   - name: runTests
     type: boolean
     default: true
   - name: publishArtifacts
     type: boolean
     default: true
   
   stages:
   - stage: Build
     displayName: 'Build and Test'
     jobs:
     - job: BuildJob
       displayName: 'Build Application'
       steps:
       - template: ../steps/dotnet-restore.yml
         parameters:
           dotnetVersion: ${{ parameters.dotnetVersion }}
       
       - template: ../steps/dotnet-build.yml
         parameters:
           buildConfiguration: ${{ parameters.buildConfiguration }}
       
       - ${{ if eq(parameters.runTests, true) }}:
         - template: ../steps/dotnet-test.yml
       
       - ${{ if eq(parameters.publishArtifacts, true) }}:
         - template: ../steps/publish-artifacts.yml
   ```

3. **Custom Actions/Tasks**:
   ```yaml
   # Custom GitHub Action
   name: 'Security Scan Action'
   description: 'Enterprise security scanning with custom rules'
   inputs:
     scan-type:
       description: 'Type of security scan'
       required: true
       default: 'full'
     severity-threshold:
       description: 'Minimum severity to fail build'
       required: false
       default: 'high'
   
   runs:
     using: 'composite'
     steps:
       - name: Run Security Scan
         shell: bash
         run: |
           # Custom security scanning logic
           ./scripts/enterprise-security-scan.sh \
             --type ${{ inputs.scan-type }} \
             --threshold ${{ inputs.severity-threshold }}
   ```

4. **Template Validation Framework**:
   ```yaml
   # Template testing pipeline
   name: Template Validation
   
   on:
     push:
       paths:
         - '.github/workflows/templates/**'
         - 'azure-pipelines/templates/**'
   
   jobs:
     validate-templates:
       runs-on: ubuntu-latest
       steps:
         - uses: actions/checkout@v4
         
         - name: Validate GitHub Actions Templates
           run: |
             # Validate YAML syntax
             yamllint .github/workflows/templates/
             
             # Test template with sample parameters
             act workflow_call \
               --input-file test-inputs.json \
               --workflows .github/workflows/templates/
         
         - name: Validate Azure DevOps Templates
           run: |
             # Validate Azure Pipelines YAML
             az pipelines validate \
               --yaml-path azure-pipelines/templates/
   ```

**✅ Success Criteria**:
- [ ] Reusable templates created for multiple technology stacks
- [ ] Template versioning and lifecycle management implemented
- [ ] Parameter validation and documentation complete
- [ ] Template testing framework operational
- [ ] Teams can consume templates easily

### Task 2: GitOps Implementation (25 minutes)

**🎯 Goal**: Implement GitOps workflows for declarative infrastructure and application management

**🤖 AI Prompt Strategy**:
```
Implement a complete GitOps workflow including:
- Git repository structure for application and infrastructure code separation
- ArgoCD or Flux configuration for Kubernetes deployments
- Terraform GitOps for cloud infrastructure management
- Branch-based environment promotion (feature → dev → staging → production)
- Policy as code integration with Open Policy Agent (OPA)
- Automated drift detection and reconciliation
- Secret management with sealed secrets or external secret operators
- Multi-tenancy support for different teams and applications
- Disaster recovery and backup strategies for GitOps repositories

Design a system that provides full auditability, automated compliance, and self-healing capabilities.
```

**📋 Implementation Steps**:

1. **GitOps Repository Structure**:
   ```
   gitops-repo/
   ├── apps/
   │   ├── frontend/
   │   │   ├── base/
   │   │   └── overlays/
   │   │       ├── dev/
   │   │       ├── staging/
   │   │       └── production/
   │   └── backend/
   │       ├── base/
   │       └── overlays/
   ├── infrastructure/
   │   ├── terraform/
   │   │   ├── modules/
   │   │   └── environments/
   │   └── kubernetes/
   │       ├── cluster-config/
   │       └── namespaces/
   ├── policies/
   │   ├── security/
   │   ├── compliance/
   │   └── governance/
   └── scripts/
       ├── validation/
       └── automation/
   ```

2. **ArgoCD Application Configuration**:
   ```yaml
   # apps/frontend/overlays/production/application.yaml
   apiVersion: argoproj.io/v1alpha1
   kind: Application
   metadata:
     name: frontend-production
     namespace: argocd
   spec:
     project: default
     source:
       repoURL: https://github.com/company/gitops-repo
       targetRevision: production
       path: apps/frontend/overlays/production
     destination:
       server: https://kubernetes.default.svc
       namespace: frontend-prod
     syncPolicy:
       automated:
         prune: true
         selfHeal: true
       syncOptions:
         - CreateNamespace=true
   ```

3. **Terraform GitOps Pipeline**:
   ```yaml
   name: Infrastructure GitOps
   
   on:
     push:
       branches: [main]
       paths: ['infrastructure/terraform/**']
   
   jobs:
     terraform-plan:
       runs-on: ubuntu-latest
       steps:
         - uses: actions/checkout@v4
         
         - name: Setup Terraform
           uses: hashicorp/setup-terraform@v2
         
         - name: Terraform Plan
           run: |
             cd infrastructure/terraform/environments/production
             terraform init
             terraform plan -out=tfplan
         
         - name: Policy Validation
           run: |
             # Validate with OPA policies
             opa test policies/terraform/
             conftest verify --policy policies/terraform/ tfplan
     
     terraform-apply:
       needs: terraform-plan
       if: github.ref == 'refs/heads/main'
       runs-on: ubuntu-latest
       environment: production
       steps:
         - name: Terraform Apply
           run: |
             terraform apply tfplan
   ```

4. **Policy as Code Integration**:
   ```rego
   # policies/kubernetes/security.rego
   package kubernetes.security
   
   deny[msg] {
     input.kind == "Deployment"
     not input.spec.template.spec.securityContext.runAsNonRoot
     msg := "Containers must run as non-root user"
   }
   
   deny[msg] {
     input.kind == "Service"
     input.spec.type == "LoadBalancer"
     not input.metadata.annotations["service.beta.kubernetes.io/azure-load-balancer-internal"]
     msg := "LoadBalancer services must be internal"
   }
   ```

**✅ Success Criteria**:
- [ ] GitOps workflows deploy applications automatically
- [ ] Infrastructure changes go through GitOps process
- [ ] Policy violations are detected and prevented
- [ ] Drift detection and auto-remediation working
- [ ] Full audit trail of all changes maintained

### Task 3: Multi-Service Orchestration (25 minutes)

**🎯 Goal**: Orchestrate complex deployments across multiple microservices

**🤖 AI Prompt Strategy**:
```
Design a comprehensive microservices deployment orchestration system including:
- Dependency-aware deployment sequencing across multiple services
- Service mesh integration (Istio/Linkerd) for traffic management
- Database migration coordination with zero-downtime deployments
- Feature flag integration for progressive rollouts
- Cross-service integration testing and validation
- Distributed tracing and monitoring during deployments
- Rollback orchestration with service dependency consideration
- Blue-green and canary deployment strategies for service clusters
- API versioning and backward compatibility validation

Include examples for both Kubernetes-native and cloud platform deployments with proper error handling and recovery procedures.
```

**📋 Implementation Steps**:

1. **Service Dependency Graph**:
   ```yaml
   # deployment-config.yaml
   services:
     database:
       dependencies: []
       deployment_strategy: rolling
       health_check: "/health"
     
     backend-api:
       dependencies: ["database"]
       deployment_strategy: blue_green
       health_check: "/api/health"
       migration_scripts: ["db-migration.sql"]
     
     frontend:
       dependencies: ["backend-api"]
       deployment_strategy: canary
       health_check: "/health"
       traffic_split: [10, 50, 100]
     
     worker-service:
       dependencies: ["database", "backend-api"]
       deployment_strategy: rolling
       health_check: "/worker/health"
   ```

2. **Orchestration Pipeline**:
   ```yaml
   name: Multi-Service Deployment
   
   on:
     push:
       branches: [main]
   
   jobs:
     detect-changes:
       runs-on: ubuntu-latest
       outputs:
         services: ${{ steps.changes.outputs.services }}
       steps:
         - name: Detect Service Changes
           id: changes
           run: |
             # Analyze changed files and determine affected services
             python scripts/detect-service-changes.py
     
     deploy-services:
       needs: detect-changes
       strategy:
         matrix:
           service: ${{ fromJson(needs.detect-changes.outputs.services) }}
       runs-on: ubuntu-latest
       steps:
         - name: Deploy Service
           run: |
             # Deploy service based on dependency order
             python scripts/orchestrated-deploy.py \
               --service ${{ matrix.service }} \
               --strategy ${{ matrix.service.deployment_strategy }}
   ```

3. **Dependency-Aware Deployment Script**:
   ```python
   # scripts/orchestrated-deploy.py
   import json
   import time
   from typing import Dict, List
   
   class ServiceOrchestrator:
       def __init__(self, config_file: str):
           with open(config_file) as f:
               self.config = json.load(f)
           self.deployment_order = self._calculate_deployment_order()
       
       def _calculate_deployment_order(self) -> List[str]:
           # Topological sort based on dependencies
           # Returns ordered list of services to deploy
           pass
       
       def deploy_services(self, changed_services: List[str]):
           for service in self.deployment_order:
               if service in changed_services:
                   self._deploy_service(service)
                   self._wait_for_health(service)
       
       def _deploy_service(self, service: str):
           strategy = self.config['services'][service]['deployment_strategy']
           if strategy == 'blue_green':
               self._blue_green_deploy(service)
           elif strategy == 'canary':
               self._canary_deploy(service)
           else:
               self._rolling_deploy(service)
       
       def _wait_for_health(self, service: str):
           # Implement health check waiting logic
           pass
   ```

4. **Service Mesh Integration**:
   ```yaml
   # Istio VirtualService for canary deployment
   apiVersion: networking.istio.io/v1alpha3
   kind: VirtualService
   metadata:
     name: frontend-canary
   spec:
     http:
     - match:
       - headers:
           canary:
             exact: "true"
       route:
       - destination:
           host: frontend
           subset: canary
     - route:
       - destination:
           host: frontend
           subset: stable
         weight: 90
       - destination:
           host: frontend
           subset: canary
         weight: 10
   ```

**✅ Success Criteria**:
- [ ] Services deploy in correct dependency order
- [ ] Health checks prevent promotion of unhealthy services
- [ ] Rollback can handle service dependencies
- [ ] Traffic management working for canary deployments
- [ ] Integration tests validate cross-service functionality

### Task 4: Monitoring and Self-Healing (15 minutes)

**🎯 Goal**: Implement comprehensive monitoring with automated remediation

**🤖 AI Prompt Strategy**:
```
Create a comprehensive monitoring and self-healing system including:
- Prometheus and Grafana setup for metrics collection and visualization
- Application Insights/DataDog integration for application performance monitoring
- Custom metrics collection from applications and infrastructure
- Alert manager configuration with escalation policies
- Automated remediation workflows (scaling, restart, rollback)
- SLI/SLO definition and tracking with error budgets
- Chaos engineering integration for resilience testing
- Log aggregation and analysis with automated anomaly detection
- Distributed tracing for microservices troubleshooting

Design alerting that minimizes noise while ensuring critical issues are addressed promptly with appropriate automation.
```

**📋 Implementation Steps**:

1. **Monitoring Stack Configuration**:
   ```yaml
   # monitoring/prometheus-config.yml
   global:
     scrape_interval: 15s
     evaluation_interval: 15s
   
   rule_files:
     - "alert-rules.yml"
     - "recording-rules.yml"
   
   scrape_configs:
     - job_name: 'kubernetes-pods'
       kubernetes_sd_configs:
         - role: pod
       relabel_configs:
         - source_labels: [__meta_kubernetes_pod_annotation_prometheus_io_scrape]
           action: keep
           regex: true
   
   alerting:
     alertmanagers:
       - static_configs:
           - targets: ['alertmanager:9093']
   ```

2. **Alert Rules and Automation**:
   ```yaml
   # monitoring/alert-rules.yml
   groups:
   - name: application-alerts
     rules:
     - alert: HighErrorRate
       expr: rate(http_requests_total{status=~"5.."}[5m]) > 0.1
       for: 5m
       labels:
         severity: critical
         automation: auto-rollback
       annotations:
         summary: "High error rate detected"
         description: "Error rate is {{ $value }} for {{ $labels.instance }}"
         runbook_url: "https://runbooks.company.com/high-error-rate"
     
     - alert: HighMemoryUsage
       expr: container_memory_usage_bytes / container_spec_memory_limit_bytes > 0.9
       for: 10m
       labels:
         severity: warning
         automation: auto-scale
   ```

3. **Self-Healing Automation**:
   ```yaml
   name: Self-Healing Automation
   
   on:
     repository_dispatch:
       types: [alert-triggered]
   
   jobs:
     auto-remediation:
       runs-on: ubuntu-latest
       steps:
         - name: Parse Alert
           id: alert
           run: |
             echo "alert_type=${{ github.event.client_payload.alert }}" >> $GITHUB_OUTPUT
             echo "severity=${{ github.event.client_payload.severity }}" >> $GITHUB_OUTPUT
         
         - name: Auto-Rollback
           if: steps.alert.outputs.alert_type == 'HighErrorRate'
           run: |
             # Trigger automated rollback
             kubectl rollout undo deployment/my-app
         
         - name: Auto-Scale
           if: steps.alert.outputs.alert_type == 'HighMemoryUsage'
           run: |
             # Scale up the deployment
             kubectl scale deployment my-app --replicas=10
   ```

4. **SLI/SLO Tracking**:
   ```yaml
   # SLI/SLO Configuration
   slos:
     availability:
       sli: rate(http_requests_total{status!~"5.."}[5m]) / rate(http_requests_total[5m])
       target: 0.999
       error_budget_window: 30d
     
     latency:
       sli: histogram_quantile(0.95, rate(http_request_duration_seconds_bucket[5m]))
       target: 0.5
       error_budget_window: 30d
   ```

**✅ Success Criteria**:
- [ ] Comprehensive monitoring covers all critical metrics
- [ ] Alerts trigger appropriate automated responses
- [ ] SLI/SLO tracking provides error budget visibility
- [ ] Self-healing reduces manual intervention requirements
- [ ] Monitoring provides sufficient observability for troubleshooting

## 🔍 Advanced Testing and Validation

### Enterprise-Scale Testing

1. **Chaos Engineering**:
   ```bash
   # Chaos Monkey integration
   kubectl apply -f chaos-engineering/
   
   # Test system resilience
   chaostoolkit run chaos-experiments.json
   ```

2. **Load Testing at Scale**:
   ```bash
   # Large-scale load testing
   k6 run --vus 1000 --duration 30m enterprise-load-test.js
   ```

3. **Security at Scale**:
   ```bash
   # Enterprise security validation
   trivy image --severity HIGH,CRITICAL myapp:latest
   kube-score score manifests/
   ```

### Governance Validation

1. **Policy Compliance**:
   ```bash
   # Validate all policies
   opa test policies/
   conftest verify --policy policies/ manifests/
   ```

2. **Template Compliance**:
   ```bash
   # Verify template usage across teams
   python scripts/audit-template-usage.py
   ```

## 🎯 Success Validation

### Completion Checklist
- [ ] **Reusable templates** standardize team practices
- [ ] **GitOps workflows** manage infrastructure and applications
- [ ] **Service orchestration** handles complex deployments
- [ ] **Monitoring and alerting** provide operational visibility
- [ ] **Self-healing systems** reduce manual intervention
- [ ] **Policy enforcement** ensures compliance automatically

### Enterprise Metrics
| Metric | Target | Your Result |
|--------|--------|-------------|
| Template Adoption | >80% | ____% |
| Deployment Success Rate | >99% | ____% |
| Mean Time to Recovery | <5 minutes | ____min |
| Policy Compliance | 100% | ____% |

## 💡 Key Learnings and Best Practices

### Template Design
- **Balance flexibility and standardization** to meet diverse team needs
- **Version templates** and provide migration paths for updates
- **Document extensively** with examples and troubleshooting guides
- **Test templates** rigorously across different scenarios

### GitOps Implementation
- **Separate concerns** between application and infrastructure repositories
- **Implement proper RBAC** and security boundaries
- **Plan for disaster recovery** and backup scenarios
- **Monitor drift** and implement automated reconciliation

### Service Orchestration
- **Design for failure** with proper timeout and retry mechanisms
- **Implement circuit breakers** to prevent cascade failures
- **Plan rollback strategies** that consider service dependencies
- **Use distributed tracing** for troubleshooting complex interactions

### Monitoring and Observability
- **Define clear SLIs and SLOs** that align with business objectives
- **Implement meaningful alerting** that drives action, not noise
- **Design for self-healing** where safe and appropriate
- **Maintain runbooks** and escalation procedures for complex issues

## 🔄 Next Steps

### Enterprise Adoption
1. **Create governance framework** for pipeline standards and templates
2. **Establish center of excellence** for DevOps practices and training
3. **Implement gradual rollout** of advanced patterns across teams
4. **Create metrics and KPIs** for measuring DevOps maturity and success

### Continuous Improvement
- **Regular template updates** based on team feedback and new requirements
- **Policy evolution** to adapt to changing security and compliance needs
- **Monitoring optimization** based on operational experience and incidents
- **Knowledge sharing** through documentation, training, and communities of practice

### Innovation and Future Technologies
- **AI/ML integration** for predictive analytics and automated optimization
- **Advanced deployment strategies** like progressive delivery and feature flags
- **Edge computing** and multi-cloud deployment patterns
- **Sustainability** and green computing practices in CI/CD pipelines

## 🤖 AI Prompting Tips for This Exercise

### Effective Prompts
✅ **Good**: "Create reusable pipeline templates for multiple technology stacks with GitOps"

✅ **Better**: "Design enterprise DevOps automation with reusable templates, GitOps workflows, service orchestration, and comprehensive monitoring"

✅ **Best**: "Build a complete enterprise DevOps platform with parameterized pipeline templates for multi-language support, GitOps-driven infrastructure and application management, intelligent service orchestration with dependency awareness, comprehensive monitoring with self-healing capabilities, and policy-as-code governance that scales across multiple teams while maintaining security and compliance standards"

### Advanced Troubleshooting Prompts
- "Design a rollback strategy for a microservices deployment with complex service dependencies"
- "Create monitoring and alerting that balances automation with human oversight for critical systems"
- "Implement policy as code that enforces security standards without blocking developer productivity"

## 🏆 Congratulations!

You've completed the most advanced exercise in the CI/CD Pipelines AI Lab! You now have enterprise-grade skills in:

- ✅ **Template Development** - Creating reusable, standardized pipeline components
- ✅ **GitOps Implementation** - Managing infrastructure and applications declaratively
- ✅ **Service Orchestration** - Coordinating complex multi-service deployments
- ✅ **Advanced Monitoring** - Implementing observability with self-healing capabilities
- ✅ **Enterprise Governance** - Enforcing policies and compliance automatically

### Your DevOps Journey Continues

With these advanced patterns mastered, you're ready to:
- **Lead DevOps transformations** in enterprise environments
- **Design scalable automation** that grows with your organization
- **Implement best practices** that balance speed, security, and reliability
- **Mentor teams** in modern DevOps practices and AI-assisted development

**Welcome to the ranks of enterprise DevOps architects! 🚀🏢✨**
