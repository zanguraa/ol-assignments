CREATE TABLE Customers (
Id INT NOT NULL Primary Key,
Name VARCHAR(255),
City VARCHAR(255),
Country VARCHAR(255))

SELECT * FROM Customers

INSERT INTO Customers (Id, Name, City, Country)
VALUES
(1, 'Alice', 'London', 'UK'),
(2, 'Bob', 'New York', 'USA'),
(3, 'Eve', 'Paris', 'France'),
(4, 'Frank', 'Berlin', 'Germany'),
(5, 'Grace', 'Mumbai', 'India')

SELECT Name FROM Customers
WHERE City = 'London' OR City = 'Paris'