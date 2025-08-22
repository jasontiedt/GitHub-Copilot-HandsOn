# SQL AI Lab - Solution Cheat Sheet 🗄️

**For Instructors & Advanced Learners**

This cheat sheet provides example solutions and effective database development strategies while maintaining the lab's independent learning philosophy.

## 🎯 **Learning Objectives Validation**

Students should demonstrate:
- **Strategic data analysis** before requesting AI assistance for queries
- **Independent database design** thinking using AI for validation and optimization
- **Iterative query improvement** based on AI feedback and performance analysis
- **Business intelligence integration** through AI-guided analytical thinking

## 📚 **Exercise 1: Query Generation Mastery (25 minutes)**

### **Effective Business-to-SQL Analysis Prompts**

#### **Complex Business Intelligence Query**
```
"I need to analyze sales performance by analyzing customer purchase patterns, product 
category performance, and regional trends for the last 12 months. The analysis should 
include year-over-year comparisons, customer segmentation by purchase behavior, and 
identification of top-performing product combinations. Help me design a comprehensive 
query strategy that provides actionable business insights."
```

#### **Advanced Join Strategy Development**
```
"Create a query that combines customer demographics, order history, product catalog, 
and inventory data to identify customers who are likely to churn based on their 
purchase patterns. Include customers who haven't purchased in 90 days but previously 
bought regularly. The query should be optimized for performance on large datasets."
```

### **Sample Advanced Query Solutions**

#### **Sales Performance Analysis**
```sql
-- Comprehensive sales analysis with business intelligence focus
WITH monthly_sales AS (
  SELECT 
    YEAR(o.OrderDate) as sales_year,
    MONTH(o.OrderDate) as sales_month,
    p.CategoryID,
    c.Region,
    SUM(od.Quantity * od.UnitPrice) as monthly_revenue,
    COUNT(DISTINCT o.CustomerID) as unique_customers,
    COUNT(DISTINCT o.OrderID) as order_count,
    AVG(od.Quantity * od.UnitPrice) as avg_order_value
  FROM Orders o
  INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
  INNER JOIN Products p ON od.ProductID = p.ProductID
  INNER JOIN Customers c ON o.CustomerID = c.CustomerID
  WHERE o.OrderDate >= DATEADD(MONTH, -24, GETDATE()) -- Last 24 months for YoY comparison
  GROUP BY YEAR(o.OrderDate), MONTH(o.OrderDate), p.CategoryID, c.Region
),
yoy_comparison AS (
  SELECT 
    sales_year,
    sales_month,
    CategoryID,
    Region,
    monthly_revenue,
    unique_customers,
    order_count,
    avg_order_value,
    LAG(monthly_revenue, 12) OVER (
      PARTITION BY CategoryID, Region 
      ORDER BY sales_year, sales_month
    ) as previous_year_revenue,
    LAG(unique_customers, 12) OVER (
      PARTITION BY CategoryID, Region 
      ORDER BY sales_year, sales_month
    ) as previous_year_customers
  FROM monthly_sales
),
category_performance AS (
  SELECT 
    cat.CategoryName,
    y.Region,
    y.sales_year,
    y.sales_month,
    y.monthly_revenue,
    y.previous_year_revenue,
    CASE 
      WHEN y.previous_year_revenue > 0 
      THEN ((y.monthly_revenue - y.previous_year_revenue) / y.previous_year_revenue) * 100
      ELSE NULL
    END as revenue_growth_percent,
    y.unique_customers,
    y.previous_year_customers,
    CASE 
      WHEN y.previous_year_customers > 0 
      THEN ((y.unique_customers - y.previous_year_customers) / y.previous_year_customers) * 100
      ELSE NULL
    END as customer_growth_percent,
    y.avg_order_value,
    RANK() OVER (
      PARTITION BY y.sales_year, y.sales_month 
      ORDER BY y.monthly_revenue DESC
    ) as revenue_rank
  FROM yoy_comparison y
  INNER JOIN Categories cat ON y.CategoryID = cat.CategoryID
  WHERE y.sales_year = YEAR(GETDATE()) -- Current year focus
)
SELECT 
  CategoryName,
  Region,
  sales_month,
  FORMAT(monthly_revenue, 'C') as monthly_revenue,
  FORMAT(previous_year_revenue, 'C') as previous_year_revenue,
  CONCAT(FORMAT(revenue_growth_percent, 'N2'), '%') as revenue_growth,
  unique_customers,
  previous_year_customers,
  CONCAT(FORMAT(customer_growth_percent, 'N2'), '%') as customer_growth,
  FORMAT(avg_order_value, 'C') as avg_order_value,
  revenue_rank
FROM category_performance
WHERE sales_month <= MONTH(GETDATE()) -- Only complete months
ORDER BY revenue_rank, CategoryName, Region;
```

#### **Customer Churn Analysis**
```sql
-- Advanced customer segmentation and churn prediction
WITH customer_metrics AS (
  SELECT 
    c.CustomerID,
    c.CustomerName,
    c.Region,
    c.City,
    DATEDIFF(DAY, MIN(o.OrderDate), MAX(o.OrderDate)) as customer_lifespan_days,
    COUNT(DISTINCT o.OrderID) as total_orders,
    SUM(od.Quantity * od.UnitPrice) as total_spent,
    AVG(od.Quantity * od.UnitPrice) as avg_order_value,
    MAX(o.OrderDate) as last_order_date,
    DATEDIFF(DAY, MAX(o.OrderDate), GETDATE()) as days_since_last_order,
    COUNT(DISTINCT p.CategoryID) as category_diversity,
    -- Calculate purchase frequency
    CASE 
      WHEN DATEDIFF(DAY, MIN(o.OrderDate), MAX(o.OrderDate)) > 0
      THEN CAST(COUNT(DISTINCT o.OrderID) AS FLOAT) / 
           (DATEDIFF(DAY, MIN(o.OrderDate), MAX(o.OrderDate)) / 30.0)
      ELSE 0
    END as orders_per_month
  FROM Customers c
  INNER JOIN Orders o ON c.CustomerID = o.CustomerID
  INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
  INNER JOIN Products p ON od.ProductID = p.ProductID
  GROUP BY c.CustomerID, c.CustomerName, c.Region, c.City
),
customer_segments AS (
  SELECT 
    *,
    -- RFM Analysis components
    CASE 
      WHEN days_since_last_order <= 30 THEN 5
      WHEN days_since_last_order <= 60 THEN 4
      WHEN days_since_last_order <= 90 THEN 3
      WHEN days_since_last_order <= 180 THEN 2
      ELSE 1
    END as recency_score,
    
    CASE 
      WHEN orders_per_month >= 2.0 THEN 5
      WHEN orders_per_month >= 1.0 THEN 4
      WHEN orders_per_month >= 0.5 THEN 3
      WHEN orders_per_month >= 0.25 THEN 2
      ELSE 1
    END as frequency_score,
    
    CASE 
      WHEN total_spent >= 10000 THEN 5
      WHEN total_spent >= 5000 THEN 4
      WHEN total_spent >= 2000 THEN 3
      WHEN total_spent >= 1000 THEN 2
      ELSE 1
    END as monetary_score
  FROM customer_metrics
),
churn_analysis AS (
  SELECT 
    *,
    (recency_score + frequency_score + monetary_score) as rfm_total,
    CASE 
      WHEN recency_score >= 4 AND frequency_score >= 4 AND monetary_score >= 4 
      THEN 'Champions'
      WHEN recency_score >= 3 AND frequency_score >= 3 AND monetary_score >= 3 
      THEN 'Loyal Customers'
      WHEN recency_score >= 3 AND frequency_score <= 2 
      THEN 'Potential Loyalists'
      WHEN recency_score <= 2 AND frequency_score >= 3 AND monetary_score >= 3 
      THEN 'At Risk'
      WHEN recency_score <= 2 AND frequency_score <= 2 AND monetary_score >= 3 
      THEN 'Cannot Lose Them'
      WHEN recency_score <= 2 AND frequency_score <= 2 AND monetary_score <= 2 
      THEN 'Hibernating'
      ELSE 'Others'
    END as customer_segment,
    
    -- Churn risk calculation
    CASE 
      WHEN days_since_last_order > 90 AND orders_per_month >= 0.5 THEN 'High Risk'
      WHEN days_since_last_order > 60 AND orders_per_month >= 0.25 THEN 'Medium Risk'
      WHEN days_since_last_order > 30 AND orders_per_month >= 0.1 THEN 'Low Risk'
      ELSE 'Active'
    END as churn_risk
  FROM customer_segments
)
SELECT 
  CustomerName,
  Region,
  City,
  customer_segment,
  churn_risk,
  total_orders,
  FORMAT(total_spent, 'C') as total_spent,
  FORMAT(avg_order_value, 'C') as avg_order_value,
  ROUND(orders_per_month, 2) as orders_per_month,
  days_since_last_order,
  category_diversity,
  CONCAT(recency_score, '-', frequency_score, '-', monetary_score) as rfm_score,
  last_order_date
FROM churn_analysis
WHERE churn_risk IN ('High Risk', 'Medium Risk')
  AND customer_segment NOT IN ('Hibernating') -- Focus on recoverable customers
ORDER BY 
  CASE churn_risk 
    WHEN 'High Risk' THEN 1 
    WHEN 'Medium Risk' THEN 2 
    ELSE 3 
  END,
  total_spent DESC;
```

### **Key Teaching Points**

**✅ Strong Student Approaches:**
- Analyzes business requirements thoroughly before writing queries
- Asks AI to explain different analytical approaches and their trade-offs
- Requests performance considerations for large datasets
- Iterates on query design based on business feedback

**❌ Missed Learning Opportunities:**
- Writing basic SELECT statements without considering analytical value
- Not thinking about query performance and optimization from the start
- Ignoring data quality and validation considerations
- Copying complex queries without understanding the business logic

## 📚 **Exercise 2: Schema Design & Optimization (30 minutes)**

### **Advanced Database Architecture Prompts**

#### **E-commerce Schema Design**
```
"Design a comprehensive database schema for a multi-vendor e-commerce platform that 
supports complex product variants, dynamic pricing, inventory tracking across multiple 
warehouses, and sophisticated order fulfillment workflows. Include considerations for 
data integrity, performance optimization, and future scalability requirements."
```

#### **Performance Optimization Strategy**
```
"Analyze this slow-performing e-commerce database and design a comprehensive optimization 
strategy. Include indexing recommendations, query optimization techniques, database 
partitioning considerations, and caching strategies. Explain how each optimization 
contributes to overall system performance."
```

### **Sample Schema Design Solutions**

#### **Advanced E-commerce Schema**
```sql
-- Comprehensive e-commerce database design with optimization focus

-- Vendor management with hierarchy support
CREATE TABLE Vendors (
    VendorID int IDENTITY(1,1) PRIMARY KEY,
    VendorName nvarchar(255) NOT NULL,
    ContactEmail nvarchar(255) NOT NULL,
    ContactPhone nvarchar(50),
    Address nvarchar(500),
    City nvarchar(100),
    State nvarchar(100),
    Country nvarchar(100),
    PostalCode nvarchar(20),
    TaxID nvarchar(50),
    IsActive bit NOT NULL DEFAULT 1,
    CreatedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    
    INDEX IX_Vendors_IsActive (IsActive),
    INDEX IX_Vendors_Country_State_City (Country, State, City)
);

-- Product catalog with hierarchical categories
CREATE TABLE Categories (
    CategoryID int IDENTITY(1,1) PRIMARY KEY,
    CategoryName nvarchar(255) NOT NULL,
    ParentCategoryID int NULL,
    CategoryPath nvarchar(1000) NOT NULL, -- Materialized path for faster queries
    Level int NOT NULL DEFAULT 0,
    IsActive bit NOT NULL DEFAULT 1,
    CreatedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    
    FOREIGN KEY (ParentCategoryID) REFERENCES Categories(CategoryID),
    INDEX IX_Categories_ParentID (ParentCategoryID),
    INDEX IX_Categories_Path (CategoryPath),
    INDEX IX_Categories_Level_Active (Level, IsActive)
);

-- Products with variant support
CREATE TABLE Products (
    ProductID int IDENTITY(1,1) PRIMARY KEY,
    VendorID int NOT NULL,
    CategoryID int NOT NULL,
    ProductName nvarchar(255) NOT NULL,
    ProductDescription nvarchar(max),
    BasePrice decimal(10,2) NOT NULL,
    SKU nvarchar(100) NOT NULL UNIQUE,
    IsVariantParent bit NOT NULL DEFAULT 0,
    ParentProductID int NULL, -- For product variants
    Brand nvarchar(100),
    Weight decimal(8,2),
    Dimensions nvarchar(100),
    IsActive bit NOT NULL DEFAULT 1,
    CreatedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    
    FOREIGN KEY (VendorID) REFERENCES Vendors(VendorID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (ParentProductID) REFERENCES Products(ProductID),
    
    INDEX IX_Products_Vendor_Category (VendorID, CategoryID),
    INDEX IX_Products_SKU (SKU),
    INDEX IX_Products_Brand_Active (Brand, IsActive),
    INDEX IX_Products_ParentID (ParentProductID)
);

-- Dynamic pricing with time-based rules
CREATE TABLE ProductPricing (
    PricingID int IDENTITY(1,1) PRIMARY KEY,
    ProductID int NOT NULL,
    PriceType nvarchar(50) NOT NULL, -- 'Base', 'Sale', 'Bulk', 'Member'
    Price decimal(10,2) NOT NULL,
    MinQuantity int NOT NULL DEFAULT 1,
    MaxQuantity int NULL,
    StartDate datetime2 NOT NULL,
    EndDate datetime2 NULL,
    IsActive bit NOT NULL DEFAULT 1,
    CreatedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    INDEX IX_ProductPricing_Product_Dates (ProductID, StartDate, EndDate),
    INDEX IX_ProductPricing_Active_Type (IsActive, PriceType)
);

-- Multi-warehouse inventory tracking
CREATE TABLE Warehouses (
    WarehouseID int IDENTITY(1,1) PRIMARY KEY,
    WarehouseName nvarchar(255) NOT NULL,
    Address nvarchar(500),
    City nvarchar(100),
    State nvarchar(100),
    Country nvarchar(100),
    PostalCode nvarchar(20),
    IsActive bit NOT NULL DEFAULT 1,
    CreatedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    
    INDEX IX_Warehouses_Location (Country, State, City),
    INDEX IX_Warehouses_Active (IsActive)
);

CREATE TABLE Inventory (
    InventoryID int IDENTITY(1,1) PRIMARY KEY,
    ProductID int NOT NULL,
    WarehouseID int NOT NULL,
    QuantityOnHand int NOT NULL DEFAULT 0,
    QuantityReserved int NOT NULL DEFAULT 0,
    QuantityAvailable AS (QuantityOnHand - QuantityReserved),
    ReorderPoint int NOT NULL DEFAULT 0,
    MaxStockLevel int NOT NULL DEFAULT 0,
    LastUpdated datetime2 NOT NULL DEFAULT GETUTCDATE(),
    
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouses(WarehouseID),
    
    UNIQUE (ProductID, WarehouseID),
    INDEX IX_Inventory_Product_Warehouse (ProductID, WarehouseID),
    INDEX IX_Inventory_LowStock (WarehouseID, QuantityOnHand, ReorderPoint)
);

-- Advanced order management
CREATE TABLE Orders (
    OrderID int IDENTITY(1,1) PRIMARY KEY,
    CustomerID int NOT NULL,
    OrderNumber nvarchar(50) NOT NULL UNIQUE,
    OrderStatus nvarchar(50) NOT NULL DEFAULT 'Pending',
    OrderDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    RequiredDate datetime2 NULL,
    ShippedDate datetime2 NULL,
    
    -- Address information
    ShippingName nvarchar(255) NOT NULL,
    ShippingAddress nvarchar(500) NOT NULL,
    ShippingCity nvarchar(100) NOT NULL,
    ShippingState nvarchar(100),
    ShippingCountry nvarchar(100) NOT NULL,
    ShippingPostalCode nvarchar(20),
    
    -- Billing information
    BillingName nvarchar(255) NOT NULL,
    BillingAddress nvarchar(500) NOT NULL,
    BillingCity nvarchar(100) NOT NULL,
    BillingState nvarchar(100),
    BillingCountry nvarchar(100) NOT NULL,
    BillingPostalCode nvarchar(20),
    
    -- Order totals
    SubtotalAmount decimal(10,2) NOT NULL DEFAULT 0,
    TaxAmount decimal(10,2) NOT NULL DEFAULT 0,
    ShippingAmount decimal(10,2) NOT NULL DEFAULT 0,
    DiscountAmount decimal(10,2) NOT NULL DEFAULT 0,
    TotalAmount decimal(10,2) NOT NULL DEFAULT 0,
    
    PaymentStatus nvarchar(50) NOT NULL DEFAULT 'Pending',
    PaymentMethod nvarchar(100),
    
    CreatedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    
    INDEX IX_Orders_Customer_Date (CustomerID, OrderDate),
    INDEX IX_Orders_Status_Date (OrderStatus, OrderDate),
    INDEX IX_Orders_Number (OrderNumber),
    INDEX IX_Orders_Payment_Status (PaymentStatus, OrderStatus)
);

-- Order details with fulfillment tracking
CREATE TABLE OrderDetails (
    OrderDetailID int IDENTITY(1,1) PRIMARY KEY,
    OrderID int NOT NULL,
    ProductID int NOT NULL,
    WarehouseID int NOT NULL,
    Quantity int NOT NULL,
    UnitPrice decimal(10,2) NOT NULL,
    LineTotal AS (Quantity * UnitPrice),
    DiscountPercent decimal(5,2) NOT NULL DEFAULT 0,
    DiscountAmount AS (Quantity * UnitPrice * DiscountPercent / 100),
    NetAmount AS (Quantity * UnitPrice - (Quantity * UnitPrice * DiscountPercent / 100)),
    
    FulfillmentStatus nvarchar(50) NOT NULL DEFAULT 'Pending',
    AllocatedDate datetime2 NULL,
    PickedDate datetime2 NULL,
    PackedDate datetime2 NULL,
    ShippedDate datetime2 NULL,
    
    CreatedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedDate datetime2 NOT NULL DEFAULT GETUTCDATE(),
    
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouses(WarehouseID),
    
    INDEX IX_OrderDetails_Order (OrderID),
    INDEX IX_OrderDetails_Product (ProductID),
    INDEX IX_OrderDetails_Fulfillment (FulfillmentStatus, AllocatedDate),
    INDEX IX_OrderDetails_Warehouse_Status (WarehouseID, FulfillmentStatus)
);
```

#### **Performance Optimization Indexes**
```sql
-- Specialized indexes for common query patterns

-- Covering index for order summary queries
CREATE NONCLUSTERED INDEX IX_Orders_Summary_Covering
ON Orders (CustomerID, OrderDate, OrderStatus)
INCLUDE (OrderNumber, TotalAmount, PaymentStatus);

-- Filtered index for active products only
CREATE NONCLUSTERED INDEX IX_Products_Active_Category
ON Products (CategoryID, VendorID)
WHERE IsActive = 1;

-- Composite index for inventory alerts
CREATE NONCLUSTERED INDEX IX_Inventory_Reorder_Alert
ON Inventory (WarehouseID, ReorderPoint)
WHERE QuantityOnHand <= ReorderPoint;

-- Index for sales analytics
CREATE NONCLUSTERED INDEX IX_OrderDetails_Analytics
ON OrderDetails (ProductID, OrderID)
INCLUDE (Quantity, UnitPrice, DiscountAmount);

-- Partitioned index for large order history
CREATE PARTITION FUNCTION pf_OrderDate (datetime2)
AS RANGE RIGHT FOR VALUES 
('2023-01-01', '2023-04-01', '2023-07-01', '2023-10-01',
 '2024-01-01', '2024-04-01', '2024-07-01', '2024-10-01');

CREATE PARTITION SCHEME ps_OrderDate
AS PARTITION pf_OrderDate
ALL TO ([PRIMARY]);

-- Partitioned table for order history
CREATE TABLE OrderHistory (
    OrderHistoryID int IDENTITY(1,1),
    OrderID int NOT NULL,
    StatusChange nvarchar(100) NOT NULL,
    ChangeDate datetime2 NOT NULL,
    ChangedBy nvarchar(255),
    Notes nvarchar(1000),
    
    INDEX IX_OrderHistory_Order_Date (OrderID, ChangeDate)
) ON ps_OrderDate(ChangeDate);
```

## 📚 **Exercise 3: Advanced Analytics & Procedures (25 minutes)**

### **Business Intelligence Integration Prompts**

#### **Executive Dashboard Analytics**
```
"Create a comprehensive analytical framework for executive reporting that includes 
KPI calculations, trend analysis, predictive indicators, and comparative metrics. 
The solution should support real-time dashboards, automated alerts for threshold 
breaches, and drill-down capabilities for detailed analysis."
```

#### **Stored Procedure Architecture**
```
"Design a stored procedure framework that handles complex business processes with 
proper error handling, transaction management, logging, and performance optimization. 
Include patterns for data validation, business rule enforcement, and audit trail 
maintenance."
```

### **Sample Advanced Procedures**

#### **Comprehensive Order Processing Procedure**
```sql
CREATE PROCEDURE [dbo].[ProcessOrder]
    @CustomerID int,
    @OrderItems NVARCHAR(MAX), -- JSON array of order items
    @ShippingAddressID int = NULL,
    @BillingAddressID int = NULL,
    @PaymentMethodID int,
    @PromoCode NVARCHAR(50) = NULL,
    @OrderID int OUTPUT,
    @TotalAmount decimal(10,2) OUTPUT,
    @ErrorMessage NVARCHAR(500) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    
    DECLARE @TransactionName NVARCHAR(50) = 'ProcessOrder_' + CAST(NEWID() AS NVARCHAR(36));
    DECLARE @LogID int;
    
    -- Initialize output parameters
    SET @OrderID = 0;
    SET @TotalAmount = 0;
    SET @ErrorMessage = NULL;
    
    BEGIN TRY
        BEGIN TRANSACTION @TransactionName;
        
        -- Log the start of order processing
        INSERT INTO ProcessingLogs (ProcessType, CustomerID, StartTime, Status)
        VALUES ('OrderProcessing', @CustomerID, GETUTCDATE(), 'Started');
        SET @LogID = SCOPE_IDENTITY();
        
        -- Validate customer
        IF NOT EXISTS (SELECT 1 FROM Customers WHERE CustomerID = @CustomerID AND IsActive = 1)
        BEGIN
            SET @ErrorMessage = 'Invalid or inactive customer ID';
            THROW 50001, @ErrorMessage, 1;
        END
        
        -- Parse and validate order items
        DECLARE @OrderItemsTable TABLE (
            ProductID int,
            Quantity int,
            RequestedWarehouseID int,
            UnitPrice decimal(10,2),
            LineTotal decimal(10,2)
        );
        
        INSERT INTO @OrderItemsTable (ProductID, Quantity, RequestedWarehouseID, UnitPrice, LineTotal)
        SELECT 
            JSON_VALUE(value, '$.ProductID'),
            JSON_VALUE(value, '$.Quantity'),
            JSON_VALUE(value, '$.WarehouseID'),
            p.BasePrice,
            JSON_VALUE(value, '$.Quantity') * p.BasePrice
        FROM OPENJSON(@OrderItems) 
        CROSS JOIN Products p 
        WHERE p.ProductID = JSON_VALUE(value, '$.ProductID')
          AND p.IsActive = 1;
        
        -- Validate inventory availability
        DECLARE @InsufficientInventory NVARCHAR(500);
        SELECT @InsufficientInventory = STRING_AGG(
            CONCAT('Product ', p.ProductName, ' has insufficient inventory'), 
            ', '
        )
        FROM @OrderItemsTable oit
        INNER JOIN Products p ON oit.ProductID = p.ProductID
        INNER JOIN Inventory i ON oit.ProductID = i.ProductID 
                                AND oit.RequestedWarehouseID = i.WarehouseID
        WHERE i.QuantityAvailable < oit.Quantity;
        
        IF @InsufficientInventory IS NOT NULL
        BEGIN
            SET @ErrorMessage = 'Insufficient inventory: ' + @InsufficientInventory;
            THROW 50002, @ErrorMessage, 1;
        END
        
        -- Calculate totals
        DECLARE @SubTotal decimal(10,2);
        DECLARE @TaxAmount decimal(10,2);
        DECLARE @ShippingAmount decimal(10,2);
        DECLARE @DiscountAmount decimal(10,2) = 0;
        
        SELECT @SubTotal = SUM(LineTotal) FROM @OrderItemsTable;
        
        -- Apply promotional discount
        IF @PromoCode IS NOT NULL
        BEGIN
            SELECT @DiscountAmount = dbo.CalculatePromoDiscount(@PromoCode, @SubTotal, @CustomerID);
        END
        
        -- Calculate tax and shipping
        SET @TaxAmount = dbo.CalculateTax(@CustomerID, @SubTotal - @DiscountAmount);
        SET @ShippingAmount = dbo.CalculateShipping(@CustomerID, @SubTotal);
        SET @TotalAmount = @SubTotal + @TaxAmount + @ShippingAmount - @DiscountAmount;
        
        -- Create the order
        INSERT INTO Orders (
            CustomerID, OrderNumber, OrderStatus, OrderDate,
            SubtotalAmount, TaxAmount, ShippingAmount, DiscountAmount, TotalAmount,
            PaymentStatus
        )
        VALUES (
            @CustomerID, 
            'ORD-' + FORMAT(GETUTCDATE(), 'yyyyMMdd') + '-' + RIGHT('00000' + CAST(NEXT VALUE FOR OrderNumberSequence AS VARCHAR(5)), 5),
            'Processing',
            GETUTCDATE(),
            @SubTotal,
            @TaxAmount,
            @ShippingAmount,
            @DiscountAmount,
            @TotalAmount,
            'Pending'
        );
        
        SET @OrderID = SCOPE_IDENTITY();
        
        -- Create order details and reserve inventory
        INSERT INTO OrderDetails (OrderID, ProductID, WarehouseID, Quantity, UnitPrice, FulfillmentStatus)
        SELECT @OrderID, ProductID, RequestedWarehouseID, Quantity, UnitPrice, 'Allocated'
        FROM @OrderItemsTable;
        
        -- Reserve inventory
        UPDATE i
        SET QuantityReserved = i.QuantityReserved + oit.Quantity,
            LastUpdated = GETUTCDATE()
        FROM Inventory i
        INNER JOIN @OrderItemsTable oit ON i.ProductID = oit.ProductID 
                                         AND i.WarehouseID = oit.RequestedWarehouseID;
        
        -- Log successful completion
        UPDATE ProcessingLogs 
        SET EndTime = GETUTCDATE(), 
            Status = 'Completed',
            OrderID = @OrderID,
            TotalAmount = @TotalAmount
        WHERE LogID = @LogID;
        
        -- Create audit trail
        INSERT INTO OrderAudit (OrderID, Action, ActionDate, ActionBy, Details)
        VALUES (@OrderID, 'OrderCreated', GETUTCDATE(), SYSTEM_USER, 
                CONCAT('Order created with total: ', FORMAT(@TotalAmount, 'C')));
        
        COMMIT TRANSACTION @TransactionName;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION @TransactionName;
        
        -- Log the error
        SET @ErrorMessage = ERROR_MESSAGE();
        
        UPDATE ProcessingLogs 
        SET EndTime = GETUTCDATE(), 
            Status = 'Failed',
            ErrorMessage = @ErrorMessage
        WHERE LogID = @LogID;
        
        -- Re-throw for upstream handling
        THROW;
    END CATCH
END;
```

#### **Advanced Analytics View**
```sql
-- Comprehensive business intelligence view
CREATE VIEW [dbo].[ExecutiveDashboard]
AS
WITH current_period AS (
    SELECT 
        YEAR(GETDATE()) as current_year,
        MONTH(GETDATE()) as current_month,
        DATEADD(MONTH, -12, GETDATE()) as year_ago_start,
        DATEADD(MONTH, -1, GETDATE()) as last_month_start,
        GETDATE() as current_date
),
sales_metrics AS (
    SELECT 
        YEAR(o.OrderDate) as sales_year,
        MONTH(o.OrderDate) as sales_month,
        COUNT(DISTINCT o.OrderID) as order_count,
        COUNT(DISTINCT o.CustomerID) as unique_customers,
        SUM(o.TotalAmount) as total_revenue,
        AVG(o.TotalAmount) as avg_order_value,
        SUM(od.Quantity) as total_units_sold,
        COUNT(DISTINCT od.ProductID) as products_sold
    FROM Orders o
    INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
    CROSS JOIN current_period cp
    WHERE o.OrderDate >= cp.year_ago_start
      AND o.OrderStatus NOT IN ('Cancelled', 'Refunded')
    GROUP BY YEAR(o.OrderDate), MONTH(o.OrderDate)
),
customer_metrics AS (
    SELECT 
        COUNT(DISTINCT CASE WHEN o.OrderDate >= cp.current_date - 30 THEN o.CustomerID END) as active_customers_30d,
        COUNT(DISTINCT CASE WHEN o.OrderDate >= cp.current_date - 90 THEN o.CustomerID END) as active_customers_90d,
        COUNT(DISTINCT o.CustomerID) as total_customers_year
    FROM Orders o
    CROSS JOIN current_period cp
    WHERE o.OrderDate >= cp.year_ago_start
      AND o.OrderStatus NOT IN ('Cancelled', 'Refunded')
),
inventory_metrics AS (
    SELECT 
        COUNT(*) as total_products,
        SUM(CASE WHEN i.QuantityAvailable <= i.ReorderPoint THEN 1 ELSE 0 END) as low_stock_count,
        SUM(i.QuantityOnHand * p.BasePrice) as inventory_value,
        AVG(CASE WHEN i.QuantityAvailable > 0 THEN i.QuantityAvailable ELSE NULL END) as avg_stock_level
    FROM Inventory i
    INNER JOIN Products p ON i.ProductID = p.ProductID
    WHERE p.IsActive = 1
),
top_products AS (
    SELECT TOP 10
        p.ProductName,
        SUM(od.Quantity) as units_sold,
        SUM(od.Quantity * od.UnitPrice) as revenue,
        ROW_NUMBER() OVER (ORDER BY SUM(od.Quantity * od.UnitPrice) DESC) as revenue_rank
    FROM OrderDetails od
    INNER JOIN Products p ON od.ProductID = p.ProductID
    INNER JOIN Orders o ON od.OrderID = o.OrderID
    CROSS JOIN current_period cp
    WHERE o.OrderDate >= cp.last_month_start
      AND o.OrderStatus NOT IN ('Cancelled', 'Refunded')
    GROUP BY p.ProductName
)
SELECT 
    -- Current period metrics
    (SELECT SUM(total_revenue) FROM sales_metrics sm CROSS JOIN current_period cp 
     WHERE sm.sales_year = cp.current_year AND sm.sales_month = cp.current_month) as current_month_revenue,
    
    (SELECT SUM(order_count) FROM sales_metrics sm CROSS JOIN current_period cp 
     WHERE sm.sales_year = cp.current_year AND sm.sales_month = cp.current_month) as current_month_orders,
    
    -- Year-over-year growth
    (SELECT 
        CASE WHEN LAG(SUM(total_revenue)) OVER (ORDER BY sales_year, sales_month) > 0
        THEN ((SUM(total_revenue) - LAG(SUM(total_revenue)) OVER (ORDER BY sales_year, sales_month)) / 
              LAG(SUM(total_revenue)) OVER (ORDER BY sales_year, sales_month)) * 100
        ELSE NULL END
     FROM sales_metrics sm CROSS JOIN current_period cp 
     WHERE sm.sales_year = cp.current_year AND sm.sales_month = cp.current_month) as revenue_growth_percent,
    
    -- Customer metrics
    cm.active_customers_30d,
    cm.active_customers_90d,
    cm.total_customers_year,
    
    -- Inventory metrics
    im.total_products,
    im.low_stock_count,
    FORMAT(im.inventory_value, 'C') as inventory_value,
    ROUND(im.avg_stock_level, 0) as avg_stock_level,
    
    -- Top products JSON
    (SELECT 
        ProductName, units_sold, FORMAT(revenue, 'C') as revenue, revenue_rank
     FROM top_products 
     FOR JSON PATH) as top_products_json,
    
    GETDATE() as report_generated_date
    
FROM customer_metrics cm
CROSS JOIN inventory_metrics im;
```

## 🎯 **Assessment Criteria**

### **SQL Development Proficiency**
- [ ] Creates efficient, maintainable queries that solve business problems
- [ ] Demonstrates understanding of query optimization and performance tuning
- [ ] Implements proper database design principles and normalization
- [ ] Uses advanced SQL features appropriately (CTEs, window functions, JSON)

### **AI Collaboration Effectiveness**
- [ ] Asks strategic questions about database architecture and optimization
- [ ] Iterates on solutions based on AI feedback and performance analysis
- [ ] Explains business reasoning behind technical decisions
- [ ] Uses AI to validate and improve data quality and integrity

### **Business Intelligence Integration**
- [ ] Designs analytics that provide actionable business insights
- [ ] Considers data quality and validation in analytical queries
- [ ] Balances query complexity with maintainability
- [ ] Implements proper error handling and logging strategies

## 🚀 **Common Challenges & Solutions**

### **Challenge: "My queries are too slow"**
**Coaching Approach:**
- Guide analysis of execution plans and query performance
- Explore indexing strategies and their trade-offs
- Discuss query optimization techniques and best practices
- Help students understand when to denormalize for performance

### **Challenge: "The data model seems overly complex"**
**Learning Opportunity:**
- Discuss the balance between normalization and practical usability
- Explore when to use views and stored procedures to simplify complexity
- Help students understand how good design reduces long-term maintenance

### **Challenge: "Business requirements keep changing"**
**Strategic Teaching:**
- Emphasize flexible design patterns and modular approaches
- Discuss version control and change management for database schemas
- Explore how proper abstraction layers handle requirement changes

## 📝 **Instructor Notes**

### **Database Platform Considerations**
- **SQL Server**: Rich enterprise features and excellent tooling
- **PostgreSQL**: Advanced analytics capabilities and JSON support
- **MySQL**: Web application focus with good performance
- **SQLite**: Lightweight option for learning and prototyping

### **Time Management Tips**
- **Exercise 1**: Query complexity can vary greatly - provide scaffolding
- **Exercise 2**: Schema design discussions often need extra time
- **Exercise 3**: Advanced topics may require follow-up sessions

### **Extension Opportunities**
- Data warehousing and ETL processes
- Advanced analytics with machine learning integration
- Database security and compliance implementation
- Performance monitoring and optimization strategies

**Remember: Focus on developing strategic data thinking with AI assistance, not just query writing! 🎯**
