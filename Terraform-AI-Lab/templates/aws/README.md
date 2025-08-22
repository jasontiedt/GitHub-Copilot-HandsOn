# AWS Infrastructure Templates

This directory contains reusable Terraform templates for common AWS infrastructure patterns. Use these as starting points for your own infrastructure projects.

## 📁 Template Categories

### 🌐 **Networking Templates**
- **vpc-basic.tf** - Simple VPC with public/private subnets
- **vpc-advanced.tf** - Enterprise VPC with NAT gateways and multiple AZs
- **vpc-peering.tf** - VPC peering connections and routing

### 🖥️ **Compute Templates**
- **ec2-web-server.tf** - Single EC2 instance with security groups
- **auto-scaling.tf** - Auto scaling group with launch template
- **ecs-cluster.tf** - ECS cluster for containerized applications

### 🗄️ **Database Templates**
- **rds-mysql.tf** - RDS MySQL with backup and monitoring
- **rds-postgresql.tf** - PostgreSQL with read replicas
- **dynamodb.tf** - DynamoDB tables with proper indexing

### ⚡ **Serverless Templates**
- **lambda-api.tf** - Lambda function with API Gateway
- **s3-static-website.tf** - S3 static website with CloudFront
- **step-functions.tf** - Step Functions state machine

## 🤖 Using Templates with AI

### Template Customization Prompts
```hcl
# Customize this VPC template for a production environment
# with 3 availability zones and dedicated NAT gateways
```

```hcl
# Modify this RDS template to include encryption at rest
# and automated backups with 30-day retention
```

### Template Enhancement
```hcl
# Add CloudWatch monitoring and alerting to this template
# Include cost optimization recommendations
```

## 🏷️ Template Standards

All templates follow these conventions:
- **Variables**: Defined in `variables.tf` for customization
- **Outputs**: Important resource IDs and endpoints
- **Tags**: Consistent tagging strategy for all resources
- **Comments**: Clear documentation for AI assistance

## 📖 Usage Instructions

1. **Copy template** to your working directory
2. **Customize variables** for your environment
3. **Use AI prompts** to modify and enhance
4. **Validate and deploy** with Terraform commands

## 🔧 AI Prompt Examples

### For VPC Templates:
- "Adapt this VPC template for a multi-tier application with DMZ"
- "Add VPC Flow Logs and security monitoring to this template"
- "Optimize this VPC configuration for cost and performance"

### For Compute Templates:
- "Enhance this EC2 template with Systems Manager integration"
- "Add auto-recovery and detailed monitoring to this instance"
- "Convert this single instance template to a high-availability setup"

### For Database Templates:
- "Secure this RDS template following AWS security best practices"
- "Add cross-region backup and disaster recovery to this database"
- "Optimize this database configuration for read-heavy workloads"
