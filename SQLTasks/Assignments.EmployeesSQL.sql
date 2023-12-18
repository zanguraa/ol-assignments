CREATE TABLE Employees (
Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Name VARCHAR(255) NOT NULL,
Salary INT NOT NULL,
Department VARCHAR(255) )

INSERT INTO Employees (Name, Salary, Department)
VALUES 
('John', 1000, 'Sales'),
('Jane', 1200, 'Marketing'),
('Bill', 1500, 'Engineering'),
('Rachel', 1200, 'Marketing'),
('Steve', 1000, 'Sales')

SELECT Department, AVG(Salary) AS AverageSalary
FROM Employees
GROUP BY Department