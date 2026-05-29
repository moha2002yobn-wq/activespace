namespace ActiveSpaceSystem.Forms.Views
{
    public class InventoryItemViewModel
    {
        public string ProductRef { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int CurrentQuantity { get; set; }
        public int MinQuantity { get; set; }
        public int DamagedQuantity { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string AssociatedCourts { get; set; } = "لا يوجد";
        public string LastSupplyDate { get; set; } = "لا يوجد";
        public string Status { get; set; } = "متوفر";
    }

    public class StockMovementViewModel
    {
        public string MovementRef { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string DateTimeText { get; set; } = string.Empty;
        public string MovementType { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string QuantityText { get; set; } = string.Empty;
        public string SourceText { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
    }
}
