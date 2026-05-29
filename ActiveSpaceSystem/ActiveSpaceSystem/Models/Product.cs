using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ActiveSpaceSystem.Data;

namespace ActiveSpaceSystem.Models
{
    public class Product
    {
        public string ProductRef { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string CategoryRef { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal SellingPrice { get; set; }
        public decimal RentalRate { get; set; }
        public int UsageType { get; set; } = 1; // 1=بيع, 2=إيجار, 3=كلاهما
        public int MinQuantity { get; set; } = 5;

        // Stock info (from INVENTORY)
        public int CurrentQuantity { get; set; }

        public static List<Product> GetAll()
        {
            var list = new List<Product>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT p.product_ref, p.product_name, ISNULL(p.category_ref, ''), 
                           ISNULL(c.category_name, ''), p.selling_price, p.rental_rate, 
                           p.usage_type, p.min_quantity,
                           ISNULL(i.current_quantity, 0)
                    FROM PRODUCTS p
                    LEFT JOIN INVENTORY_CATEGORIES c ON p.category_ref = c.category_ref
                    LEFT JOIN INVENTORY i ON p.product_ref = i.item_ref";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Product
                        {
                            ProductRef = reader.GetString(0),
                            ProductName = reader.GetString(1),
                            CategoryRef = reader.GetString(2),
                            CategoryName = reader.GetString(3),
                            SellingPrice = reader.GetDecimal(4),
                            RentalRate = reader.GetDecimal(5),
                            UsageType = reader.GetInt32(6),
                            MinQuantity = reader.GetInt32(7),
                            CurrentQuantity = reader.GetInt32(8)
                        });
                    }
                }
            }
            return list;
        }

        public static Product? GetByRef(string productRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT p.product_ref, p.product_name, ISNULL(p.category_ref, ''), 
                           ISNULL(c.category_name, ''), p.selling_price, p.rental_rate, 
                           p.usage_type, p.min_quantity,
                           ISNULL(i.current_quantity, 0)
                    FROM PRODUCTS p
                    LEFT JOIN INVENTORY_CATEGORIES c ON p.category_ref = c.category_ref
                    LEFT JOIN INVENTORY i ON p.product_ref = i.item_ref
                    WHERE p.product_ref = @ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", productRef);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                ProductRef = reader.GetString(0),
                                ProductName = reader.GetString(1),
                                CategoryRef = reader.GetString(2),
                                CategoryName = reader.GetString(3),
                                SellingPrice = reader.GetDecimal(4),
                                RentalRate = reader.GetDecimal(5),
                                UsageType = reader.GetInt32(6),
                                MinQuantity = reader.GetInt32(7),
                                CurrentQuantity = reader.GetInt32(8)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static Product? GetByName(string productName)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT p.product_ref, p.product_name, ISNULL(p.category_ref, ''), 
                           ISNULL(c.category_name, ''), p.selling_price, p.rental_rate, 
                           p.usage_type, p.min_quantity,
                           ISNULL(i.current_quantity, 0)
                    FROM PRODUCTS p
                    LEFT JOIN INVENTORY_CATEGORIES c ON p.category_ref = c.category_ref
                    LEFT JOIN INVENTORY i ON p.product_ref = i.item_ref
                    WHERE p.product_name = @name";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", productName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                ProductRef = reader.GetString(0),
                                ProductName = reader.GetString(1),
                                CategoryRef = reader.GetString(2),
                                CategoryName = reader.GetString(3),
                                SellingPrice = reader.GetDecimal(4),
                                RentalRate = reader.GetDecimal(5),
                                UsageType = reader.GetInt32(6),
                                MinQuantity = reader.GetInt32(7),
                                CurrentQuantity = reader.GetInt32(8)
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Save or update product in PRODUCTS table. Also ensures INVENTORY row exists.
        /// </summary>
        public void Save()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Generate product_ref if empty
                        if (string.IsNullOrEmpty(this.ProductRef))
                        {
                            string maxQ = "SELECT ISNULL(MAX(CAST(SUBSTRING(product_ref, 5, 4) AS INT)), 0) FROM PRODUCTS WHERE product_ref LIKE 'INV-%'";
                            int nextSeq = 1;
                            using (var maxCmd = new SqlCommand(maxQ, conn, transaction))
                            {
                                nextSeq = Convert.ToInt32(maxCmd.ExecuteScalar()) + 1;
                            }
                            this.ProductRef = $"INV-{nextSeq.ToString("D4")}";
                        }

                        // Check if product exists
                        string checkQ = "SELECT COUNT(*) FROM PRODUCTS WHERE product_ref = @ref";
                        bool exists = false;
                        using (var checkCmd = new SqlCommand(checkQ, conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@ref", this.ProductRef);
                            exists = (int)checkCmd.ExecuteScalar() > 0;
                        }

                        if (exists)
                        {
                            string updateQ = @"
                                UPDATE PRODUCTS 
                                SET product_name = @name, category_ref = @cat_ref, 
                                    selling_price = @sell_price, rental_rate = @rental_rate,
                                    usage_type = @usage_type, min_quantity = @min_qty
                                WHERE product_ref = @ref";
                            using (var cmd = new SqlCommand(updateQ, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ref", this.ProductRef);
                                cmd.Parameters.AddWithValue("@name", this.ProductName);
                                cmd.Parameters.AddWithValue("@cat_ref", (object)this.CategoryRef ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@sell_price", this.SellingPrice);
                                cmd.Parameters.AddWithValue("@rental_rate", this.RentalRate);
                                cmd.Parameters.AddWithValue("@usage_type", this.UsageType);
                                cmd.Parameters.AddWithValue("@min_qty", this.MinQuantity);
                                cmd.ExecuteNonQuery();
                            }

                            // Also keep INVENTORY in sync (only if it needs current_quantity updating, but current_quantity is handled by stock movements, so no update needed here)
                        }
                        else
                        {
                            // Insert into PRODUCTS
                            string insertQ = @"
                                INSERT INTO PRODUCTS (product_ref, product_name, category_ref, selling_price, rental_rate, usage_type, min_quantity)
                                VALUES (@ref, @name, @cat_ref, @sell_price, @rental_rate, @usage_type, @min_qty)";
                            using (var cmd = new SqlCommand(insertQ, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ref", this.ProductRef);
                                cmd.Parameters.AddWithValue("@name", this.ProductName);
                                cmd.Parameters.AddWithValue("@cat_ref", (object)this.CategoryRef ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@sell_price", this.SellingPrice);
                                cmd.Parameters.AddWithValue("@rental_rate", this.RentalRate);
                                cmd.Parameters.AddWithValue("@usage_type", this.UsageType);
                                cmd.Parameters.AddWithValue("@min_qty", this.MinQuantity);
                                cmd.ExecuteNonQuery();
                            }

                            // Also ensure INVENTORY row exists
                            string checkInv = "SELECT COUNT(*) FROM INVENTORY WHERE item_ref = @ref";
                            bool invExists = false;
                            using (var checkCmd = new SqlCommand(checkInv, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@ref", this.ProductRef);
                                invExists = (int)checkCmd.ExecuteScalar() > 0;
                            }

                            if (!invExists)
                            {
                                string insertInv = @"
                                    INSERT INTO INVENTORY (item_ref, current_quantity, product_ref)
                                    VALUES (@ref, 0, @ref)";
                                using (var cmd = new SqlCommand(insertInv, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ref", this.ProductRef);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
