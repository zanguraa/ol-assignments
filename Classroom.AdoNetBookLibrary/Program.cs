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

            var query = $"SELECT Id, Title, YearPublished FROM dbo.Books WHERE YearPublished > @YearPublished";


            SqlDataAdapter adapter = new SqlDataAdapter();
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
