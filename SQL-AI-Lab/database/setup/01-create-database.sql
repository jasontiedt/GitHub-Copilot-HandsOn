-- SQL AI Lab Database Setup
-- Creates the main database for the SQL AI Development Lab

USE master;
GO

-- Drop database if it exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'SQLAILab')
BEGIN
    ALTER DATABASE SQLAILab SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SQLAILab;
END
GO

-- Create the database
CREATE DATABASE SQLAILab;
GO

-- Use the new database
USE SQLAILab;
GO

PRINT 'SQLAILab database created successfully!';
GO
