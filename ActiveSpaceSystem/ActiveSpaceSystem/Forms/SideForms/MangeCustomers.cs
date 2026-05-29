using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Forms.DialogForms;
using ActiveSpaceSystem.Forms.GridStyle;
using ActiveSpaceSystem.Forms.Views;
using ActiveSpaceSystem.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ActiveSpaceSystem.Forms.SideForms
{
    public partial class MangeCustomers : Form
    {
        private BindingList<CustomerViewModel> customersList;
        private ImageList actionImageList;
        private CustomerGridRenderer gridRenderer;
        private Employee currentUser;

        public MangeCustomers(Employee user)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Load += MangeCustomers_Load;
            currentUser = user;
        }

        private void InitializeActionImages()
        {
            actionImageList = new ImageList();
            actionImageList.ImageSize = new Size(32, 32);
            actionImageList.ColorDepth = ColorDepth.Depth32Bit;
            gridRenderer = new CustomerGridRenderer(actionImageList);

            try
            {
                var assembly = typeof(ManageBooking).Assembly;
                using (var editStream = assembly.GetManifestResourceStream("ActiveSpaceSystem.Resources.icons8-edit-48.png"))
                {
                    if (editStream != null) actionImageList.Images.Add("edit", Image.FromStream(editStream));
                }
                using (var deleteStream = assembly.GetManifestResourceStream("ActiveSpaceSystem.Resources.icons8-delete-48.png"))
                {
                    if (deleteStream != null) actionImageList.Images.Add("delete", Image.FromStream(deleteStream));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Resource Error: " + ex.Message);
            }
        }

        private void SetupGrid()
        {
            dgvCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvCustomers.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvCustomers.CellPainting += DgvCustomers_CellPainting;
            dgvCustomers.CellClick += DgvCustomers_CellClick;
            AddColumns();
        }

        private void AddColumns()
        {
            dgvCustomers.Columns.Clear();

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "اسم العميل",
                Name = "FullName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "رقم الهاتف",
                Name = "Phone",
                Width = 120
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalDebt",
                HeaderText = "إجمالي الدين",
                Name = "TotalDebt",
                Width = 100
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NoShowCount",
                HeaderText = "غياب",
                Name = "NoShowCount",
                Width = 70
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastBookingDate",
                HeaderText = "آخر حجز",
                Name = "LastBookingDate",
                Width = 120
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Actions",
                HeaderText = "الإجراءات",
                Width = 120
            });
        }

        private void MangeCustomers_Load(object sender, EventArgs e)
        {
            InitializeActionImages();
            SetupGrid();
            LoadData();
            btnAll.IsToggled = true;

            if (dgvCustomers.Rows.Count > 0)
                dgvCustomers.ClearSelection();
        }

        public void LoadData()
        {
            try
            {
                var data = Customer.GetAll().Select(CustomerViewModel.FromCustomer).ToList();
                customersList = new BindingList<CustomerViewModel>(data);
                dgvCustomers.DataSource = customersList;

                if (dgvCustomers.Columns["CustomerId"] != null)
                    dgvCustomers.Columns["CustomerId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message);
            }
            updateStatisticsCards();
        }

        private void DgvCustomers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dgvCustomers.Columns[e.ColumnIndex].Name;

            if (columnName == "Actions")
            {
                gridRenderer.RenderActionsCell(e);
            }
        }

        private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvCustomers.Columns[e.ColumnIndex].Name == "Actions")
            {
                var cellRect = dgvCustomers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var mousePos = dgvCustomers.PointToClient(Cursor.Position);
                int relativeX = mousePos.X - cellRect.X;

                var (isEdit, isDelete) = gridRenderer.GetClickedButton(cellRect, relativeX);

                if (isEdit) HandleEditClick(e.RowIndex);
                else if (isDelete) HandleDeleteClick(e.RowIndex);
            }
        }

        private void HandleEditClick(int rowIndex)
        {
            if (currentUser.Role != UserRole.Admin)
            {
                MessageBox.Show("عذراً، لا تمتلك صلاحيات التعديل.", "صلاحيات غير كافية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rowIndex < 0 || dgvCustomers.Rows[rowIndex].DataBoundItem == null) return;

            var selectedCustomerVm = (CustomerViewModel)dgvCustomers.Rows[rowIndex].DataBoundItem;
            string customerId = selectedCustomerVm.CustomerId;

            var customerToEdit = Customer.GetByPhone(customerId);

            if (customerToEdit != null)
            {
                using (AddCustomerForm editForm = new AddCustomerForm(customerToEdit))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                        updateStatisticsCards();

                        var bookingForm = Application.OpenForms.OfType<ManageBooking>().FirstOrDefault();
                        if (bookingForm != null)
                        {
                            bookingForm.LoadData();
                        }
                        var paymentsForm = Application.OpenForms.OfType<PaymentForm>().FirstOrDefault();
                        if (paymentsForm != null)
                        {
                            paymentsForm.LoadData();
                        }

                        foreach (DataGridViewRow row in dgvCustomers.Rows)
                        {
                            if (((CustomerViewModel)row.DataBoundItem).CustomerId == customerId)
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("عذراً، لم يتم العثور على بيانات العميل الأصلية.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleDeleteClick(int rowIndex)
        {
            if (currentUser.Role != UserRole.Admin)
            {
                MessageBox.Show("عذراً، لا تمتلك صلاحيات الحذف.", "صلاحيات غير كافية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rowIndex < 0 || dgvCustomers.Rows[rowIndex].DataBoundItem == null) return;

            var customerVm = dgvCustomers.Rows[rowIndex].DataBoundItem as CustomerViewModel;
            if (customerVm == null) return;

            var result = MessageBox.Show("هل أنت متأكد من الحذف النهائي؟ سيتم حذف جميع الحجوزات والمدفوعات الخاصة بهذا العميل.", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Customer.Delete(customerVm.CustomerId);

                    updateStatisticsCards();
                    NotifyMonthlyContractsUpdate();

                    if (!string.IsNullOrWhiteSpace(txtSearch.Texts))
                    {
                        txtSearch__TextChanged(null, null);
                    }
                    else
                    {
                        LoadData();
                    }

                    MessageBox.Show("تم الحذف من قاعدة البيانات بنجاح.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ: {ex.Message}");
                }
            }
        }

        public void NotifyMonthlyContractsUpdate()
        {
            var form = Application.OpenForms.OfType<MonthlyContractForm>().FirstOrDefault();
            if (form != null)
            {
                form.RefreshContractsGrid();
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            AddCustomerForm addForm = new AddCustomerForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                updateStatisticsCards();
                LoadData();
            }
        }

        private void updateStatisticsCards()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // 1. Total customers
                string q1 = "SELECT COUNT(*) FROM CUSTOMERS";
                using (var cmd = new SqlCommand(q1, conn))
                {
                    customerCard2.ValueText = cmd.ExecuteScalar().ToString();
                }

                // 2. Active customers
                string q2 = "SELECT COUNT(DISTINCT customer_phone_number) FROM BOOKINGS WHERE status = @status";
                using (var cmd = new SqlCommand(q2, conn))
                {
                    cmd.Parameters.AddWithValue("@status", "مؤكد");
                    customerCard1.ValueText = cmd.ExecuteScalar().ToString();
                }

                // 3. Total debt
                string q3 = @"
                    SELECT 
                        (SELECT ISNULL(SUM(price), 0) FROM BOOKINGS WHERE status != N'ملغى') +
                        (SELECT ISNULL(SUM(monthly_value), 0) FROM MONTHLY_CONTRACTS) -
                        (SELECT ISNULL(SUM(amount), 0) FROM PAYMENTS)";
                using (var cmd = new SqlCommand(q3, conn))
                {
                    object res = cmd.ExecuteScalar();
                    double totalDebts = res != DBNull.Value && res != null ? Convert.ToDouble(res) : 0.0;
                    customerCard3.ValueText = totalDebts.ToString("N0");
                }
            }
        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Texts.Trim().ToLower();

            var filtered = Customer.GetAll()
                .Where(c => c.FullName.ToLower().Contains(searchTerm) || c.Phone.Contains(searchTerm))
                .Select(CustomerViewModel.FromCustomer)
                .ToList();

            dgvCustomers.DataSource = new BindingList<CustomerViewModel>(filtered);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                var data = Customer.GetAll().Select(CustomerViewModel.FromCustomer).ToList();
                customersList = new BindingList<CustomerViewModel>(data);

                if (dgvCustomers.Columns["CustomerId"] != null)
                    dgvCustomers.Columns["CustomerId"].Visible = false;
                dgvCustomers.DataSource = customersList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message);
            }

            SetFilterButtonsState(btnAll);
        }

        private void btnDebtFilter_Click(object sender, EventArgs e)
        {
            var debtors = Customer.GetAll()
                .Where(c => c.TotalDebt > 0)
                .Select(CustomerViewModel.FromCustomer)
                .ToList();

            dgvCustomers.DataSource = new BindingList<CustomerViewModel>(debtors);
            SetFilterButtonsState(btnDebtFilter);
        }

        private void SetFilterButtonsState(Control activeBtn)
        {
            var buttons = new[] { btnAll, btnDebtFilter };
            foreach (var btn in buttons)
                if (btn != null) btn.IsToggled = (btn == activeBtn);
        }
    }
}