# Exercise 4: AI-Assisted Stored Procedures and Functions

## Objective
Learn to use AI assistance for creating stored procedures, functions, triggers, and other database programming constructs.

## Basic Stored Procedures

### Exercise 1: CRUD Operations
**AI Prompt**: "Create a complete set of CRUD stored procedures for the Products table with proper error handling, input validation, and transaction management."

**Expected Procedures**:
- `sp_CreateProduct`
- `sp_GetProduct`
- `sp_UpdateProduct`
- `sp_DeleteProduct`
- `sp_GetProductsList`

### Exercise 2: Business Logic Procedures
**AI Prompt**: "Create a stored procedure to process a customer order that:
- Validates customer exists and is active
- Checks product availability
- Calculates totals with tax and discounts
- Updates inventory
- Creates order and order details
- Handles all error scenarios with proper rollback"

### Exercise 3: Search and Filtering
**AI Prompt**: "Create a flexible product search stored procedure that supports:
- Text search in name and description
- Category filtering
- Price range filtering
- Availability filtering
- Pagination with offset and limit
- Multiple sort options
- Return total count for pagination"

## Advanced Stored Procedures

### Exercise 4: Batch Processing
**AI Prompt**: "Create a stored procedure for bulk order processing that:
- Accepts a table-valued parameter with multiple orders
- Processes all orders in a single transaction
- Provides detailed success/failure reporting
- Handles partial failures appropriately
- Logs all processing activities"

### Exercise 5: Data Synchronization
**AI Prompt**: "Create stored procedures for synchronizing product data between systems:
- Compare source and target data
- Identify inserts, updates, and deletes needed
- Apply changes with conflict resolution
- Generate synchronization reports
- Handle large datasets efficiently"

### Exercise 6: Reporting Procedures
**AI Prompt**: "Create stored procedures for sales reporting:
- Monthly sales summary by category
- Customer lifetime value calculation
- Top performing products analysis
- Inventory turnover reports
- Support date range parameters and filtering"

## User-Defined Functions

### Exercise 7: Scalar Functions
**AI Prompt**: "Create these utility functions:
- Calculate age from birth date
- Format phone numbers consistently
- Calculate distance between zip codes
- Generate SKU codes from product attributes
- Validate email address format"

### Exercise 8: Table-Valued Functions
**AI Prompt**: "Create table-valued functions for:
- Get customer order history with summary
- Calculate product profitability analysis
- Generate date ranges for reporting
- Parse delimited strings into tables
- Get hierarchical category structures"

### Exercise 9: Aggregate Functions
**AI Prompt**: "Create custom aggregate functions (if supported) or equivalent logic for:
- Median calculation
- Weighted average
- Concatenate strings with delimiters
- Calculate running totals
- Statistical calculations (standard deviation, etc.)"

## Triggers

### Exercise 10: Audit Triggers
**AI Prompt**: "Create triggers for comprehensive auditing:
- Track all changes to sensitive tables
- Capture old and new values
- Record user and timestamp information
- Handle both single row and bulk operations
- Minimize performance impact"

### Exercise 11: Business Rule Triggers
**AI Prompt**: "Create triggers to enforce business rules:
- Prevent deletion of customers with active orders
- Auto-update product last modified date
- Maintain inventory levels and reorder points
- Enforce data validation beyond constraints
- Send notifications for critical events"

### Exercise 12: Data Synchronization Triggers
**AI Prompt**: "Create triggers for maintaining related data:
- Update order totals when details change
- Maintain aggregate tables automatically
- Synchronize data across related tables
- Handle cascading updates properly
- Ensure referential integrity"

## Error Handling and Logging

### Exercise 13: Comprehensive Error Handling
**AI Prompt**: "Create a framework for consistent error handling including:
- Custom error messages and codes
- Error logging procedures
- Exception handling patterns
- Transaction rollback strategies
- User-friendly error responses"

### Exercise 14: Logging Framework
**AI Prompt**: "Design a logging system for database operations:
- Different log levels (DEBUG, INFO, WARN, ERROR)
- Performance timing logs
- User activity tracking
- Automatic log cleanup
- Query performance monitoring"

## Performance Optimization

### Exercise 15: Query Optimization in Procedures
**AI Prompt**: "Optimize these slow stored procedures:
[Provide sample slow procedures]
Focus on:
- Parameter sniffing issues
- Query plan reuse
- Index utilization
- Memory optimization
- Parallel processing"

### Exercise 16: Caching Strategies
**AI Prompt**: "Implement caching within stored procedures:
- Temporary table caching for expensive operations
- Session-level caching
- Application-level cache integration
- Cache invalidation strategies
- Performance measurement"

## Security and Permissions

### Exercise 17: Security Implementation
**AI Prompt**: "Create a security framework for database access:
- Role-based stored procedure access
- Data masking for sensitive information
- Row-level security implementation
- SQL injection prevention
- Audit trail for security events"

### Exercise 18: Data Encryption
**AI Prompt**: "Implement data encryption in stored procedures:
- Encrypt sensitive customer data
- Secure password handling
- Key management procedures
- Decryption with proper authorization
- Performance considerations"

## Testing and Validation

### Exercise 19: Unit Testing Framework
**AI Prompt**: "Create a unit testing framework for stored procedures:
- Test data setup and cleanup
- Assertion procedures for validation
- Mock data generation
- Test result reporting
- Automated test execution"

### Exercise 20: Integration Testing
**AI Prompt**: "Design integration tests for database procedures:
- End-to-end transaction testing
- Concurrent access testing
- Performance benchmarking
- Error scenario testing
- Data consistency validation"

## Advanced Patterns

### Exercise 21: Dynamic SQL Procedures
**AI Prompt**: "Create safe dynamic SQL procedures for:
- Flexible search with optional parameters
- Dynamic sorting and filtering
- Table name parameterization
- SQL injection prevention
- Query plan optimization"

### Exercise 22: Recursive Procedures
**AI Prompt**: "Implement recursive stored procedures for:
- Hierarchical data processing
- Tree traversal operations
- Bill of materials explosion
- Organizational chart queries
- Category path generation"

### Exercise 23: Parallel Processing
**AI Prompt**: "Design procedures for parallel processing:
- Batch job splitting and coordination
- Concurrent data processing
- Progress tracking and monitoring
- Error handling in parallel operations
- Resource management"

## Documentation and Maintenance

### Exercise 24: Auto-Documentation
**AI Prompt**: "Create procedures to automatically document:
- Generate procedure documentation
- Extract parameter information
- Create usage examples
- Generate dependency maps
- Maintain version history"

### Exercise 25: Health Monitoring
**AI Prompt**: "Implement database health monitoring:
- Performance metric collection
- Procedure execution statistics
- Resource utilization tracking
- Automated alerts for issues
- Trending and reporting"

## Best Practices Checklist

Use AI to ensure your procedures follow these practices:

- [ ] Consistent naming conventions
- [ ] Proper parameter validation
- [ ] Comprehensive error handling
- [ ] Transaction management
- [ ] Security considerations
- [ ] Performance optimization
- [ ] Documentation standards
- [ ] Testing coverage

## Expected Outcomes
- Master stored procedure development
- Understand advanced T-SQL programming
- Learn error handling and logging patterns
- Practice security implementation
- Develop testing and maintenance strategies

## Practical Project

Create a complete order processing system:

1. **Design the workflow** with AI assistance
2. **Implement all procedures** using AI prompts
3. **Add comprehensive testing** with AI-generated tests
4. **Document the system** using AI documentation tools
5. **Performance test** with AI-generated load tests

## Next Steps
After completing this exercise, proceed to Exercise 5: Data Analysis and Reporting.
