using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ActiveSpaceSystem.Data;

namespace ActiveSpace.Models
{
    public class Payment
    {
        public string PaymentRef { get; set; } = string.Empty;
        public string CustomerPhoneNumber { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; } = DateTime.Today;
        public TimeSpan PaymentTime { get; set; } = DateTime.Now.TimeOfDay;
        public string? BookingRef { get; set; }
        public string? ContractRef { get; set; }
        public double Amount { get; set; }

        // Backwards compatibility properties
        public string PaymentID
        {
            get => PaymentRef;
            set => PaymentRef = value;
        }

        public string BookingID
        {
            get => BookingRef ?? string.Empty;
            set => BookingRef = string.IsNullOrEmpty(value) ? null : value;
        }

        public double AmountPaid
        {
            get => Amount;
            set => Amount = value;
        }

        public DateTime PaidAt
        {
            get => PaymentDate.Date + PaymentTime;
            set
            {
                PaymentDate = value.Date;
                PaymentTime = value.TimeOfDay;
            }
        }

        public Booking? Booking
        {
            get => string.IsNullOrEmpty(BookingRef) ? null : Booking.GetByRef(BookingRef);
            set
            {
                if (value != null)
                {
                    BookingRef = value.BookingRef;
                    CustomerPhoneNumber = value.CustomerPhoneNumber;
                }
            }
        }

        public static List<Payment> GetAll()
        {
            var list = new List<Payment>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT payment_ref, customer_phone_number, payment_date, payment_time, booking_ref, contract_ref, amount FROM PAYMENTS";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Payment
                        {
                            PaymentRef = reader.GetString(0),
                            CustomerPhoneNumber = reader.GetString(1),
                            PaymentDate = reader.GetDateTime(2),
                            PaymentTime = reader.GetTimeSpan(3),
                            BookingRef = reader.IsDBNull(4) ? null : reader.GetString(4),
                            ContractRef = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Amount = reader.IsDBNull(6) ? 0.0 : (double)reader.GetDecimal(6)
                        });
                    }
                }
            }
            return list;
        }

        public static Payment? GetByRef(string paymentRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT payment_ref, customer_phone_number, payment_date, payment_time, booking_ref, contract_ref, amount FROM PAYMENTS WHERE payment_ref = @ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", paymentRef);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Payment
                            {
                                PaymentRef = reader.GetString(0),
                                CustomerPhoneNumber = reader.GetString(1),
                                PaymentDate = reader.GetDateTime(2),
                                PaymentTime = reader.GetTimeSpan(3),
                                BookingRef = reader.IsDBNull(4) ? null : reader.GetString(4),
                                ContractRef = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Amount = reader.IsDBNull(6) ? 0.0 : (double)reader.GetDecimal(6)
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
                string checkQuery = "SELECT COUNT(*) FROM PAYMENTS WHERE payment_ref = @ref";
                bool exists = false;
                using (var checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@ref", this.PaymentRef);
                    exists = (int)checkCmd.ExecuteScalar() > 0;
                }

                // If CustomerPhoneNumber is empty, try to resolve it from the linked Booking or Contract
                if (string.IsNullOrEmpty(this.CustomerPhoneNumber))
                {
                    if (!string.IsNullOrEmpty(this.BookingRef))
                    {
                        var b = Booking.GetByRef(this.BookingRef);
                        if (b != null) this.CustomerPhoneNumber = b.CustomerPhoneNumber;
                    }
                    else if (!string.IsNullOrEmpty(this.ContractRef))
                    {
                        var c = MonthlyContract.GetByRef(this.ContractRef);
                        if (c != null) this.CustomerPhoneNumber = c.CustomerPhoneNumber;
                    }
                }

                if (exists)
                {
                    string updateQuery = @"
                        UPDATE PAYMENTS 
                        SET customer_phone_number = @cust_phone, payment_date = @date, 
                            payment_time = @time, booking_ref = @booking_ref, 
                            contract_ref = @contract_ref, amount = @amount 
                        WHERE payment_ref = @ref";
                    using (var cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", this.PaymentRef);
                        cmd.Parameters.AddWithValue("@cust_phone", this.CustomerPhoneNumber);
                        cmd.Parameters.AddWithValue("@date", this.PaymentDate);
                        cmd.Parameters.AddWithValue("@time", this.PaymentTime);
                        cmd.Parameters.AddWithValue("@booking_ref", (object)this.BookingRef ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@contract_ref", (object)this.ContractRef ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@amount", this.Amount);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Generate payment_ref using gap-filling algorithm
                    if (string.IsNullOrEmpty(this.PaymentRef))
                    {
                        string dateStr = this.PaymentDate.ToString("yyyyMMdd");
                        var existingRefs = new HashSet<int>();
                        string selectQuery = "SELECT CAST(RIGHT(payment_ref, 3) AS INT) FROM PAYMENTS WHERE payment_ref LIKE 'PAY-' + @date + '-%'";
                        using (var selectCmd = new SqlCommand(selectQuery, conn))
                        {
                            selectCmd.Parameters.AddWithValue("@date", dateStr);
                            using (var reader = selectCmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (!reader.IsDBNull(0)) existingRefs.Add(reader.GetInt32(0));
                                }
                            }
                        }
                        int nextSeq = 1;
                        while (existingRefs.Contains(nextSeq)) nextSeq++;
                        this.PaymentRef = $"PAY-{dateStr}-{nextSeq.ToString("D3")}";
                    }

                    string insertQuery = @"
                        INSERT INTO PAYMENTS (payment_ref, customer_phone_number, payment_date, payment_time, booking_ref, contract_ref, amount) 
                        VALUES (@ref, @cust_phone, @date, @time, @booking_ref, @contract_ref, @amount)";
                    using (var cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", this.PaymentRef);
                        cmd.Parameters.AddWithValue("@cust_phone", this.CustomerPhoneNumber);
                        cmd.Parameters.AddWithValue("@date", this.PaymentDate);
                        cmd.Parameters.AddWithValue("@time", this.PaymentTime);
                        cmd.Parameters.AddWithValue("@booking_ref", (object)this.BookingRef ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@contract_ref", (object)this.ContractRef ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@amount", this.Amount);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static double CalculateRemaining(string bookingRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT ISNULL((SELECT price FROM BOOKINGS WHERE booking_ref = @ref), 0) - 
                           ISNULL((SELECT SUM(amount) FROM PAYMENTS WHERE booking_ref = @ref), 0)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", bookingRef);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDouble(result) : 0.0;
                }
            }
        }

        public static double CalculateRemainingForContract(string contractRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT ISNULL((SELECT monthly_value FROM MONTHLY_CONTRACTS WHERE contract_ref = @ref), 0) - 
                           ISNULL((SELECT SUM(amount) FROM PAYMENTS WHERE contract_ref = @ref), 0)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", contractRef);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDouble(result) : 0.0;
                }
            }
        }

        public static void Delete(string paymentRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM PAYMENTS WHERE payment_ref = @ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", paymentRef);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}