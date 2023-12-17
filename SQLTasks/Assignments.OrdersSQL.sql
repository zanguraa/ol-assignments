CREATE TABLE Orders (
Id INT IDENTITY(1,1) NOT NULL,
CustomerId INT NOT NULL,
ProductName VARCHAR(255) NOT NULL,
Quantity INT NOT NULL)

SELECT * FROM Orders

INSERT INTO Orders (CustomerId, ProductName, Quantity)
VALUES
(1, 'Phone', 2),
(1, 'Tablet', 1),
(2, 'Laptop', 3),
(3, 'SmartWatch', 1),
(4, 'HeardPhones', 2),
(5, 'Speaker', 1)

ALTER TABLE Orders
ADD FOREIGN KEY (CustomerId) REFERENCES Customers(Id);

SELECT
    Customers.Name AS CustomerName,
    SUM(Orders.Quantity) AS TotalProducts
FROM
    Customers
JOIN
    Orders ON Customers.Id = Orders.CustomerId
GROUP BY
    Customers.Name;

