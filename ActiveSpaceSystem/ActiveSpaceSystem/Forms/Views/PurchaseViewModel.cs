using ActiveSpaceSystem.Models;
using System;

namespace ActiveSpaceSystem.Forms.Views
{
    public class PurchaseViewModel
    {
        public string PurchaseRef { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string AssociatedCourt { get; set; } = "جميع الملاعب";
        public string Notes { get; set; } = string.Empty;

        public static PurchaseViewModel FromPurchase(Purchase p)
        {
            // Parse Associated Court from Notes if notes contain court info, otherwise default
            string court = "جميع الملاعب";
            if (!string.IsNullOrEmpty(p.Notes))
            {
                if (p.Notes.Contains("نوع الملعب:") && p.Notes.Contains("اسم الملعب:"))
                {
                    try
                    {
                        string[] parts = p.Notes.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 2)
                        {
                            string typePart = parts[0].Replace("نوع الملعب:", "").Trim();
                            string namePart = parts[1].Replace("اسم الملعب:", "").Trim();

                            if (typePart == "جميع التصنيفات" || typePart == "جميع أنواع الملاعب" || string.IsNullOrEmpty(typePart) || namePart == "جميع الملاعب")
                            {
                                court = "جميع الملاعب";
                            }
                            else if (namePart == "جميع ملاعب" || namePart == "جميع" || namePart.StartsWith("جميع"))
                            {
                                if (typePart == "كرة قدم" || typePart == "كرة القدم")
                                    court = "جميع ملاعب كرة القدم";
                                else if (typePart == "بادل" || typePart == "البادل")
                                    court = "جميع ملاعب البادل";
                                else if (typePart == "تنس" || typePart == "التنس")
                                    court = "جميع ملاعب التنس";
                                else
                                    court = $"جميع ملاعب {typePart}";
                            }
                            else
                            {
                                court = namePart;
                            }
                        }
                    }
                    catch
                    {
                        court = p.Notes;
                    }
                }
                else
                {
                    // Fallback to old simple check
                    if (p.Notes.Contains("ملعب كرة القدم 1")) court = "ملعب كرة القدم 1";
                    else if (p.Notes.Contains("ملعب كرة القدم 2")) court = "ملعب كرة القدم 2";
                    else if (p.Notes.Contains("ملعب التنس 1")) court = "ملعب التنس 1";
                    else if (p.Notes.Contains("ملعب البادل 1")) court = "ملعب البادل 1";
                    else if (p.Notes.StartsWith("ملعب ") || p.Notes.Contains("ملعب"))
                    {
                        court = p.Notes;
                    }
                }
            }

            return new PurchaseViewModel
            {
                PurchaseRef = p.PurchaseRef,
                Date = p.PurchaseDate.ToString("yyyy-MM-dd"),
                Category = p.Category,
                ItemName = p.ItemName,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
                TotalPrice = p.TotalPrice,
                SupplierName = p.SupplierName,
                AssociatedCourt = court,
                Notes = p.Notes ?? string.Empty
            };
        }
    }
}
