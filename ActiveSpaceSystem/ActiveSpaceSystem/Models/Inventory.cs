using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Forms.Views;

namespace ActiveSpaceSystem.Models
{
    public static class Inventory
    {
        public static List<InventoryItemViewModel> GetInventoryItems()
        {
            var list = new List<InventoryItemViewModel>();

            var sportTypeCounts = new Dictionary<string, int>();
            int totalCourtsCount = 0;

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string infoQ = "SELECT ISNULL(sport_type, ''), COUNT(*) FROM COURTS GROUP BY sport_type";
                using (var cmd = new SqlCommand(infoQ, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string sportType = reader.GetString(0);
                        int count = reader.GetInt32(1);
                        sportTypeCounts[sportType] = count;
                        totalCourtsCount += count;
                    }
                }
            }

            var productCourts = new Dictionary<string, List<(string Name, string SportType)>>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string courtsQ = @"
                    SELECT DISTINCT p.item_ref, c.court_name, ISNULL(c.sport_type, '') 
                    FROM PURCHASE_COURTS pc
                    JOIN COURTS c ON pc.court_ref = c.court_ref
                    JOIN PURCHASES p ON pc.purchase_ref = p.purchase_ref";
                using (var cmd = new SqlCommand(courtsQ, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string productRef = reader.GetString(0);
                        string courtName = reader.GetString(1);
                        string sportType = reader.GetString(2);
                        if (!productCourts.ContainsKey(productRef))
                        {
                            productCourts[productRef] = new List<(string Name, string SportType)>();
                        }
                        productCourts[productRef].Add((courtName, sportType));
                    }
                }
            }

            var productLastSupply = new Dictionary<string, DateTime>();
            var productLastSupplyNotes = new Dictionary<string, string>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string supplyQ = @"
                    SELECT p.item_ref, p.purchase_date, ISNULL(p.notes, '')
                    FROM PURCHASES p
                    INNER JOIN (
                        SELECT item_ref, MAX(purchase_date) as max_date
                        FROM PURCHASES
                        GROUP BY item_ref
                    ) latest ON p.item_ref = latest.item_ref AND p.purchase_date = latest.max_date";
                using (var cmd = new SqlCommand(supplyQ, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string productRef = reader.GetString(0);
                        DateTime maxDate = reader.GetDateTime(1);
                        string notes = reader.GetString(2);
                        productLastSupply[productRef] = maxDate;
                        productLastSupplyNotes[productRef] = notes;
                    }
                }
            }

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string mainQ = @"
                    SELECT p.product_ref, p.product_name, ISNULL(c.category_name, N'غير مصنف'), 
                           ISNULL(i.current_quantity, 0), ISNULL(p.min_quantity, 5), 
                           ISNULL(i.damaged_quantity, 0), ISNULL(p.selling_price, 0),
                           ISNULL((SELECT TOP 1 unit_price FROM PURCHASES WHERE item_ref = p.product_ref ORDER BY purchase_date DESC), 0) AS purchase_price
                    FROM PRODUCTS p
                    LEFT JOIN INVENTORY_CATEGORIES c ON p.category_ref = c.category_ref
                    LEFT JOIN INVENTORY i ON p.product_ref = i.product_ref";
                using (var cmd = new SqlCommand(mainQ, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string pRef = reader.GetString(0);
                        string pName = reader.GetString(1);
                        string catName = reader.GetString(2);
                        int currentQty = reader.GetInt32(3);
                        int minQty = reader.GetInt32(4);
                        int damagedQty = reader.GetInt32(5);
                        decimal sellingPrice = reader.GetDecimal(6);
                        decimal purchasePrice = reader.GetDecimal(7);

                        string courtsText = "لا يوجد";
                        var linkedNames = productCourts.TryGetValue(pRef, out var lc) ? lc.Select(x => x.Name).ToList() : new List<string>();
                        if (productLastSupplyNotes.TryGetValue(pRef, out var latestNotes) && !string.IsNullOrEmpty(latestNotes))
                        {
                            courtsText = ParseAssociatedCourtsFromNotes(latestNotes, linkedNames);
                        }
                        else if (linkedNames.Count > 0)
                        {
                            if (linkedNames.Count == totalCourtsCount && totalCourtsCount > 0)
                            {
                                courtsText = "جميع الملاعب";
                            }
                            else
                            {
                                // Check if all courts of a specific sport type are linked
                                var linkedBySport = productCourts[pRef].GroupBy(x => x.SportType).ToDictionary(g => g.Key, g => g.Count());
                                string matchedSport = null;
                                foreach (var kvp in sportTypeCounts)
                                {
                                    if (linkedBySport.TryGetValue(kvp.Key, out int linkedCount) && linkedCount == kvp.Value && productCourts[pRef].Count == kvp.Value)
                                    {
                                        matchedSport = kvp.Key;
                                        break;
                                    }
                                }

                                if (matchedSport != null)
                                {
                                    if (matchedSport == "بادل" || matchedSport == "البادل") courtsText = "جميع ملاعب البادل";
                                    else if (matchedSport == "كرة القدم" || matchedSport == "كرة قدم") courtsText = "جميع ملاعب كرة القدم";
                                    else if (matchedSport == "كرة السلة" || matchedSport == "كرة سلة") courtsText = "جميع ملاعب كرة السلة";
                                    else if (matchedSport == "تنس" || matchedSport == "التنس") courtsText = "جميع ملاعب التنس";
                                    else courtsText = $"جميع ملاعب {matchedSport}";
                                }
                                else
                                {
                                    courtsText = string.Join("، ", linkedNames);
                                }
                            }
                        }

                        string lastSupplyText = "لا يوجد";
                        if (productLastSupply.TryGetValue(pRef, out var supplyDate))
                        {
                            lastSupplyText = supplyDate.ToString("yyyy-MM-dd");
                        }

                        string status = currentQty > minQty ? "متوفر" : "منخفض";

                        list.Add(new InventoryItemViewModel
                        {
                            ProductRef = pRef,
                            ProductName = pName,
                            CategoryName = catName,
                            CurrentQuantity = currentQty,
                            MinQuantity = minQty,
                            DamagedQuantity = damagedQty,
                            SellingPrice = sellingPrice,
                            PurchasePrice = purchasePrice,
                            AssociatedCourts = courtsText,
                            LastSupplyDate = lastSupplyText,
                            Status = status
                        });
                    }
                }
            }

            return list;
        }

        public static List<StockMovementViewModel> GetStockMovements()
        {
            var list = new List<StockMovementViewModel>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string q = @"
                    SELECT m.movement_ref, p.product_name, m.movement_date, m.movement_time, 
                           m.movement_type, m.quantity, ISNULL(e.full_name, N'النظام'), ISNULL(m.notes, N''),
                           -- Fallback for Purchases
                           (SELECT TOP 1 N'مشتريات - ' + pur.supplier_name FROM PURCHASES pur 
                            WHERE pur.item_ref = m.item_ref AND pur.purchase_date = m.movement_date AND pur.quantity = m.quantity) AS pur_fallback,
                           -- Fallback for Bookings
                           (SELECT TOP 1 N'حجز - ' + cust.full_name FROM BOOKINGS b JOIN CUSTOMERS cust ON b.customer_phone_number = cust.phone_number
                            WHERE b.booking_date = m.movement_date AND EXISTS (SELECT 1 FROM BOOKING_INVENTORY bi WHERE bi.booking_ref = b.booking_ref AND bi.item_ref = m.item_ref)) AS bkg_fallback
                    FROM INVENTORY_MOVEMENTS m
                    JOIN PRODUCTS p ON m.item_ref = p.product_ref
                    LEFT JOIN EMPLOYEES e ON m.employee_id = e.employee_id
                    ORDER BY m.movement_date DESC, m.movement_time DESC";
                using (var cmd = new SqlCommand(q, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string movRef = reader.GetString(0);
                        string prodName = reader.GetString(1);
                        DateTime mDate = reader.GetDateTime(2);
                        TimeSpan mTime = reader.GetTimeSpan(3);
                        string mTypeRaw = reader.GetString(4);
                        int qty = reader.GetInt32(5);
                        string empName = reader.GetString(6);
                        string notes = reader.GetString(7);
                        string purFallback = reader.IsDBNull(8) ? "" : reader.GetString(8);
                        string bkgFallback = reader.IsDBNull(9) ? "" : reader.GetString(9);

                        string mType = "خصم";
                        if (mTypeRaw == "in") mType = "إضافة";
                        else if (mTypeRaw == "out") mType = "خصم";
                        else if (mTypeRaw == "damaged" || mTypeRaw == "dmg") mType = "تالف";
                        else if (mTypeRaw == "adjusted") mType = "تعديل";

                        string qtyText = qty.ToString();
                        if (mType == "إضافة") qtyText = $"+{qty}";
                        else if (mType == "خصم" || mType == "تالف") qtyText = $"-{qty}";

                        string sourceText = notes;
                        if (string.IsNullOrEmpty(sourceText))
                        {
                            if (mTypeRaw == "in") sourceText = string.IsNullOrEmpty(purFallback) ? "مشتريات" : purFallback;
                            else if (mTypeRaw == "out") sourceText = string.IsNullOrEmpty(bkgFallback) ? "حجز" : bkgFallback;
                            else if (mTypeRaw == "damaged" || mTypeRaw == "dmg") sourceText = "تقرير تالف";
                            else sourceText = "تعديل رصيد";
                        }

                        string dateTimeText = mDate.ToString("yyyy-MM-dd") + Environment.NewLine + mTime.ToString(@"hh\:mm");

                        list.Add(new StockMovementViewModel
                        {
                            MovementRef = movRef,
                            ProductName = prodName,
                            DateTimeText = dateTimeText,
                            MovementType = mType,
                            Quantity = qty,
                            QuantityText = qtyText,
                            SourceText = sourceText,
                            EmployeeName = empName
                        });
                    }
                }
            }
            return list;
        }

        public static void DeleteProductWithInventory(string productRef)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // Delete movements
                        string delMov = "DELETE FROM INVENTORY_MOVEMENTS WHERE item_ref = @ref";
                        using (var cmd = new SqlCommand(delMov, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@ref", productRef);
                            cmd.ExecuteNonQuery();
                        }

                        // Delete inventory entry
                        string delInv = "DELETE FROM INVENTORY WHERE product_ref = @ref";
                        using (var cmd = new SqlCommand(delInv, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@ref", productRef);
                            cmd.ExecuteNonQuery();
                        }

                        // Delete purchases court links
                        string delPurC = @"
                            DELETE FROM PURCHASE_COURTS 
                            WHERE purchase_ref IN (SELECT purchase_ref FROM PURCHASES WHERE item_ref = @ref)";
                        using (var cmd = new SqlCommand(delPurC, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@ref", productRef);
                            cmd.ExecuteNonQuery();
                        }

                        // Delete purchases
                        string delPur = "DELETE FROM PURCHASES WHERE item_ref = @ref";
                        using (var cmd = new SqlCommand(delPur, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@ref", productRef);
                            cmd.ExecuteNonQuery();
                        }

                        // Delete product
                        string delProd = "DELETE FROM PRODUCTS WHERE product_ref = @ref";
                        using (var cmd = new SqlCommand(delProd, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@ref", productRef);
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public static void ClearDamagedQuantity(string productRef, string employeeId = null)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        int currentDmg = 0;
                        string getDmgQ = "SELECT ISNULL(damaged_quantity, 0) FROM INVENTORY WHERE product_ref = @ref";
                        using (var cmd = new SqlCommand(getDmgQ, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@ref", productRef);
                            object res = cmd.ExecuteScalar();
                            if (res != null && res != DBNull.Value)
                            {
                                currentDmg = Convert.ToInt32(res);
                            }
                        }

                        if (currentDmg > 0)
                        {
                            string updateQ = "UPDATE INVENTORY SET damaged_quantity = 0 WHERE product_ref = @ref";
                            using (var cmd = new SqlCommand(updateQ, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@ref", productRef);
                                cmd.ExecuteNonQuery();
                            }

                            string uniqueSuffix = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
                            string movRef = $"MOV-CLR-{uniqueSuffix}";
                            string insMovement = @"INSERT INTO INVENTORY_MOVEMENTS (movement_ref, item_ref, employee_id, movement_date, movement_time, movement_type, quantity, notes) 
                                                   VALUES (@mov_ref, @item_ref, @emp_id, @date, @time, @type, @qty, @notes)";
                            using (var cmd = new SqlCommand(insMovement, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@mov_ref", movRef);
                                cmd.Parameters.AddWithValue("@item_ref", productRef);
                                cmd.Parameters.AddWithValue("@emp_id", (object)employeeId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@date", DateTime.Today);
                                cmd.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay);
                                cmd.Parameters.AddWithValue("@type", "out");
                                cmd.Parameters.AddWithValue("@qty", currentDmg);
                                cmd.Parameters.AddWithValue("@notes", "إزالة كمية التالف المسجلة");
                                cmd.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        private static string ParseAssociatedCourtsFromNotes(string notes, List<string> linkedCourts)
        {
            if (string.IsNullOrEmpty(notes))
            {
                return linkedCourts.Count > 0 ? string.Join("، ", linkedCourts) : "لا يوجد";
            }

            if (notes.Contains("نوع الملعب:") && notes.Contains("اسم الملعب:"))
            {
                try
                {
                    string[] parts = notes.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 2)
                    {
                        string typePart = parts[0].Replace("نوع الملعب:", "").Trim();
                        string namePart = parts[1].Replace("اسم الملعب:", "").Trim();

                        if (typePart == "جميع التصنيفات" || typePart == "جميع أنواع الملاعب" || string.IsNullOrEmpty(typePart) || namePart == "جميع الملاعب")
                        {
                            return "جميع الملاعب";
                        }
                        else if (namePart == "جميع ملاعب" || namePart == "جميع" || namePart.StartsWith("جميع"))
                        {
                            if (typePart == "كرة قدم" || typePart == "كرة القدم")
                                return "جميع ملاعب كرة القدم";
                            else if (typePart == "بادل" || typePart == "البادل")
                                return "جميع ملاعب البادل";
                            else if (typePart == "تنس" || typePart == "التنس")
                                return "جميع ملاعب التنس";
                            else if (typePart == "كرة سلة" || typePart == "كرة السلة")
                                return "جميع ملاعب كرة السلة";
                            else
                                return $"جميع ملاعب {typePart}";
                        }
                        else
                        {
                            return namePart;
                        }
                    }
                }
                catch { }
            }

            return linkedCourts.Count > 0 ? string.Join("، ", linkedCourts) : "لا يوجد";
        }
    }
}
