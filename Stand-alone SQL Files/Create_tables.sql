-- Create a new database
CREATE DATABASE DB;
GO

-- Use the created database
USE DB;
GO

-- Create Customers table
CREATE TABLE Customers (
    CustomerId INT IDENTITY(1, 1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    DateOfBirth DATETIME2 NOT NULL,
    Email NVARCHAR(MAX) NOT NULL,
    PhoneNumber NVARCHAR(MAX) NOT NULL,
    Address NVARCHAR(MAX) NOT NULL
);
GO

-- Create Tickets table
CREATE TABLE Tickets (
    TicketId INT IDENTITY(1, 1) PRIMARY KEY,
    Title NVARCHAR(MAX) NOT NULL,
    Departure NVARCHAR(MAX) NOT NULL,
    Arrival NVARCHAR(MAX) NOT NULL,
    Priority NVARCHAR(MAX) NOT NULL,
    DueDate DATETIME2 NOT NULL,
    Duration INT NOT NULL,
    CustomerId INT NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);
