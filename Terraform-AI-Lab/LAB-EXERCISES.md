# LAB EXERCISES - Terraform AI Lab

Complete hands-on exercises to master Infrastructure as Code with AI assistance.

## 🎯 Exercise Progression

Work through these exercises in order to build your Terraform and AI skills progressively:

### 🟢 **Exercise 1: Basic Infrastructure** (25 minutes)
**Objective**: Learn Terraform fundamentals with AI assistance
- Create VPC, subnets, and security groups
- Master provider configuration and resource blocks
- Practice effective AI prompting for infrastructure

**Skills Learned**: Terraform syntax, basic networking, AI-assisted development

### � **Exercise 2: Web Application Stack** (35 minutes)  
**Objective**: Build a complete 3-tier web application
- Deploy Application Load Balancer and Auto Scaling Group
- Configure RDS database with proper security
- Learn resource dependencies and data sources

**Skills Learned**: Multi-tier architecture, scalability patterns, database integration

### � **Exercise 3: Security & Best Practices** (30 minutes)
**Objective**: Implement production-ready infrastructure
- Create IAM policies and roles with least privilege
- Enable encryption and monitoring
- Add proper tagging and resource organization

**Skills Learned**: Security hardening, compliance frameworks, production readiness

**⏱️ Total Duration**: 1-1.5 hours | **📊 Difficulty**: Intermediate

## 🚀 Getting Started

### Prerequisites Checklist
Before starting any exercise, ensure you have:
- [ ] **Cloud CLI configured** (AWS CLI, Azure CLI, or gcloud)
- [ ] **Terraform installed** (v1.0 or later)
- [ ] **VS Code** with HashiCorp Terraform extension
- [ ] **GitHub Copilot** active and working
- [ ] **Basic understanding** of cloud computing concepts

### Environment Setup
1. **Choose your cloud provider** (AWS, Azure, or GCP)
2. **Run setup script** for your chosen provider:
   ```bash
   # For AWS
   ./scripts/setup-aws.sh
   
   # For Azure
   ./scripts/setup-azure.sh
   ```
3. **Verify installation**:
   ```bash
   terraform version
   aws sts get-caller-identity  # or equivalent for your cloud
   ```

## 💡 AI-Assisted Learning Approach

### Effective Prompting Strategy
For each exercise, use this proven approach:

1. **Start with requirements**: "Create AWS infrastructure for a web application with high availability"
2. **Be specific about components**: "Include Application Load Balancer, Auto Scaling Group, and RDS database"
3. **Request best practices**: "Follow AWS security best practices and include proper tagging"
4. **Ask for explanations**: "Explain why we need separate subnets for each tier"

### Learning Workflow
1. **📖 Read** the exercise README completely
2. **🤖 Generate** initial code with AI prompts
3. **🔍 Review** AI suggestions and understand the logic
4. **🛠️ Customize** for your specific requirements
5. **✅ Validate** with `terraform plan` and `terraform apply`
6. **📝 Document** what you learned for future reference

## 🔍 **Validation and Independent Learning**

### **Your Validation Methodology**
For each exercise, develop your systematic approach:

**Think About Validation Strategy:**
- How do you verify Terraform code quality before applying?
- What infrastructure testing should happen at each stage?
- How do you validate security and compliance requirements?
- What constitutes successful infrastructure deployment?

<details>
<summary>💡 Click for Infrastructure Validation Strategies</summary>

**Systematic Infrastructure Testing:**

1. **Pre-Deployment Validation:**
   ```
   "Help me create a comprehensive validation strategy for my Terraform infrastructure 
   that includes syntax checking, security scanning, cost estimation, and compliance 
   verification before applying changes. What tools and approaches should I use?"
   ```

2. **Infrastructure Testing:**
   ```
   "Design a testing approach for my cloud infrastructure that validates connectivity, 
   security groups, load balancer health, and database accessibility. How can I 
   automate infrastructure testing as part of my deployment process?"
   ```

3. **Security and Compliance Verification:**
   ```
   "Create a security validation checklist for my Terraform infrastructure that covers 
   IAM permissions, network security, encryption, and compliance requirements. How 
   can I automate security scanning for Infrastructure as Code?"
   ```

</details>
2. **Apply changes incrementally**:
   ```bash
   terraform apply
   ```
3. **Test functionality**:
   - Verify resources in cloud console
   - Test connectivity and functionality
   - Check security configurations
4. **Clean up resources**:
   ```bash
   terraform destroy
   ```

### Success Criteria
Each exercise includes specific success criteria. You've completed an exercise when:
- [ ] All resources deploy without errors
- [ ] Infrastructure passes functional tests
- [ ] Security configurations follow best practices
- [ ] You can explain the architecture to someone else
- [ ] Resources can be destroyed and recreated consistently

## 🆘 Troubleshooting Guide

### Common Issues and Solutions

**🔧 Terraform Init Fails**
- Check provider version constraints
- Verify network connectivity
- Ensure proper credentials are configured

**⚠️ Plan Shows Unexpected Changes**
- Check for configuration drift
- Verify variable values
- Review resource dependencies

**💥 Apply Fails with Errors**
- Read error messages carefully
- Check cloud service limits and quotas
- Verify IAM permissions
- Ask AI: "Help me resolve this Terraform error: [paste error]"

**🔐 Permission Denied Errors**
- Verify cloud CLI credentials
- Check IAM policies and roles
- Ensure required permissions for all services

### Getting Help
1. **Check exercise README** for specific guidance
2. **Use AI assistance**: "I'm getting this error in Terraform: [describe issue]"
3. **Review documentation** in the `docs/` folder
4. **Validate syntax**: Use VS Code Terraform extension for validation

## 📊 Progress Tracking

### Learning Milestones
Track your progress through the lab:

- [ ] **Terraform Basics** - Can create simple resources with AI help
- [ ] **Architecture Design** - Can build multi-tier applications
- [ ] **Security Implementation** - Can apply security best practices
- [ ] **Advanced Patterns** - Can create reusable modules and complex deployments
- [ ] **Troubleshooting** - Can debug and resolve infrastructure issues

### Competency Levels

**🟢 Beginner**: 
- Understands basic Terraform syntax
- Can use AI to generate simple infrastructure
- Follows guided exercises successfully

**🟡 Intermediate**:
- Designs multi-tier architectures
- Implements security and compliance requirements
- Customizes AI-generated code effectively

**🔴 Advanced**:
- Creates reusable infrastructure modules
- Implements multi-cloud strategies
- Mentors others in IaC best practices

## 🎯 Learning Outcomes

Upon completing all exercises, you will be able to:

### Technical Skills
- ✅ **Design and deploy** cloud infrastructure using Terraform
- ✅ **Implement security** and compliance requirements
- ✅ **Create reusable modules** for team collaboration
- ✅ **Troubleshoot infrastructure issues** effectively
- ✅ **Apply best practices** for Infrastructure as Code

### AI Integration Skills
- ✅ **Generate infrastructure code** using effective AI prompts
- ✅ **Review and customize** AI-generated configurations
- ✅ **Use AI for troubleshooting** and optimization
- ✅ **Combine AI assistance** with professional judgment
- ✅ **Teach others** to use AI for infrastructure development

## 🔄 Next Steps

After completing the lab:

1. **Apply skills** to real projects in your organization
2. **Create custom modules** for common infrastructure patterns
3. **Implement CI/CD pipelines** for infrastructure automation
4. **Share knowledge** with your team and community
5. **Stay updated** with latest Terraform and cloud provider features

## 💭 Reflection Questions

After each exercise, consider:
1. How did AI assistance improve your productivity?
2. What infrastructure concepts did you learn or reinforce?
3. How would you adapt this infrastructure for production use?
4. What security considerations are most important for this architecture?
5. How could you optimize costs while maintaining functionality?

**Ready to start your Infrastructure as Code journey? Begin with Exercise 1! 🚀**
