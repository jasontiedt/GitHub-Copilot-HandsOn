# Exercise 2: Web Application Stack 🌐

Build a complete 3-tier web application infrastructure using AI-assisted Terraform development.

## 🎯 Learning Objectives

- Create a scalable web application architecture
- Implement load balancing and auto-scaling
- Configure RDS database with proper security
- Learn about resource dependencies and data sources

## 🏗️ Architecture Overview

```
Internet → ALB → Auto Scaling Group → EC2 Instances → RDS Database
               ↓
           CloudWatch Monitoring
```

## 📋 Prerequisites

- Completed Exercise 1 (Basic Infrastructure)
- Understanding of web application components
- AWS CLI access with EC2 and RDS permissions

## 🚀 Exercise Steps

### Step 1: Application Load Balancer (15 minutes)

Create `load-balancer.tf` and ask Copilot:

```hcl
# Create an Application Load Balancer for the web application
# Configure it to use the public subnets from Exercise 1
# Add target group for EC2 instances on port 80
# Create listener for HTTP traffic on port 80
```

### Step 2: Launch Template and Auto Scaling (15 minutes)

Create `compute.tf`:

```hcl
# Create launch template for web servers
# Use Amazon Linux 2 AMI with t3.micro instance type
# Include user data script to install and start Apache web server
# Reference security group from Exercise 1
```

```hcl
# Create Auto Scaling Group using the launch template
# Set min size 2, max size 6, desired capacity 2
# Use private subnets for instances
# Attach to the load balancer target group
```

### Step 3: RDS Database (15 minutes)

Create `database.tf`:

```hcl
# Create DB subnet group using private subnets
# Create security group for RDS allowing MySQL traffic from web servers
# Create RDS MySQL instance with proper security configuration
# Use db.t3.micro, allocated storage 20GB, backup retention 7 days
```

## 💡 Advanced AI Prompting

### Complex Infrastructure Prompts
- **Multi-resource scenarios**: "Create an auto scaling group that registers instances with a load balancer target group"
- **Security considerations**: "Configure RDS security group to only allow access from web server security group"
- **Best practices**: "Generate launch template with latest security patches and monitoring enabled"

### Data Source Usage
Ask Copilot:
```hcl
# Use data source to get latest Amazon Linux 2 AMI ID
# Reference VPC and subnet IDs from Exercise 1 using data sources
```

## 📝 Configuration Files to Create

1. **load-balancer.tf** - ALB, target group, and listener
2. **compute.tf** - Launch template and auto scaling group  
3. **database.tf** - RDS instance and related security
4. **variables.tf** - Input variables for customization
5. **outputs.tf** - Important resource information

## 🔍 Validation and Testing

### Deployment Steps
1. **Plan the infrastructure**:
   ```bash
   terraform plan -var="db_password=YourSecurePassword123!"
   ```

2. **Apply the configuration**:
   ```bash
   terraform apply -var="db_password=YourSecurePassword123!"
   ```

### Testing the Application
1. **Get load balancer DNS**:
   ```bash
   terraform output load_balancer_dns
   ```

2. **Test web application**:
   ```bash
   curl http://[load-balancer-dns]
   ```

3. **Verify auto scaling**:
   - Check EC2 console for running instances
   - Verify instances are registered with target group

## 📊 Expected Resources

After completion, you should have:
- ✅ Application Load Balancer with target group
- ✅ Launch template with web server configuration
- ✅ Auto Scaling Group with 2 running instances
- ✅ RDS MySQL database in private subnets
- ✅ Proper security groups for all components
- ✅ Working web application accessible via ALB

## 🧪 Advanced Testing with AI

Ask Copilot to help you create:

```hcl
# CloudWatch alarms for high CPU utilization
# SNS topic for notifications
# Auto scaling policies based on CPU metrics
```

## 🔒 Security Validation

Use AI to review your configuration:
- "Review this Terraform configuration for security best practices"
- "What security improvements should I make to this RDS setup?"
- "How can I enhance the security of this web application stack?"

## 🎯 Success Criteria

- [ ] Load balancer responds to HTTP requests
- [ ] Auto scaling group maintains desired capacity
- [ ] RDS database is accessible from web servers only
- [ ] All resources have appropriate tags
- [ ] Security groups follow least privilege principle
- [ ] Infrastructure can be destroyed and recreated consistently

## 🔄 Next Steps

Ready for Exercise 3? We'll add advanced networking with VPN connections and multi-region capabilities!

## 💭 Reflection Questions

1. How did AI help you understand the relationships between ALB, ASG, and EC2?
2. What security considerations did AI suggest for the database configuration?
3. How would you scale this architecture for production workloads?
