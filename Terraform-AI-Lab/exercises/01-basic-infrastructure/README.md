# Exercise 1: Basic Infrastructure 🏗️

Learn Terraform fundamentals with AI assistance by creating essential cloud resources.

## 🎯 Learning Objectives

- Understand Terraform syntax and structure
- Create basic AWS resources using AI prompts
- Learn about providers, resources, and variables
- Practice infrastructure planning and deployment

## 📋 Prerequisites

- AWS CLI configured with appropriate credentials
- Terraform installed (v1.0+)
- VS Code with HashiCorp Terraform extension
- GitHub Copilot enabled

## 🚀 Exercise Steps

### Step 1: Provider Configuration (5 minutes)

Create `providers.tf` and ask Copilot:

```hcl
# Configure AWS provider for us-east-1 region with latest best practices
```

**Expected AI Response**: Provider block with version constraints

### Step 2: Basic VPC Infrastructure (10 minutes)

Create `vpc.tf` and use these AI prompts:

```hcl
# Create a VPC with CIDR 10.0.0.0/16 named "main-vpc"
# Include DNS hostnames and resolution enabled
```

```hcl
# Create public and private subnets in different AZs
# Public subnet: 10.0.1.0/24 in us-east-1a
# Private subnet: 10.0.2.0/24 in us-east-1b
```

### Step 3: Internet Gateway and Routing (10 minutes)

Add to `vpc.tf`:

```hcl
# Create internet gateway for the VPC
# Create route table for public subnet with route to internet gateway
# Associate route table with public subnet
```

### Step 4: Security Groups (10 minutes)

Create `security-groups.tf`:

```hcl
# Create security group for web servers
# Allow inbound HTTP (80) and HTTPS (443) from anywhere
# Allow outbound traffic to anywhere
# Include descriptive tags
```

## 💡 AI Prompting Tips

### Effective Terraform Prompts
- **Be specific about resource names**: "Create an AWS VPC named 'main-vpc'"
- **Include configuration details**: "with CIDR block 10.0.0.0/16 and DNS hostnames enabled"
- **Request best practices**: "following AWS security best practices"
- **Ask for explanations**: "Explain why we need an internet gateway for public subnets"

### Common AI Requests
- "Generate Terraform code to..."
- "What's the best practice for..."
- "How do I configure..."
- "Explain this Terraform resource..."

## 🔍 Validation Steps

1. **Initialize Terraform**:
   ```bash
   terraform init
   ```

2. **Validate configuration**:
   ```bash
   terraform validate
   ```

3. **Review plan**:
   ```bash
   terraform plan
   ```

4. **Apply infrastructure**:
   ```bash
   terraform apply
   ```

## 📊 Expected Resources

After completion, you should have:
- ✅ VPC with proper CIDR block
- ✅ Public and private subnets in different AZs
- ✅ Internet gateway attached to VPC
- ✅ Route table with internet route
- ✅ Security group with web server rules

## 🧪 Testing Your Infrastructure

Ask Copilot to help you:

```hcl
# Create outputs to display VPC ID, subnet IDs, and security group ID
```

Run `terraform output` to verify all resources were created successfully.

## 🎯 Success Criteria

- [ ] All resources plan and apply without errors
- [ ] Resources follow naming conventions
- [ ] Security groups have appropriate rules
- [ ] Outputs display correct resource IDs
- [ ] Infrastructure can be destroyed cleanly with `terraform destroy`

## 🔄 Next Steps

Once complete, move to Exercise 2 to build a web application stack on this foundation!

## 💭 Reflection Questions

1. How did AI help you understand Terraform resource relationships?
2. What prompting strategies worked best for generating infrastructure code?
3. How would you modify this infrastructure for production use?
