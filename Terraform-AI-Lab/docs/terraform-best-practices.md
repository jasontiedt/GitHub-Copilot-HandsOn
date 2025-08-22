# Terraform Best Practices with AI 🏆

Learn industry-standard practices for Infrastructure as Code development enhanced with AI assistance.

## 🎯 Core Terraform Principles

### **1. Code Organization**
Structure your Terraform projects for maintainability:

```
project/
├── main.tf              # Primary resource definitions
├── variables.tf         # Input variables
├── outputs.tf          # Output values
├── providers.tf        # Provider configurations
├── terraform.tfvars    # Variable values (never commit secrets!)
├── modules/            # Reusable modules
│   ├── vpc/
│   ├── compute/
│   └── database/
└── environments/       # Environment-specific configurations
    ├── dev/
    ├── staging/
    └── prod/
```

**AI Prompt**: "Organize this Terraform code following best practices for a multi-environment project"

### **2. Resource Naming Conventions**
Use consistent, descriptive names:

```hcl
# Good naming examples
resource "aws_vpc" "main" {
  # vpc-projectname-environment-purpose
  tags = {
    Name = "vpc-myapp-prod-main"
  }
}

resource "aws_security_group" "web_servers" {
  name = "sg-myapp-prod-web"
}
```

**AI Prompt**: "Create a comprehensive tagging strategy for AWS resources following best practices"

### **3. Variable Management**
Define clear, documented variables:

```hcl
variable "environment" {
  description = "Environment name (dev, staging, prod)"
  type        = string
  validation {
    condition     = contains(["dev", "staging", "prod"], var.environment)
    error_message = "Environment must be dev, staging, or prod."
  }
}

variable "instance_count" {
  description = "Number of EC2 instances to create"
  type        = number
  default     = 2
  validation {
    condition     = var.instance_count >= 1 && var.instance_count <= 10
    error_message = "Instance count must be between 1 and 10."
  }
}
```

## 🔒 Security Best Practices

### **State File Security**
Never store state files locally in production:

```hcl
terraform {
  backend "s3" {
    bucket         = "my-terraform-state-bucket"
    key            = "prod/terraform.tfstate"
    region         = "us-east-1"
    encrypt        = true
    dynamodb_table = "terraform-state-locks"
  }
}
```

**AI Prompt**: "Configure secure Terraform backend with S3 and DynamoDB for state locking"

### **Secrets Management**
Never hardcode sensitive values:

```hcl
# Bad - hardcoded password
resource "aws_db_instance" "bad_example" {
  password = "hardcoded123!"  # Never do this!
}

# Good - use AWS Secrets Manager
data "aws_secretsmanager_secret_version" "db_password" {
  secret_id = "prod/database/password"
}

resource "aws_db_instance" "good_example" {
  password = data.aws_secretsmanager_secret_version.db_password.secret_string
}
```

**AI Prompt**: "Implement secure secrets management for this RDS database configuration"

### **Least Privilege IAM**
Create minimal IAM policies:

```hcl
data "aws_iam_policy_document" "lambda_policy" {
  statement {
    effect = "Allow"
    actions = [
      "logs:CreateLogGroup",
      "logs:CreateLogStream",
      "logs:PutLogEvents"
    ]
    resources = ["arn:aws:logs:*:*:*"]
  }
  
  statement {
    effect = "Allow"
    actions = ["dynamodb:GetItem", "dynamodb:PutItem"]
    resources = [aws_dynamodb_table.example.arn]
  }
}
```

**AI Prompt**: "Create minimal IAM policy for Lambda function accessing DynamoDB and CloudWatch Logs"

## 🏗️ Module Development

### **Creating Reusable Modules**
Structure modules for reusability:

```
modules/web-app/
├── main.tf
├── variables.tf
├── outputs.tf
├── README.md
└── examples/
    └── complete/
```

**Module Interface Example**:
```hcl
# modules/web-app/variables.tf
variable "environment" {
  description = "Environment name"
  type        = string
}

variable "vpc_id" {
  description = "VPC ID where resources will be created"
  type        = string
}

variable "subnet_ids" {
  description = "List of subnet IDs for the application"
  type        = list(string)
}

# modules/web-app/outputs.tf
output "load_balancer_dns" {
  description = "DNS name of the load balancer"
  value       = aws_lb.main.dns_name
}

output "auto_scaling_group_arn" {
  description = "ARN of the auto scaling group"
  value       = aws_autoscaling_group.main.arn
}
```

**AI Prompt**: "Create a reusable Terraform module for a web application with configurable scaling parameters"

### **Module Versioning**
Use semantic versioning for modules:

```hcl
module "web_app" {
  source  = "git::https://github.com/company/terraform-modules.git//web-app?ref=v1.2.0"
  
  environment = var.environment
  vpc_id      = module.vpc.vpc_id
  subnet_ids  = module.vpc.private_subnet_ids
}
```

## 📊 Resource Management

### **Resource Lifecycle Management**
Handle resource dependencies properly:

```hcl
resource "aws_launch_template" "web" {
  name_prefix   = "web-"
  image_id      = data.aws_ami.amazon_linux.id
  instance_type = var.instance_type
  
  lifecycle {
    create_before_destroy = true
  }
  
  depends_on = [aws_security_group.web]
}
```

**AI Prompt**: "Add proper lifecycle management to this launch template configuration"

### **Data Sources vs Resources**
Use data sources for existing infrastructure:

```hcl
# Reference existing VPC
data "aws_vpc" "existing" {
  tags = {
    Name = "existing-vpc"
  }
}

# Create new subnet in existing VPC
resource "aws_subnet" "new" {
  vpc_id     = data.aws_vpc.existing.id
  cidr_block = "10.0.1.0/24"
}
```

## 🔍 Testing and Validation

### **Input Validation**
Validate variables at the source:

```hcl
variable "allowed_cidr_blocks" {
  description = "CIDR blocks allowed to access the application"
  type        = list(string)
  
  validation {
    condition = alltrue([
      for cidr in var.allowed_cidr_blocks : can(cidrhost(cidr, 0))
    ])
    error_message = "All CIDR blocks must be valid."
  }
}
```

**AI Prompt**: "Add comprehensive input validation to these Terraform variables"

### **Plan Before Apply**
Always review plans in CI/CD:

```bash
#!/bin/bash
# CI/CD script example
terraform init -backend-config="bucket=${TF_STATE_BUCKET}"
terraform plan -out=tfplan
terraform show -json tfplan > plan.json

# Review plan with AI assistance
# AI Prompt: "Review this Terraform plan for security and best practices"
```

## 📈 Performance Optimization

### **Parallel Resource Creation**
Design for parallel execution:

```hcl
# These resources can be created in parallel
resource "aws_subnet" "public" {
  count = length(var.availability_zones)
  # ... configuration
}

resource "aws_subnet" "private" {
  count = length(var.availability_zones)
  # ... configuration
}

# This depends on subnets being created first
resource "aws_route_table_association" "public" {
  count          = length(aws_subnet.public)
  subnet_id      = aws_subnet.public[count.index].id
  route_table_id = aws_route_table.public.id
}
```

### **Resource Targeting**
Use targeting for large infrastructures:

```bash
# Apply only specific resources
terraform apply -target=module.database
terraform apply -target=aws_security_group.web
```

## 🔄 CI/CD Integration

### **GitOps Workflow**
Implement infrastructure as code in CI/CD:

```yaml
# .github/workflows/terraform.yml
name: Terraform
on:
  push:
    branches: [main]
  pull_request:
    branches: [main]

jobs:
  terraform:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v3
    - uses: hashicorp/setup-terraform@v2
    
    - name: Terraform Format
      run: terraform fmt -check
      
    - name: Terraform Init
      run: terraform init
      
    - name: Terraform Plan
      run: terraform plan
      
    - name: Terraform Apply
      if: github.ref == 'refs/heads/main'
      run: terraform apply -auto-approve
```

**AI Prompt**: "Create a comprehensive CI/CD pipeline for Terraform with security scanning and approval workflows"

## 💰 Cost Optimization

### **Resource Right-Sizing**
Use AI to optimize costs:

```hcl
# Use locals for cost-optimized configurations
locals {
  instance_type_by_env = {
    dev     = "t3.micro"
    staging = "t3.small"
    prod    = "t3.medium"
  }
}

resource "aws_instance" "web" {
  instance_type = local.instance_type_by_env[var.environment]
  # ... other configuration
}
```

**AI Prompt**: "Optimize this Terraform configuration for cost while maintaining performance requirements"

### **Tagging for Cost Allocation**
Implement comprehensive tagging:

```hcl
locals {
  common_tags = {
    Environment = var.environment
    Project     = var.project_name
    Owner       = var.owner
    CostCenter  = var.cost_center
    Terraform   = "true"
  }
}

resource "aws_instance" "web" {
  tags = merge(local.common_tags, {
    Name = "web-server-${var.environment}"
    Type = "web-server"
  })
}
```

## 🛠️ Troubleshooting Common Issues

### **State Drift Detection**
Regularly check for configuration drift:

```bash
# Detect drift
terraform plan -detailed-exitcode

# Refresh state
terraform refresh

# Import existing resources
terraform import aws_instance.web i-1234567890abcdef0
```

**AI Prompt**: "Help me resolve this Terraform state drift issue and prevent it in the future"

### **Dependency Issues**
Handle complex dependencies:

```hcl
resource "aws_security_group_rule" "web_ingress" {
  type                     = "ingress"
  from_port                = 80
  to_port                  = 80
  protocol                 = "tcp"
  source_security_group_id = aws_security_group.lb.id
  security_group_id        = aws_security_group.web.id
}
```

## 📚 Documentation

### **Self-Documenting Code**
Write clear, documented configurations:

```hcl
# Web Application Load Balancer
# Distributes incoming HTTP/HTTPS traffic across multiple EC2 instances
# in multiple availability zones for high availability
resource "aws_lb" "web" {
  name               = "${var.project_name}-${var.environment}-alb"
  internal           = false
  load_balancer_type = "application"
  
  # Use public subnets for internet-facing load balancer
  subnets = var.public_subnet_ids
  
  # Security group allows HTTP/HTTPS from internet
  security_groups = [aws_security_group.alb.id]
  
  # Enable deletion protection in production
  enable_deletion_protection = var.environment == "prod"
  
  tags = local.common_tags
}
```

**AI Prompt**: "Add comprehensive documentation comments to this Terraform configuration"

Remember: These best practices ensure your Infrastructure as Code is secure, maintainable, and scalable. Use AI to help implement these patterns, but always understand the underlying concepts!
