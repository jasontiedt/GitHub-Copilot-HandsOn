# Terraform AI Lab - Solution Cheat Sheet 🏗️

**For Instructors & Advanced Learners**

This cheat sheet provides example solutions and effective Infrastructure as Code prompting strategies while maintaining the lab's independent learning philosophy.

## 🎯 **Learning Objectives Validation**

Students should demonstrate:
- **Strategic infrastructure analysis** before requesting AI assistance
- **Independent architecture planning** using AI for validation and optimization
- **Iterative infrastructure design** improvement based on AI feedback
- **Security and compliance integration** throughout the infrastructure lifecycle

## 📚 **Exercise 1: Basic Infrastructure (25 minutes)**

### **Effective Infrastructure Analysis Prompts**

#### **VPC Architecture Strategy**
```
"I need to design a VPC infrastructure for a web application that requires high 
availability, security isolation, and scalability. Help me understand the key 
components needed: public/private subnets, security groups, routing, and NAT 
gateways. Explain the architectural decisions and security implications of each 
component choice."
```

#### **Security-First Design**
```
"Design a network security strategy for AWS VPC that implements defense in depth. 
Include security group rules, NACL configurations, and proper subnet isolation. 
Explain how each security layer contributes to the overall security posture and 
what attack vectors they protect against."
```

### **Sample Terraform VPC Solution**

```hcl
# main.tf - Comprehensive VPC setup
terraform {
  required_version = ">= 1.0"
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 5.0"
    }
  }
}

provider "aws" {
  region = var.aws_region
  
  default_tags {
    tags = {
      Project     = var.project_name
      Environment = var.environment
      ManagedBy   = "Terraform"
    }
  }
}

# VPC with carefully planned CIDR
resource "aws_vpc" "main" {
  cidr_block           = var.vpc_cidr
  enable_dns_hostnames = true
  enable_dns_support   = true
  
  tags = {
    Name = "${var.project_name}-vpc"
  }
}

# Internet Gateway for public subnet connectivity
resource "aws_internet_gateway" "main" {
  vpc_id = aws_vpc.main.id
  
  tags = {
    Name = "${var.project_name}-igw"
  }
}

# Public subnets for load balancers and NAT gateways
resource "aws_subnet" "public" {
  count = length(var.availability_zones)
  
  vpc_id                  = aws_vpc.main.id
  cidr_block              = var.public_subnet_cidrs[count.index]
  availability_zone       = var.availability_zones[count.index]
  map_public_ip_on_launch = true
  
  tags = {
    Name = "${var.project_name}-public-${var.availability_zones[count.index]}"
    Type = "Public"
  }
}

# Private subnets for application servers
resource "aws_subnet" "private" {
  count = length(var.availability_zones)
  
  vpc_id            = aws_vpc.main.id
  cidr_block        = var.private_subnet_cidrs[count.index]
  availability_zone = var.availability_zones[count.index]
  
  tags = {
    Name = "${var.project_name}-private-${var.availability_zones[count.index]}"
    Type = "Private"
  }
}

# Database subnets with additional isolation
resource "aws_subnet" "database" {
  count = length(var.availability_zones)
  
  vpc_id            = aws_vpc.main.id
  cidr_block        = var.database_subnet_cidrs[count.index]
  availability_zone = var.availability_zones[count.index]
  
  tags = {
    Name = "${var.project_name}-database-${var.availability_zones[count.index]}"
    Type = "Database"
  }
}

# Elastic IPs for NAT gateways
resource "aws_eip" "nat" {
  count = length(var.availability_zones)
  
  domain = "vpc"
  
  tags = {
    Name = "${var.project_name}-nat-eip-${count.index + 1}"
  }
  
  depends_on = [aws_internet_gateway.main]
}

# NAT gateways for private subnet internet access
resource "aws_nat_gateway" "main" {
  count = length(var.availability_zones)
  
  allocation_id = aws_eip.nat[count.index].id
  subnet_id     = aws_subnet.public[count.index].id
  
  tags = {
    Name = "${var.project_name}-nat-${count.index + 1}"
  }
  
  depends_on = [aws_internet_gateway.main]
}

# Route table for public subnets
resource "aws_route_table" "public" {
  vpc_id = aws_vpc.main.id
  
  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_internet_gateway.main.id
  }
  
  tags = {
    Name = "${var.project_name}-public-rt"
  }
}

# Route tables for private subnets
resource "aws_route_table" "private" {
  count = length(var.availability_zones)
  
  vpc_id = aws_vpc.main.id
  
  route {
    cidr_block     = "0.0.0.0/0"
    nat_gateway_id = aws_nat_gateway.main[count.index].id
  }
  
  tags = {
    Name = "${var.project_name}-private-rt-${count.index + 1}"
  }
}

# Associate public subnets with public route table
resource "aws_route_table_association" "public" {
  count = length(aws_subnet.public)
  
  subnet_id      = aws_subnet.public[count.index].id
  route_table_id = aws_route_table.public.id
}

# Associate private subnets with their respective route tables
resource "aws_route_table_association" "private" {
  count = length(aws_subnet.private)
  
  subnet_id      = aws_subnet.private[count.index].id
  route_table_id = aws_route_table.private[count.index].id
}
```

### **Sample Security Groups**

```hcl
# security-groups.tf
# Web tier security group
resource "aws_security_group" "web" {
  name_prefix = "${var.project_name}-web-"
  vpc_id      = aws_vpc.main.id
  description = "Security group for web tier load balancers"
  
  ingress {
    description = "HTTPS from internet"
    from_port   = 443
    to_port     = 443
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }
  
  ingress {
    description = "HTTP from internet"
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }
  
  egress {
    description = "All outbound traffic"
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
  
  tags = {
    Name = "${var.project_name}-web-sg"
  }
  
  lifecycle {
    create_before_destroy = true
  }
}

# Application tier security group
resource "aws_security_group" "app" {
  name_prefix = "${var.project_name}-app-"
  vpc_id      = aws_vpc.main.id
  description = "Security group for application servers"
  
  ingress {
    description     = "HTTP from web tier"
    from_port       = 8080
    to_port         = 8080
    protocol        = "tcp"
    security_groups = [aws_security_group.web.id]
  }
  
  ingress {
    description     = "SSH for management"
    from_port       = 22
    to_port         = 22
    protocol        = "tcp"
    security_groups = [aws_security_group.bastion.id]
  }
  
  egress {
    description = "All outbound traffic"
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
  
  tags = {
    Name = "${var.project_name}-app-sg"
  }
  
  lifecycle {
    create_before_destroy = true
  }
}

# Database tier security group
resource "aws_security_group" "database" {
  name_prefix = "${var.project_name}-db-"
  vpc_id      = aws_vpc.main.id
  description = "Security group for database servers"
  
  ingress {
    description     = "MySQL/Aurora from app tier"
    from_port       = 3306
    to_port         = 3306
    protocol        = "tcp"
    security_groups = [aws_security_group.app.id]
  }
  
  tags = {
    Name = "${var.project_name}-db-sg"
  }
  
  lifecycle {
    create_before_destroy = true
  }
}
```

### **Key Teaching Points**

**✅ Strong Student Approaches:**
- Analyzes application requirements before designing infrastructure
- Asks about security implications and best practices
- Considers high availability and disaster recovery from the start
- Requests explanation of resource dependencies and relationships

**❌ Missed Learning Opportunities:**
- Creating flat network architectures without proper isolation
- Ignoring security group principles and least privilege access
- Not considering scalability and cost implications
- Copying examples without understanding the architectural decisions

## 📚 **Exercise 2: Web Application Stack (35 minutes)**

### **Advanced Architecture Prompts**

#### **Multi-Tier Application Design**
```
"Design a complete 3-tier web application infrastructure on AWS that supports high 
availability, auto-scaling, and disaster recovery. Include Application Load Balancer, 
Auto Scaling Groups, RDS with Multi-AZ, and proper security isolation. Explain the 
architectural decisions and how each component contributes to reliability and performance."
```

#### **Scalability and Performance Strategy**
```
"Create an infrastructure design that can handle variable traffic loads efficiently. 
Include auto-scaling policies, load balancing strategies, database read replicas, 
and CDN integration. Explain how to balance cost optimization with performance 
requirements."
```

### **Sample Application Stack Solution**

```hcl
# application-stack.tf
# Application Load Balancer
resource "aws_lb" "main" {
  name               = "${var.project_name}-alb"
  internal           = false
  load_balancer_type = "application"
  security_groups    = [aws_security_group.web.id]
  subnets            = aws_subnet.public[*].id
  
  enable_deletion_protection = var.environment == "production"
  
  tags = {
    Name = "${var.project_name}-alb"
  }
}

# ALB Target Group
resource "aws_lb_target_group" "app" {
  name     = "${var.project_name}-app-tg"
  port     = 8080
  protocol = "HTTP"
  vpc_id   = aws_vpc.main.id
  
  health_check {
    enabled             = true
    healthy_threshold   = 2
    interval            = 30
    matcher             = "200"
    path                = "/health"
    port                = "traffic-port"
    protocol            = "HTTP"
    timeout             = 5
    unhealthy_threshold = 2
  }
  
  stickiness {
    type            = "lb_cookie"
    cookie_duration = 86400
    enabled         = var.enable_sticky_sessions
  }
  
  tags = {
    Name = "${var.project_name}-app-tg"
  }
}

# ALB Listener
resource "aws_lb_listener" "app" {
  load_balancer_arn = aws_lb.main.arn
  port              = "80"
  protocol          = "HTTP"
  
  default_action {
    type             = "forward"
    target_group_arn = aws_lb_target_group.app.arn
  }
}

# Launch Template for Auto Scaling
resource "aws_launch_template" "app" {
  name_prefix   = "${var.project_name}-app-"
  image_id      = data.aws_ami.amazon_linux.id
  instance_type = var.instance_type
  
  vpc_security_group_ids = [aws_security_group.app.id]
  
  user_data = base64encode(templatefile("${path.module}/user-data.sh", {
    database_endpoint = aws_rds_cluster.main.endpoint
    app_port         = 8080
  }))
  
  tag_specifications {
    resource_type = "instance"
    tags = {
      Name = "${var.project_name}-app-instance"
    }
  }
  
  lifecycle {
    create_before_destroy = true
  }
}

# Auto Scaling Group
resource "aws_autoscaling_group" "app" {
  name                = "${var.project_name}-app-asg"
  vpc_zone_identifier = aws_subnet.private[*].id
  target_group_arns   = [aws_lb_target_group.app.arn]
  health_check_type   = "ELB"
  health_check_grace_period = 300
  
  min_size         = var.asg_min_size
  max_size         = var.asg_max_size
  desired_capacity = var.asg_desired_capacity
  
  launch_template {
    id      = aws_launch_template.app.id
    version = "$Latest"
  }
  
  tag {
    key                 = "Name"
    value               = "${var.project_name}-app-asg"
    propagate_at_launch = false
  }
  
  lifecycle {
    create_before_destroy = true
  }
}

# Auto Scaling Policy - Scale Up
resource "aws_autoscaling_policy" "scale_up" {
  name                   = "${var.project_name}-scale-up"
  scaling_adjustment     = 2
  adjustment_type        = "ChangeInCapacity"
  cooldown              = 300
  autoscaling_group_name = aws_autoscaling_group.app.name
}

# CloudWatch Alarm - High CPU
resource "aws_cloudwatch_metric_alarm" "cpu_high" {
  alarm_name          = "${var.project_name}-cpu-high"
  comparison_operator = "GreaterThanThreshold"
  evaluation_periods  = "2"
  metric_name         = "CPUUtilization"
  namespace           = "AWS/EC2"
  period              = "120"
  statistic           = "Average"
  threshold           = "75"
  alarm_description   = "This metric monitors ec2 cpu utilization"
  alarm_actions       = [aws_autoscaling_policy.scale_up.arn]
  
  dimensions = {
    AutoScalingGroupName = aws_autoscaling_group.app.name
  }
}
```

### **Sample RDS Configuration**

```hcl
# database.tf
# RDS Subnet Group
resource "aws_db_subnet_group" "main" {
  name       = "${var.project_name}-db-subnet-group"
  subnet_ids = aws_subnet.database[*].id
  
  tags = {
    Name = "${var.project_name}-db-subnet-group"
  }
}

# RDS Aurora Cluster
resource "aws_rds_cluster" "main" {
  cluster_identifier     = "${var.project_name}-aurora-cluster"
  engine                 = "aurora-mysql"
  engine_version         = "8.0.mysql_aurora.3.02.0"
  database_name          = var.database_name
  master_username        = var.database_username
  master_password        = var.database_password
  
  db_subnet_group_name   = aws_db_subnet_group.main.name
  vpc_security_group_ids = [aws_security_group.database.id]
  
  backup_retention_period = var.backup_retention_period
  preferred_backup_window = "03:00-04:00"
  preferred_maintenance_window = "sun:04:00-sun:05:00"
  
  storage_encrypted = true
  kms_key_id       = aws_kms_key.rds.arn
  
  skip_final_snapshot       = var.environment != "production"
  final_snapshot_identifier = var.environment == "production" ? "${var.project_name}-final-snapshot-${formatdate("YYYY-MM-DD-hhmm", timestamp())}" : null
  
  tags = {
    Name = "${var.project_name}-aurora-cluster"
  }
}

# Aurora Cluster Instances
resource "aws_rds_cluster_instance" "cluster_instances" {
  count              = var.rds_instance_count
  identifier         = "${var.project_name}-aurora-${count.index}"
  cluster_identifier = aws_rds_cluster.main.id
  instance_class     = var.rds_instance_class
  engine             = aws_rds_cluster.main.engine
  engine_version     = aws_rds_cluster.main.engine_version
  
  performance_insights_enabled = true
  monitoring_interval         = 60
  monitoring_role_arn         = aws_iam_role.rds_monitoring.arn
  
  tags = {
    Name = "${var.project_name}-aurora-instance-${count.index}"
  }
}

# KMS Key for RDS encryption
resource "aws_kms_key" "rds" {
  description             = "KMS key for RDS encryption"
  deletion_window_in_days = 7
  
  tags = {
    Name = "${var.project_name}-rds-key"
  }
}

resource "aws_kms_alias" "rds" {
  name          = "alias/${var.project_name}-rds"
  target_key_id = aws_kms_key.rds.key_id
}
```

## 📚 **Exercise 3: Security & Best Practices (30 minutes)**

### **Production-Ready Security Prompts**

#### **Comprehensive Security Strategy**
```
"Design a production-ready security framework for AWS infrastructure that implements 
defense in depth, least privilege access, encryption at rest and in transit, and 
comprehensive monitoring. Include IAM policies, KMS key management, VPC Flow Logs, 
CloudTrail integration, and security scanning automation."
```

#### **Compliance and Governance**
```
"Create an infrastructure setup that meets enterprise compliance requirements (SOC 2, 
PCI DSS). Include proper resource tagging for cost allocation, automated compliance 
scanning, audit logging, and governance policies. Explain how each component 
contributes to the overall compliance posture."
```

### **Sample Security Implementation**

```hcl
# security.tf
# IAM Role for EC2 instances
resource "aws_iam_role" "ec2_role" {
  name = "${var.project_name}-ec2-role"
  
  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action = "sts:AssumeRole"
        Effect = "Allow"
        Principal = {
          Service = "ec2.amazonaws.com"
        }
      }
    ]
  })
  
  tags = {
    Name = "${var.project_name}-ec2-role"
  }
}

# IAM Policy for application access
resource "aws_iam_policy" "app_policy" {
  name        = "${var.project_name}-app-policy"
  description = "Policy for application instances"
  
  policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Action = [
          "s3:GetObject",
          "s3:PutObject"
        ]
        Resource = "${aws_s3_bucket.app_data.arn}/*"
      },
      {
        Effect = "Allow"
        Action = [
          "ssm:GetParameter",
          "ssm:GetParameters",
          "ssm:GetParametersByPath"
        ]
        Resource = "arn:aws:ssm:${data.aws_region.current.name}:${data.aws_caller_identity.current.account_id}:parameter/${var.project_name}/*"
      },
      {
        Effect = "Allow"
        Action = [
          "kms:Decrypt",
          "kms:DescribeKey"
        ]
        Resource = aws_kms_key.app.arn
      }
    ]
  })
}

# Attach policy to role
resource "aws_iam_role_policy_attachment" "app_policy_attachment" {
  role       = aws_iam_role.ec2_role.name
  policy_arn = aws_iam_policy.app_policy.arn
}

# Instance profile for EC2
resource "aws_iam_instance_profile" "ec2_profile" {
  name = "${var.project_name}-ec2-profile"
  role = aws_iam_role.ec2_role.name
}

# KMS Key for application data
resource "aws_kms_key" "app" {
  description             = "KMS key for application data encryption"
  deletion_window_in_days = 7
  
  policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Sid    = "Enable IAM User Permissions"
        Effect = "Allow"
        Principal = {
          AWS = "arn:aws:iam::${data.aws_caller_identity.current.account_id}:root"
        }
        Action   = "kms:*"
        Resource = "*"
      },
      {
        Sid    = "Allow application role access"
        Effect = "Allow"
        Principal = {
          AWS = aws_iam_role.ec2_role.arn
        }
        Action = [
          "kms:Decrypt",
          "kms:DescribeKey"
        ]
        Resource = "*"
      }
    ]
  })
  
  tags = {
    Name = "${var.project_name}-app-key"
  }
}

# VPC Flow Logs
resource "aws_flow_log" "vpc" {
  iam_role_arn    = aws_iam_role.flow_log.arn
  log_destination = aws_cloudwatch_log_group.vpc_flow_logs.arn
  traffic_type    = "ALL"
  vpc_id          = aws_vpc.main.id
  
  tags = {
    Name = "${var.project_name}-vpc-flow-logs"
  }
}

# CloudWatch Log Group for VPC Flow Logs
resource "aws_cloudwatch_log_group" "vpc_flow_logs" {
  name              = "/aws/vpc/flowlogs/${var.project_name}"
  retention_in_days = 30
  kms_key_id        = aws_kms_key.logs.arn
  
  tags = {
    Name = "${var.project_name}-vpc-flow-logs"
  }
}

# S3 Bucket for application data
resource "aws_s3_bucket" "app_data" {
  bucket = "${var.project_name}-app-data-${random_id.bucket_suffix.hex}"
  
  tags = {
    Name = "${var.project_name}-app-data"
  }
}

# S3 Bucket encryption
resource "aws_s3_bucket_server_side_encryption_configuration" "app_data" {
  bucket = aws_s3_bucket.app_data.id
  
  rule {
    apply_server_side_encryption_by_default {
      kms_master_key_id = aws_kms_key.app.arn
      sse_algorithm     = "aws:kms"
    }
    bucket_key_enabled = true
  }
}

# S3 Bucket public access block
resource "aws_s3_bucket_public_access_block" "app_data" {
  bucket = aws_s3_bucket.app_data.id
  
  block_public_acls       = true
  block_public_policy     = true
  ignore_public_acls      = true
  restrict_public_buckets = true
}

# Random ID for bucket naming
resource "random_id" "bucket_suffix" {
  byte_length = 4
}
```

## 🎯 **Assessment Criteria**

### **Infrastructure Design Skills**
- [ ] Creates well-architected, scalable infrastructure designs
- [ ] Implements proper security controls and least privilege access
- [ ] Considers cost optimization and operational efficiency
- [ ] Designs for high availability and disaster recovery

### **AI Collaboration Effectiveness**
- [ ] Asks strategic questions about infrastructure best practices
- [ ] Iterates on designs based on AI feedback and recommendations
- [ ] Explains architectural decisions and trade-offs clearly
- [ ] Uses AI to validate security and compliance requirements

### **Terraform Proficiency**
- [ ] Organizes code with proper module structure and variables
- [ ] Implements resource dependencies and lifecycle management
- [ ] Uses appropriate data sources and resource references
- [ ] Follows Terraform best practices for maintainability

## 🚀 **Common Challenges & Solutions**

### **Challenge: "My infrastructure is overly complex"**
**Coaching Approach:**
- Guide students to start simple and add complexity incrementally
- Discuss the principle of minimum viable infrastructure
- Help them understand when complexity adds value vs. overhead

### **Challenge: "Security seems like an afterthought"**
**Learning Opportunity:**
- Emphasize security-by-design principles
- Show how security controls can be built into the architecture
- Discuss the cost of retrofitting security vs. building it in

### **Challenge: "Terraform code is hard to maintain"**
**Strategic Teaching:**
- Introduce module concepts and code organization
- Discuss variable usage and environment management
- Explore state management and team collaboration patterns

## 📝 **Instructor Notes**

### **Cloud Provider Considerations**
- **AWS**: Most comprehensive examples and documentation
- **Azure**: Strong enterprise integration and hybrid capabilities
- **GCP**: Excellent for container and serverless architectures

### **Time Management Tips**
- **Exercise 1**: Network concepts often need additional explanation
- **Exercise 2**: Application architecture may require more time for complex scenarios
- **Exercise 3**: Security concepts can be overwhelming - focus on key principles

### **Extension Opportunities**
- Multi-region deployments and disaster recovery
- Infrastructure testing with tools like Terratest
- GitOps workflows with Terraform Cloud/Enterprise
- Cost optimization strategies and monitoring

**Remember: Focus on developing strategic infrastructure thinking with AI assistance, not just resource creation! 🎯**
