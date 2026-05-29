using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Models.enums;

namespace ActiveSpace.Models
{
    public class Court
    {
        public string CourtRef { get; set; } = string.Empty;
        public string CourtName { get; set; } = string.Empty;
        public string SportType { get; set; } = string.Empty;
        public double PricePerHour { get; set; } = 0.0;

        // Backwards compatibility properties
        public string CourtID
        {
            get => CourtRef;
            set => CourtRef = value;
        }

        public string Category
        {
            get => SportType;
            set => SportType = value;
        }


        public TimeSpan OpenTime { get; set; } = new TimeSpan(8, 0, 0); // Default open time
        public TimeSpan CloseTime { get; set; } = new TimeSpan(0, 0, 0); // Default close time (midnight)

        public CourtType Type => new CourtType { TypeName = SportType };

        public bool IsCurrentlyOpen()
        {
            TimeSpan now = DateTime.Now.TimeOfDay;
            if (OpenTime <= CloseTime)
            {
                return now >= OpenTime && now <= CloseTime;
            }
            else
            {
                // Midnight crossing (e.g. 08:00 to 02:00 next day)
                return now >= OpenTime || now <= CloseTime;
            }
        }



        public static List<Court> GetAll()
        {
            var list = new List<Court>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT court_ref, court_name, sport_type, ISNULL(price_per_hour, 0.0), open_time, close_time FROM COURTS";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Court
                        {
                            CourtRef = reader.GetString(0),
                            CourtName = reader.GetString(1),
                            SportType = reader.GetString(2),
                            PricePerHour = reader.IsDBNull(3) ? 0.0 : Convert.ToDouble(reader.GetValue(3)),
                            OpenTime = reader.IsDBNull(4) ? new TimeSpan(8, 0, 0) : reader.GetTimeSpan(4),
                            CloseTime = reader.IsDBNull(5) ? new TimeSpan(0, 0, 0) : reader.GetTimeSpan(5)
                        });
                    }
                }
            }
            return list;
        }
        public static Court? GetByName(string name) => GetByRef(name);

        public static Court? GetByRef(string courtRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT court_ref, court_name, sport_type, ISNULL(price_per_hour, 0.0), open_time, close_time FROM COURTS WHERE court_ref = @ref OR court_name = @ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", courtRef);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Court
                            {
                                CourtRef = reader.GetString(0),
                                CourtName = reader.GetString(1),
                                SportType = reader.GetString(2),
                                PricePerHour = reader.IsDBNull(3) ? 0.0 : Convert.ToDouble(reader.GetValue(3)),
                                OpenTime = reader.IsDBNull(4) ? new TimeSpan(8, 0, 0) : reader.GetTimeSpan(4),
                                CloseTime = reader.IsDBNull(5) ? new TimeSpan(0, 0, 0) : reader.GetTimeSpan(5)
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
                string checkQuery = "SELECT COUNT(*) FROM COURTS WHERE court_ref = @ref OR court_name = @name";
                bool exists = false;
                using (var checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@ref", this.CourtRef ?? "");
                    checkCmd.Parameters.AddWithValue("@name", this.CourtName);
                    exists = (int)checkCmd.ExecuteScalar() > 0;
                }

                if (exists)
                {
                    string updateQuery = @"
                        UPDATE COURTS 
                        SET sport_type = @sport_type, court_name = @name, price_per_hour = @price, open_time = @open_time, close_time = @close_time
                        WHERE court_ref = @ref OR court_name = @name";
                    using (var cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", this.CourtRef ?? "");
                        cmd.Parameters.AddWithValue("@name", this.CourtName);
                        cmd.Parameters.AddWithValue("@sport_type", this.SportType);
                        cmd.Parameters.AddWithValue("@price", this.PricePerHour);
                        cmd.Parameters.AddWithValue("@open_time", this.OpenTime);
                        cmd.Parameters.AddWithValue("@close_time", this.CloseTime);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string insertQuery = @"
                        INSERT INTO COURTS (court_ref, court_name, sport_type, price_per_hour, open_time, close_time) 
                        VALUES (@ref, @name, @sport_type, @price, @open_time, @close_time)";
                    using (var cmd = new SqlCommand(insertQuery, conn))
                    {
                        if (string.IsNullOrEmpty(this.CourtRef))
                        {
                            // A trigger generates the ref if we leave it blank, but we need to insert it
                            insertQuery = "INSERT INTO COURTS (court_name, sport_type, price_per_hour, open_time, close_time) VALUES (@name, @sport_type, @price, @open_time, @close_time)";
                            cmd.CommandText = insertQuery;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ref", this.CourtRef);
                        }
                        cmd.Parameters.AddWithValue("@name", this.CourtName);
                        cmd.Parameters.AddWithValue("@sport_type", this.SportType);
                        cmd.Parameters.AddWithValue("@price", this.PricePerHour);
                        cmd.Parameters.AddWithValue("@open_time", this.OpenTime);
                        cmd.Parameters.AddWithValue("@close_time", this.CloseTime);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void Delete(string name)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // 1. Delete payments linked to bookings of this court
                string deleteBookingPayments = "DELETE FROM PAYMENTS WHERE booking_ref IN (SELECT booking_ref FROM BOOKINGS WHERE court_ref IN (SELECT court_ref FROM COURTS WHERE court_name = @name))";
                using (var cmd = new SqlCommand(deleteBookingPayments, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }

                // 2. Delete payments linked to contracts of this court
                string deleteContractPayments = "DELETE FROM PAYMENTS WHERE contract_ref IN (SELECT contract_ref FROM MONTHLY_CONTRACTS WHERE court_ref IN (SELECT court_ref FROM COURTS WHERE court_name = @name))";
                using (var cmd = new SqlCommand(deleteContractPayments, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }

                // 3. Delete bookings of this court
                string deleteBookings = "DELETE FROM BOOKINGS WHERE court_ref IN (SELECT court_ref FROM COURTS WHERE court_name = @name)";
                using (var cmd = new SqlCommand(deleteBookings, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }

                // 4. Delete contracts of this court
                string deleteContracts = "DELETE FROM MONTHLY_CONTRACTS WHERE court_ref IN (SELECT court_ref FROM COURTS WHERE court_name = @name)";
                using (var cmd = new SqlCommand(deleteContracts, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }

                // 5. Delete purchase-court links
                string deletePurchaseCourts = "DELETE FROM PURCHASE_COURTS WHERE court_ref IN (SELECT court_ref FROM COURTS WHERE court_name = @name)";
                using (var cmd = new SqlCommand(deletePurchaseCourts, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }

                // 6. Delete the court itself
                string query = "DELETE FROM COURTS WHERE court_name = @name";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}