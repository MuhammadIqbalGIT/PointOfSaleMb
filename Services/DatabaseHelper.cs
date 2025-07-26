using System.Data.SqlClient;


namespace App1.Services
{
    public class DatabaseHelper
    {
        public static readonly string connectionString = "Server=LAPTOP-ER40B9S8;Database=PointOfSalesDatabase;User Id=sa;Password=Passw0rd;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static string GetConnectionString()
        {
            return connectionString;
        }
    }
}


