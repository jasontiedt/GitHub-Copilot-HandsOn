# SQL AI Lab - Setup Instructions

## Prerequisites

### Software Requirements
1. **SQL Server** (LocalDB, Express, or full version)
   - SQL Server 2019 or later recommended
   - SQL Server Management Studio (SSMS) 18.0 or later
   - OR Azure Data Studio (cross-platform alternative)

2. **Visual Studio Code** (recommended for AI assistance)
   - SQL Server (mssql) extension
   - GitHub Copilot extension
   - SQLTools extension (optional)

3. **Git** (for version control)
   - Latest version from https://git-scm.com/

### Account Requirements
- GitHub account with Copilot access
- Azure account (optional, for cloud exercises)

## Database Setup

### Option 1: SQL Server LocalDB (Recommended for local development)

1. **Install SQL Server LocalDB**
   ```cmd
   # Download from Microsoft website or use SQL Server installer
   # LocalDB is included with Visual Studio
   ```

2. **Connect to LocalDB**
   ```cmd
   # Connection string example:
   Server=(localdb)\MSSQLLocalDB;Integrated Security=true;
   ```

3. **Verify Installation**
   ```cmd
   sqllocaldb info
   sqllocaldb start MSSQLLocalDB
   ```

### Option 2: SQL Server Express

1. **Download and Install**
   - Download SQL Server Express from Microsoft
   - Include SQL Server Management Studio

2. **Configure Instance**
   - Enable mixed mode authentication
   - Set strong SA password
   - Enable TCP/IP protocol

### Option 3: Azure SQL Database

1. **Create Azure SQL Database**
   ```bash
   # Using Azure CLI
   az sql server create --name sqlailab-server --resource-group rg-sqlailab --location eastus --admin-user sqladmin --admin-password YourStrongPassword123!
   
   az sql db create --resource-group rg-sqlailab --server sqlailab-server --name SQLAILab --service-objective Basic
   ```

2. **Configure Firewall**
   ```bash
   # Allow your IP
   az sql server firewall-rule create --resource-group rg-sqlailab --server sqlailab-server --name AllowMyIP --start-ip-address YOUR_IP --end-ip-address YOUR_IP
   ```

## Project Setup

### 1. Clone the Repository
```bash
git clone https://github.com/your-org/github-copilot-handson.git
cd github-copilot-handson/SQL-AI-Lab
```

### 2. Database Initialization

#### Using SQL Server Management Studio (SSMS)
1. Open SSMS and connect to your SQL Server instance
2. Open the setup scripts in order:
   - `database/setup/01-create-database.sql`
   - `database/setup/02-create-tables.sql`
   - `database/sample-data/insert-sample-data.sql`
3. Execute each script (F5 or Ctrl+E)

#### Using Azure Data Studio
1. Open Azure Data Studio
2. Create new connection to your SQL Server
3. Open and execute the setup scripts in order

#### Using Command Line (sqlcmd)
```cmd
# Connect to LocalDB
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -i "database\setup\01-create-database.sql"
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -i "database\setup\02-create-tables.sql"
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -i "database\sample-data\insert-sample-data.sql"

# For SQL Server Express (adjust server name)
sqlcmd -S "localhost\SQLEXPRESS" -E -i "database\setup\01-create-database.sql"
```

### 3. Verify Installation
Run this verification query:
```sql
USE SQLAILab;
GO

SELECT 'Database Setup Complete' as Status;

SELECT 
    TABLE_NAME,
    (SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = t.TABLE_NAME) as ColumnCount
FROM INFORMATION_SCHEMA.TABLES t
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;

-- Verify sample data
SELECT 
    'Customers' as TableName, COUNT(*) as RecordCount FROM Customers
UNION ALL
SELECT 'Products', COUNT(*) FROM Products
UNION ALL
SELECT 'Orders', COUNT(*) FROM Orders
UNION ALL
SELECT 'Categories', COUNT(*) FROM Categories;
```

Expected output should show all tables with appropriate record counts.

## Visual Studio Code Setup

### 1. Install Extensions
```bash
# Open VS Code in the project folder
code .

# Install extensions (will prompt to install if not present)
# - SQL Server (mssql)
# - GitHub Copilot
# - GitHub Copilot Chat
```

### 2. Configure SQL Server Extension
1. Open Command Palette (Ctrl+Shift+P)
2. Type "SQL: Connect" and select it
3. Choose "Create Connection Profile"
4. Enter connection details:
   - **Server**: `(localdb)\MSSQLLocalDB` (for LocalDB) or your server name
   - **Database**: `SQLAILab`
   - **Authentication**: Windows Authentication (or SQL Login)
   - **Profile Name**: `SQLAILab-Local`

### 3. Test Connection
1. Open a new `.sql` file
2. Connect to your database profile
3. Run a test query:
   ```sql
   SELECT 'Connection Successful' as Message, GETDATE() as CurrentTime;
   ```

## GitHub Copilot Setup

### 1. Verify Copilot Access
1. Ensure you have GitHub Copilot subscription
2. Sign in to GitHub in VS Code
3. Check Copilot status in VS Code status bar

### 2. Test Copilot Functionality
1. Create a new SQL file
2. Type a comment like: `-- Get all customers from New York`
3. Press Enter and see if Copilot suggests a query
4. Accept suggestion with Tab key

### 3. Configure Copilot Settings
1. Open VS Code settings (Ctrl+,)
2. Search for "copilot"
3. Adjust settings as needed:
   - Enable/disable suggestions
   - Configure suggestion trigger
   - Set language preferences

## Environment Validation

### Run the Validation Script
Create and run this validation script:

```sql
-- File: validate-setup.sql
USE SQLAILab;
GO

PRINT '=== SQL AI Lab Environment Validation ===';
PRINT '';

-- Check database version
PRINT 'SQL Server Version:';
SELECT @@VERSION;
PRINT '';

-- Check database name
PRINT 'Current Database:';
SELECT DB_NAME() as DatabaseName;
PRINT '';

-- Check tables
PRINT 'Table Validation:';
DECLARE @tableCount INT = (SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE');
PRINT 'Total Tables: ' + CAST(@tableCount AS VARCHAR);

IF @tableCount >= 8
    PRINT 'PASS: All expected tables present'
ELSE
    PRINT 'FAIL: Missing tables - expected 8 or more';
PRINT '';

-- Check sample data
PRINT 'Data Validation:';
DECLARE @customerCount INT = (SELECT COUNT(*) FROM Customers);
DECLARE @productCount INT = (SELECT COUNT(*) FROM Products);
DECLARE @orderCount INT = (SELECT COUNT(*) FROM Orders);

PRINT 'Customers: ' + CAST(@customerCount AS VARCHAR);
PRINT 'Products: ' + CAST(@productCount AS VARCHAR);
PRINT 'Orders: ' + CAST(@orderCount AS VARCHAR);

IF @customerCount > 0 AND @productCount > 0 AND @orderCount > 0
    PRINT 'PASS: Sample data loaded successfully'
ELSE
    PRINT 'FAIL: Sample data missing';
PRINT '';

-- Check relationships
PRINT 'Relationship Validation:';
DECLARE @fkCount INT = (
    SELECT COUNT(*) 
    FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS
);
PRINT 'Foreign Key Constraints: ' + CAST(@fkCount AS VARCHAR);

IF @fkCount >= 5
    PRINT 'PASS: Foreign key relationships established'
ELSE
    PRINT 'FAIL: Missing foreign key constraints';
PRINT '';

PRINT '=== Validation Complete ===';
PRINT 'If all tests show PASS, your environment is ready!';
PRINT 'If any tests show FAIL, review the setup instructions.';
```

## Troubleshooting

### Common Issues

#### 1. Cannot Connect to LocalDB
**Solution**:
```cmd
# Check if LocalDB is running
sqllocaldb info

# Start LocalDB if stopped
sqllocaldb start MSSQLLocalDB

# If corrupt, delete and recreate
sqllocaldb stop MSSQLLocalDB
sqllocaldb delete MSSQLLocalDB
sqllocaldb create MSSQLLocalDB
```

#### 2. Permission Denied Errors
**Solution**:
- Run SQL Server Management Studio as Administrator
- Ensure your Windows user has appropriate permissions
- For SQL Authentication, verify username/password

#### 3. GitHub Copilot Not Working
**Solution**:
- Check GitHub Copilot subscription status
- Sign out and sign in to GitHub in VS Code
- Restart VS Code
- Check VS Code extension logs

#### 4. SQL Server Extension Connection Issues
**Solution**:
- Verify server name and instance
- Check SQL Server service is running
- Verify firewall settings
- Test connection with SSMS first

### Getting Help

1. **Documentation**: Review Microsoft SQL Server documentation
2. **GitHub Issues**: Check repository issues for known problems
3. **Community**: Stack Overflow, SQL Server forums
4. **AI Assistance**: Use GitHub Copilot Chat for troubleshooting

## Next Steps

Once setup is complete:

1. **Start with Exercise 1**: Query Generation
2. **Work through exercises sequentially**
3. **Practice AI prompting techniques**
4. **Experiment with different approaches**
5. **Build your own scenarios**

## Environment Information

Record your setup details for reference:

- **SQL Server Version**: ________________
- **Connection String**: ________________
- **VS Code Version**: ________________
- **Copilot Status**: ________________
- **Setup Date**: ________________

Happy learning with SQL AI development!
