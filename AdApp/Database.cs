using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace AdApp
{
    internal class Database
    {
        private readonly string connectionString =
    "Server=localhost\\SQLEXPRESS;Database=AdDB;Trusted_Connection=True;Connect Timeout=5;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
