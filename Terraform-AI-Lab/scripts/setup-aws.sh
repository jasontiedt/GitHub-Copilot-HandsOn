#!/bin/bash

# AWS Environment Setup Script for Terraform AI Lab
# This script helps configure your AWS environment for the lab exercises

set -e  # Exit on any error

echo "🚀 Setting up AWS environment for Terraform AI Lab..."

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

# Function to print colored output
print_status() {
    echo -e "${BLUE}[INFO]${NC} $1"
}

print_success() {
    echo -e "${GREEN}[SUCCESS]${NC} $1"
}

print_warning() {
    echo -e "${YELLOW}[WARNING]${NC} $1"
}

print_error() {
    echo -e "${RED}[ERROR]${NC} $1"
}

# Check if AWS CLI is installed
if ! command -v aws &> /dev/null; then
    print_error "AWS CLI not found. Please install AWS CLI first."
    echo "Visit: https://docs.aws.amazon.com/cli/latest/userguide/getting-started-install.html"
    exit 1
fi

# Check if Terraform is installed
if ! command -v terraform &> /dev/null; then
    print_error "Terraform not found. Please install Terraform first."
    echo "Visit: https://learn.hashicorp.com/tutorials/terraform/install-cli"
    exit 1
fi

print_success "AWS CLI and Terraform are installed"

# Check AWS credentials
print_status "Checking AWS credentials..."
if aws sts get-caller-identity &> /dev/null; then
    USER_INFO=$(aws sts get-caller-identity)
    ACCOUNT_ID=$(echo $USER_INFO | jq -r '.Account')
    USER_ARN=$(echo $USER_INFO | jq -r '.Arn')
    print_success "AWS credentials configured"
    print_status "Account ID: $ACCOUNT_ID"
    print_status "User/Role: $USER_ARN"
else
    print_error "AWS credentials not configured or invalid"
    echo "Run: aws configure"
    echo "Or set environment variables: AWS_ACCESS_KEY_ID, AWS_SECRET_ACCESS_KEY"
    exit 1
fi

# Set default region if not set
DEFAULT_REGION="us-east-1"
CURRENT_REGION=$(aws configure get region)
if [ -z "$CURRENT_REGION" ]; then
    print_warning "No default region set. Setting to $DEFAULT_REGION"
    aws configure set region $DEFAULT_REGION
    CURRENT_REGION=$DEFAULT_REGION
fi
print_status "Using AWS region: $CURRENT_REGION"

# Create S3 bucket for Terraform state (optional)
read -p "Create S3 bucket for Terraform state? (y/n): " -n 1 -r
echo
if [[ $REPLY =~ ^[Yy]$ ]]; then
    BUCKET_NAME="terraform-state-$(date +%s)-$(openssl rand -hex 4)"
    print_status "Creating S3 bucket: $BUCKET_NAME"
    
    if [ "$CURRENT_REGION" == "us-east-1" ]; then
        aws s3api create-bucket --bucket $BUCKET_NAME
    else
        aws s3api create-bucket --bucket $BUCKET_NAME --region $CURRENT_REGION \
            --create-bucket-configuration LocationConstraint=$CURRENT_REGION
    fi
    
    # Enable versioning
    aws s3api put-bucket-versioning --bucket $BUCKET_NAME \
        --versioning-configuration Status=Enabled
    
    # Enable server-side encryption
    aws s3api put-bucket-encryption --bucket $BUCKET_NAME \
        --server-side-encryption-configuration '{
            "Rules": [{
                "ApplyServerSideEncryptionByDefault": {
                    "SSEAlgorithm": "AES256"
                }
            }]
        }'
    
    print_success "S3 bucket created: $BUCKET_NAME"
    
    # Create DynamoDB table for state locking
    TABLE_NAME="terraform-state-locks"
    print_status "Creating DynamoDB table for state locking: $TABLE_NAME"
    
    aws dynamodb create-table \
        --table-name $TABLE_NAME \
        --attribute-definitions AttributeName=LockID,AttributeType=S \
        --key-schema AttributeName=LockID,KeyType=HASH \
        --billing-mode PAY_PER_REQUEST \
        --region $CURRENT_REGION
    
    print_success "DynamoDB table created: $TABLE_NAME"
    
    # Create backend configuration file
    cat > backend.tf << EOF
terraform {
  backend "s3" {
    bucket         = "$BUCKET_NAME"
    key            = "terraform.tfstate"
    region         = "$CURRENT_REGION"
    encrypt        = true
    dynamodb_table = "$TABLE_NAME"
  }
}
EOF
    
    print_success "Backend configuration saved to backend.tf"
fi

# Check required permissions
print_status "Checking AWS permissions..."

REQUIRED_PERMISSIONS=(
    "ec2:*"
    "vpc:*"
    "iam:*"
    "rds:*"
    "s3:*"
    "dynamodb:*"
    "cloudwatch:*"
    "logs:*"
)

# Note: This is a simplified check. In reality, you'd need more sophisticated permission testing
print_warning "Please ensure your AWS user/role has permissions for:"
for permission in "${REQUIRED_PERMISSIONS[@]}"; do
    echo "  - $permission"
done

# Create example terraform.tfvars file
print_status "Creating example terraform.tfvars file..."
cat > terraform.tfvars.example << EOF
# Example Terraform variables file
# Copy this to terraform.tfvars and customize for your environment

# General Configuration
project_name = "terraform-ai-lab"
environment  = "dev"
region      = "$CURRENT_REGION"

# Networking
vpc_cidr = "10.0.0.0/16"

# Compute
instance_type = "t3.micro"
key_pair_name = "my-key-pair"  # Create this in EC2 console

# Database
db_instance_class = "db.t3.micro"
db_name          = "webapp"
db_username      = "admin"
# db_password will be generated or retrieved from AWS Secrets Manager

# Tags
owner       = "your-name"
cost_center = "engineering"
EOF

print_success "Example variables file created: terraform.tfvars.example"

# Create cleanup script
print_status "Creating cleanup script..."
cat > cleanup-resources.sh << 'EOF'
#!/bin/bash
# Cleanup script for Terraform AI Lab resources

echo "🧹 Cleaning up Terraform AI Lab resources..."

# Destroy Terraform-managed resources
if [ -f "terraform.tfstate" ] || [ -f ".terraform/terraform.tfstate" ]; then
    echo "Destroying Terraform resources..."
    terraform destroy -auto-approve
else
    echo "No Terraform state found"
fi

# Optional: Remove S3 bucket and DynamoDB table
read -p "Remove S3 bucket and DynamoDB table for Terraform state? (y/n): " -n 1 -r
echo
if [[ $REPLY =~ ^[Yy]$ ]]; then
    # Get bucket name from backend.tf if it exists
    if [ -f "backend.tf" ]; then
        BUCKET_NAME=$(grep 'bucket.*=' backend.tf | cut -d'"' -f2)
        TABLE_NAME=$(grep 'dynamodb_table.*=' backend.tf | cut -d'"' -f2)
        
        if [ ! -z "$BUCKET_NAME" ]; then
            echo "Emptying and deleting S3 bucket: $BUCKET_NAME"
            aws s3 rm s3://$BUCKET_NAME --recursive
            aws s3api delete-bucket --bucket $BUCKET_NAME
        fi
        
        if [ ! -z "$TABLE_NAME" ]; then
            echo "Deleting DynamoDB table: $TABLE_NAME"
            aws dynamodb delete-table --table-name $TABLE_NAME
        fi
    fi
fi

echo "✅ Cleanup complete!"
EOF

chmod +x cleanup-resources.sh
print_success "Cleanup script created: cleanup-resources.sh"

# Final instructions
echo
print_success "AWS environment setup complete! 🎉"
echo
print_status "Next steps:"
echo "1. Copy terraform.tfvars.example to terraform.tfvars"
echo "2. Edit terraform.tfvars with your specific values"
echo "3. Create an EC2 key pair in the AWS console if needed"
echo "4. Start with Exercise 1: Basic Infrastructure"
echo
print_status "Useful commands:"
echo "  terraform init    # Initialize Terraform"
echo "  terraform plan    # Preview changes"
echo "  terraform apply   # Apply changes"
echo "  terraform destroy # Destroy resources"
echo
print_warning "Remember to run './cleanup-resources.sh' when done to avoid charges!"
