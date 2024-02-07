using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Assignments.BookLibraryApi.DataContextDapper
{
    public class DataContext
    {
        private readonly string _connectionString;

        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public void EnsureTablesCreated()
        {
            using IDbConnection db = GetConnection();

            // Create tables if not exists
            string createShelfTableQuery = @"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Shelf')
                CREATE TABLE Shelf (
                    Id INT PRIMARY KEY IDENTITY,
                    Name NVARCHAR(255)
                );";

            string createBookTableQuery = @"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Book')
                CREATE TABLE Book (
                    Id INT PRIMARY KEY IDENTITY,
                    ShelfId INT,
                    Title NVARCHAR(255),
                    ISBN NVARCHAR(20),
                    Description NVARCHAR(MAX),
                    FOREIGN KEY (ShelfId) REFERENCES Shelf(Id)
                );";

            db.Execute(createShelfTableQuery);
            db.Execute(createBookTableQuery);
        }
    }
}
