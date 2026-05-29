using System;
using System.IO;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        try
        {
            using (var conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=ActiveSpaceDB;Trusted_Connection=True;"))
            {
                conn.Open();
                
                using (var cmd = new SqlCommand("SELECT employee_id, full_name, position, salary FROM EMPLOYEES", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    File.WriteAllText("employees.txt", "Employees in DB:\n");
                    while (reader.Read())
                    {
                        File.AppendAllText("employees.txt", reader.GetString(0) + " | " + reader.GetString(1) + " | " + reader.GetString(2) + " | " + reader.GetDecimal(3) + "\n");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            File.WriteAllText("error.txt", ex.ToString());
        }
    }
}
