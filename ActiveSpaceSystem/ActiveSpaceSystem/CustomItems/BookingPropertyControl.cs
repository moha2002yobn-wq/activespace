using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Models;

namespace ActiveSpaceSystem.CustomItems
{
    public partial class BookingPropertyControl : UserControl
    {
        public event EventHandler ValueChanged;
        public event EventHandler DeleteClicked;

        private string _courtRef = "";
        public string CourtRef
        {
            get => _courtRef;
            set
            {
                _courtRef = value;
                LoadCategories();
            }
        }

        private string _courtName = "";
        public string CourtName
        {
            get => _courtName;
            set
            {
                _courtName = value;
                // Look up court_ref if we only have courtName
                if (string.IsNullOrEmpty(_courtRef) && !string.IsNullOrEmpty(_courtName))
                {
                    using (var conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        string q = "SELECT court_ref FROM COURTS WHERE court_name = @name";
                        using (var cmd = new SqlCommand(q, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", _courtName);
                            var res = cmd.ExecuteScalar();
                            if (res != null) _courtRef = res.ToString();
                        }
                    }
                }
                LoadCategories();
            }
        }

        // Cache lists to make it responsive
        private List<CategoryItem> _categories = new List<CategoryItem>();
        private List<InventoryItemDetails> _items = new List<InventoryItemDetails>();

        public BookingPropertyControl()
        {
            InitializeComponent();
            
            cmbType.Items.Clear();
            cmbType.Items.Add("إيجار");
            cmbType.Items.Add("بيع");
            cmbType.SelectedIndex = 0;

            cmbCategory.SelectedIndexChanged += CmbCategory_SelectedIndexChanged;
            cmbItem.SelectedIndexChanged += CmbItem_SelectedIndexChanged;
            cmbType.SelectedIndexChanged += CmbType_SelectedIndexChanged;
            txtQty.TextChanged += TxtQty_TextChanged;
            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);

            cmbItem.DropDown += (s, e) => AdjustComboBoxDropdownWidth(cmbItem);
            cmbCategory.DropDown += (s, e) => AdjustComboBoxDropdownWidth(cmbCategory);
        }

        public string SelectedCategoryRef => cmbCategory.SelectedValue?.ToString() ?? "";
        public string SelectedItemRef => cmbItem.SelectedValue?.ToString() ?? "";
        public string SelectedItemName => cmbItem.Text;
        public int SelectedQuantity => int.TryParse(txtQty.Text, out int q) ? q : 1;
        public string SelectedUsageType => cmbType.Text == "إيجار" ? "Rent" : "Sale";

        public decimal SelectedUnitPrice
        {
            get
            {
                if (cmbItem.SelectedItem is InventoryItemDetails selectedDetails)
                {
                    return SelectedUsageType == "Rent" ? selectedDetails.RentalRate : selectedDetails.SellingPrice;
                }
                return 0m;
            }
        }

        public decimal TotalPrice => SelectedQuantity * SelectedUnitPrice;

        private void LoadCategories()
        {
            if (string.IsNullOrEmpty(_courtRef)) return;

            _categories.Clear();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT DISTINCT c.category_ref, c.category_name 
                    FROM INVENTORY_CATEGORIES c
                    JOIN PRODUCTS pr ON c.category_ref = pr.category_ref
                    JOIN PURCHASES p ON pr.product_ref = p.item_ref
                    JOIN PURCHASE_COURTS pc ON p.purchase_ref = pc.purchase_ref
                    WHERE pc.court_ref = @court_ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@court_ref", _courtRef);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _categories.Add(new CategoryItem
                            {
                                Ref = reader.GetString(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            cmbCategory.DataSource = null;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Ref";
            cmbCategory.DataSource = _categories;

            if (_categories.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
                LoadItems();
            }
            else
            {
                cmbItem.DataSource = null;
                lblPrice.Text = "السعر: 0 د.ل";
            }
        }

        private void LoadItems()
        {
            string catRef = SelectedCategoryRef;
            if (string.IsNullOrEmpty(_courtRef) || string.IsNullOrEmpty(catRef)) return;

            _items.Clear();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT i.item_ref, pr.product_name, 
                           pr.usage_type, 
                           pr.rental_rate, 
                           pr.selling_price AS selling_price, 
                           i.current_quantity
                    FROM INVENTORY i
                    INNER JOIN PRODUCTS pr ON i.item_ref = pr.product_ref
                    WHERE EXISTS (
                        SELECT 1 FROM PURCHASES p
                        JOIN PURCHASE_COURTS pc ON p.purchase_ref = pc.purchase_ref
                        WHERE p.item_ref = i.item_ref AND pc.court_ref = @court_ref
                    ) AND pr.category_ref = @category_ref";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@court_ref", _courtRef);
                    cmd.Parameters.AddWithValue("@category_ref", catRef);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _items.Add(new InventoryItemDetails
                            {
                                Ref = reader.GetString(0),
                                Name = reader.GetString(1),
                                UsageType = reader.GetInt32(2),
                                RentalRate = reader.GetDecimal(3),
                                SellingPrice = reader.GetDecimal(4),
                                CurrentQuantity = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }

            cmbItem.DataSource = null;
            cmbItem.DisplayMember = "Name";
            cmbItem.ValueMember = "Ref";
            cmbItem.DataSource = _items;

            if (_items.Count > 0)
            {
                cmbItem.SelectedIndex = 0;
                UpdateUsageTypeOptions();
            }
            else
            {
                lblPrice.Text = "السعر: 0 د.ل";
            }
        }

        private void UpdateUsageTypeOptions()
        {
            if (cmbItem.SelectedItem is InventoryItemDetails selectedDetails)
            {
                cmbType.SelectedIndexChanged -= CmbType_SelectedIndexChanged;
                cmbType.Items.Clear();

                int usage = selectedDetails.UsageType;
                if (usage == 1) // Sale
                {
                    cmbType.Items.Add("بيع");
                    cmbType.SelectedIndex = 0;
                }
                else if (usage == 2) // Rent
                {
                    cmbType.Items.Add("إيجار");
                    cmbType.SelectedIndex = 0;
                }
                else // Both
                {
                    cmbType.Items.Add("إيجار");
                    cmbType.Items.Add("بيع");
                    cmbType.SelectedIndex = 0;
                }

                cmbType.SelectedIndexChanged += CmbType_SelectedIndexChanged;
            }
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            decimal unitPrice = SelectedUnitPrice;
            int qty = SelectedQuantity;
            decimal total = qty * unitPrice;
            lblPrice.Text = $"السعر: {qty} × {unitPrice:0.##} = {total:0.##} د.ل";
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void CmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUsageTypeOptions();
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void TxtQty_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void AdjustComboBoxDropdownWidth(ComboBox sender)
        {
            int width = sender.Width;
            using (Graphics g = sender.CreateGraphics())
            {
                Font font = sender.Font;
                int vertScrollBarWidth = (sender.Items.Count > sender.MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0;

                foreach (object item in sender.Items)
                {
                    string text = sender.GetItemText(item) ?? "";
                    int newWidth = (int)g.MeasureString(text, font).Width + vertScrollBarWidth + 10;
                    if (width < newWidth)
                    {
                        width = newWidth;
                    }
                }
            }
            sender.DropDownWidth = width;
        }

        public void SetPropertyData(string itemRef, int qty, string usageType)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string q = "SELECT category_ref FROM PRODUCTS WHERE product_ref = @ref";
                    using (var cmd = new SqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@ref", itemRef);
                        var catRef = cmd.ExecuteScalar()?.ToString();
                        if (catRef != null)
                        {
                            cmbCategory.SelectedValue = catRef;
                            LoadItems();
                            cmbItem.SelectedValue = itemRef;
                            UpdateUsageTypeOptions();
                            
                            string displayType = usageType == "Rent" ? "إيجار" : "بيع";
                            if (cmbType.Items.Contains(displayType))
                            {
                                cmbType.SelectedItem = displayType;
                            }
                            txtQty.Text = qty.ToString();
                            UpdatePrice();
                        }
                    }
                }
            }
            catch { }
        }

        // Helper classes for binding
        public class CategoryItem
        {
            public string Ref { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        public class InventoryItemDetails
        {
            public string Ref { get; set; }
            public string Name { get; set; }
            public int UsageType { get; set; }
            public decimal RentalRate { get; set; }
            public decimal SellingPrice { get; set; }
            public int CurrentQuantity { get; set; }
            public override string ToString() => Name;
        }
    }
}
