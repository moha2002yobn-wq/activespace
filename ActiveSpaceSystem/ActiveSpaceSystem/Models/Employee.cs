using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Models.enums;

namespace ActiveSpace.Models
{
    public class Employee
    {
        public string EmployeeID { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public double Salary { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;
        public bool HasSystemAccess { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? SystemRole { get; set; }

        public UserRole Role
        {
            get => SystemRole == "Admin" ? UserRole.Admin : UserRole.Staff;
            set => SystemRole = value == UserRole.Admin ? "Admin" : "Staff";
        }

        public string UsernameOrEmpty => Username ?? string.Empty;

        public static List<Employee> GetAll()
        {
            var list = new List<Employee>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT employee_id, full_name, phone_number, position, salary, hire_date, has_system_access, username, password_hash, system_role FROM EMPLOYEES";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee
                        {
                            EmployeeID = reader.GetString(0),
                            FullName = reader.GetString(1),
                            PhoneNumber = reader.GetString(2),
                            Position = reader.GetString(3),
                            Salary = reader.IsDBNull(4) ? 0.0 : (double)reader.GetDecimal(4),
                            HireDate = reader.GetDateTime(5),
                            HasSystemAccess = reader.GetBoolean(6),
                            Username = reader.IsDBNull(7) ? null : reader.GetString(7),
                            PasswordHash = reader.IsDBNull(8) ? null : reader.GetString(8),
                            SystemRole = reader.IsDBNull(9) ? null : reader.GetString(9)
                        });
                    }
                }
            }
            return list;
        }

        public static Employee? GetById(string id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT employee_id, full_name, phone_number, position, salary, hire_date, has_system_access, username, password_hash, system_role FROM EMPLOYEES WHERE employee_id = @id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Employee
                            {
                                EmployeeID = reader.GetString(0),
                                FullName = reader.GetString(1),
                                PhoneNumber = reader.GetString(2),
                                Position = reader.GetString(3),
                                Salary = reader.IsDBNull(4) ? 0.0 : (double)reader.GetDecimal(4),
                                HireDate = reader.GetDateTime(5),
                                HasSystemAccess = reader.GetBoolean(6),
                                Username = reader.IsDBNull(7) ? null : reader.GetString(7),
                                PasswordHash = reader.IsDBNull(8) ? null : reader.GetString(8),
                                SystemRole = reader.IsDBNull(9) ? null : reader.GetString(9)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static Employee? Login(string username, string password)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT employee_id, full_name, phone_number, position, salary, hire_date, has_system_access, username, password_hash, system_role 
                    FROM EMPLOYEES 
                    WHERE username = @username 
                      AND password_hash = CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', CAST(@password AS VARCHAR(100))), 2)
                      AND has_system_access = 1";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Employee
                            {
                                EmployeeID = reader.GetString(0),
                                FullName = reader.GetString(1),
                                PhoneNumber = reader.GetString(2),
                                Position = reader.GetString(3),
                                Salary = reader.IsDBNull(4) ? 0.0 : (double)reader.GetDecimal(4),
                                HireDate = reader.GetDateTime(5),
                                HasSystemAccess = reader.GetBoolean(6),
                                Username = reader.IsDBNull(7) ? null : reader.GetString(7),
                                PasswordHash = reader.IsDBNull(8) ? null : reader.GetString(8),
                                SystemRole = reader.IsDBNull(9) ? null : reader.GetString(9)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void Save()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM EMPLOYEES WHERE employee_id = @id";
                bool exists = false;
                using (var checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", this.EmployeeID);
                    exists = (int)checkCmd.ExecuteScalar() > 0;
                }

                if (exists)
                {
                    string updateQuery = @"
                        UPDATE EMPLOYEES 
                        SET full_name = @full_name, phone_number = @phone_number, position = @position, 
                            salary = @salary, hire_date = @hire_date, has_system_access = @has_access, 
                            username = @username, system_role = @role
                        WHERE employee_id = @id";
                    using (var cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", this.EmployeeID);
                        cmd.Parameters.AddWithValue("@full_name", this.FullName);
                        cmd.Parameters.AddWithValue("@phone_number", this.PhoneNumber);
                        cmd.Parameters.AddWithValue("@position", this.Position);
                        cmd.Parameters.AddWithValue("@salary", this.Salary);
                        cmd.Parameters.AddWithValue("@hire_date", this.HireDate);
                        cmd.Parameters.AddWithValue("@has_access", this.HasSystemAccess);
                        cmd.Parameters.AddWithValue("@username", (object)this.Username ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@role", (object)this.SystemRole ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string insertQuery = @"
                        INSERT INTO EMPLOYEES (employee_id, full_name, phone_number, position, salary, hire_date, has_system_access, username, password_hash, system_role) 
                        VALUES (@id, @full_name, @phone_number, @position, @salary, @hire_date, @has_access, @username, CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', '1234'), 2), @role)";
                    using (var cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", this.EmployeeID);
                        cmd.Parameters.AddWithValue("@full_name", this.FullName);
                        cmd.Parameters.AddWithValue("@phone_number", this.PhoneNumber);
                        cmd.Parameters.AddWithValue("@position", this.Position);
                        cmd.Parameters.AddWithValue("@salary", this.Salary);
                        cmd.Parameters.AddWithValue("@hire_date", this.HireDate);
                        cmd.Parameters.AddWithValue("@has_access", this.HasSystemAccess);
                        cmd.Parameters.AddWithValue("@username", (object)this.Username ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@role", (object)this.SystemRole ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void UpdatePassword(string newPassword)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE EMPLOYEES SET password_hash = CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', CAST(@password AS VARCHAR(100))), 2) WHERE employee_id = @id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", this.EmployeeID);
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(string id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // 1. Delete salaries
                string delSalaries = "DELETE FROM SALARIES WHERE employee_id = @id";
                using (var cmd = new SqlCommand(delSalaries, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                // 2. Delete inventory movements
                string delMovements = "DELETE FROM INVENTORY_MOVEMENTS WHERE employee_id = @id";
                using (var cmd = new SqlCommand(delMovements, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                // 3. Delete purchase_courts for purchases by this employee
                string delPurchaseCourts = "DELETE FROM PURCHASE_COURTS WHERE purchase_ref IN (SELECT purchase_ref FROM PURCHASES WHERE employee_id = @id)";
                using (var cmd = new SqlCommand(delPurchaseCourts, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                // 4. Delete purchases
                string delPurchases = "DELETE FROM PURCHASES WHERE employee_id = @id";
                using (var cmd = new SqlCommand(delPurchases, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                // 5. Delete expenses
                string delExpenses = "DELETE FROM EXPENSES WHERE employee_id = @id";
                using (var cmd = new SqlCommand(delExpenses, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                // 6. Delete the employee
                string query = "DELETE FROM EMPLOYEES WHERE employee_id = @id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
