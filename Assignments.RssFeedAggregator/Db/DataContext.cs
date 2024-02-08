using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.RssFeedAggregator.Db
{
    public static class DataContext
    {
        public static SqlConnection GetConnection()
        {
            // Return your SQL Server connection string here
            string connectionString = "Your_SQL_Server_Connection_String";
            return new SqlConnection(connectionString);
        }
    }
}
