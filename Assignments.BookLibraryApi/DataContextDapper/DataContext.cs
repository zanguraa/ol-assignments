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
    }
}
