using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ActiveSpaceSystem.CustomItems;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Models;
using ActiveSpace.Models;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    public partial class AddPurchaseForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private readonly Purchase? _targetPurchase;
        private readonly bool _isEditMode = false;
        private readonly Employee? _currentUser;

        public AddPurchaseForm()
        {
            InitializeComponent();
            _isEditMode = false;
            this.Text = "إضافة مشتريات جديدة";
            lblTitle.Text = "إضافة مشتريات جديدة";
        }

        public AddPurchaseForm(Employee user) : this()
        {
            _currentUser = user;
        }

        public AddPurchaseForm(Purchase purchase) : this()
        {
            if (purchase == null) return;

            _targetPurchase = purchase;
            _isEditMode = true;
            this.Text = "تعديل المشتريات";
            lblTitle.Text = "تعديل المشتريات";
            btSave.Text = "تحديث المشتريات";
            btnAddItem.Visible = false; // Hide add button in edit mode
        }

        public AddPurchaseForm(Purchase purchase, Employee user) : this(purchase)
        {
            _currentUser = user;
        }

        private void AddPurchaseForm_Load(object sender, EventArgs e)
        {
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

            // Force dynamic resizing of flowItems elements
            this.flowItems.Resize += (s, ev) =>
            {
                foreach (Control ctrl in flowItems.Controls)
                {
                    ctrl.Width = flowItems.ClientSize.Width - 25;
                }
            };

            if (_isEditMode && _targetPurchase != null)
            {
                FillData(_targetPurchase);
            }
            else
            {
                // Add first item by default
                AddPurchaseItem();
            }
        }

        private void FillData(Purchase purchase)
        {
            dtpDate.Value = purchase.PurchaseDate > dtpDate.MinDate ? purchase.PurchaseDate : DateTime.Now;
            txtSupplierName.Texts = purchase.SupplierName;

            // Add the single item control and populate it
            var itemCtrl = AddPurchaseItem();
            itemCtrl.CategoryName = purchase.Category;
            itemCtrl.ItemName = purchase.ItemName;
            itemCtrl.Quantity = purchase.Quantity;
            itemCtrl.UnitPrice = purchase.UnitPrice;
            itemCtrl.SellingPrice = purchase.SellingPrice;
            itemCtrl.UsageType = purchase.UsageType;
            itemCtrl.RentalRate = purchase.RentalRate;
            itemCtrl.MinQuantity = purchase.MinQuantity;
            itemCtrl.ManualMinQuantity = purchase.ManualMinQuantity;

            // Try to extract CourtType and CourtName from Notes if present
            if (!string.IsNullOrEmpty(purchase.Notes))
            {
                try
                {
                    string notes = purchase.Notes;
                    if (notes.Contains("نوع الملعب:") && notes.Contains("اسم الملعب:"))
                    {
                        int typeIndex = notes.IndexOf("نوع الملعب:") + "نوع الملعب:".Length;
                        int nameIndex = notes.IndexOf("اسم الملعب:");
                        
                        string typeStr = notes.Substring(typeIndex, nameIndex - typeIndex).Replace("-", "").Trim();
                        string nameStr = notes.Substring(nameIndex + "اسم الملعب:".Length).Trim();

                        itemCtrl.CourtTypeName = typeStr;
                        itemCtrl.CourtName = nameStr;
                    }
                }
                catch { }
            }
        }

        private PurchaseItemControl AddPurchaseItem()
        {
            var item = new PurchaseItemControl();
            item.Index = flowItems.Controls.Count + 1;
            item.Width = flowItems.ClientSize.Width - 25;
            item.Margin = new Padding(0, 5, 0, 5);

            // Delete button behavior
            item.DeleteClicked += (sender, e) =>
            {
                if (flowItems.Controls.Count <= 1)
                {
                    return; // Can't delete last item
                }

                flowItems.Controls.Remove(item);
                item.Dispose();
                ReindexItems();
                UpdateDeleteButtons();
            };

            flowItems.Controls.Add(item);
            UpdateDeleteButtons();
            return item;
        }

        private void ReindexItems()
        {
            int idx = 1;
            foreach (Control ctrl in flowItems.Controls)
            {
                if (ctrl is PurchaseItemControl itemCtrl)
                {
                    itemCtrl.Index = idx++;
                }
            }
        }

        private void UpdateDeleteButtons()
        {
            bool showDelete = flowItems.Controls.Count > 1;
            foreach (Control ctrl in flowItems.Controls)
            {
                if (ctrl is PurchaseItemControl itemCtrl)
                {
                    itemCtrl.ShowDeleteButton = showDelete;
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddPurchaseItem();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                DateTime date = dtpDate.Value;
                string supplierName = txtSupplierName.Texts.Trim();

                if (_isEditMode && _targetPurchase != null)
                {
                    var item = (PurchaseItemControl)flowItems.Controls[0];
                    _targetPurchase.PurchaseDate = date;
                    _targetPurchase.Category = item.CategoryName;
                    _targetPurchase.ItemName = item.ItemName;
                    _targetPurchase.Quantity = item.Quantity;
                    _targetPurchase.UnitPrice = item.UnitPrice;
                    _targetPurchase.SellingPrice = item.SellingPrice;
                    _targetPurchase.UsageType = item.UsageType;
                    _targetPurchase.RentalRate = item.RentalRate;
                    _targetPurchase.MinQuantity = item.MinQuantity;
                    _targetPurchase.ManualMinQuantity = item.ManualMinQuantity;
                    _targetPurchase.SupplierName = supplierName;
                    _targetPurchase.Notes = $"نوع الملعب: {item.CourtTypeName} - اسم الملعب: {item.CourtName}";
                    if (_currentUser != null)
                    {
                        _targetPurchase.EmployeeId = _currentUser.EmployeeID;
                    }

                    _targetPurchase.Save();

                    // Save purchase court relations
                    SavePurchaseCourts(_targetPurchase.PurchaseRef, item.CourtTypeName, item.CourtName);
                }
                else
                {
                    foreach (Control ctrl in flowItems.Controls)
                    {
                        if (ctrl is PurchaseItemControl item)
                        {
                            var newPurchase = new Purchase
                            {
                                PurchaseDate = date,
                                Category = item.CategoryName,
                                ItemName = item.ItemName,
                                Quantity = item.Quantity,
                                UnitPrice = item.UnitPrice,
                                SellingPrice = item.SellingPrice,
                                UsageType = item.UsageType,
                                RentalRate = item.RentalRate,
                                MinQuantity = item.MinQuantity,
                                ManualMinQuantity = item.ManualMinQuantity,
                                SupplierName = supplierName,
                                EmployeeId = _currentUser?.EmployeeID,
                                Notes = $"نوع الملعب: {item.CourtTypeName} - اسم الملعب: {item.CourtName}"
                            };

                            newPurchase.Save();

                            // Save purchase court relations
                            SavePurchaseCourts(newPurchase.PurchaseRef, item.CourtTypeName, item.CourtName);
                        }
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حفظ البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePurchaseCourts(string purchaseRef, string courtType, string courtName)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Delete existing relationships first for this purchase
                string delQ = "DELETE FROM PURCHASE_COURTS WHERE purchase_ref = @p_ref";
                using (var delCmd = new SqlCommand(delQ, conn))
                {
                    delCmd.Parameters.AddWithValue("@p_ref", purchaseRef);
                    delCmd.ExecuteNonQuery();
                }

                List<string> courtRefsToLink = new List<string>();

                if (courtType == "جميع أنواع الملاعب" || courtName == "جميع الملاعب")
                {
                    // Get ALL courts
                    string q = "SELECT court_ref FROM COURTS";
                    using (var cmd = new SqlCommand(q, conn))
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read()) courtRefsToLink.Add(r.GetString(0));
                    }
                }
                else if (courtName.StartsWith("جميع ملاعب"))
                {
                    // Get all courts of this specific type
                    string q = "SELECT court_ref FROM COURTS WHERE sport_type = @type";
                    using (var cmd = new SqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@type", courtType);
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read()) courtRefsToLink.Add(r.GetString(0));
                        }
                    }
                }
                else
                {
                    // Specific court
                    string q = "SELECT court_ref FROM COURTS WHERE court_name = @name";
                    using (var cmd = new SqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", courtName);
                        var obj = cmd.ExecuteScalar();
                        if (obj != null) courtRefsToLink.Add(obj.ToString());
                    }
                }

                // Insert into PURCHASE_COURTS
                foreach (var courtRef in courtRefsToLink)
                {
                    string insQ = "INSERT INTO PURCHASE_COURTS (purchase_ref, court_ref) VALUES (@p_ref, @c_ref)";
                    using (var cmd = new SqlCommand(insQ, conn))
                    {
                        cmd.Parameters.AddWithValue("@p_ref", purchaseRef);
                        cmd.Parameters.AddWithValue("@c_ref", courtRef);
                        try { cmd.ExecuteNonQuery(); } catch { } // Ignore duplicates if any
                    }
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Texts))
            {
                MessageBox.Show("يرجى إدخال اسم المورد", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierName.Focus();
                return false;
            }

            if (flowItems.Controls.Count == 0)
            {
                MessageBox.Show("يرجى إضافة صنف واحد على الأقل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (Control ctrl in flowItems.Controls)
            {
                if (ctrl is PurchaseItemControl item)
                {
                    if (string.IsNullOrWhiteSpace(item.CategoryName))
                    {
                        MessageBox.Show($"الصنف {item.Index}: يرجى اختيار الفئة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(item.ItemName))
                    {
                        MessageBox.Show($"الصنف {item.Index}: يرجى إدخال اسم الصنف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (item.Quantity <= 0)
                    {
                        MessageBox.Show($"الصنف {item.Index}: يرجى إدخال كمية صحيحة (أكبر من 0)", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (item.UnitPrice <= 0)
                    {
                        MessageBox.Show($"الصنف {item.Index}: يرجى إدخال سعر وحدة صحيح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (item.UsageType == 1 || item.UsageType == 3)
                    {
                        if (item.SellingPrice <= 0)
                        {
                            MessageBox.Show($"الصنف {item.Index}: يرجى إدخال سعر بيع صحيح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    if (item.UsageType == 2 || item.UsageType == 3)
                    {
                        if (item.RentalRate <= 0)
                        {
                            MessageBox.Show($"الصنف {item.Index}: يرجى إدخال سعر تأجير صحيح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    if (item.ManualMinQuantity && item.MinQuantity < 0)
                    {
                        MessageBox.Show($"الصنف {item.Index}: يرجى إدخال حد أدنى صحيح (أكبر من أو يساوي 0)", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            btCancel_Click(sender, e);
        }

        private void AddPurchaseForm_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.FromArgb(230, 233, 237);
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
        }
    }
}
