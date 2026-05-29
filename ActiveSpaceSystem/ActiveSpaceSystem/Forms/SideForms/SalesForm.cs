using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ActiveSpace.Models;
using ActiveSpaceSystem.Forms.DialogForms;
using ActiveSpaceSystem.Forms.GridStyle;
using ActiveSpaceSystem.Forms.Views;
using ActiveSpaceSystem.Models;
using ActiveSpaceSystem.Models.enums;

namespace ActiveSpaceSystem.Forms.SideForms
{
    public partial class SalesForm : Form
    {
        private ImageList actionImageList;
        private PurchaseGridRenderer gridRenderer;
        private Employee currentUser;

        public SalesForm(Employee user)
        {
            InitializeComponent();
            this.TopLevel = false;
            currentUser = user;
            InitializeActionImages();
            SetupGrid();
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

            gridRenderer = new PurchaseGridRenderer(actionImageList);
        }

        private void SetupGrid()
        {
            dgvPurchases.AutoGenerateColumns = false;
            dgvPurchases.RowHeight = 55;
            dgvPurchases.RowTemplate.Height = 55;

            dgvPurchases.CellPainting -= DgvPurchases_CellPainting;
            dgvPurchases.CellClick -= DgvPurchases_CellClick;

            dgvPurchases.CellPainting += DgvPurchases_CellPainting;
            dgvPurchases.CellClick += DgvPurchases_CellClick;

            AddColumns();
        }

        private void AddColumns()
        {
            dgvPurchases.Columns.Clear();

            var columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Date", HeaderText = "التاريخ", Name = "Date", Width = 110 },
                new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "الفئة", Name = "Category", Width = 140 },
                new DataGridViewTextBoxColumn { DataPropertyName = "ItemName", HeaderText = "اسم الصنف", Name = "ItemName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
                new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "الكمية", Name = "Quantity", Width = 90 },
                new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "سعر الوحدة", Name = "UnitPrice", Width = 110 },
                new DataGridViewTextBoxColumn { DataPropertyName = "TotalPrice", HeaderText = "الإجمالي", Name = "TotalPrice", Width = 120 },
                new DataGridViewTextBoxColumn { DataPropertyName = "SupplierName", HeaderText = "المورد", Name = "SupplierName", Width = 130 },
                new DataGridViewTextBoxColumn { DataPropertyName = "AssociatedCourt", HeaderText = "الملعب المرتبط", Name = "AssociatedCourt", Width = 230, MinimumWidth = 220, FillWeight = 160 },
                new DataGridViewTextBoxColumn { Name = "Actions", HeaderText = "الإجراءات", Width = 110 }
            };

            dgvPurchases.Columns.AddRange(columns);
        }

        private void DgvPurchases_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvPurchases.Columns[e.ColumnIndex].Name;

            // Paint default backgrounds and borders
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

            if (colName == "Actions")
            {
                if (gridRenderer != null)
                {
                    gridRenderer.RenderActionsCell(e);
                }
                e.Handled = true;
            }
            else if (colName == "Category")
            {
                string category = e.Value?.ToString() ?? "";
                if (gridRenderer != null)
                {
                    gridRenderer.RenderCategoryCell(e, category);
                }
                e.Handled = true;
            }
            else if (colName == "AssociatedCourt")
            {
                string courtName = e.Value?.ToString() ?? "";
                if (gridRenderer != null)
                {
                    gridRenderer.RenderCourtCell(e, courtName);
                }
                e.Handled = true;
            }
            else if (colName == "UnitPrice" || colName == "TotalPrice")
            {
                decimal val = 0;
                if (e.Value != null)
                {
                    decimal.TryParse(e.Value.ToString(), out val);
                }
                
                string rlm = "\u200F";
                string text = $"{rlm}{val:N0} د.ل";
                
                Color color = colName == "TotalPrice" ? Color.FromArgb(29, 78, 216) : Color.FromArgb(70, 70, 70);
                if ((e.State & DataGridViewElementStates.Selected) != 0)
                {
                    color = e.CellStyle.SelectionForeColor;
                }

                using (Font font = new Font("Tajawal", 10.5f, colName == "TotalPrice" ? FontStyle.Bold : FontStyle.Regular))
                {
                    TextRenderer.DrawText(e.Graphics, text, font, e.CellBounds, color,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.RightToLeft);
                }
                e.Handled = true;
            }
        }

        private void DgvPurchases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvPurchases.Columns[e.ColumnIndex].Name == "Actions")
            {
                try
                {
                    Rectangle cellRect = dgvPurchases.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    Point mousePos = dgvPurchases.PointToClient(Cursor.Position);
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
                MessageBox.Show("ليس لديك صلاحية تعديل المشتريات.", "صلاحية مرفوضة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var vm = dgvPurchases.Rows[rowIndex].DataBoundItem as PurchaseViewModel;
            if (vm == null) return;

            var purchase = Purchase.GetByRef(vm.PurchaseRef);
            if (purchase == null) return;

            using (AddPurchaseForm frm = new AddPurchaseForm(purchase, currentUser))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void HandleDeleteClick(int rowIndex)
        {
            if (currentUser == null || currentUser.Role == UserRole.Staff)
            {
                MessageBox.Show("ليس لديك صلاحية حذف المشتريات.", "صلاحية مرفوضة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var vm = dgvPurchases.Rows[rowIndex].DataBoundItem as PurchaseViewModel;
            if (vm == null) return;

            if (MessageBox.Show($"هل أنت متأكد من حذف المشتريات لصنف '{vm.ItemName}'؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2,
                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                Purchase.Delete(vm.PurchaseRef);
                LoadData();
            }
        }

        public void LoadData()
        {
            var purchases = Purchase.GetAll();
            var viewModels = purchases.Select(PurchaseViewModel.FromPurchase).ToList();

            ApplyFiltersAndSearch(viewModels);
        }

        private void ApplyFiltersAndSearch(List<PurchaseViewModel> list)
        {
            string searchText = txtSearch.Texts.Trim().ToLower();

            string currentCategory = "الكل";
            if (btnFilterSportsBalls.Checked) currentCategory = "معدات رياضية";
            else if (btnFilterEquipment.Checked) currentCategory = "مبيعات مقهى";
            else if (btnFilterLighting.Checked) currentCategory = "نظافة";

            var filtered = list.Where(x =>
                (currentCategory == "الكل" || x.Category == currentCategory) &&
                (string.IsNullOrEmpty(searchText) ||
                 x.ItemName.ToLower().Contains(searchText) ||
                 x.SupplierName.ToLower().Contains(searchText) ||
                 x.Category.ToLower().Contains(searchText))
            ).ToList();

            dgvPurchases.DataSource = null;
            dgvPurchases.DataSource = filtered;

            UpdateStatistics(filtered);
        }

        private void UpdateStatistics(List<PurchaseViewModel> list)
        {
            decimal totalAll = list.Sum(x => x.TotalPrice);

            DateTime today = DateTime.Now;
            decimal monthlyTotal = list
                .Where(x => DateTime.TryParse(x.Date, out DateTime dt) && dt.Year == today.Year && dt.Month == today.Month)
                .Sum(x => x.TotalPrice);

            int distinctItemsCount = list.Select(x => x.ItemName).Distinct().Count();

            string rlm = "\u200F";
            cardTotalPurchases.ValueText = $"{rlm}{totalAll:N0} د.ل";
            cardMonthPurchases.ValueText = $"{rlm}{monthlyTotal:N0} د.ل";
            cardItemCount.ValueText = distinctItemsCount.ToString();
        }

        private void SetFilterButtonsState(Control activeBtn)
        {
            var buttons = new[] { btnFilterAll, btnFilterSportsBalls, btnFilterEquipment, btnFilterLighting };
            foreach (var btn in buttons)
                if (btn != null) btn.Checked = (btn == activeBtn);
        }

        private void btnFilterAll_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterAll);
            LoadData();
        }

        private void btnFilterSportsBalls_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterSportsBalls);
            LoadData();
        }

        private void btnFilterEquipment_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterEquipment);
            LoadData();
        }

        private void btnFilterLighting_Click(object sender, EventArgs e)
        {
            SetFilterButtonsState(btnFilterLighting);
            LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnOpenAdd_Click(object sender, EventArgs e)
        {
            using (AddPurchaseForm frm = new AddPurchaseForm(currentUser))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            btnFilterSportsBalls.Text = "معدات رياضية";
            btnFilterEquipment.Text = "مبيعات مقهى";
            btnFilterLighting.Text = "نظافة";

            LoadData();
        }
    }
}
