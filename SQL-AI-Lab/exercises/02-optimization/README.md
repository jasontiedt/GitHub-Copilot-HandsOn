# Exercise 2: AI-Assisted Query Optimization

## Objective
Learn to use AI assistance to optimize SQL queries for better performance, readability, and maintainability.

## Slow Queries to Optimize

### Query 1: Inefficient JOIN
```sql
-- SLOW QUERY: Missing proper indexes and using inefficient joins
SELECT c.FirstName, c.LastName, p.ProductName, od.Quantity
FROM Customers c, Orders o, OrderDetails od, Products p
WHERE c.CustomerID = o.CustomerID
AND o.OrderID = od.OrderID
AND od.ProductID = p.ProductID
AND c.City = 'New York'
AND o.OrderDate > '2024-01-01';
```

**AI Prompt**: "Optimize this SQL query for better performance. Suggest proper JOIN syntax and explain the improvements."

### Query 2: N+1 Query Problem
```sql
-- SLOW QUERY: This would typically be called in a loop (N+1 problem)
SELECT CustomerID, FirstName, LastName
FROM Customers
WHERE CustomerID = @CustomerID;

-- For each customer, another query:
SELECT COUNT(*) as OrderCount
FROM Orders
WHERE CustomerID = @CustomerID;
```

**AI Prompt**: "This query has an N+1 problem. Rewrite it as a single efficient query that gets customer info and order count together."

### Query 3: Inefficient Aggregation
```sql
-- SLOW QUERY: Using DISTINCT and multiple subqueries
SELECT DISTINCT c.CustomerID, c.FirstName, c.LastName,
    (SELECT COUNT(*) FROM Orders WHERE CustomerID = c.CustomerID) as OrderCount,
    (SELECT SUM(TotalAmount) FROM Orders WHERE CustomerID = c.CustomerID) as TotalSpent,
    (SELECT MAX(OrderDate) FROM Orders WHERE CustomerID = c.CustomerID) as LastOrderDate
FROM Customers c
WHERE c.IsActive = 1;
```

**AI Prompt**: "Optimize this query to eliminate multiple subqueries and improve performance."

### Query 4: Missing WHERE Clause Optimization
```sql
-- SLOW QUERY: Filtering after aggregation instead of before
SELECT p.ProductName, SUM(od.Quantity) as TotalSold
FROM Products p
JOIN OrderDetails od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
GROUP BY p.ProductID, p.ProductName
HAVING SUM(od.Quantity) > 10
AND MAX(o.OrderDate) > '2024-01-01';
```

**AI Prompt**: "Optimize this query by moving filters to WHERE clause where possible and explain the performance difference."

## AI Optimization Exercises

### Exercise 1: Index Recommendations
**Task**: Ask AI to analyze your queries and suggest index strategies.

**AI Prompt**: 
```
"Analyze these tables and queries, then recommend optimal indexes:

Tables: Customers, Orders, OrderDetails, Products, Categories
Common queries:
- Find customers by city and state
- Get orders for a specific date range
- Look up products by category
- Calculate order totals with details

Suggest specific CREATE INDEX statements and explain the reasoning."
```

### Exercise 2: Query Plan Analysis
**Task**: Get AI to explain execution plans and bottlenecks.

**AI Prompt**:
```
"Explain what this execution plan means and identify performance bottlenecks:
[Paste actual execution plan or describe query structure]

Suggest specific optimizations."
```

### Exercise 3: Rewriting for Performance
**Task**: Transform complex queries into more efficient versions.

**Problematic Query**:
```sql
-- Transform this complex query
SELECT c.FirstName, c.LastName,
       CASE 
           WHEN EXISTS (SELECT 1 FROM Orders WHERE CustomerID = c.CustomerID AND YEAR(OrderDate) = 2024) 
           THEN 'Active 2024'
           WHEN EXISTS (SELECT 1 FROM Orders WHERE CustomerID = c.CustomerID AND YEAR(OrderDate) = 2023)
           THEN 'Active 2023'
           ELSE 'Inactive'
       END as CustomerStatus
FROM Customers c;
```

**AI Prompt**: "Rewrite this query for better performance. The multiple EXISTS clauses are slow."

### Exercise 4: Bulk Operations Optimization
**Task**: Optimize data manipulation queries.

**Slow Update**:
```sql
-- This would be slow for large datasets
UPDATE Products 
SET LastModified = GETDATE()
WHERE ProductID IN (
    SELECT DISTINCT od.ProductID 
    FROM OrderDetails od 
    JOIN Orders o ON od.OrderID = o.OrderID 
    WHERE o.OrderDate > '2024-01-01'
);
```

**AI Prompt**: "Optimize this UPDATE statement for a large dataset. Suggest bulk operation improvements."

## Performance Testing Prompts

### Prompt 1: Benchmark Generation
```
"Create a script to benchmark these two query versions:
[Query Version 1]
[Query Version 2]

Include timing measurements and result comparison."
```

### Prompt 2: Load Testing Scenarios
```
"Generate sample data creation scripts to test query performance with:
- 10,000 customers
- 100,000 orders
- 500,000 order details

Include realistic data distribution."
```

### Prompt 3: Index Impact Analysis
```
"Create before/after performance tests for these index additions:
[List of proposed indexes]

Show how to measure the improvement."
```

## Advanced Optimization Topics

### 1. Query Hints and Plan Forcing
**AI Prompt**: "When and how should I use SQL Server query hints? Show examples of FORCESEEK, FORCESCAN, and INDEX hints."

### 2. Partitioning Strategies
**AI Prompt**: "Design a table partitioning strategy for the Orders table that will improve query performance for date-range queries."

### 3. Columnstore Indexes
**AI Prompt**: "When should I use columnstore indexes? Show how to implement them for our data warehouse scenarios."

### 4. Statistics and Cardinality
**AI Prompt**: "Explain how SQL Server statistics affect query performance and show how to maintain them properly."

## Optimization Checklist

Use AI to help create queries that follow these optimization principles:

- [ ] Use proper JOIN syntax instead of WHERE clause joins
- [ ] Filter early with WHERE clauses
- [ ] Avoid SELECT * in production queries
- [ ] Use appropriate indexes
- [ ] Minimize subqueries when possible
- [ ] Use EXISTS instead of IN for subqueries
- [ ] Consider query hints only when necessary
- [ ] Test with realistic data volumes

## Expected Outcomes
- Understand common SQL performance bottlenecks
- Learn to identify and fix slow queries
- Master index design principles
- Practice using AI for optimization analysis
- Develop performance testing strategies

## Next Steps
After completing this exercise, proceed to Exercise 3: Schema Design.
