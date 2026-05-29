using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ActiveSpace.Models;
using ActiveSpaceSystem.Data;

namespace ActiveSpaceSystem.Models
{
    public class Expense
    {
        public string ExpenseRef { get; set; } = string.Empty;
        public string? EmployeeID { get; set; }
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public string Category { get; set; } = "نثريات";
        public string CategoryRef { get; set; } = string.Empty;
        public string ExpenseDescription { get; set; } = string.Empty;
        public double Amount { get; set; }

        // Backwards compatibility properties
        public string ExpenseID
        {
            get => ExpenseRef;
            set => ExpenseRef = value;
        }

        public string Description
        {
            get => ExpenseDescription;
            set => ExpenseDescription = value;
        }

        public int ExpenseTypeId { get; set; } // Dummy property

        public ExpenseType ExpenseType
        {
            get => new ExpenseType { ExpenseName = Category };
            set => Category = value?.ExpenseName ?? "نثريات";
        }

        public string CategoryName => Category;

        public static List<Expense> GetAll()
        {
            var list = new List<Expense>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT e.expense_ref, e.employee_id, e.expense_date, c.category_name, e.expense_description, e.amount, e.category_ref FROM EXPENSES e LEFT JOIN EXPENSE_CATEGORIES c ON e.category_ref = c.category_ref";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Expense
                        {
                            ExpenseRef = reader.GetString(0),
                            EmployeeID = reader.IsDBNull(1) ? null : reader.GetString(1),
                            ExpenseDate = reader.GetDateTime(2),
                            Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            ExpenseDescription = reader.GetString(4),
                            Amount = (double)reader.GetDecimal(5),
                            CategoryRef = reader.IsDBNull(6) ? "" : reader.GetString(6)
                        });
                    }
                }
            }
            return list;
        }

        public static Expense? GetByRef(string expenseRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT e.expense_ref, e.employee_id, e.expense_date, c.category_name, e.expense_description, e.amount, e.category_ref FROM EXPENSES e LEFT JOIN EXPENSE_CATEGORIES c ON e.category_ref = c.category_ref WHERE e.expense_ref = @ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", expenseRef);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Expense
                            {
                                ExpenseRef = reader.GetString(0),
                                EmployeeID = reader.IsDBNull(1) ? null : reader.GetString(1),
                                ExpenseDate = reader.GetDateTime(2),
                                Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                ExpenseDescription = reader.GetString(4),
                                Amount = (double)reader.GetDecimal(5),
                                CategoryRef = reader.IsDBNull(6) ? "" : reader.GetString(6)
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
                string checkQuery = "SELECT COUNT(*) FROM EXPENSES WHERE expense_ref = @ref";
                bool exists = false;
                using (var checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@ref", this.ExpenseRef);
                    exists = (int)checkCmd.ExecuteScalar() > 0;
                }

                if (string.IsNullOrEmpty(this.CategoryRef) && !string.IsNullOrEmpty(this.Category))
                {
                    string catQuery = "SELECT category_ref FROM EXPENSE_CATEGORIES WHERE category_name = @name";
                    using (var catCmd = new SqlCommand(catQuery, conn))
                    {
                        catCmd.Parameters.AddWithValue("@name", this.Category);
                        var obj = catCmd.ExecuteScalar();
                        if (obj != null) 
                        {
                            this.CategoryRef = obj.ToString();
                        }
                        else
                        {
                            string insCat = "INSERT INTO EXPENSE_CATEGORIES (category_name, affects_inventory) VALUES (@name, 0); SELECT category_ref FROM EXPENSE_CATEGORIES WHERE category_name = @name;";
                            using (var insCmd = new SqlCommand(insCat, conn))
                            {
                                insCmd.Parameters.AddWithValue("@name", this.Category);
                                var newObj = insCmd.ExecuteScalar();
                                if (newObj != null) this.CategoryRef = newObj.ToString();
                            }
                        }
                    }
                }

                if (exists)
                {
                    string updateQuery = @"
                        UPDATE EXPENSES 
                        SET employee_id = @emp_id, expense_date = @date, 
                            category_ref = @category_ref, expense_description = @desc, 
                            amount = @amount 
                        WHERE expense_ref = @ref";
                    using (var cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", this.ExpenseRef);
                        cmd.Parameters.AddWithValue("@emp_id", (object)this.EmployeeID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@date", this.ExpenseDate);
                        cmd.Parameters.AddWithValue("@category_ref", (object)this.CategoryRef ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@desc", this.ExpenseDescription);
                        cmd.Parameters.AddWithValue("@amount", this.Amount);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Let trigger generate expense_ref if it's empty, or generate one
                    if (string.IsNullOrEmpty(this.ExpenseRef))
                    {
                        string dateStr = this.ExpenseDate.ToString("yyyyMMdd");
                        var existingRefs = new HashSet<int>();
                        string selectQuery = "SELECT CAST(RIGHT(expense_ref, 3) AS INT) FROM EXPENSES WHERE expense_ref LIKE 'EXP-' + @date + '-%'";
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
                        this.ExpenseRef = $"EXP-{dateStr}-{nextSeq.ToString("D3")}";
                    }

                    string insertQuery = @"
                        INSERT INTO EXPENSES (expense_ref, employee_id, expense_date, category_ref, expense_description, amount) 
                        VALUES (@ref, @emp_id, @date, @category_ref, @desc, @amount)";
                    using (var cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", this.ExpenseRef);
                        cmd.Parameters.AddWithValue("@emp_id", (object)this.EmployeeID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@date", this.ExpenseDate);
                        cmd.Parameters.AddWithValue("@category_ref", (object)this.CategoryRef ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@desc", this.ExpenseDescription);
                        cmd.Parameters.AddWithValue("@amount", this.Amount);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void Delete(string expenseRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // 1. Delete purchase_courts linked to purchases of this expense
                string delPurchaseCourts = "DELETE FROM PURCHASE_COURTS WHERE purchase_ref IN (SELECT purchase_ref FROM PURCHASES WHERE expense_ref = @ref)";
                using (var cmd = new SqlCommand(delPurchaseCourts, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", expenseRef);
                    cmd.ExecuteNonQuery();
                }

                // 2. Delete purchases linked to this expense
                string delPurchases = "DELETE FROM PURCHASES WHERE expense_ref = @ref";
                using (var cmd = new SqlCommand(delPurchases, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", expenseRef);
                    cmd.ExecuteNonQuery();
                }

                // 3. Delete the expense itself
                string query = "DELETE FROM EXPENSES WHERE expense_ref = @ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", expenseRef);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
