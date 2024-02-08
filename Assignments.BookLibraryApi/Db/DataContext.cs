using Assignments.BookLibraryApi.Models;
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

        public void AddBook(Book book)
        {
            using (IDbConnection db = GetConnection())
            {
                string query = @"
                    INSERT INTO Book (ShelfId, Title, ISBN, Description)
                    VALUES (@ShelfId, @Title, @ISBN, @Description);";
                db.Execute(query, book);
            }
        }

        public IEnumerable<Book> GetBooksByShelfId(int shelfId)
        {
            using (IDbConnection db = GetConnection())
            {
                string query = "SELECT * FROM Book WHERE ShelfId = @ShelfId;";
                return db.Query<Book>(query, new { ShelfId = shelfId }).ToList();
            }
        }

        public Book GetBookById(int bookId)
        {
            using (IDbConnection db = GetConnection())
            {
                string query = "SELECT * FROM Book WHERE Id = @BookId;";
                return db.QueryFirstOrDefault<Book>(query, new { BookId = bookId });
            }
        }

        public void MoveBookToShelf(int bookId, int destinationShelfId)
        {
            using (IDbConnection db = GetConnection())
            {
                string query = "UPDATE Book SET ShelfId = @DestinationShelfId WHERE Id = @BookId;";
                db.Execute(query, new { BookId = bookId, DestinationShelfId = destinationShelfId });
            }
        }

        public void EnsureTablesCreated()
        {
            using IDbConnection db = GetConnection();

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

