using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ActiveSpaceSystem.Data;

namespace ActiveSpace.Models
{
    public class Customer
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;

        // Backwards compatibility properties
        public string CustomerID
        {
            get => PhoneNumber;
            set => PhoneNumber = value;
        }

        public string Phone
        {
            get => PhoneNumber;
            set => PhoneNumber = value;
        }

        public double TotalDebt
        {
            get
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT (
                            (SELECT ISNULL(SUM(price), 0) FROM BOOKINGS WHERE customer_phone_number = @phone AND status != N'ملغى') +
                            (SELECT ISNULL(SUM(monthly_value), 0) FROM MONTHLY_CONTRACTS WHERE customer_phone_number = @phone) -
                            (SELECT ISNULL(SUM(amount), 0) FROM PAYMENTS WHERE customer_phone_number = @phone)
                        )";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", this.PhoneNumber);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToDouble(result) : 0.0;
                    }
                }
            }
        }

        public static List<Customer> GetAll()
        {
            var list = new List<Customer>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT phone_number, full_name FROM CUSTOMERS";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Customer
                        {
                            PhoneNumber = reader.GetString(0),
                            FullName = reader.GetString(1)
                        });
                    }
                }
            }
            return list;
        }

        public static Customer? GetByPhone(string phone)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT phone_number, full_name FROM CUSTOMERS WHERE phone_number = @phone";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                PhoneNumber = reader.GetString(0),
                                FullName = reader.GetString(1)
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
                // Check if exists
                string checkQuery = "SELECT COUNT(*) FROM CUSTOMERS WHERE phone_number = @phone";
                bool exists = false;
                using (var checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@phone", this.PhoneNumber);
                    exists = (int)checkCmd.ExecuteScalar() > 0;
                }

                if (exists)
                {
                    string updateQuery = "UPDATE CUSTOMERS SET full_name = @full_name WHERE phone_number = @phone";
                    using (var cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", this.PhoneNumber);
                        cmd.Parameters.AddWithValue("@full_name", this.FullName);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string insertQuery = "INSERT INTO CUSTOMERS (phone_number, full_name) VALUES (@phone, @full_name)";
                    using (var cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", this.PhoneNumber);
                        cmd.Parameters.AddWithValue("@full_name", this.FullName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void Delete(string phone)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // 1. Delete payments related to bookings or contracts of this customer
                string delPayments = "DELETE FROM PAYMENTS WHERE customer_phone_number = @phone";
                using (var cmd = new SqlCommand(delPayments, conn))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.ExecuteNonQuery();
                }

                // 2. Delete bookings of this customer
                string delBookings = "DELETE FROM BOOKINGS WHERE customer_phone_number = @phone";
                using (var cmd = new SqlCommand(delBookings, conn))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.ExecuteNonQuery();
                }

                // 3. Delete contracts of this customer
                string delContracts = "DELETE FROM MONTHLY_CONTRACTS WHERE customer_phone_number = @phone";
                using (var cmd = new SqlCommand(delContracts, conn))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.ExecuteNonQuery();
                }

                // 4. Finally delete the customer
                string delCust = "DELETE FROM CUSTOMERS WHERE phone_number = @phone";
                using (var cmd = new SqlCommand(delCust, conn))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}