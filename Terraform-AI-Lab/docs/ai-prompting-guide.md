# AI Prompting Guide for Terraform 🤖

Master the art of generating infrastructure code with AI assistance. This guide provides proven strategies for effective Terraform development with GitHub Copilot.

## 🎯 Core Prompting Principles

### 1. **Be Specific and Contextual**
Instead of vague requests, provide detailed context:

❌ **Poor**: "Create a server"
✅ **Good**: "Create an AWS EC2 instance running Amazon Linux 2, t3.micro size, in the public subnet with a security group allowing HTTP traffic"

### 2. **Include Business Requirements**
Help AI understand the purpose:

❌ **Poor**: "Make a database"
✅ **Good**: "Create an RDS MySQL database for a web application with read replicas for scaling, automated backups, and encryption at rest"

### 3. **Request Best Practices**
Always ask for industry standards:

❌ **Poor**: "Add monitoring"
✅ **Good**: "Add CloudWatch monitoring with best practice alarms for CPU, memory, and disk utilization with SNS notifications"

## 🏗️ Infrastructure Pattern Prompts

### **VPC and Networking**
```hcl
# Create a production-ready VPC with:
# - CIDR 10.0.0.0/16
# - Public subnets in 3 AZs for load balancers
# - Private subnets in 3 AZs for application servers
# - Database subnets in 3 AZs for RDS
# - NAT gateways in each AZ for high availability
# - VPC Flow Logs for security monitoring
```

### **Compute Resources**
```hcl
# Create an Auto Scaling Group for a web application with:
# - Launch template using latest Amazon Linux 2 AMI
# - t3.medium instances with detailed monitoring
# - Min 2, max 10, desired 3 instances
# - Health checks integrated with Application Load Balancer
# - User data script to install and configure Apache
# - CloudWatch agent for custom metrics
```

### **Database Configuration**
```hcl
# Create an RDS PostgreSQL instance following AWS best practices:
# - Multi-AZ deployment for high availability
# - Encrypted storage with customer-managed KMS key
# - Automated backups with 30-day retention
# - Performance Insights enabled
# - Security group allowing access only from application tier
# - Parameter group optimized for web applications
```

### **Security and Compliance**
```hcl
# Create security groups following least privilege principle:
# - Web tier: Allow HTTP/HTTPS from internet, SSH from bastion
# - App tier: Allow traffic only from web tier and to database tier
# - Database tier: Allow database port only from app tier
# - Include descriptive tags and documentation
```

## 🔧 Advanced AI Techniques

### **Iterative Refinement**
Start simple and enhance with follow-up prompts:

1. **Initial**: "Create basic VPC with public and private subnets"
2. **Enhance**: "Add high availability by creating subnets in multiple AZs"
3. **Secure**: "Add VPC Flow Logs and network ACLs for enhanced security"
4. **Monitor**: "Add CloudWatch dashboards and alarms for network monitoring"

### **Template Generation**
Ask AI to create reusable templates:

```hcl
# Create a Terraform module for a web application stack that accepts:
# - Environment name (dev, staging, prod)
# - Instance size and count variables
# - Database engine and version
# - Generates all necessary networking, compute, and database resources
# - Includes comprehensive outputs for integration
```

### **Code Review and Optimization**
Use AI to improve existing code:

```hcl
# Review this Terraform configuration for:
# - Security best practices and vulnerabilities
# - Cost optimization opportunities
# - Performance improvements
# - Compliance with AWS Well-Architected Framework
# - Missing monitoring and alerting
```

## 📊 Cloud Provider Specific Prompts

### **AWS Prompts**
```hcl
# Create AWS Lambda function with API Gateway integration:
# - Python 3.9 runtime with proper IAM role
# - CloudWatch Logs with 30-day retention
# - X-Ray tracing enabled for monitoring
# - API Gateway with CORS configuration
# - Custom domain with Route 53 and ACM certificate
```

### **Azure Prompts**
```hcl
# Create Azure App Service with:
# - Linux container deployment
# - Application Insights monitoring
# - Azure SQL Database backend
# - Virtual Network integration
# - Managed identity for secure database access
# - Deployment slots for blue-green deployments
```

### **Google Cloud Prompts**
```hcl
# Create GKE cluster following Google's best practices:
# - Regional cluster with 3 zones
# - Node auto-scaling and auto-upgrade enabled
# - Workload Identity for secure pod authentication
# - Network policies for micro-segmentation
# - Cloud Monitoring and Logging integration
```

## 🛡️ Security-Focused Prompts

### **Identity and Access Management**
```hcl
# Create IAM roles and policies following least privilege:
# - EC2 instance role for web servers with minimal S3 access
# - Lambda execution role with specific DynamoDB permissions
# - Cross-account access role with time-limited sessions
# - Include condition statements for IP restrictions
```

### **Encryption and Secrets**
```hcl
# Implement encryption at rest and in transit:
# - KMS keys with proper key rotation policies
# - RDS encryption with customer-managed keys
# - S3 bucket encryption with default encryption
# - Secrets Manager for database credentials with auto-rotation
```

### **Compliance Requirements**
```hcl
# Create infrastructure meeting SOC 2 compliance:
# - All resources tagged with data classification
# - CloudTrail logging with log file validation
# - GuardDuty for threat detection
# - Config rules for compliance monitoring
# - Backup strategies with cross-region replication
```

## 🔄 Troubleshooting with AI

### **Error Resolution**
When encountering errors, provide context:

```hcl
# I'm getting this Terraform error: [paste error message]
# Here's my configuration: [paste relevant code]
# Please explain what's wrong and provide a fix
```

### **State Management Issues**
```hcl
# Help me resolve Terraform state conflicts:
# - Resource exists in AWS but not in state
# - State file is locked and won't unlock
# - Need to import existing infrastructure
# - Planning shows unexpected changes
```

### **Performance Optimization**
```hcl
# Analyze this infrastructure for performance bottlenecks:
# - Review compute instance sizing
# - Database connection pooling optimization
# - Network latency considerations
# - Caching strategies for better performance
```

## 📈 Monitoring and Observability Prompts

### **Comprehensive Monitoring**
```hcl
# Create complete monitoring solution:
# - CloudWatch dashboards for application metrics
# - Custom metrics from application logs
# - Automated alerting for critical thresholds
# - SNS notifications with escalation policies
# - Integration with PagerDuty or Slack
```

### **Cost Monitoring**
```hcl
# Implement cost optimization and monitoring:
# - Cost allocation tags for all resources
# - Budget alerts with spending thresholds
# - Reserved instance recommendations
# - Automated shutdown for development environments
# - Spot instance usage where appropriate
```

## 🚀 Pro Tips for Success

### **Effective Workflow**
1. **Start with architecture**: Ask AI to design the overall structure first
2. **Build incrementally**: Create one component at a time with AI assistance
3. **Validate frequently**: Use `terraform plan` to verify AI-generated code
4. **Document everything**: Ask AI to generate comments and documentation
5. **Review and optimize**: Use AI to review your final configuration

### **Common Pitfalls to Avoid**
- Don't accept AI suggestions blindly - always review and understand
- Test in development environment before applying to production
- Use version constraints for providers and modules
- Implement proper state management from the beginning
- Include proper error handling and rollback procedures

### **Collaboration with AI**
- Treat AI as a knowledgeable pair programmer, not an infallible oracle
- Ask for explanations when you don't understand suggestions
- Request alternative approaches to compare options
- Use AI to learn Terraform concepts, not just generate code

Remember: The goal is not just to generate working Terraform code, but to understand infrastructure concepts and develop expertise in Infrastructure as Code practices!
