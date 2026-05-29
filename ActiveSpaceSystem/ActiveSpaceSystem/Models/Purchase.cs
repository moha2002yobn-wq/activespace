using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using ActiveSpace.Models;
using ActiveSpaceSystem.Data;

namespace ActiveSpaceSystem.Models
{
    public class Purchase
    {
        public string PurchaseRef { get; set; } = string.Empty;
        public string? ExpenseRef { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        public string Category { get; set; } = string.Empty;
        public string CategoryRef { get; set; } = string.Empty;
        public string ItemRef { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty; // For UI compat
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal TotalPrice { get; set; } // Read-only / Computed on DB side, but useful to have
        public string SupplierName { get; set; } = string.Empty;
        public string? EmployeeId { get; set; }
        public string? Notes { get; set; }
        public int UsageType { get; set; } = 1; // 1 = للبيع, 2 = للإيجار, 3 = كلاهما
        public decimal RentalRate { get; set; }
        public int MinQuantity { get; set; } = 5;
        public bool ManualMinQuantity { get; set; } = false;

        public static List<Purchase> GetAll()
        {
            var list = new List<Purchase>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT p.purchase_ref, p.expense_ref, p.purchase_date, c.category_name, p.item_ref, p.quantity, p.unit_price, ISNULL(pr.selling_price, 0) AS selling_price, p.total_price, p.supplier_name, p.employee_id, p.notes, ISNULL(pr.product_name, ''), ISNULL(pr.category_ref, '') AS inventory_category_ref, ISNULL(pr.usage_type, 1), ISNULL(pr.rental_rate, 0), ISNULL(pr.min_quantity, 5) 
                                 FROM PURCHASES p 
                                 LEFT JOIN INVENTORY i ON p.item_ref = i.item_ref 
                                 LEFT JOIN PRODUCTS pr ON p.item_ref = pr.product_ref
                                 LEFT JOIN INVENTORY_CATEGORIES c ON pr.category_ref = c.category_ref";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Purchase
                        {
                            PurchaseRef = reader.GetString(0),
                            ExpenseRef = reader.IsDBNull(1) ? null : reader.GetString(1),
                            PurchaseDate = reader.GetDateTime(2),
                            Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            ItemRef = reader.GetString(4),
                            Quantity = reader.GetInt32(5),
                            UnitPrice = reader.GetDecimal(6),
                            SellingPrice = reader.GetDecimal(7),
                            TotalPrice = reader.GetDecimal(8),
                            SupplierName = reader.GetString(9),
                            EmployeeId = reader.IsDBNull(10) ? null : reader.GetString(10),
                            Notes = reader.IsDBNull(11) ? null : reader.GetString(11),
                            ItemName = reader.GetString(12),
                            CategoryRef = reader.IsDBNull(13) ? "" : reader.GetString(13),
                            UsageType = reader.GetInt32(14),
                            RentalRate = reader.GetDecimal(15),
                            MinQuantity = reader.GetInt32(16)
                        });
                    }
                }
            }
            return list;
        }

        public static Purchase? GetByRef(string purchaseRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT p.purchase_ref, p.expense_ref, p.purchase_date, c.category_name, p.item_ref, p.quantity, p.unit_price, ISNULL(pr.selling_price, 0) AS selling_price, p.total_price, p.supplier_name, p.employee_id, p.notes, ISNULL(pr.product_name, ''), ISNULL(pr.category_ref, '') AS inventory_category_ref, ISNULL(pr.usage_type, 1), ISNULL(pr.rental_rate, 0), ISNULL(pr.min_quantity, 5) 
                                 FROM PURCHASES p 
                                 LEFT JOIN INVENTORY i ON p.item_ref = i.item_ref 
                                 LEFT JOIN PRODUCTS pr ON p.item_ref = pr.product_ref
                                 LEFT JOIN INVENTORY_CATEGORIES c ON pr.category_ref = c.category_ref 
                                 WHERE p.purchase_ref = @ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", purchaseRef);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Purchase
                            {
                                PurchaseRef = reader.GetString(0),
                                ExpenseRef = reader.IsDBNull(1) ? null : reader.GetString(1),
                                PurchaseDate = reader.GetDateTime(2),
                                Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                ItemRef = reader.GetString(4),
                                Quantity = reader.GetInt32(5),
                                UnitPrice = reader.GetDecimal(6),
                                SellingPrice = reader.GetDecimal(7),
                                TotalPrice = reader.GetDecimal(8),
                                SupplierName = reader.GetString(9),
                                EmployeeId = reader.IsDBNull(10) ? null : reader.GetString(10),
                                Notes = reader.IsDBNull(11) ? null : reader.GetString(11),
                                ItemName = reader.GetString(12),
                                CategoryRef = reader.IsDBNull(13) ? "" : reader.GetString(13),
                                UsageType = reader.GetInt32(14),
                                RentalRate = reader.GetDecimal(15),
                                MinQuantity = reader.GetInt32(16)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static Purchase? GetByExpenseRef(string expenseRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT p.purchase_ref, p.expense_ref, p.purchase_date, c.category_name, p.item_ref, p.quantity, p.unit_price, ISNULL(pr.selling_price, 0) AS selling_price, p.total_price, p.supplier_name, p.employee_id, p.notes, ISNULL(pr.product_name, ''), ISNULL(pr.category_ref, '') AS inventory_category_ref, ISNULL(pr.usage_type, 1), ISNULL(pr.rental_rate, 0), ISNULL(pr.min_quantity, 5) 
                                 FROM PURCHASES p 
                                 LEFT JOIN INVENTORY i ON p.item_ref = i.item_ref 
                                 LEFT JOIN PRODUCTS pr ON p.item_ref = pr.product_ref
                                 LEFT JOIN INVENTORY_CATEGORIES c ON pr.category_ref = c.category_ref 
                                 WHERE p.expense_ref = @ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", expenseRef);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Purchase
                            {
                                PurchaseRef = reader.GetString(0),
                                ExpenseRef = reader.IsDBNull(1) ? null : reader.GetString(1),
                                PurchaseDate = reader.GetDateTime(2),
                                Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                ItemRef = reader.GetString(4),
                                Quantity = reader.GetInt32(5),
                                UnitPrice = reader.GetDecimal(6),
                                SellingPrice = reader.GetDecimal(7),
                                TotalPrice = reader.GetDecimal(8),
                                SupplierName = reader.GetString(9),
                                EmployeeId = reader.IsDBNull(10) ? null : reader.GetString(10),
                                Notes = reader.IsDBNull(11) ? null : reader.GetString(11),
                                ItemName = reader.GetString(12),
                                CategoryRef = reader.IsDBNull(13) ? "" : reader.GetString(13),
                                UsageType = reader.GetInt32(14),
                                RentalRate = reader.GetDecimal(15),
                                MinQuantity = reader.GetInt32(16)
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
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // --- الخطوة 1: التأكد من وجود المنتج في جدول INVENTORY أو إضافته كمية 0 ---
                        if (string.IsNullOrEmpty(this.CategoryRef) && !string.IsNullOrEmpty(this.Category))
                        {
                            string catQuery = "SELECT category_ref FROM INVENTORY_CATEGORIES WHERE category_name = @name";
                            using (var catCmd = new SqlCommand(catQuery, conn, transaction))
                            {
                                catCmd.Parameters.AddWithValue("@name", this.Category);
                                var obj = catCmd.ExecuteScalar();
                                if (obj != null)
                                {
                                    this.CategoryRef = obj.ToString()!;
                                }
                                else
                                {
                                    // Generate and insert new category
                                    string maxQ = "SELECT ISNULL(MAX(CAST(SUBSTRING(category_ref, 9, 3) AS INT)), 0) FROM INVENTORY_CATEGORIES WHERE category_ref LIKE 'CAT-INV-%'";
                                    int nextSeq = 1;
                                    using (var maxCmd = new SqlCommand(maxQ, conn, transaction))
                                    {
                                        nextSeq = Convert.ToInt32(maxCmd.ExecuteScalar()) + 1;
                                    }
                                    string newRef = $"CAT-INV-{nextSeq.ToString("D3")}";

                                    string insCat = "INSERT INTO INVENTORY_CATEGORIES (category_ref, category_name, description) VALUES (@ref, @name, @desc)";
                                    using (var insCmd = new SqlCommand(insCat, conn, transaction))
                                    {
                                        insCmd.Parameters.AddWithValue("@ref", newRef);
                                        insCmd.Parameters.AddWithValue("@name", this.Category);
                                        insCmd.Parameters.AddWithValue("@desc", "أضيفت تلقائياً");
                                        insCmd.ExecuteNonQuery();
                                    }
                                    this.CategoryRef = newRef;
                                }
                            }
                        }


                        if (!string.IsNullOrEmpty(this.ItemName))
                        {
                            // Check if product exists by name in PRODUCTS first, then fallback to INVENTORY
                            string checkProduct = "SELECT product_ref FROM PRODUCTS WHERE product_name = @name";
                            string existingProductRef = null;
                            using (var cmd = new SqlCommand(checkProduct, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@name", this.ItemName);
                                var obj = cmd.ExecuteScalar();
                                if (obj != null) existingProductRef = obj.ToString();
                            }

                            if (existingProductRef != null)
                            {
                                // Product exists - update it
                                this.ItemRef = existingProductRef;

                                int minQtyVal = this.ManualMinQuantity ? this.MinQuantity : 5;
                                string updateProduct = @"
                                    UPDATE PRODUCTS SET category_ref = @cat_ref, selling_price = @sell_price,
                                        rental_rate = @rental_rate, usage_type = @usage_type, min_quantity = @min_qty
                                    WHERE product_ref = @ref";
                                using (var cmd = new SqlCommand(updateProduct, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ref", this.ItemRef);
                                    cmd.Parameters.AddWithValue("@cat_ref", (object)this.CategoryRef ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@sell_price", this.SellingPrice);
                                    cmd.Parameters.AddWithValue("@rental_rate", this.RentalRate);
                                    cmd.Parameters.AddWithValue("@usage_type", this.UsageType);
                                    cmd.Parameters.AddWithValue("@min_qty", minQtyVal);
                                    cmd.ExecuteNonQuery();
                                }

                                // No longer update obsolete columns in INVENTORY
                                // The new schema relies entirely on PRODUCTS for product metadata
                            }
                            else
                            {
                                // We no longer check INVENTORY for backward compat by item_name since item_name will be dropped from INVENTORY.
                                if (string.IsNullOrEmpty(this.ItemRef))
                                {
                                    // Brand new product - generate ref
                                    // Check max across both tables to avoid conflicts
                                    string maxQ = @"SELECT ISNULL(MAX(seq), 0) FROM (
                                        SELECT CAST(SUBSTRING(item_ref, 5, 4) AS INT) AS seq FROM INVENTORY WHERE item_ref LIKE 'INV-%'
                                        UNION ALL
                                        SELECT CAST(SUBSTRING(product_ref, 5, 4) AS INT) AS seq FROM PRODUCTS WHERE product_ref LIKE 'INV-%'
                                    ) t";
                                    int nextSeq = 1;
                                    using (var maxCmd = new SqlCommand(maxQ, conn, transaction))
                                    {
                                        nextSeq = Convert.ToInt32(maxCmd.ExecuteScalar()) + 1;
                                    }
                                    this.ItemRef = $"INV-{nextSeq.ToString("D4")}";
                                }

                                int minQtyToInsert = this.ManualMinQuantity ? this.MinQuantity : 5;

                                // Insert into PRODUCTS
                                string insProduct = @"
                                    INSERT INTO PRODUCTS (product_ref, product_name, category_ref, selling_price, rental_rate, usage_type, min_quantity)
                                    VALUES (@ref, @name, @cat_ref, @sell_price, @rental_rate, @usage_type, @min_qty)";
                                using (var cmd = new SqlCommand(insProduct, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ref", this.ItemRef);
                                    cmd.Parameters.AddWithValue("@name", this.ItemName);
                                    cmd.Parameters.AddWithValue("@cat_ref", (object)this.CategoryRef ?? DBNull.Value);
                                    cmd.Parameters.AddWithValue("@sell_price", this.SellingPrice);
                                    cmd.Parameters.AddWithValue("@rental_rate", this.RentalRate);
                                    cmd.Parameters.AddWithValue("@usage_type", this.UsageType);
                                    cmd.Parameters.AddWithValue("@min_qty", minQtyToInsert);
                                    cmd.ExecuteNonQuery();
                                }

                                // Ensure INVENTORY row exists
                                string checkInvExists = "SELECT COUNT(*) FROM INVENTORY WHERE item_ref = @ref";
                                bool invExists = false;
                                using (var cmd = new SqlCommand(checkInvExists, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@ref", this.ItemRef);
                                    invExists = (int)cmd.ExecuteScalar() > 0;
                                }

                                if (!invExists)
                                {
                                    string insItem = "INSERT INTO INVENTORY (item_ref, current_quantity, product_ref) VALUES (@ref, 0, @ref)";
                                    using (var insItemCmd = new SqlCommand(insItem, conn, transaction))
                                    {
                                        insItemCmd.Parameters.AddWithValue("@ref", this.ItemRef);
                                        insItemCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // --- الخطوة 2: إنشاء أو تحديث سجل مصروف (EXPENSE) لعملية الشراء بقيمة إجمالية ---
                        decimal totalExpenseAmount = this.Quantity * this.UnitPrice;
                        string expenseDesc = $"شراء صنف: {this.ItemName}";
                        
                        bool expenseExists = false;
                        if (!string.IsNullOrEmpty(this.ExpenseRef))
                        {
                            string checkExp = "SELECT COUNT(*) FROM EXPENSES WHERE expense_ref = @ref";
                            using (var checkExpCmd = new SqlCommand(checkExp, conn, transaction))
                            {
                                checkExpCmd.Parameters.AddWithValue("@ref", this.ExpenseRef);
                                expenseExists = (int)checkExpCmd.ExecuteScalar() > 0;
                            }
                        }

                        if (expenseExists)
                        {
                            // Update existing expense
                            string updExpense = @"UPDATE EXPENSES 
                                                 SET employee_id = @emp_id, expense_date = @date, 
                                                     expense_description = @desc, amount = @amount
                                                 WHERE expense_ref = @ref";
                            using (var expCmd = new SqlCommand(updExpense, conn, transaction))
                            {
                                expCmd.Parameters.AddWithValue("@ref", this.ExpenseRef);
                                expCmd.Parameters.AddWithValue("@emp_id", (object)this.EmployeeId ?? DBNull.Value);
                                expCmd.Parameters.AddWithValue("@date", this.PurchaseDate);
                                expCmd.Parameters.AddWithValue("@desc", expenseDesc);
                                expCmd.Parameters.AddWithValue("@amount", totalExpenseAmount);
                                expCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Insert expense with Trigger automatically generating expense_ref
                            string insExpense = @"INSERT INTO EXPENSES (employee_id, expense_date, category_ref, expense_description, amount) 
                                                 VALUES (@emp_id, @date, 'CAT-EXP-002', @desc, @amount)";
                            using (var expCmd = new SqlCommand(insExpense, conn, transaction))
                            {
                                expCmd.Parameters.AddWithValue("@emp_id", (object)this.EmployeeId ?? DBNull.Value);
                                expCmd.Parameters.AddWithValue("@date", this.PurchaseDate);
                                expCmd.Parameters.AddWithValue("@desc", expenseDesc);
                                expCmd.Parameters.AddWithValue("@amount", totalExpenseAmount);
                                expCmd.ExecuteNonQuery();
                            }

                            // Retrieve the generated expense_ref
                            string getExpRef = @"SELECT TOP 1 expense_ref FROM EXPENSES 
                                                 WHERE (employee_id = @emp_id OR (employee_id IS NULL AND @emp_id IS NULL)) 
                                                   AND CAST(expense_date AS DATE) = CAST(@date AS DATE) 
                                                   AND category_ref = 'CAT-EXP-002' 
                                                   AND amount = @amount 
                                                 ORDER BY expense_ref DESC";
                            using (var getCmd = new SqlCommand(getExpRef, conn, transaction))
                            {
                                getCmd.Parameters.AddWithValue("@emp_id", (object)this.EmployeeId ?? DBNull.Value);
                                getCmd.Parameters.AddWithValue("@date", this.PurchaseDate);
                                getCmd.Parameters.AddWithValue("@amount", totalExpenseAmount);
                                var obj = getCmd.ExecuteScalar();
                                if (obj != null)
                                {
                                    this.ExpenseRef = obj.ToString();
                                }
                            }
                        }

                        // --- الخطوة 3: إدراج عملية الشراء في جدول PURCHASES ---
                        string checkQuery = "SELECT COUNT(*) FROM PURCHASES WHERE purchase_ref = @ref";
                        bool exists = false;
                        if (!string.IsNullOrEmpty(this.PurchaseRef))
                        {
                            using (var checkCmd = new SqlCommand(checkQuery, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@ref", this.PurchaseRef);
                                exists = (int)checkCmd.ExecuteScalar() > 0;
                            }
                        }

                        if (exists)
                        {
                            string updateQuery = @"
                                UPDATE PURCHASES 
                                SET expense_ref = @exp_ref, purchase_date = @date, 
                                    item_ref = @item_ref, 
                                    quantity = @qty, unit_price = @price, 
                                    supplier_name = @supplier, employee_id = @emp_id, 
                                    notes = @notes 
                                WHERE purchase_ref = @ref";
                            using (var cmd = new SqlCommand(updateQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ref", this.PurchaseRef);
                                cmd.Parameters.AddWithValue("@exp_ref", (object)this.ExpenseRef ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@date", this.PurchaseDate);
                                cmd.Parameters.AddWithValue("@item_ref", this.ItemRef);
                                cmd.Parameters.AddWithValue("@qty", this.Quantity);
                                cmd.Parameters.AddWithValue("@price", this.UnitPrice);
                                cmd.Parameters.AddWithValue("@supplier", this.SupplierName);
                                cmd.Parameters.AddWithValue("@emp_id", (object)this.EmployeeId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@notes", (object)this.Notes ?? DBNull.Value);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertQuery = @"
                                INSERT INTO PURCHASES (expense_ref, purchase_date, item_ref, quantity, unit_price, supplier_name, employee_id, notes) 
                                VALUES (@exp_ref, @date, @item_ref, @qty, @price, @supplier, @emp_id, @notes)";
                            using (var cmd = new SqlCommand(insertQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@exp_ref", (object)this.ExpenseRef ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@date", this.PurchaseDate);
                                cmd.Parameters.AddWithValue("@item_ref", this.ItemRef);
                                cmd.Parameters.AddWithValue("@qty", this.Quantity);
                                cmd.Parameters.AddWithValue("@price", this.UnitPrice);
                                cmd.Parameters.AddWithValue("@supplier", this.SupplierName);
                                cmd.Parameters.AddWithValue("@emp_id", (object)this.EmployeeId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@notes", (object)this.Notes ?? DBNull.Value);
                                cmd.ExecuteNonQuery();
                            }

                            // Retrieve generated purchase_ref
                            string getPurchaseRef = @"SELECT TOP 1 purchase_ref FROM PURCHASES 
                                                     WHERE item_ref = @item_ref 
                                                       AND quantity = @qty 
                                                       AND unit_price = @price 
                                                       AND CAST(purchase_date AS DATE) = CAST(@date AS DATE) 
                                                     ORDER BY purchase_ref DESC";
                            using (var getCmd = new SqlCommand(getPurchaseRef, conn, transaction))
                            {
                                getCmd.Parameters.AddWithValue("@item_ref", this.ItemRef);
                                getCmd.Parameters.AddWithValue("@qty", this.Quantity);
                                getCmd.Parameters.AddWithValue("@price", this.UnitPrice);
                                getCmd.Parameters.AddWithValue("@date", this.PurchaseDate);
                                var obj = getCmd.ExecuteScalar();
                                if (obj != null)
                                {
                                    this.PurchaseRef = obj.ToString()!;
                                }
                            }
                        }

                        // --- الخطوة 4: تحديث كمية المخزون الحالية ---
                        string updateQty = @"UPDATE INVENTORY 
                                             SET current_quantity = current_quantity + @qty 
                                             WHERE item_ref = @item_ref";
                        using (var qtyCmd = new SqlCommand(updateQty, conn, transaction))
                        {
                            qtyCmd.Parameters.AddWithValue("@qty", this.Quantity);
                            qtyCmd.Parameters.AddWithValue("@item_ref", this.ItemRef);
                            qtyCmd.ExecuteNonQuery();
                        }

                        // --- الخطوة 5: تسجيل حركة مخزون (INVENTORY_MOVEMENTS) ---
                        // Generate a unique suffix using a random 6-character identifier to prevent any conflict when saving multiple items
                        string uniqueSuffix = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
                        string movRef = string.IsNullOrEmpty(this.PurchaseRef) 
                            ? $"MOV-PUR-TEMP-{uniqueSuffix}" 
                            : $"MOV-PUR-{this.PurchaseRef}-{uniqueSuffix}";
                        TimeSpan currentSqlTime = DateTime.Now.TimeOfDay;

                        string insMovement = @"INSERT INTO INVENTORY_MOVEMENTS (movement_ref, item_ref, employee_id, movement_date, movement_time, movement_type, quantity) 
                                               VALUES (@mov_ref, @item_ref, @emp_id, @date, @time, 'in', @qty)";
                        using (var movCmd = new SqlCommand(insMovement, conn, transaction))
                        {
                            movCmd.Parameters.AddWithValue("@mov_ref", movRef);
                            movCmd.Parameters.AddWithValue("@item_ref", this.ItemRef);
                            movCmd.Parameters.AddWithValue("@emp_id", (object)this.EmployeeId ?? DBNull.Value);
                            movCmd.Parameters.AddWithValue("@date", this.PurchaseDate);
                            movCmd.Parameters.AddWithValue("@time", currentSqlTime);
                            movCmd.Parameters.AddWithValue("@qty", this.Quantity);
                            movCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static void Delete(string purchaseRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // 1. Delete purchase_courts links
                string delPurchaseCourts = "DELETE FROM PURCHASE_COURTS WHERE purchase_ref = @ref";
                using (var cmd = new SqlCommand(delPurchaseCourts, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", purchaseRef);
                    cmd.ExecuteNonQuery();
                }

                // 2. Delete the purchase itself
                string query = "DELETE FROM PURCHASES WHERE purchase_ref = @ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", purchaseRef);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
