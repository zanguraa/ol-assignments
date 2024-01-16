using System;
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

        public void AddProduct(Products products)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
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


    }
}
