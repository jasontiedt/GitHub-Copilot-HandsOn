-- Create Tables for SQL AI Lab
-- This script creates the sample tables used throughout the lab exercises

USE SQLAILab;
GO

-- Create Customers table
CREATE TABLE Customers (
    CustomerID int IDENTITY(1,1) PRIMARY KEY,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    Email nvarchar(100) UNIQUE NOT NULL,
    Phone nvarchar(20),
    DateOfBirth date,
    City nvarchar(50),
    State nvarchar(50),
    Country nvarchar(50),
    CreatedDate datetime2 DEFAULT GETDATE(),
    IsActive bit DEFAULT 1
);

-- Create Categories table
CREATE TABLE Categories (
    CategoryID int IDENTITY(1,1) PRIMARY KEY,
    CategoryName nvarchar(50) NOT NULL,
    Description nvarchar(255),
    CreatedDate datetime2 DEFAULT GETDATE()
);

-- Create Products table
CREATE TABLE Products (
    ProductID int IDENTITY(1,1) PRIMARY KEY,
    ProductName nvarchar(100) NOT NULL,
    CategoryID int FOREIGN KEY REFERENCES Categories(CategoryID),
    Price decimal(10,2) NOT NULL,
    Cost decimal(10,2),
    StockQuantity int DEFAULT 0,
    Description nvarchar(500),
    IsActive bit DEFAULT 1,
    CreatedDate datetime2 DEFAULT GETDATE(),
    LastModified datetime2 DEFAULT GETDATE()
);

-- Create Orders table
CREATE TABLE Orders (
    OrderID int IDENTITY(1,1) PRIMARY KEY,
    CustomerID int FOREIGN KEY REFERENCES Customers(CustomerID),
    OrderDate datetime2 DEFAULT GETDATE(),
    ShippedDate datetime2,
    TotalAmount decimal(10,2),
    Status nvarchar(20) DEFAULT 'Pending',
    ShippingAddress nvarchar(255),
    PaymentMethod nvarchar(50)
);

-- Create OrderDetails table
CREATE TABLE OrderDetails (
    OrderDetailID int IDENTITY(1,1) PRIMARY KEY,
    OrderID int FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID int FOREIGN KEY REFERENCES Products(ProductID),
    Quantity int NOT NULL,
    UnitPrice decimal(10,2) NOT NULL,
    Discount decimal(5,2) DEFAULT 0
);

-- Create Employees table
CREATE TABLE Employees (
    EmployeeID int IDENTITY(1,1) PRIMARY KEY,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    Email nvarchar(100) UNIQUE NOT NULL,
    Department nvarchar(50),
    Position nvarchar(50),
    Salary decimal(10,2),
    HireDate date,
    ManagerID int FOREIGN KEY REFERENCES Employees(EmployeeID),
    IsActive bit DEFAULT 1
);

-- Create Suppliers table
CREATE TABLE Suppliers (
    SupplierID int IDENTITY(1,1) PRIMARY KEY,
    CompanyName nvarchar(100) NOT NULL,
    ContactName nvarchar(50),
    Email nvarchar(100),
    Phone nvarchar(20),
    Address nvarchar(255),
    City nvarchar(50),
    Country nvarchar(50),
    CreatedDate datetime2 DEFAULT GETDATE()
);

-- Create ProductSuppliers junction table
CREATE TABLE ProductSuppliers (
    ProductID int FOREIGN KEY REFERENCES Products(ProductID),
    SupplierID int FOREIGN KEY REFERENCES Suppliers(SupplierID),
    SupplyPrice decimal(10,2),
    PRIMARY KEY (ProductID, SupplierID)
);

PRINT 'All tables created successfully!';
GO
