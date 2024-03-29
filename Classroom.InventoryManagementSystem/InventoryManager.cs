﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;



namespace Classroom.InventoryManagementSystem
{
    public class InventoryManager
    {
        private readonly string connectionString;

        public InventoryManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Products> GetProducts(string name)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Products WHERE Name LIKE '%' + @name + '%'";

                return connection.Query<Products>(query, new { name });
            }
        }

        public Products GetProductById(int productId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Products WHERE Id = @productId";

                return connection.QueryFirstOrDefault<Products>(query, new { productId });
            }
        }

        public void AddProduct(Products products)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO Products (Name, Price, Stock, CategoryId) VALUES (@Name, @Price, @Stock, @CategoryId)", products);
            }
        }

        public void InsertIfNotExist()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int rowCount = connection.QueryFirstOrDefault<int>("SELECT COUNT(*) FROM Categories");

                if (rowCount == 0)
                {
                    string query = "INSERT INTO Categories (Name, Description) VALUES " +
                          "('Electronics', 'Devices and gadgets like smartphones, laptops, and cameras.')," +
                          "('Clothing', 'Apparel items including shirts, pants, and accessories.')," +
                          "('Home Appliances', 'Household appliances like refrigerators, microwaves, and washing machines.')," +
                          "('Books', 'Various genres of books, including fiction, non-fiction, and academic.')," +
                          "('Sports & Fitness', 'Equipment and accessories for sports and fitness activities.')," +
                          "('Groceries', 'Everyday items including food, beverages, and household essentials.')," +
                          "('Health & Beauty', 'Products for personal care, wellness, and beauty.')," +
                          "('Toys & Games', 'Children’s toys and games for all ages.')," +
                          "('Automotive', 'Automobile accessories and car care products.');";

                    connection.Execute(query);
                }
            }
        }

        public void RecordSale(Products product, int quantitySold)
        {
            using (SqlConnection connencion = new SqlConnection(connectionString))
            {
                connencion.Open();
                if (product.Stock >= quantitySold)
                {
                    product.Stock -= quantitySold;
                    connencion.Execute("UPDATE Products SET Stock = @Stock WHERE Id = @ProductId", new { Stock = product.Stock, ProductId = product.Id });

                    Sales sale = new Sales
                    {
                        ProductId = product.Id,
                        Quantity = quantitySold,
                        SaleDate = DateTime.Now,
                    };

                    connencion.Execute("INSERT INTO Sales (ProductId, Quantity, SaleDate) VALUES (@ProductId, @Quantity, @SaleDate)", sale);
                }
                else
                {
                    Console.WriteLine("Not enought stock available for the sale");
                }
            }
        }

        public List<Products> GetAllProducts()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<Products>("SELECT * FROM Products").ToList();
            }
        }

        public void DeleteProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.Execute("DELETE FROM Sales WHERE ProductId = @ProductId", new { ProductId = id });

                connection.Execute("DELETE FROM Products WHERE Id = @ProductId", new { ProductId = id });
            }
        }

        public IEnumerable<TotalSalesReport> GetTotalSalesReportWithDetails()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT 
                P.Id AS ProductId,
                P.Name AS ProductName,
                P.Price AS UnitPrice,
                COALESCE(SUM(S.Quantity), 0) AS TotalQuantitySold,
                COALESCE(SUM(S.Quantity * P.Price), 0) AS TotalRevenue,
                S.Id AS SaleId,
                S.Quantity AS SaleQuantity,
                S.SaleDate
            FROM 
                Products P
                LEFT JOIN Sales S ON P.Id = S.ProductId
            GROUP BY 
                P.Id, P.Name, P.Price, S.Id, S.Quantity, S.SaleDate
            ORDER BY
                P.Id, S.Id";

                return connection.Query<TotalSalesReport>(query);
            }
        }

        public IEnumerable<TotalSalesPerProduct> GetTotalSalesPerProduct()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT 
                P.Id AS ProductId,
                P.Name AS ProductName,
                P.Price AS UnitPrice,
                COALESCE(SUM(S.Quantity), 0) AS TotalQuantitySold,
                COALESCE(SUM(S.Quantity * P.Price), 0) AS TotalRevenue
            FROM 
                Products P
                LEFT JOIN Sales S ON P.Id = S.ProductId
            GROUP BY 
                P.Id, P.Name, P.Price
            ORDER BY
                P.Id";

                return connection.Query<TotalSalesPerProduct>(query);
            }
        }


    }
}
