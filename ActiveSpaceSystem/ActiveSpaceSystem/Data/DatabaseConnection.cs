using System.Data.SqlClient;

namespace ActiveSpaceSystem.Data
{
    public static class DatabaseConnection
    {
        // Connection string based on user configuration
        private static readonly string connectionString = "Data Source=MOHAMEDYOUSEF;Initial Catalog=ActiveSpaceDB;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;";

        public static SqlConnection GetConnection()
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                // Optionally, handle opening the connection here, but usually it's better 
                // for the caller to open and close it in a using block to manage pooling properly.
                return connection;
            }
            catch (SqlException ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"SQL Exception: {ex.Message}");
                throw; // Re-throw the exception after logging
            }
        }
    }
}
