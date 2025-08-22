# Exercise 3: AI-Assisted Database Schema Design

## Objective
Learn to use AI assistance for designing database schemas, relationships, and data models for enterprise applications.

## Schema Design Scenarios

### Scenario 1: E-Learning Platform
**Business Requirements**:
- Students can enroll in multiple courses
- Instructors can teach multiple courses
- Courses have lessons and assignments
- Track student progress and grades
- Support video content and documents
- Handle subscription payments

**AI Prompt**:
```
"Design a database schema for an e-learning platform with these requirements:
[List requirements above]

Include:
- All necessary tables with primary/foreign keys
- Proper data types and constraints
- Normalization to 3NF
- Indexes for common queries
- Sample data insertion scripts"
```

### Scenario 2: Hospital Management System
**Business Requirements**:
- Patients with medical history
- Doctors with specializations
- Appointments scheduling
- Medical prescriptions and treatments
- Department and ward management
- Insurance and billing

**AI Prompt**:
```
"Create a hospital management database schema including:
- Patient registration and medical history
- Doctor scheduling and appointments
- Treatment records and prescriptions
- Billing and insurance handling
- Department organization

Ensure HIPAA compliance considerations and proper data relationships."
```

### Scenario 3: Inventory Management System
**Business Requirements**:
- Multi-location warehouse management
- Product variants (size, color, etc.)
- Supplier relationships
- Stock movements and transfers
- Purchase orders and receiving
- Barcode/SKU tracking

**AI Prompt**:
```
"Design an inventory management schema supporting:
- Multi-location warehouses
- Product variations and attributes
- Supplier management
- Stock movements and transfers
- Purchase order workflow
- Audit trail for all transactions

Include proper constraints and business rules."
```

## Database Design Patterns

### Pattern 1: Audit Tables
**AI Prompt**: "Show me how to implement audit tables for tracking all changes to the Products table. Include triggers or other mechanisms to automatically log changes."

### Pattern 2: Soft Deletes
**AI Prompt**: "Implement a soft delete pattern for the Customers table. Show how to modify queries to respect the soft delete flag."

### Pattern 3: Hierarchical Data
**AI Prompt**: "Design a table structure for storing hierarchical data like organizational charts or product categories. Show both adjacency list and nested sets approaches."

### Pattern 4: Temporal Tables
**AI Prompt**: "Create temporal tables for tracking historical changes to employee data. Show how to query historical states."

## Normalization Exercises

### Exercise 1: Denormalized Data Fix
**Given this denormalized table**:
```sql
CREATE TABLE OrderSummary (
    OrderID int,
    CustomerName nvarchar(100),
    CustomerEmail nvarchar(100),
    CustomerPhone nvarchar(20),
    ProductName nvarchar(100),
    ProductPrice decimal(10,2),
    Quantity int,
    OrderDate datetime2,
    ShippingAddress nvarchar(255)
);
```

**AI Prompt**: "Normalize this table to 3NF. Show the resulting table structure and the relationships between them."

### Exercise 2: Over-Normalization Fix
**AI Prompt**: "I have a highly normalized database where simple queries require 8+ table joins. Show me how to strategically denormalize for better performance while maintaining data integrity."

## Advanced Schema Design

### Data Warehouse Design
**AI Prompt**:
```
"Design a data warehouse schema for sales analytics with:
- Star schema for sales facts
- Customer, Product, Time, and Geography dimensions
- Slowly Changing Dimensions (SCD) Type 2 for customers
- Aggregate tables for performance
- ETL considerations"
```

### Multi-Tenant Architecture
**AI Prompt**:
```
"Design a multi-tenant SaaS database schema where:
- Each tenant's data is isolated
- Shared reference data is efficient
- Queries are automatically tenant-scoped
- Easy to backup individual tenants
Show both shared database and database-per-tenant approaches."
```

### Event Sourcing Pattern
**AI Prompt**:
```
"Implement an event sourcing pattern for order processing:
- Event store for all state changes
- Event replay capabilities
- Snapshot tables for performance
- Projection tables for queries
Show the complete schema and basic operations."
```

## Performance Considerations

### Partitioning Strategy
**AI Prompt**: "Design a partitioning strategy for a large Orders table with 100+ million records. Show monthly partitioning with proper constraints and indexes."

### Index Strategy
**AI Prompt**: "Analyze this schema and recommend a comprehensive indexing strategy. Consider clustered, non-clustered, covering, and filtered indexes based on expected query patterns."

### Archival Strategy
**AI Prompt**: "Design an archival strategy for historical data. Show how to move old orders to archive tables while maintaining referential integrity and query performance."

## Schema Validation and Testing

### Constraint Testing
**AI Prompt**:
```
"Create comprehensive test scripts to validate:
- All foreign key constraints
- Check constraints
- Unique constraints
- Data type validations
- Business rule enforcement

Include both positive and negative test cases."
```

### Data Integrity Scripts
**AI Prompt**: "Generate scripts to check data integrity across the entire schema. Identify orphaned records, constraint violations, and data quality issues."

### Performance Baseline
**AI Prompt**: "Create scripts to establish performance baselines for common operations on this schema. Include insert, update, delete, and select operations with timing measurements."

## Migration Scripts

### Schema Evolution
**AI Prompt**:
```
"Generate migration scripts to evolve the schema from version 1.0 to 2.0 with these changes:
- Add new 'ProductReviews' table
- Add 'Rating' column to Products
- Split 'Address' into separate components
- Migrate existing data safely
Include rollback scripts."
```

### Data Migration
**AI Prompt**: "Create scripts to migrate data from this legacy structure to the new normalized schema. Handle data cleansing and transformation during migration."

## Documentation Generation

### Schema Documentation
**AI Prompt**: "Generate comprehensive documentation for this database schema including:
- Table descriptions and purposes
- Column definitions and constraints
- Relationship diagrams
- Business rules and assumptions
- Query examples and use cases"

### API Documentation
**AI Prompt**: "Based on this schema, generate REST API documentation showing typical CRUD operations for each entity with request/response examples."

## Expected Outcomes
- Master database normalization principles
- Understand schema design patterns
- Learn performance optimization in design
- Practice using AI for complex design decisions
- Develop migration and documentation skills

## Practical Exercise

Design a complete schema for your own business scenario:

1. **Choose a domain** (e.g., restaurant management, real estate, library system)
2. **Define requirements** with AI assistance
3. **Create the schema** using AI prompts
4. **Validate the design** with AI review
5. **Generate test data** and performance tests
6. **Document the solution** with AI help

## Next Steps
After completing this exercise, proceed to Exercise 4: Stored Procedures and Functions.
