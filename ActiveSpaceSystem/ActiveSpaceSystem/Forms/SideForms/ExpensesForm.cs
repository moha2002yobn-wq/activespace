using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Forms.DialogForms;
using ActiveSpaceSystem.Forms.GridStyle;
using ActiveSpaceSystem.Models;
using ActiveSpaceSystem.Models.enums;

namespace ActiveSpaceSystem.Forms.SideForms
{
    public partial class ExpensesForm : Form
    {
        private ImageList actionImageList;
        private ExpenseGridRenderer gridRenderer;
        private Employee currentUser;

        public ExpensesForm(Employee user)
        {
            InitializeComponent();
            this.TopLevel = false;
            InitializeActionImages();
            SetupGrid();
            currentUser = user;
            RefreshGrid();
        }

        private void InitializeActionImages()
        {
            actionImageList = new ImageList
            {
                ImageSize = new Size(32, 32),
                ColorDepth = ColorDepth.Depth32Bit
            };

            try
            {
                if (Properties.Resources.icons8_edit_48 != null)
                    actionImageList.Images.Add("edit", Properties.Resources.icons8_edit_48);
                
                if (Properties.Resources.icons8_delete_48 != null)
                    actionImageList.Images.Add("delete", Properties.Resources.icons8_delete_48);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"خطأ في تحميل الموارد: {ex.Message}");
            }
            
            gridRenderer = new ExpenseGridRenderer(actionImageList);
        }

        private void SetupGrid()
        {
            dgvExpenses.AutoGenerateColumns = false;
            dgvExpenses.RowHeight = 55;
            dgvExpenses.RowTemplate.Height = 55;
            dgvExpenses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            
            // Explicitly synchronize fonts with dgvPurchases (SalesForm)
            dgvExpenses.Font = new Font("Tajawal", 10.2F, FontStyle.Regular);
            dgvExpenses.ColumnHeadersDefaultCellStyle.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            dgvExpenses.DefaultCellStyle.Font = new Font("Tajawal", 10.2F, FontStyle.Regular);
            
            dgvExpenses.CellPainting -= DgvExpenses_CellPainting;
            dgvExpenses.CellClick -= DgvExpenses_CellClick;
            
            dgvExpenses.CellPainting += DgvExpenses_CellPainting;
            dgvExpenses.CellClick += DgvExpenses_CellClick;

            AddColumns();
        }

        private void AddColumns()
        {
            dgvExpenses.Columns.Clear();

            var columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "ExpenseDate", HeaderText = "التاريخ", Name = "ExpenseDate", Width = 130 },
                new DataGridViewTextBoxColumn { DataPropertyName = "CategoryName", HeaderText = "الفئة", Name = "CategoryName", Width = 150 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Description", HeaderText = "الوصف", Name = "Description", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "المبلغ", Name = "Amount", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "الحالة", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "Actions", HeaderText = "الإجراءات", Width = 120 }
            };

            dgvExpenses.Columns.AddRange(columns);
        }

        private void DgvExpenses_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvExpenses.Columns[e.ColumnIndex].Name;

            // Draw default background and borders
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

            if (colName == "Actions")
            {
                var rowItem = dgvExpenses.Rows[e.RowIndex].DataBoundItem as Expense;
                if (rowItem != null && (rowItem.Category == "مشتريات" || rowItem.CategoryRef == "CAT-EXP-002" || (rowItem.ExpenseDescription != null && rowItem.ExpenseDescription.StartsWith("شراء صنف:"))))
                {
                    Color pillBack = Color.FromArgb(224, 242, 254); // Sky Blue (sky-100)
                    Color pillText = Color.FromArgb(3, 105, 161);   // Sky Blue dark text (sky-700)
                    DrawPillBadge(e.Graphics, e.CellBounds, "التحديث من المشتريات", pillBack, pillText);
                    e.Handled = true;
                }
                else
                {
                    if (gridRenderer != null)
                    {
                        gridRenderer.RenderActionsCell(e);
                    }
                    e.Handled = true;
                }
            }
            else if (colName == "ExpenseDate")
            {
                var val = e.Value;
                if (val is DateTime dt)
                {
                    string dateText = dt.ToString("yyyy-MM-dd");
                    using (Font font = new Font("Tajawal", 10.5f, FontStyle.Regular))
                    {
                        TextRenderer.DrawText(e.Graphics, dateText, font, e.CellBounds, Color.FromArgb(70, 70, 70),
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft);
                    }
                }
                e.Handled = true;
            }
            else if (colName == "CategoryName")
            {
                string catName = e.Value?.ToString() ?? "نثريات";
                
                // Color mapping matching SalesForm tags
                Color pillBack = Color.FromArgb(232, 240, 254);
                Color pillText = Color.FromArgb(29, 78, 216);

                if (catName == "صيانة الملاعب")
                {
                    pillBack = Color.FromArgb(236, 253, 245);
                    pillText = Color.FromArgb(4, 120, 87);
                }
                else if (catName == "كهرباء" || catName == "كهرباء ومياه")
                {
                    pillBack = Color.FromArgb(243, 232, 255);
                    pillText = Color.FromArgb(110, 68, 255);
                }
                else if (catName == "رواتب الموظفين")
                {
                    pillBack = Color.FromArgb(241, 245, 249);
                    pillText = Color.FromArgb(51, 65, 85);
                }

                DrawPillBadge(e.Graphics, e.CellBounds, catName, pillBack, pillText);
                e.Handled = true;
            }
            else if (colName == "Amount")
            {
                double amt = 0;
                if (e.Value != null)
                {
                    double.TryParse(e.Value.ToString(), out amt);
                }
                string rlm = "\u200F";
                string amountText = $"{rlm}{amt:N0} د.ل";
                
                // Color matches SalesForm total price (Blue)
                Color color = Color.FromArgb(29, 78, 216);
                
                using (Font font = new Font("Tajawal", 10.5f, FontStyle.Bold))
                {
                    TextRenderer.DrawText(e.Graphics, amountText, font, e.CellBounds, color,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft);
                }
                e.Handled = true;
            }
            else if (colName == "Status")
            {
                Color pillBack = Color.FromArgb(224, 248, 237);
                Color pillText = Color.FromArgb(38, 191, 141);
                DrawPillBadge(e.Graphics, e.CellBounds, "مدفوع", pillBack, pillText);
                e.Handled = true;
            }
            else if (colName == "Description")
            {
                string descText = e.Value?.ToString() ?? "";
                using (Font font = new Font("Tajawal", 10.5f, FontStyle.Regular))
                {
                    TextRenderer.DrawText(e.Graphics, descText, font, e.CellBounds, Color.FromArgb(30, 30, 30),
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft | TextFormatFlags.WordBreak);
                }
                e.Handled = true;
            }
        }

        private void DgvExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvExpenses.Columns[e.ColumnIndex].Name == "Actions")
            {
                var rowItem = dgvExpenses.Rows[e.RowIndex].DataBoundItem as Expense;
                if (rowItem != null && (rowItem.Category == "مشتريات" || rowItem.CategoryRef == "CAT-EXP-002" || (rowItem.ExpenseDescription != null && rowItem.ExpenseDescription.StartsWith("شراء صنف:"))))
                {
                    return; // Ignore action clicks for purchase rows since they can only be edited/deleted from purchases section
                }

                try 
                {
                    Rectangle cellRect = dgvExpenses.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    Point mousePos = dgvExpenses.PointToClient(Cursor.Position);
                    int relativeX = mousePos.X - cellRect.X;

                    var (isEdit, isDelete) = gridRenderer.GetClickedButton(cellRect, relativeX);

                    if (isEdit) HandleEditClick(e.RowIndex);
                    else if (isDelete) HandleDeleteClick(e.RowIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء معالجة النقر: " + ex.Message);
                }
            }
        }

        private void HandleEditClick(int rowIndex)
        {
            if (currentUser == null || currentUser.Role == UserRole.Staff)
            {
                MessageBox.Show("ليس لديك صلاحية تعديل المصروفات.", "صلاحية مرفوضة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var item = dgvExpenses.Rows[rowIndex].DataBoundItem as Expense;
            if (item == null) return;

            if (item.Category == "مشتريات" || item.CategoryRef == "CAT-EXP-002" || (item.ExpenseDescription != null && item.ExpenseDescription.StartsWith("شراء صنف:")))
            {
                MessageBox.Show("لا يمكن تعديل المشتريات من هنا. يرجى التعديل من قسم المشتريات.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            using (AddExpens frm = new AddExpens(item, currentUser))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void HandleDeleteClick(int rowIndex)
        {
            if (currentUser == null || currentUser.Role == UserRole.Staff)
            {
                MessageBox.Show("ليس لديك صلاحية حذف المصروفات.", "صلاحية مرفوضة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var item = dgvExpenses.Rows[rowIndex].DataBoundItem as Expense;
            if (item == null) return;

            if (item.Category == "مشتريات" || item.CategoryRef == "CAT-EXP-002" || (item.ExpenseDescription != null && item.ExpenseDescription.StartsWith("شراء صنف:")))
            {
                MessageBox.Show("لا يمكن حذف المشتريات من هنا. يرجى الحذف من قسم المشتريات لإعادة ضبط المخزون بشكل صحيح.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            if (MessageBox.Show($"هل أنت متأكد من حذف مصروف '{item.Description}'؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 
                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                Expense.Delete(item.ExpenseRef);
                RefreshGrid();
            }
        }

        private void FilterByCategory(string category)
        {
            var allExpenses = Expense.GetAll();

            var filtered = (category == "الكل") 
                ? allExpenses 
                : allExpenses.Where(x => x.CategoryName == category).ToList();

            UpdateGridDataSource(filtered);
        }

        private void UpdateGridDataSource(object source)
        {
            dgvExpenses.DataSource = null;
            dgvExpenses.DataSource = source;
            UpdateStatistics();
        }

        public void RefreshGrid()
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Texts))
                txtSearch_TextChanged(null, null);
            else
                UpdateGridDataSource(Expense.GetAll());
        }

        private void UpdateStatistics()
        {
            var currentData = dgvExpenses.DataSource as List<Expense> ?? new List<Expense>();

            double totalAll = currentData.Sum(x => x.Amount);

            DateTime today = DateTime.Now;
            double monthlyTotal = currentData
                .Where(x => x.ExpenseDate.Year == today.Year && x.ExpenseDate.Month == today.Month)
                .Sum(x => x.Amount);

            advancedStatusCard4.ValueText = totalAll.ToString("N0") + " د.ل";
            advancedStatusCard3.ValueText = monthlyTotal.ToString("N0") + " د.ل";
            advancedStatusCard1.ValueText = currentData.Count.ToString();
        }

        private void SetFilterButtonsState(Control activeBtn)
        {
            var buttons = new[] { btnFilterAll, btnFilterElectricity, btnFilterMaintenance, btnFilterSalaries };
            foreach (var btn in buttons) 
                if (btn != null) btn.Checked = (btn == activeBtn);
        }

        private void btnFilterAll_Click_1(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterAll);
            FilterByCategory("الكل");
        }

        private void btnFilterMaintenance_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterMaintenance);
            FilterByCategory("مشتريات");
        }

        private void btnFilterElectricity_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterElectricity);
            FilterByCategory("كهرباء");
        }

        private void btnFilterSalaries_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterSalaries);
            FilterByCategory("رواتب الموظفين");
        }

        private void ExpensesForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            using (AddExpens frm = new AddExpens(currentUser))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var allExpenses = Expense.GetAll();
            string searchText = txtSearch.Texts.Trim().ToLower();

            string currentCategory = "الكل";
            if (btnFilterMaintenance.Checked) currentCategory = "مشتريات";
            else if (btnFilterElectricity.Checked) currentCategory = "كهرباء";
            else if (btnFilterSalaries.Checked) currentCategory = "رواتب الموظفين";

            var filtered = allExpenses.Where(x =>
                (currentCategory == "الكل" || x.CategoryName == currentCategory) &&
                ((x.Description?.ToLower() ?? "").Contains(searchText) ||
                 (x.CategoryName?.ToLower() ?? "").Contains(searchText))
            ).ToList();

            UpdateGridDataSource(filtered);
        }

        private void DrawPillBadge(Graphics g, Rectangle cellBounds, string text, Color backColor, Color textColor)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Font font = new Font("Tajawal", 9.5f, FontStyle.Bold))
            {
                Size textSize = TextRenderer.MeasureText(text, font);
                int paddingX = 14;
                int paddingY = 5;
                int pillWidth = textSize.Width + paddingX * 2;
                int pillHeight = textSize.Height + paddingY * 2;

                int pillX = cellBounds.X + (cellBounds.Width - pillWidth) / 2;
                int pillY = cellBounds.Y + (cellBounds.Height - pillHeight) / 2;

                Rectangle pillRect = new Rectangle(pillX, pillY, pillWidth, pillHeight);

                using (GraphicsPath path = GetRoundedRectPath(pillRect, pillHeight / 2))
                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    g.FillPath(brush, path);
                }

                TextRenderer.DrawText(g, text, font, pillRect, textColor, 
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft);
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            
            // Adjust diameter if it is larger than dimensions
            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;

            Rectangle arc = new Rectangle(rect.X, rect.Y, diameter, diameter);

            // Top-left
            path.AddArc(arc, 180, 90);
            // Top-right
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            // Bottom-right
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // Bottom-left
            arc.X = rect.X;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}