# Exercise 1: AI-Assisted Query Generation

## Objective
Learn to use AI assistance to generate SQL queries from natural language descriptions.

## Setup
Ensure you have completed the database setup and have the SQLAILab database with sample data.

## AI Prompts for Query Generation

### Basic Queries

#### Prompt 1: Simple SELECT
**Natural Language**: "Show me all customers from New York"
**AI Generated Query**:
```sql
-- Let AI generate this query
-- Prompt: "Write a SQL query to select all customers from New York"
```

#### Prompt 2: Aggregation
**Natural Language**: "Count how many products we have in each category"
**AI Generated Query**:
```sql
-- Let AI generate this query
-- Prompt: "Write a SQL query to count products by category"
```

#### Prompt 3: JOIN Operations
**Natural Language**: "Show customer names and their order totals"
**AI Generated Query**:
```sql
-- Let AI generate this query
-- Prompt: "Write a SQL query to show customer names with their order totals"
```

### Intermediate Queries

#### Prompt 4: Date Filtering
**Natural Language**: "Find all orders placed in the last 30 days"
**AI Generated Query**:
```sql
-- Let AI generate this query
-- Prompt: "Write a SQL query to find orders from the last 30 days"
```

#### Prompt 5: Subqueries
**Natural Language**: "Find customers who have never placed an order"
**AI Generated Query**:
```sql
-- Let AI generate this query
-- Prompt: "Write a SQL query to find customers with no orders"
```

#### Prompt 6: Complex Aggregation
**Natural Language**: "Show the top 5 best-selling products by quantity"
**AI Generated Query**:
```sql
-- Let AI generate this query
-- Prompt: "Write a SQL query for top 5 products by total quantity sold"
```

### Advanced Queries

#### Prompt 7: Window Functions
**Natural Language**: "Rank customers by their total purchase amount"
**AI Generated Query**:
```sql
-- Let AI generate this query
-- Prompt: "Write a SQL query to rank customers by total purchase amount using window functions"
```

#### Prompt 8: Multiple JOINs
**Natural Language**: "Show product names, category names, and supplier information"
**AI Generated Query**:
```sql
-- Let AI generate this query
-- Prompt: "Write a SQL query joining products, categories, and suppliers"
```

#### Prompt 9: Conditional Logic
**Natural Language**: "Categorize customers as 'High Value' (>$1000), 'Medium Value' ($500-$1000), or 'Low Value' (<$500) based on total purchases"
**AI Generated Query**:
```sql
-- Let AI generate this query
-- Prompt: "Write a SQL query to categorize customers by purchase value with CASE statements"
```

## Exercise Tasks

### Task 1: Generate Basic Queries
1. Use the prompts above to generate basic SELECT, COUNT, and JOIN queries
2. Test each generated query in your SQL environment
3. Document any modifications needed

### Task 2: Create Custom Queries
Generate queries for these business questions:
1. "Which products are running low on stock (less than 10 items)?"
2. "What's the average order value per customer?"
3. "Which employees work in the IT department?"
4. "Show monthly sales totals for the current year"

### Task 3: Optimize Generated Queries
1. Ask AI to explain the execution plan of generated queries
2. Request performance optimizations
3. Ask for index recommendations

## AI Prompt Examples

### For Query Explanation
```
"Explain what this SQL query does step by step:
[paste your query here]"
```

### For Performance Optimization
```
"How can I optimize this SQL query for better performance?
[paste your query here]"
```

### For Alternative Approaches
```
"Show me 3 different ways to write this query:
[paste your query here]"
```

## Expected Outcomes
- Understand how to translate business requirements to SQL
- Learn different SQL patterns and techniques
- Practice using AI for query generation and optimization
- Build confidence in SQL development

## Next Steps
After completing this exercise, proceed to Exercise 2: Query Optimization.
