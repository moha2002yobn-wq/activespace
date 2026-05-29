using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Forms.DialogForms;
using ActiveSpaceSystem.Models.enums;
using ActiveSpaceSystem.Forms.GridStyle;
using ActiveSpaceSystem.Forms.Views;

namespace ActiveSpaceSystem.Forms.SideForms
{
    public partial class MonthlyContractForm : Form
    {
        private Color ColorActiveBack = Color.FromArgb(232, 245, 233);
        private Color ColorActiveText = Color.FromArgb(46, 125, 50);
        private Color ColorExpiredBack = Color.FromArgb(255, 235, 238);
        private Color ColorExpiredText = Color.FromArgb(198, 40, 40);
        private Color ColorCanceledBack = Color.FromArgb(245, 245, 245);
        private Color ColorCanceledText = Color.FromArgb(117, 117, 117);

        private BindingList<ContractViewModel> contractsBindingList;
        private ImageList actionImageList;
        private ContractGridRenderer gridRenderer;
        private Employee CurrentUser { get; set; }

        public MonthlyContractForm(Employee user)
        {
            InitializeComponent();
            this.TopLevel = false;

            InitializeActionImages();
            SetupGrid();

            this.Load += MonthlyContractForm_Load;
            CurrentUser = user;
        }

        private void InitializeActionImages()
        {
            actionImageList = new ImageList { ImageSize = new Size(32, 32), ColorDepth = ColorDepth.Depth32Bit };
            gridRenderer = new ContractGridRenderer(actionImageList);

            try
            {
                var assembly = typeof(MonthlyContractForm).Assembly;
                using (var editStream = assembly.GetManifestResourceStream("ActiveSpaceSystem.Resources.icons8-edit-48.png"))
                    if (editStream != null) actionImageList.Images.Add("edit", Image.FromStream(editStream));

                using (var deleteStream = assembly.GetManifestResourceStream("ActiveSpaceSystem.Resources.icons8-delete-48.png"))
                    if (deleteStream != null) actionImageList.Images.Add("delete", Image.FromStream(deleteStream));
            }
            catch { }
        }

        private void SetupGrid()
        {
            dgvMonthlyContract.DataSource = null;
            dgvMonthlyContract.Columns.Clear();
            dgvMonthlyContract.AutoGenerateColumns = false;

            dgvMonthlyContract.RowTemplate.Height = 55;
            dgvMonthlyContract.ColumnHeadersHeight = 45;
            dgvMonthlyContract.EnableHeadersVisualStyles = false;
            dgvMonthlyContract.DefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 249, 250);
            dgvMonthlyContract.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvMonthlyContract.DefaultCellStyle.Font = new Font("Tajawal", 9);
            dgvMonthlyContract.ColumnHeadersDefaultCellStyle.Font = new Font("Tajawal", 10, FontStyle.Bold);

            AddColumns();

            dgvMonthlyContract.CellPainting += dgvMonthlyContract_CellPainting;
            dgvMonthlyContract.CellClick += dgvMonthlyContract_CellClick;
        }

        private void AddColumns()
        {
            dgvMonthlyContract.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerName", HeaderText = "اسم العميل", Name = "CustomerName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvMonthlyContract.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PhoneNumber", HeaderText = "رقم الهاتف", Width = 110 });
            dgvMonthlyContract.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CourtName", HeaderText = "الملعب", Width = 110 });
            dgvMonthlyContract.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DayOfWeek", HeaderText = "اليوم", Width = 80 });
            dgvMonthlyContract.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TimeSlot", HeaderText = "الفترة", Width = 110 });
            dgvMonthlyContract.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StartDate", HeaderText = "البداية", Width = 95 });
            dgvMonthlyContract.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EndDate", HeaderText = "النهاية", Width = 95 });
            dgvMonthlyContract.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", HeaderText = "المبلغ", Width = 80 });
            dgvMonthlyContract.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "الحالة", Name = "Status", Width = 100 });
            dgvMonthlyContract.Columns.Add(new DataGridViewTextBoxColumn { Name = "Actions", HeaderText = "الإجراءات", Width = 110 });
        }

        private void MonthlyContractForm_Load(object sender, EventArgs e)
        {
            RefreshContractsGrid();
            dgvMonthlyContract.ClearSelection();
        }

        public void RefreshContractsGrid()
        {
            var data = MonthlyContract.GetAll()
                .Select(ContractViewModel.FromContract)
                .ToList();

            contractsBindingList = new BindingList<ContractViewModel>(data);
            dgvMonthlyContract.DataSource = contractsBindingList;

            UpdateDashboardCards();
        }

        private void dgvMonthlyContract_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvMonthlyContract.Columns[e.ColumnIndex].Name == "Status")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                string rawStatus = e.Value?.ToString();

                Color backColor = ColorActiveBack;
                Color textColor = ColorActiveText;
                string displayStatus = "نشط";

                if (rawStatus == "Expired") { backColor = ColorExpiredBack; textColor = ColorExpiredText; displayStatus = "منتهي"; }
                else if (rawStatus == "Canceled") { backColor = ColorCanceledBack; textColor = ColorCanceledText; displayStatus = "ملغي"; }

                using (GraphicsPath path = new GraphicsPath())
                {
                    Rectangle rect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 16, e.CellBounds.Width - 16, e.CellBounds.Height - 32);
                    int d = rect.Height;
                    path.AddArc(rect.X, rect.Y, d, d, 90, 180);
                    path.AddArc(rect.Right - d, rect.Y, d, d, 270, 180);
                    path.CloseFigure();
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (SolidBrush sb = new SolidBrush(backColor)) e.Graphics.FillPath(sb, path);
                }
                TextRenderer.DrawText(e.Graphics, displayStatus, e.CellStyle.Font, e.CellBounds, textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                e.Handled = true;
            }
            else if (dgvMonthlyContract.Columns[e.ColumnIndex].Name == "Actions")
            {
                gridRenderer.RenderActionsCell(e);
            }
        }

        private void dgvMonthlyContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvMonthlyContract.Columns[e.ColumnIndex].Name == "Actions")
            {
                var cellRect = dgvMonthlyContract.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var mousePos = dgvMonthlyContract.PointToClient(Cursor.Position);
                int relativeX = mousePos.X - cellRect.X;

                var (isEdit, isDelete) = gridRenderer.GetClickedButton(cellRect, relativeX);

                if (isEdit) HandleEdit(e.RowIndex);
                else if (isDelete) HandleDelete(e.RowIndex);
            }
        }

        private void HandleEdit(int rowIndex)
        {
            if (CurrentUser.Role != UserRole.Admin)
            {
                MessageBox.Show("عذرًا، لا تمتلك صلاحية تعديل العقود.", "صلاحيات غير كافية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var item = dgvMonthlyContract.Rows[rowIndex].DataBoundItem as ContractViewModel;
            if (item == null) return;

            var contract = MonthlyContract.GetByRef(item.ContractID);
            if (contract != null)
            {
                using (var editForm = new AddContract(contract))
                {
                    if (editForm.ShowDialog() == DialogResult.OK) RefreshContractsGrid();
                }
            }
        }

        private void HandleDelete(int rowIndex)
        {
            if (CurrentUser.Role != UserRole.Admin)
            {
                MessageBox.Show("عذرًا، لا تمتلك صلاحية حذف العقود.", "صلاحيات غير كافية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = dgvMonthlyContract.Rows[rowIndex].DataBoundItem as ContractViewModel;
            if (item == null) return;

            if (MessageBox.Show("هل أنت متأكد من حذف هذا العقد وجميع متعلقاته؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // حذف العقد والحجوزات المرتبطة به من قاعدة البيانات
                MonthlyContract.Delete(item.ContractID);

                // تحديث الواجهة
                contractsBindingList.RemoveAt(rowIndex);
                UpdateDashboardCards();

                // تحديث فورم العملاء إذا كان مفتوحاً
                NotifyCustomerFormUpdate();

                MessageBox.Show("تم حذف العقد بنجاح.", "إشعار", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NotifyCustomerFormUpdate()
        {
            var customerForm = Application.OpenForms.OfType<MangeCustomers>().FirstOrDefault();
            customerForm?.LoadData();
        }

        private void UpdateDashboardCards()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // عدد العقود النشطة
                    string q1 = "SELECT COUNT(*) FROM MONTHLY_CONTRACTS WHERE payment_status = N'مدفوع'";
                    using (var cmd = new SqlCommand(q1, conn))
                    {
                        if (statusCardCont != null) statusCardCont.ValueText = cmd.ExecuteScalar().ToString();
                    }

                    // إجمالي الإيرادات من العقود النشطة
                    string q2 = "SELECT ISNULL(SUM(monthly_value), 0) FROM MONTHLY_CONTRACTS WHERE payment_status = N'مدفوع'";
                    using (var cmd = new SqlCommand(q2, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        double total = res != DBNull.Value && res != null ? Convert.ToDouble(res) : 0.0;
                        if (statusCardTotal != null) statusCardTotal.ValueText = total.ToString("N0") + " د.ل";
                    }

                    // العقود المنتهية قريباً (هذا الشهر)
                    string q3 = "SELECT COUNT(*) FROM MONTHLY_CONTRACTS WHERE MONTH(end_date) = @month AND YEAR(end_date) = @year";
                    using (var cmd = new SqlCommand(q3, conn))
                    {
                        cmd.Parameters.AddWithValue("@month", DateTime.Now.Month);
                        cmd.Parameters.AddWithValue("@year", DateTime.Now.Year);
                        if (statusCardEXP != null) statusCardEXP.ValueText = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch { }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddContract())
            {
                if (addForm.ShowDialog() == DialogResult.OK) RefreshContractsGrid();
            }
        }
    }
}