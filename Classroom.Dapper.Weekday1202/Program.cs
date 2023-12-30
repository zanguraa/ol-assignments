using System.Data;
using System.Data.SqlClient;
using Classroom.Dapper.Weekday1202;
using Dapper;


Console.WriteLine("Hello, World!");
string connectionString = "Data Source=DESKTOP-7OLVUTI;Initial Catalog=credo_test;Integrated Security=SSPI;TrustServerCertificate=True";
await using SqlConnection connection = new SqlConnection(connectionString);
await connection.OpenAsync();

var sqlQuery = $"SELECT Id, Name, Age FROM Authors WHERE Age < @Age";
var authors = connection.Query<Author>(sqlQuery, new { Age = 40});

var insertSql = "INSERT INTO Authors (Name, Age) VALUES(@Name, @Age)";

var valeri = new Author();
valeri.Name = "Valeri";
valeri.Age = 32;

var barbara = new Author();
barbara.Name = "Barbara";
barbara.Age = 20;

var iauthors = new List<Author>();
iauthors.Add(valeri);
iauthors.Add((barbara));

var insertCound = connection.Execute(insertSql, authors);



foreach (var auth in authors)
{
    
    Console.WriteLine($"Id: {auth.Id}, Name: {auth.Name}, Age: {auth.Age}");
}

//SqlCommand command = new SqlCommand(sqlQuery, connection);
//command.CommandType = System.Data.CommandType.Text;
//SqlDataReader reader = command.ExecuteReader();

//while (reader.Read())
//{
//    var id = reader.GetInt32("Id");
//    var name = reader["Name"];
//    Console.WriteLine($"Id: {id}, Name: {name}");
//}
await connection.CloseAsync();



