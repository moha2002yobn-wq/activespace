using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Models;
using ActiveSpaceSystem.Models.enums;
using ActiveSpaceSystem.Forms.Views;
using ActiveSpaceSystem.Forms.GridStyle;

namespace ActiveSpaceSystem.Forms.SideForms
{
    public partial class InventoryForm : Form
    {
        private Employee currentUser;
        private List<InventoryItemViewModel> allInventory = new List<InventoryItemViewModel>();
        private List<StockMovementViewModel> allMovements = new List<StockMovementViewModel>();
        private InventoryGridRenderer gridRenderer;

        private bool showDamagedOnly = false;

        public InventoryForm() : this(null!) { }

        public InventoryForm(Employee user)
        {
            InitializeComponent();
            this.TopLevel = false;
            currentUser = user;
            gridRenderer = new InventoryGridRenderer();
            
            SetupGrid();

            if (cardDamagedGoods != null)
            {
                cardDamagedGoods.Cursor = Cursors.Hand;
                cardDamagedGoods.Click += CardDamagedGoods_Click;
            }
        }

        private void CardDamagedGoods_Click(object sender, EventArgs e)
        {
            using (var dlg = new Forms.DialogForms.DamagedGoodsDialog(currentUser))
            {
                dlg.ShowDialog();
                LoadData();
            }
        }

        private void SetupGrid()
        {
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.RowHeight = 55;
            dgvInventory.RowTemplate.Height = 55;

            dgvInventory.CellPainting -= DgvInventory_CellPainting;
            dgvInventory.CellClick -= DgvInventory_CellClick;

            dgvInventory.CellPainting += DgvInventory_CellPainting;
            dgvInventory.CellClick += DgvInventory_CellClick;
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterAll);
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                allInventory = Inventory.GetInventoryItems();
                allMovements = Inventory.GetStockMovements();

                ApplyFiltersAndSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFiltersAndSearch()
        {
            string searchText = txtSearch.Texts.Trim().ToLower();
            string activeCategory = "الكل";
            if (btnFilterSportsBalls.Checked) activeCategory = "كرات رياضية";
            else if (btnFilterEquipment.Checked) activeCategory = "معدات الملاعب";
            else if (btnFilterSupplies.Checked) activeCategory = "مستلزمات";
            else if (btnFilterLighting.Checked) activeCategory = "إضاءة";

            // Update stats based on category
            UpdateStatistics(allInventory.Where(x => activeCategory == "الكل" || x.CategoryName == activeCategory).ToList());

            if (btnTabInventory.Checked)
            {
                // Show Inventory Columns
                SetupInventoryColumns();

                var filtered = allInventory.Where(x =>
                    (activeCategory == "الكل" || x.CategoryName == activeCategory) &&
                    (!showDamagedOnly || x.DamagedQuantity > 0) &&
                    (string.IsNullOrEmpty(searchText) ||
                     x.ProductName.ToLower().Contains(searchText) ||
                     x.CategoryName.ToLower().Contains(searchText) ||
                     x.ProductRef.ToLower().Contains(searchText))
                ).ToList();

                dgvInventory.DataSource = null;
                dgvInventory.DataSource = filtered;
            }
            else
            {
                // Show Movements Columns
                SetupMovementColumns();

                var filtered = allMovements.Where(x =>
                    (string.IsNullOrEmpty(searchText) ||
                     x.ProductName.ToLower().Contains(searchText) ||
                     x.MovementRef.ToLower().Contains(searchText) ||
                     x.MovementType.ToLower().Contains(searchText) ||
                     x.EmployeeName.ToLower().Contains(searchText))
                ).ToList();

                dgvInventory.DataSource = null;
                dgvInventory.DataSource = filtered;
            }
        }

        private void SetupInventoryColumns()
        {
            dgvInventory.Columns.Clear();
            var columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "ProductRef", HeaderText = "رمز الصنف", Name = "ProductRef", Width = 90 },
                new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "اسم الصنف", Name = "ProductName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { DataPropertyName = "CategoryName", HeaderText = "الفئة", Name = "CategoryName", Width = 120 },
                new DataGridViewTextBoxColumn { DataPropertyName = "CurrentQuantity", HeaderText = "الكمية الحالية", Name = "CurrentQuantity", Width = 100 },
                new DataGridViewTextBoxColumn { DataPropertyName = "MinQuantity", HeaderText = "الحد الأدنى", Name = "MinQuantity", Width = 100 },
                new DataGridViewTextBoxColumn { DataPropertyName = "DamagedQuantity", HeaderText = "التالف", Name = "DamagedQuantity", Width = 80 },
                new DataGridViewTextBoxColumn { DataPropertyName = "AssociatedCourts", HeaderText = "الملاعب المرتبطة", Name = "AssociatedCourts", Width = 230, MinimumWidth = 220, FillWeight = 160 },
                new DataGridViewTextBoxColumn { DataPropertyName = "LastSupplyDate", HeaderText = "آخر توريد", Name = "LastSupplyDate", Width = 110 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "الحالة", Name = "Status", Width = 90 },
                new DataGridViewTextBoxColumn { Name = "Actions", HeaderText = "الإجراءات", Width = 110 }
            };
            dgvInventory.Columns.AddRange(columns);
        }

        private void SetupMovementColumns()
        {
            dgvInventory.Columns.Clear();
            var columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "DateTimeText", HeaderText = "التاريخ والوقت", Name = "DateTimeText", Width = 150 },
                new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "الصنف", Name = "ProductName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { DataPropertyName = "MovementType", HeaderText = "نوع الحركة", Name = "MovementType", Width = 110 },
                new DataGridViewTextBoxColumn { DataPropertyName = "QuantityText", HeaderText = "الكمية", Name = "QuantityText", Width = 90 },
                new DataGridViewTextBoxColumn { DataPropertyName = "SourceText", HeaderText = "المصدر/السبب", Name = "SourceText", Width = 230 },
                new DataGridViewTextBoxColumn { DataPropertyName = "EmployeeName", HeaderText = "المنفذ", Name = "EmployeeName", Width = 130 }
            };
            dgvInventory.Columns.AddRange(columns);
        }

        private void UpdateStatistics(List<InventoryItemViewModel> list)
        {
            int totalItems = list.Count;
            int lowStockCount = list.Count(x => x.CurrentQuantity <= x.MinQuantity);
            int damagedTotal = list.Sum(x => x.DamagedQuantity);
            decimal totalValue = list.Sum(x => x.CurrentQuantity * x.SellingPrice);

            string rlm = "\u200F";
            cardTotalItems.ValueText = totalItems.ToString();
            cardLowStock.ValueText = lowStockCount.ToString();
            cardDamagedGoods.ValueText = damagedTotal.ToString();
            cardTotalValue.ValueText = $"{rlm}{totalValue:N0} د.ل";
        }

        private void DgvInventory_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvInventory.Columns[e.ColumnIndex].Name;

            if (colName == "Actions" && btnTabInventory.Checked)
            {
                gridRenderer.RenderActionsCell(e);
            }
            else if (colName == "CategoryName")
            {
                string text = e.Value?.ToString() ?? "";
                gridRenderer.RenderCategoryCell(e, text);
            }
            else if (colName == "AssociatedCourts")
            {
                string text = e.Value?.ToString() ?? "";
                gridRenderer.RenderCourtCell(e, text);
            }
            else if (colName == "Status")
            {
                string text = e.Value?.ToString() ?? "";
                gridRenderer.RenderStatusCell(e, text);
            }
            else if (colName == "MovementType" && !btnTabInventory.Checked)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                string text = e.Value?.ToString() ?? "";
                Color back = Color.FromArgb(243, 244, 246);
                Color fore = Color.FromArgb(107, 114, 128);

                if (text == "إضافة") { back = Color.FromArgb(236, 253, 245); fore = Color.FromArgb(5, 150, 105); }
                else if (text == "خصم") { back = Color.FromArgb(239, 246, 255); fore = Color.FromArgb(29, 78, 216); }
                else if (text == "تالف") { back = Color.FromArgb(254, 226, 226); fore = Color.FromArgb(220, 38, 38); }
                else if (text == "تعديل") { back = Color.FromArgb(219, 234, 254); fore = Color.FromArgb(79, 70, 229); }

                gridRenderer.RenderMovementTypeCell(e, text, back, fore);
                e.Handled = true;
            }
            else if (colName == "QuantityText" && !btnTabInventory.Checked)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                string text = e.Value?.ToString() ?? "0";
                string mType = dgvInventory.Rows[e.RowIndex].Cells["MovementType"].Value?.ToString() ?? "";
                
                Color textColor = Color.FromArgb(30, 41, 59); // Default dark slate
                if (mType == "إضافة")
                {
                    textColor = Color.FromArgb(5, 150, 105); // Green
                }
                else if (mType == "تالف")
                {
                    textColor = Color.FromArgb(220, 38, 38); // Red
                }
                else if (mType == "خصم")
                {
                    textColor = Color.FromArgb(29, 78, 216); // Blue
                }

                TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font, e.CellBounds, textColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                e.Handled = true;
            }
            else if (colName == "DateTimeText" && !btnTabInventory.Checked)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                string text = e.Value?.ToString() ?? "";
                Color textColor = Color.FromArgb(30, 41, 59); // Dark slate
                
                TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font, e.CellBounds, textColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak);
                e.Handled = true;
            }
            else if (colName == "CurrentQuantity" || colName == "MinQuantity" || colName == "DamagedQuantity")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                string text = e.Value?.ToString() ?? "0";
                Color textColor = Color.FromArgb(100, 116, 139); // Default Slate Gray

                if (colName == "CurrentQuantity")
                {
                    int currentQty = Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells["CurrentQuantity"].Value ?? 0);
                    int minQty = Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells["MinQuantity"].Value ?? 0);
                    if (currentQty < minQty)
                    {
                        textColor = Color.FromArgb(220, 38, 38); // Red
                    }
                    else
                    {
                        textColor = Color.FromArgb(30, 41, 59); // Dark Blue/Slate
                    }
                }
                else if (colName == "DamagedQuantity")
                {
                    int damagedQty = Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells["DamagedQuantity"].Value ?? 0);
                    if (damagedQty > 0)
                    {
                        textColor = Color.FromArgb(220, 38, 38); // Red
                    }
                }

                TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font, e.CellBounds, textColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                e.Handled = true;
            }
        }

        private void DgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvInventory.Columns[e.ColumnIndex].Name == "Actions" && btnTabInventory.Checked)
            {
                var row = dgvInventory.Rows[e.RowIndex];
                var vm = row.DataBoundItem as InventoryItemViewModel;
                if (vm == null) return;

                Rectangle cellRect = dgvInventory.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point mousePos = dgvInventory.PointToClient(Cursor.Position);
                int relativeX = mousePos.X - cellRect.X;

                var (isAdjust, isEdit, isDelete) = gridRenderer.GetClickedButton(cellRect, relativeX);

                if (isAdjust) HandleAdjustClick(vm);
                else if (isEdit) HandleEditClick(vm);
                else if (isDelete) HandleDeleteClick(vm);
            }
        }

        private void HandleEditClick(InventoryItemViewModel vm)
        {
            if (currentUser != null && currentUser.Role == UserRole.Staff)
            {
                MessageBox.Show("ليس لديك صلاحية تعديل بيانات الصنف.", "صلاحية مرفوضة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dlg = new EditInventoryDialog(vm))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void HandleAdjustClick(InventoryItemViewModel vm)
        {
            using (var dlg = new AdjustStockDialog(vm, currentUser))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void HandleDeleteClick(InventoryItemViewModel vm)
        {
            if (currentUser != null && currentUser.Role == UserRole.Staff)
            {
                MessageBox.Show("ليس لديك صلاحية حذف الأصناف.", "صلاحية مرفوضة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"هل أنت متأكد من حذف الصنف '{vm.ProductName}' نهائياً من النظام؟\nسيؤدي هذا إلى حذف كل السجلات المتعلقة به في المخزون.", 
                "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2,
                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                try
                {
                    Inventory.DeleteProductWithInventory(vm.ProductRef);
                    MessageBox.Show("تم حذف الصنف وكل متعلقاته بنجاح.", "تم العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء الحذف: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetFilterButtonsState(Control activeBtn)
        {
            var buttons = new[] { btnFilterAll, btnFilterSportsBalls, btnFilterEquipment, btnFilterSupplies, btnFilterLighting };
            foreach (var btn in buttons)
                if (btn != null) btn.Checked = (btn == activeBtn);
        }

        private void btnFilterAll_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterAll);
            ApplyFiltersAndSearch();
        }

        private void btnFilterSportsBalls_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterSportsBalls);
            ApplyFiltersAndSearch();
        }

        private void btnFilterEquipment_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterEquipment);
            ApplyFiltersAndSearch();
        }

        private void btnFilterSupplies_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterSupplies);
            ApplyFiltersAndSearch();
        }

        private void btnFilterLighting_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterLighting);
            ApplyFiltersAndSearch();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        private void btnTabInventory_Click(object sender, EventArgs e)
        {
            btnTabInventory.Checked = true;
            btnTabMovements.Checked = false;
            ApplyFiltersAndSearch();
        }

        private void btnTabMovements_Click(object sender, EventArgs e)
        {
            btnTabMovements.Checked = true;
            btnTabInventory.Checked = false;
            ApplyFiltersAndSearch();
        }

        private void btnDamagedGoods_Click(object sender, EventArgs e)
        {
            using (var dlg = new Forms.DialogForms.DamagedGoodsDialog(currentUser))
            {
                dlg.ShowDialog();
                LoadData();
            }
        }

        private void panelAlert_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, panelAlert.Width - 1, panelAlert.Height - 1);
            int radius = 12;
            using (var path = new GraphicsPath())
            {
                int d = radius * 2;
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                using (var brush = new SolidBrush(Color.FromArgb(239, 246, 255)))
                {
                    e.Graphics.FillPath(brush, path);
                }
                using (var pen = new Pen(Color.FromArgb(191, 219, 254), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }


    // --- Modern Sleek Custom Dialog Classes ---

    public class EditInventoryDialog : Form
    {
        private InventoryItemViewModel targetVm;
        private TextBox txtName;
        private ComboBox cmbCat;
        private NumericUpDown numMin;
        private Button btnSave;
        private Button btnCancel;

        public EditInventoryDialog(InventoryItemViewModel vm)
        {
            this.targetVm = vm;
            InitializeDialog();
        }

        private void InitializeDialog()
        {
            this.Text = "تعديل بيانات الصنف";
            this.Size = new Size(450, 320);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Font = new Font("Tajawal", 10.5f);
            this.BackColor = Color.White;

            var lblTitle = new Label { Text = "تعديل بيانات صنف المخزون", Font = new Font("Tajawal", 14f, FontStyle.Bold), ForeColor = Color.MidnightBlue, Location = new Point(20, 15), Size = new Size(400, 30) };
            
            var lblName = new Label { Text = "اسم الصنف:", Location = new Point(20, 65), Size = new Size(100, 25) };
            txtName = new TextBox { Text = targetVm.ProductName, Location = new Point(130, 62), Size = new Size(280, 28) };

            var lblCat = new Label { Text = "الفئة التصنيفية:", Location = new Point(20, 115), Size = new Size(100, 25) };
            cmbCat = new ComboBox { Location = new Point(130, 112), Size = new Size(280, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            LoadCategories();

            var lblMin = new Label { Text = "الحد الأدنى للتنبيه:", Location = new Point(20, 165), Size = new Size(110, 25) };
            numMin = new NumericUpDown { Value = targetVm.MinQuantity, Minimum = 0, Maximum = 9999, Location = new Point(130, 162), Size = new Size(100, 28) };

            btnSave = new Button { Text = "حفظ التغييرات", Location = new Point(260, 220), Size = new Size(150, 40), BackColor = Color.FromArgb(41, 51, 146), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += btnSave_Click;

            btnCancel = new Button { Text = "إلغاء", Location = new Point(130, 220), Size = new Size(120, 40), BackColor = Color.FromArgb(243, 244, 246), FlatStyle = FlatStyle.Flat };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] { lblTitle, lblName, txtName, lblCat, cmbCat, lblMin, numMin, btnSave, btnCancel });
        }

        private void LoadCategories()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string q = "SELECT category_ref, category_name FROM INVENTORY_CATEGORIES";
                    using (var cmd = new SqlCommand(q, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var items = new List<KeyValuePair<string, string>>();
                        while (reader.Read())
                        {
                            items.Add(new KeyValuePair<string, string>(reader.GetString(0), reader.GetString(1)));
                        }
                        cmbCat.DataSource = items;
                        cmbCat.DisplayMember = "Value";
                        cmbCat.ValueMember = "Key";

                        // Select current
                        var match = items.FirstOrDefault(x => x.Value == targetVm.CategoryName);
                        if (match.Key != null)
                        {
                            cmbCat.SelectedValue = match.Key;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الفئات: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("يرجى إدخال اسم الصنف.");
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string q = @"UPDATE PRODUCTS 
                                 SET product_name = @name, category_ref = @cat_ref, min_quantity = @min 
                                 WHERE product_ref = @ref";
                    using (var cmd = new SqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@cat_ref", cmbCat.SelectedValue);
                        cmd.Parameters.AddWithValue("@min", (int)numMin.Value);
                        cmd.Parameters.AddWithValue("@ref", targetVm.ProductRef);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("تم تحديث بيانات الصنف بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حفظ التعديلات: " + ex.Message);
            }
        }
    }

    public class AdjustStockDialog : Form
    {
        private InventoryItemViewModel targetVm;
        private Employee? _currentUser;
        private RadioButton rdbAdjust;
        private RadioButton rdbDamaged;
        private NumericUpDown numQty;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnCancel;

        public AdjustStockDialog(InventoryItemViewModel vm, Employee? user = null)
        {
            this.targetVm = vm;
            this._currentUser = user;
            InitializeDialog();
        }

        private void InitializeDialog()
        {
            this.Text = "تعديل المخزون / تسجيل تالف";
            this.Size = new Size(450, 360);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Font = new Font("Tajawal", 10.5f);
            this.BackColor = Color.White;

            var lblTitle = new Label { Text = "تسوية المخزون وإدارة الهالك", Font = new Font("Tajawal", 14f, FontStyle.Bold), ForeColor = Color.MidnightBlue, Location = new Point(20, 15), Size = new Size(400, 30) };

            rdbAdjust = new RadioButton { Text = "تعديل كمية المخزون الحالي لتصبح", Checked = true, Location = new Point(20, 60), Size = new Size(250, 25) };
            rdbDamaged = new RadioButton { Text = "تسجيل بضاعة تالفة / هالكة من المخزون", Checked = false, Location = new Point(20, 95), Size = new Size(280, 25) };

            var lblQty = new Label { Text = "الكمية:", Location = new Point(20, 145), Size = new Size(80, 25) };
            numQty = new NumericUpDown { Value = targetVm.CurrentQuantity, Minimum = 0, Maximum = 99999, Location = new Point(130, 142), Size = new Size(120, 28) };

            rdbDamaged.CheckedChanged += (s, e) =>
            {
                if (rdbDamaged.Checked)
                {
                    numQty.Value = 1; // Default damaged to 1
                }
                else
                {
                    numQty.Value = targetVm.CurrentQuantity;
                }
            };

            var lblNotes = new Label { Text = "السبب / ملاحظات:", Location = new Point(20, 195), Size = new Size(110, 25) };
            txtNotes = new TextBox { Location = new Point(130, 192), Size = new Size(280, 50), Multiline = true };

            btnSave = new Button { Text = "تأكيد العملية", Location = new Point(260, 265), Size = new Size(150, 40), BackColor = Color.FromArgb(5, 150, 105), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += btnSave_Click;

            btnCancel = new Button { Text = "إلغاء", Location = new Point(130, 265), Size = new Size(120, 40), BackColor = Color.FromArgb(243, 244, 246), FlatStyle = FlatStyle.Flat };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] { lblTitle, rdbAdjust, rdbDamaged, lblQty, numQty, lblNotes, txtNotes, btnSave, btnCancel });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int enteredQty = (int)numQty.Value;
            bool isDamagedMode = rdbDamaged.Checked;

            if (isDamagedMode && enteredQty > targetVm.CurrentQuantity)
            {
                MessageBox.Show("لا يمكن تسجيل كمية تالفة أكبر من الكمية الحالية المتوفرة في المخزون.");
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (var trans = conn.BeginTransaction())
                    {
                        try
                        {
                            int currentQty = 0;
                            int damagedQty = 0;
                            string getQ = "SELECT current_quantity, damaged_quantity FROM INVENTORY WHERE product_ref = @ref";
                            using (var cmd = new SqlCommand(getQ, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@ref", targetVm.ProductRef);
                                using (var reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        currentQty = reader.GetInt32(0);
                                        damagedQty = reader.GetInt32(1);
                                    }
                                }
                            }

                            int newQty = currentQty;
                            int newDamaged = damagedQty;
                            string mType = "adjusted";

                            if (isDamagedMode)
                            {
                                mType = "damaged";
                                newQty = Math.Max(0, currentQty - enteredQty);
                                newDamaged = damagedQty + enteredQty;
                            }
                            else
                            {
                                newQty = enteredQty;
                                mType = "adjusted";
                            }

                            // Update inventory
                            string updateQ = "UPDATE INVENTORY SET current_quantity = @curr, damaged_quantity = @dmg WHERE product_ref = @ref";
                            using (var cmd = new SqlCommand(updateQ, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@curr", newQty);
                                cmd.Parameters.AddWithValue("@dmg", newDamaged);
                                cmd.Parameters.AddWithValue("@ref", targetVm.ProductRef);
                                cmd.ExecuteNonQuery();
                            }

                            // Insert movement log
                            string uniqueSuffix = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
                            string movRef = isDamagedMode ? $"MOV-DMG-{uniqueSuffix}" : $"MOV-ADJ-{uniqueSuffix}";
                            int deltaQty = isDamagedMode ? enteredQty : (newQty - currentQty);

                            string insMovement = @"INSERT INTO INVENTORY_MOVEMENTS (movement_ref, item_ref, employee_id, movement_date, movement_time, movement_type, quantity, notes) 
                                                   VALUES (@mov_ref, @item_ref, @emp_id, @date, @time, @type, @qty, @notes)";
                            using (var cmd = new SqlCommand(insMovement, conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@mov_ref", movRef);
                                cmd.Parameters.AddWithValue("@item_ref", targetVm.ProductRef);
                                cmd.Parameters.AddWithValue("@emp_id", _currentUser != null ? (object)_currentUser.EmployeeID : DBNull.Value);
                                cmd.Parameters.AddWithValue("@date", DateTime.Today);
                                cmd.Parameters.AddWithValue("@time", DateTime.Now.TimeOfDay);
                                cmd.Parameters.AddWithValue("@type", mType);
                                cmd.Parameters.AddWithValue("@qty", Math.Abs(deltaQty));
                                
                                string noteText = txtNotes.Text.Trim();
                                if (isDamagedMode)
                                {
                                    noteText = string.IsNullOrEmpty(noteText) ? "تقرير تالف" : $"تقرير تالف - {noteText}";
                                }
                                else
                                {
                                    noteText = string.IsNullOrEmpty(noteText) ? "تعديل رصيد" : $"تعديل رصيد - {noteText}";
                                }
                                cmd.Parameters.AddWithValue("@notes", noteText);
                                cmd.ExecuteNonQuery();
                            }

                            trans.Commit();
                            MessageBox.Show("تم تسوية كميات المخزون بنجاح وتسجيل الحركة.", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء إجراء التسوية: " + ex.Message);
            }
        }
    }
}
