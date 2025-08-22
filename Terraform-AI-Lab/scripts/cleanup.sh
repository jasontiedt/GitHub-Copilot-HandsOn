#!/bin/bash

# Cleanup Script for Terraform AI Lab
# Safely removes all lab resources to prevent unexpected charges

set -e  # Exit on any error

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

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

echo "🧹 Terraform AI Lab Cleanup Script"
echo "=================================="

# Warning message
print_warning "This script will destroy ALL Terraform-managed resources!"
print_warning "Make sure you have saved any important data before proceeding."
echo
read -p "Are you sure you want to continue? Type 'yes' to proceed: " -r
if [[ ! $REPLY == "yes" ]]; then
    print_status "Cleanup cancelled."
    exit 0
fi

# Function to cleanup a directory
cleanup_directory() {
    local dir=$1
    local desc=$2
    
    if [ -d "$dir" ]; then
        print_status "Cleaning up $desc in $dir..."
        cd "$dir"
        
        if [ -f ".terraform/terraform.tfstate" ] || [ -f "terraform.tfstate" ]; then
            print_status "Found Terraform state, destroying resources..."
            terraform destroy -auto-approve
            print_success "Resources destroyed in $dir"
        else
            print_status "No Terraform state found in $dir"
        fi
        
        # Clean up .terraform directory
        if [ -d ".terraform" ]; then
            rm -rf .terraform
            print_status "Removed .terraform directory"
        fi
        
        # Clean up tfplan files
        if ls *.tfplan 1> /dev/null 2>&1; then
            rm -f *.tfplan
            print_status "Removed plan files"
        fi
        
        cd - > /dev/null
    else
        print_status "Directory $dir not found, skipping..."
    fi
}

# Get the script directory
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
LAB_DIR="$(dirname "$SCRIPT_DIR")"

print_status "Lab directory: $LAB_DIR"

# Clean up exercise directories
EXERCISE_DIRS=(
    "exercises/01-basic-infrastructure"
    "exercises/02-web-app-stack"
    "exercises/03-advanced-networking"
    "exercises/04-security-compliance"
    "exercises/05-multi-cloud-modules"
)

for exercise_dir in "${EXERCISE_DIRS[@]}"; do
    cleanup_directory "$LAB_DIR/$exercise_dir" "$exercise_dir"
done

# Clean up any root-level Terraform files
cleanup_directory "$LAB_DIR" "root directory"

# Optional: Clean up backend resources (S3 bucket and DynamoDB table)
if [ -f "$LAB_DIR/backend.tf" ]; then
    echo
    print_warning "Found backend configuration (S3 + DynamoDB)"
    read -p "Do you want to remove the S3 bucket and DynamoDB table used for Terraform state? (y/n): " -n 1 -r
    echo
    
    if [[ $REPLY =~ ^[Yy]$ ]]; then
        # Extract bucket and table names from backend.tf
        BUCKET_NAME=$(grep 'bucket.*=' "$LAB_DIR/backend.tf" | cut -d'"' -f2)
        TABLE_NAME=$(grep 'dynamodb_table.*=' "$LAB_DIR/backend.tf" | cut -d'"' -f2)
        
        if [ ! -z "$BUCKET_NAME" ]; then
            print_status "Emptying and deleting S3 bucket: $BUCKET_NAME"
            
            # Empty the bucket first
            if aws s3 ls "s3://$BUCKET_NAME" 2>/dev/null; then
                aws s3 rm "s3://$BUCKET_NAME" --recursive
                aws s3api delete-bucket --bucket "$BUCKET_NAME"
                print_success "S3 bucket deleted: $BUCKET_NAME"
            else
                print_warning "S3 bucket not found or already deleted: $BUCKET_NAME"
            fi
        fi
        
        if [ ! -z "$TABLE_NAME" ]; then
            print_status "Deleting DynamoDB table: $TABLE_NAME"
            
            if aws dynamodb describe-table --table-name "$TABLE_NAME" 2>/dev/null; then
                aws dynamodb delete-table --table-name "$TABLE_NAME"
                print_success "DynamoDB table deleted: $TABLE_NAME"
            else
                print_warning "DynamoDB table not found or already deleted: $TABLE_NAME"
            fi
        fi
        
        # Remove backend.tf file
        rm -f "$LAB_DIR/backend.tf"
        print_status "Removed backend.tf file"
    fi
fi

# Clean up generated files
GENERATED_FILES=(
    "terraform.tfvars"
    "terraform.tfvars.backup"
    ".terraform.lock.hcl"
    "crash.log"
    "terraform-output.json"
)

for file in "${GENERATED_FILES[@]}"; do
    if [ -f "$LAB_DIR/$file" ]; then
        rm -f "$LAB_DIR/$file"
        print_status "Removed $file"
    fi
done

# Summary
echo
print_success "🎉 Cleanup complete!"
echo
print_status "Summary of actions taken:"
echo "  ✅ Destroyed all Terraform-managed resources"
echo "  ✅ Removed .terraform directories"
echo "  ✅ Cleaned up temporary files"
if [ ! -z "$BUCKET_NAME" ] || [ ! -z "$TABLE_NAME" ]; then
    echo "  ✅ Removed backend infrastructure (S3 + DynamoDB)"
fi

echo
print_status "Files preserved:"
echo "  📄 terraform.tfvars.example (template file)"
echo "  📄 All .tf template files"
echo "  📄 Documentation and README files"

echo
print_warning "Next steps:"
echo "  🔄 If you want to restart the lab, run './scripts/setup-aws.sh'"
echo "  💰 Check your AWS console to confirm all resources are removed"
echo "  📊 Review your AWS billing to ensure no unexpected charges"

echo
print_success "Thank you for using the Terraform AI Lab! 🚀"
