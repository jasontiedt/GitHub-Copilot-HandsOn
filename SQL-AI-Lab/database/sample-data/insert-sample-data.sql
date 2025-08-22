-- Insert Sample Data for SQL AI Lab
-- This script populates the database with realistic sample data

USE SQLAILab;
GO

-- Insert Categories
INSERT INTO Categories (CategoryName, Description) VALUES
('Electronics', 'Electronic devices and accessories'),
('Clothing', 'Apparel and fashion items'),
('Books', 'Books and educational materials'),
('Home & Garden', 'Home improvement and gardening supplies'),
('Sports', 'Sports equipment and accessories'),
('Beauty', 'Beauty and personal care products');

-- Insert Customers
INSERT INTO Customers (FirstName, LastName, Email, Phone, DateOfBirth, City, State, Country) VALUES
('John', 'Smith', 'john.smith@email.com', '555-0101', '1985-03-15', 'New York', 'NY', 'USA'),
('Emily', 'Johnson', 'emily.johnson@email.com', '555-0102', '1990-07-22', 'Los Angeles', 'CA', 'USA'),
('Michael', 'Brown', 'michael.brown@email.com', '555-0103', '1982-11-08', 'Chicago', 'IL', 'USA'),
('Sarah', 'Davis', 'sarah.davis@email.com', '555-0104', '1995-01-30', 'Houston', 'TX', 'USA'),
('David', 'Wilson', 'david.wilson@email.com', '555-0105', '1988-09-12', 'Phoenix', 'AZ', 'USA'),
('Jessica', 'Miller', 'jessica.miller@email.com', '555-0106', '1993-05-18', 'Philadelphia', 'PA', 'USA'),
('Robert', 'Garcia', 'robert.garcia@email.com', '555-0107', '1987-12-03', 'San Antonio', 'TX', 'USA'),
('Ashley', 'Martinez', 'ashley.martinez@email.com', '555-0108', '1991-08-25', 'San Diego', 'CA', 'USA');

-- Insert Products
INSERT INTO Products (ProductName, CategoryID, Price, Cost, StockQuantity, Description) VALUES
('Laptop Computer', 1, 999.99, 650.00, 25, 'High-performance laptop for business and gaming'),
('Smartphone', 1, 699.99, 450.00, 50, 'Latest smartphone with advanced camera'),
('Wireless Headphones', 1, 199.99, 120.00, 75, 'Premium wireless noise-canceling headphones'),
('Men''s T-Shirt', 2, 29.99, 15.00, 100, 'Comfortable cotton t-shirt in various colors'),
('Women''s Jeans', 2, 79.99, 40.00, 60, 'Designer jeans with perfect fit'),
('Programming Book', 3, 49.99, 25.00, 30, 'Complete guide to modern programming'),
('Garden Tools Set', 4, 89.99, 45.00, 20, 'Professional gardening tools kit'),
('Basketball', 5, 39.99, 20.00, 40, 'Official size basketball for outdoor play'),
('Face Cream', 6, 24.99, 12.00, 80, 'Anti-aging face cream with natural ingredients');

-- Insert Employees
INSERT INTO Employees (FirstName, LastName, Email, Department, Position, Salary, HireDate) VALUES
('Alice', 'Manager', 'alice.manager@company.com', 'Sales', 'Sales Manager', 75000.00, '2020-01-15'),
('Bob', 'Developer', 'bob.developer@company.com', 'IT', 'Software Developer', 85000.00, '2019-03-20'),
('Carol', 'Analyst', 'carol.analyst@company.com', 'Finance', 'Financial Analyst', 65000.00, '2021-06-10'),
('Dan', 'Support', 'dan.support@company.com', 'IT', 'Technical Support', 45000.00, '2022-02-01');

-- Insert Suppliers
INSERT INTO Suppliers (CompanyName, ContactName, Email, Phone, Address, City, Country) VALUES
('TechCorp Inc', 'James Wilson', 'james@techcorp.com', '555-1001', '123 Tech Street', 'Seattle', 'USA'),
('Fashion Plus', 'Maria Garcia', 'maria@fashionplus.com', '555-1002', '456 Style Avenue', 'New York', 'USA'),
('Book World', 'Peter Jones', 'peter@bookworld.com', '555-1003', '789 Literature Lane', 'Boston', 'USA'),
('Garden Supply Co', 'Lisa Chen', 'lisa@gardensupply.com', '555-1004', '321 Green Road', 'Portland', 'USA');

-- Insert Orders
INSERT INTO Orders (CustomerID, OrderDate, TotalAmount, Status, ShippingAddress, PaymentMethod) VALUES
(1, '2024-01-15', 1199.98, 'Shipped', '123 Main St, New York, NY', 'Credit Card'),
(2, '2024-01-16', 699.99, 'Processing', '456 Oak Ave, Los Angeles, CA', 'PayPal'),
(3, '2024-01-17', 259.97, 'Delivered', '789 Pine St, Chicago, IL', 'Credit Card'),
(4, '2024-01-18', 109.98, 'Shipped', '321 Elm St, Houston, TX', 'Debit Card'),
(1, '2024-01-20', 79.99, 'Processing', '123 Main St, New York, NY', 'Credit Card');

-- Insert OrderDetails
INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice, Discount) VALUES
(1, 1, 1, 999.99, 0.00),
(1, 3, 1, 199.99, 0.00),
(2, 2, 1, 699.99, 0.00),
(3, 3, 1, 199.99, 0.00),
(3, 4, 2, 29.99, 0.00),
(4, 6, 1, 49.99, 0.00),
(4, 8, 1, 39.99, 0.00),
(4, 9, 1, 24.99, 5.00),
(5, 5, 1, 79.99, 0.00);

-- Insert ProductSuppliers
INSERT INTO ProductSuppliers (ProductID, SupplierID, SupplyPrice) VALUES
(1, 1, 650.00),
(2, 1, 450.00),
(3, 1, 120.00),
(4, 2, 15.00),
(5, 2, 40.00),
(6, 3, 25.00),
(7, 4, 45.00),
(8, 4, 20.00),
(9, 2, 12.00);

PRINT 'Sample data inserted successfully!';
GO
