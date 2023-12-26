using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Classroom.AdoNetBookLibrary
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=DESKTOP-7OLVUTI;Initial Catalog=credo_test;Integrated Security=SSPI;TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(connectionString);

            await connection.OpenAsync();

            var insertQuery = $"INSERT INTO dbo.Books (Title, AuthorId, YearPublished) values (@Title, @AuthorId, @YearPublished)";
            var query = $"SELECT Id, Title, YearPublished FROM dbo.Books WHERE YearPublished > @YearPublished";


            string title = "book1";
            int authorId = 3;
            int yearPublished = 2003;

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
            insertCommand.CommandType = CommandType.Text;
            insertCommand.Parameters.AddWithValue("@Title", title);
            insertCommand.Parameters.AddWithValue("@AuthorId", authorId);
            insertCommand.Parameters.AddWithValue("@YearPublished", yearPublished);
            int rowsAffected = await insertCommand.ExecuteNonQueryAsync();

            if (rowsAffected > 0)
            {
                Console.WriteLine($"Insert successful. Rows affected: {rowsAffected}");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }

            adapter.SelectCommand = new SqlCommand(query, connection);
            adapter.SelectCommand.CommandType = System.Data.CommandType.Text;
            adapter.SelectCommand.Parameters.AddWithValue("@YearPublished", 2000);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"Id: {row["Id"]}, Title: {row["Title"]}, YearPublished: {row["YearPublished"]}");
            }



            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    await connection.OpenAsync();
            //    Console.WriteLine("Connection successful!");


            //    using (SqlCommand command = new SqlCommand("SELECT Id, Title, YearPublished FROM dbo.Books", connection))
            //    {
            //        using (SqlDataReader reader = await command.ExecuteReaderAsync())
            //        {
            //            while (await reader.ReadAsync())
            //            {
            //                Console.WriteLine($"Id: {reader["Id"]}, Title: {reader["Title"]}, YearPublished: {reader["YearPublished"]}");
            //            }
            //        }
            //    }
            //    await connection.CloseAsync();
        }
    }
    
}
