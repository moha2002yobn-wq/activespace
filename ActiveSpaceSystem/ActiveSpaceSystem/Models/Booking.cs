using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Models.enums;

namespace ActiveSpace.Models
{
    public class BookingInventoryItem
    {
        public string ItemRef { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string UsageType { get; set; } = "Sale"; // "Rent" or "Sale"
    }

    public class Booking
    {
        public List<BookingInventoryItem> InventoryItems { get; set; } = new List<BookingInventoryItem>();

        public string BookingRef { get; set; } = string.Empty;
        public string CustomerPhoneNumber { get; set; } = string.Empty;
        public string CourtRef { get; set; } = string.Empty;
        public string CourtName { get; set; } = string.Empty; // Added for UI compatibility
        public string? ContractRef { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Today;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public double Price { get; set; }
        public string StatusString { get; set; } = "مؤكد";

        // Backwards compatibility properties
        public string BookingID
        {
            get => BookingRef;
            set => BookingRef = value;
        }

        public string CustomerID
        {
            get => CustomerPhoneNumber;
            set => CustomerPhoneNumber = value;
        }

        public string CourtID
        {
            get => CourtRef;
            set => CourtRef = value;
        }

        public int UserID { get; set; } // Dummy property

        public string? ContractID
        {
            get => ContractRef;
            set => ContractRef = value;
        }

        public double TotalAmount
        {
            get => Price;
            set => Price = value;
        }

        public BookingStatus Status
        {
            get
            {
                if (StatusString == "مكتمل") return BookingStatus.Completed;
                if (StatusString == "ملغى") return BookingStatus.NoShow;
                return BookingStatus.Confirmed;
            }
            set
            {
                if (value == BookingStatus.Completed) StatusString = "مكتمل";
                else if (value == BookingStatus.NoShow) StatusString = "ملغى";
                else StatusString = "مؤكد";
            }
        }

        public Customer Customer
        {
            get => Customer.GetByPhone(CustomerPhoneNumber) ?? new Customer { FullName = "غير معروف" };
            set => CustomerPhoneNumber = value?.PhoneNumber ?? string.Empty;
        }

        public Court? Court
        {
            get => Court.GetByRef(CourtRef) ?? Court.GetByRef(CourtName);
            set { 
                CourtRef = value?.CourtRef ?? string.Empty;
                CourtName = value?.CourtName ?? string.Empty;
            }
        }

        public Employee? User => null; // Dummy

        // Deposit is the total amount paid so far for this booking
        private double _tempDeposit = 0;
        public double Deposit
        {
            get
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ISNULL(SUM(amount), 0) FROM PAYMENTS WHERE booking_ref = @ref";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", this.BookingRef);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToDouble(result) : 0.0;
                    }
                }
            }
            set
            {
                _tempDeposit = value;
            }
        }

        public double DurationHours => (EndTime - StartTime).TotalHours;

        public void LoadInventoryItems()
        {
            this.InventoryItems.Clear();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT bi.item_ref, ISNULL(pr.product_name, ''), bi.quantity, bi.price, bi.usage_type
                    FROM BOOKING_INVENTORY bi
                    JOIN INVENTORY i ON bi.item_ref = i.item_ref
                    LEFT JOIN PRODUCTS pr ON i.item_ref = pr.product_ref
                    WHERE bi.booking_ref = @booking_ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@booking_ref", this.BookingRef);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.InventoryItems.Add(new BookingInventoryItem
                            {
                                ItemRef = reader.GetString(0),
                                ItemName = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                                Price = reader.GetDecimal(3),
                                UsageType = reader.GetString(4)
                            });
                        }
                    }
                }
            }
        }

        public static int GetAvailableQuantity(string itemRef, DateTime date, TimeSpan startTime, TimeSpan endTime, string usageType, string excludeBookingRef = "")
        {
            int currentQty = 0;
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string qtyQuery = "SELECT current_quantity FROM INVENTORY WHERE item_ref = @item_ref";
                using (var cmd = new SqlCommand(qtyQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@item_ref", itemRef);
                    object res = cmd.ExecuteScalar();
                    if (res != null) currentQty = Convert.ToInt32(res);
                }

                if (usageType == "Rent")
                {
                    string rentQuery = @"
                        SELECT ISNULL(SUM(bi.quantity), 0)
                        FROM BOOKING_INVENTORY bi
                        JOIN BOOKINGS b ON bi.booking_ref = b.booking_ref
                        WHERE bi.item_ref = @item_ref 
                          AND bi.usage_type = 'Rent'
                          AND b.booking_date = @date
                          AND b.status <> 'ملغى'
                          AND b.start_time < @end_time 
                          AND b.end_time > @start_time" + 
                          (!string.IsNullOrEmpty(excludeBookingRef) ? " AND b.booking_ref <> @exclude_ref" : "");
                    using (var cmd = new SqlCommand(rentQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@item_ref", itemRef);
                        cmd.Parameters.AddWithValue("@date", date.Date);
                        cmd.Parameters.AddWithValue("@start_time", startTime);
                        cmd.Parameters.AddWithValue("@end_time", endTime);
                        if (!string.IsNullOrEmpty(excludeBookingRef))
                        {
                            cmd.Parameters.AddWithValue("@exclude_ref", excludeBookingRef);
                        }
                        currentQty -= Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                else
                {
                    string saleQuery = @"
                        SELECT ISNULL(SUM(bi.quantity), 0)
                        FROM BOOKING_INVENTORY bi
                        JOIN BOOKINGS b ON bi.booking_ref = b.booking_ref
                        WHERE bi.item_ref = @item_ref 
                          AND bi.usage_type = 'Sale'
                          AND b.status <> 'ملغى'" + 
                          (!string.IsNullOrEmpty(excludeBookingRef) ? " AND b.booking_ref <> @exclude_ref" : "");
                    using (var cmd = new SqlCommand(saleQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@item_ref", itemRef);
                        if (!string.IsNullOrEmpty(excludeBookingRef))
                        {
                            cmd.Parameters.AddWithValue("@exclude_ref", excludeBookingRef);
                        }
                        currentQty -= Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            return currentQty >= 0 ? currentQty : 0;
        }

        public static List<Booking> GetAll()
        {
            var list = new List<Booking>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT b.booking_ref, b.customer_phone_number, b.court_ref, b.contract_ref, b.booking_date, b.start_time, b.end_time, b.price, b.status, ISNULL(c.court_name, '') 
                                 FROM BOOKINGS b LEFT JOIN COURTS c ON b.court_ref = c.court_ref";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Booking
                        {
                            BookingRef = reader.GetString(0),
                            CustomerPhoneNumber = reader.GetString(1),
                            CourtRef = reader.GetString(2),
                            ContractRef = reader.IsDBNull(3) ? null : reader.GetString(3),
                            BookingDate = reader.GetDateTime(4),
                            StartTime = reader.GetTimeSpan(5),
                            EndTime = reader.GetTimeSpan(6),
                            Price = reader.IsDBNull(7) ? 0.0 : (double)reader.GetDecimal(7),
                            StatusString = reader.GetString(8),
                            CourtName = reader.GetString(9)
                        });
                    }
                }
            }
            foreach (var booking in list)
            {
                booking.LoadInventoryItems();
            }
            return list;
        }

        public static Booking? GetByRef(string bookingRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT b.booking_ref, b.customer_phone_number, b.court_ref, b.contract_ref, b.booking_date, b.start_time, b.end_time, b.price, b.status, ISNULL(c.court_name, '') 
                                 FROM BOOKINGS b LEFT JOIN COURTS c ON b.court_ref = c.court_ref 
                                 WHERE b.booking_ref = @ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", bookingRef);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var booking = new Booking
                            {
                                BookingRef = reader.GetString(0),
                                CustomerPhoneNumber = reader.GetString(1),
                                CourtRef = reader.GetString(2),
                                ContractRef = reader.IsDBNull(3) ? null : reader.GetString(3),
                                BookingDate = reader.GetDateTime(4),
                                StartTime = reader.GetTimeSpan(5),
                                EndTime = reader.GetTimeSpan(6),
                                Price = reader.IsDBNull(7) ? 0.0 : (double)reader.GetDecimal(7),
                                StatusString = reader.GetString(8),
                                CourtName = reader.GetString(9)
                            };
                            reader.Close();
                            booking.LoadInventoryItems();
                            return booking;
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
                string checkQuery = "SELECT COUNT(*) FROM BOOKINGS WHERE booking_ref = @ref";
                bool exists = false;
                using (var checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@ref", this.BookingRef);
                    exists = (int)checkCmd.ExecuteScalar() > 0;
                }

                if (exists)
                {
                    string updateQuery = @"
                        UPDATE BOOKINGS 
                        SET customer_phone_number = @cust_phone, court_ref = @court_ref, 
                            contract_ref = @contract_ref, booking_date = @date, 
                            start_time = @start_time, end_time = @end_time, 
                            price = @price, status = @status 
                        WHERE booking_ref = @ref";
                    using (var cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", this.BookingRef);
                        cmd.Parameters.AddWithValue("@cust_phone", this.CustomerPhoneNumber);
                        cmd.Parameters.AddWithValue("@court_ref", this.CourtRef);
                        cmd.Parameters.AddWithValue("@contract_ref", (object)this.ContractRef ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@date", this.BookingDate);
                        cmd.Parameters.AddWithValue("@start_time", this.StartTime);
                        cmd.Parameters.AddWithValue("@end_time", this.EndTime);
                        cmd.Parameters.AddWithValue("@price", this.Price);
                        cmd.Parameters.AddWithValue("@status", this.StatusString);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Let trigger generate booking_ref if it's empty, or generate one
                    if (string.IsNullOrEmpty(this.BookingRef))
                    {
                        string dateStr = this.BookingDate.ToString("yyyyMMdd");
                        var existingRefs = new HashSet<int>();
                        string selectQuery = "SELECT CAST(RIGHT(booking_ref, 3) AS INT) FROM BOOKINGS WHERE booking_ref LIKE 'BKG-' + @date + '-%'";
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
                        this.BookingRef = $"BKG-{dateStr}-{nextSeq.ToString("D3")}";
                    }

                    string insertQuery = @"
                        INSERT INTO BOOKINGS (booking_ref, customer_phone_number, court_ref, contract_ref, booking_date, start_time, end_time, price, status) 
                        VALUES (@ref, @cust_phone, @court_ref, @contract_ref, @date, @start_time, @end_time, @price, @status)";
                    using (var cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", this.BookingRef);
                        cmd.Parameters.AddWithValue("@cust_phone", this.CustomerPhoneNumber);
                        cmd.Parameters.AddWithValue("@court_ref", this.CourtRef);
                        cmd.Parameters.AddWithValue("@contract_ref", (object)this.ContractRef ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@date", this.BookingDate);
                        cmd.Parameters.AddWithValue("@start_time", this.StartTime);
                        cmd.Parameters.AddWithValue("@end_time", this.EndTime);
                        cmd.Parameters.AddWithValue("@price", this.Price);
                        cmd.Parameters.AddWithValue("@status", this.StatusString);
                        cmd.ExecuteNonQuery();
                    }

                    // If a temp deposit was set, create a Payment record for it!
                    if (_tempDeposit > 0)
                    {
                        string payQuery = @"
                            INSERT INTO PAYMENTS (payment_ref, customer_phone_number, payment_date, payment_time, booking_ref, contract_ref, amount)
                            VALUES (@pay_ref, @cust_phone, @date, @time, @booking_ref, NULL, @amount)";
                        using (var cmd = new SqlCommand(payQuery, conn))
                        {
                            string payDateStr = DateTime.Today.ToString("yyyyMMdd");
                            var existingRefs = new HashSet<int>();
                            string selectQuery = "SELECT CAST(RIGHT(payment_ref, 3) AS INT) FROM PAYMENTS WHERE payment_ref LIKE 'PAY-' + @date + '-%'";
                            using (var selectCmd = new SqlCommand(selectQuery, conn))
                            {
                                selectCmd.Parameters.AddWithValue("@date", payDateStr);
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
                            string payRef = $"PAY-{payDateStr}-{nextSeq.ToString("D3")}";

                            cmd.Parameters.AddWithValue("@pay_ref", payRef);
                            cmd.Parameters.AddWithValue("@cust_phone", this.CustomerPhoneNumber);
                            cmd.Parameters.AddWithValue("@date", DateTime.Today);
                            cmd.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay);
                            cmd.Parameters.AddWithValue("@booking_ref", this.BookingRef);
                            cmd.Parameters.AddWithValue("@amount", (decimal)_tempDeposit);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                if (exists)
                {
                    string oldSalesQuery = @"
                        SELECT item_ref, quantity 
                        FROM BOOKING_INVENTORY 
                        WHERE booking_ref = @ref AND usage_type = 'Sale'";
                    var oldSales = new List<Tuple<string, int>>();
                    using (var cmd = new SqlCommand(oldSalesQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", this.BookingRef);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oldSales.Add(new Tuple<string, int>(reader.GetString(0), reader.GetInt32(1)));
                            }
                        }
                    }

                    foreach (var sale in oldSales)
                    {
                        string restoreStock = "UPDATE INVENTORY SET current_quantity = current_quantity + @qty WHERE item_ref = @item_ref";
                        using (var cmd = new SqlCommand(restoreStock, conn))
                        {
                            cmd.Parameters.AddWithValue("@qty", sale.Item2);
                            cmd.Parameters.AddWithValue("@item_ref", sale.Item1);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                string deleteInvQuery = "DELETE FROM BOOKING_INVENTORY WHERE booking_ref = @ref";
                using (var cmd = new SqlCommand(deleteInvQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", this.BookingRef);
                    cmd.ExecuteNonQuery();
                }

                foreach (var item in this.InventoryItems)
                {
                    string insertInvQuery = @"
                        INSERT INTO BOOKING_INVENTORY (booking_ref, item_ref, quantity, price, usage_type)
                        VALUES (@ref, @item, @qty, @price, @usage)";
                    using (var cmd = new SqlCommand(insertInvQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", this.BookingRef);
                        cmd.Parameters.AddWithValue("@item", item.ItemRef);
                        cmd.Parameters.AddWithValue("@qty", item.Quantity);
                        cmd.Parameters.AddWithValue("@price", item.Price);
                        cmd.Parameters.AddWithValue("@usage", item.UsageType);
                        cmd.ExecuteNonQuery();
                    }

                    if (item.UsageType == "Sale")
                    {
                        string updateStockQuery = "UPDATE INVENTORY SET current_quantity = current_quantity - @qty WHERE item_ref = @item_ref";
                        using (var cmd = new SqlCommand(updateStockQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@qty", item.Quantity);
                            cmd.Parameters.AddWithValue("@item_ref", item.ItemRef);
                            cmd.ExecuteNonQuery();
                        }

                        string movRef = $"MOV-BKG-{this.BookingRef}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}";
                        string insMovement = @"
                            INSERT INTO INVENTORY_MOVEMENTS (movement_ref, item_ref, movement_date, movement_time, movement_type, quantity)
                            VALUES (@mov_ref, @item_ref, @date, @time, 'out', @qty)";
                        using (var cmd = new SqlCommand(insMovement, conn))
                        {
                            cmd.Parameters.AddWithValue("@mov_ref", movRef);
                            cmd.Parameters.AddWithValue("@item_ref", item.ItemRef);
                            cmd.Parameters.AddWithValue("@date", this.BookingDate);
                            cmd.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay);
                            cmd.Parameters.AddWithValue("@qty", item.Quantity);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static void Delete(string bookingRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                string oldSalesQuery = @"
                    SELECT item_ref, quantity 
                    FROM BOOKING_INVENTORY 
                    WHERE booking_ref = @ref AND usage_type = 'Sale'";
                var oldSales = new List<Tuple<string, int>>();
                using (var cmd = new SqlCommand(oldSalesQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", bookingRef);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            oldSales.Add(new Tuple<string, int>(reader.GetString(0), reader.GetInt32(1)));
                        }
                    }
                }

                foreach (var sale in oldSales)
                {
                    string restoreStock = "UPDATE INVENTORY SET current_quantity = current_quantity + @qty WHERE item_ref = @item_ref";
                    using (var cmd = new SqlCommand(restoreStock, conn))
                    {
                        cmd.Parameters.AddWithValue("@qty", sale.Item2);
                        cmd.Parameters.AddWithValue("@item_ref", sale.Item1);
                        cmd.ExecuteNonQuery();
                    }
                }

                string deletePayments = "DELETE FROM PAYMENTS WHERE booking_ref = @ref";
                using (var cmd = new SqlCommand(deletePayments, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", bookingRef);
                    cmd.ExecuteNonQuery();
                }

                string deleteBooking = "DELETE FROM BOOKINGS WHERE booking_ref = @ref";
                using (var cmd = new SqlCommand(deleteBooking, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", bookingRef);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}