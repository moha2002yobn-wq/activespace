using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ActiveSpace.Models;
using ActiveSpaceSystem.Forms.GridStyle;
using ActiveSpaceSystem.CustomItems;

namespace ActiveSpaceSystem.Forms.SideForms
{
    public partial class EmployeesForm : Form
    {
        private Employee _currentUser;
        private EmployeeGridRenderer gridRenderer;
        private ImageList actionImageList;
        private List<Employee> allEmployees = new List<Employee>();
        private List<SalaryLogItem> salaryLogs = new List<SalaryLogItem>();

        public EmployeesForm() : this(null!) { }

        public EmployeesForm(Employee user)
        {
            InitializeComponent();
            _currentUser = user;

            // Setup action icons
            actionImageList = new ImageList();
            actionImageList.ImageSize = new Size(32, 32);
            actionImageList.ColorDepth = ColorDepth.Depth32Bit;
            
            if (Properties.Resources.icons8_edit_48 != null)
                actionImageList.Images.Add("edit", Properties.Resources.icons8_edit_48);
            if (Properties.Resources.icons8_delete_48 != null)
                actionImageList.Images.Add("delete", Properties.Resources.icons8_delete_48);

            gridRenderer = new EmployeeGridRenderer(actionImageList);

            // Wire up events
            btnTabEmployees.Click += BtnTabEmployees_Click;
            btnTabSalaryLog.Click += BtnTabSalaryLog_Click;
            txtSearch._TextChanged += TxtSearch_TextChanged;
            
            dgvSalaries.CellPainting += DgvSalaries_CellPainting;
            dgvSalaries.CellClick += DgvSalaries_CellClick;

            btnAddEmployee.Click += BtnAddEmployee_Click;
            btnRegisterSalary.Click += BtnRegisterSalary_Click;

            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvSalaries.Columns.Clear();
            dgvSalaries.Columns.Add("EmployeeID", "EmployeeID");
            dgvSalaries.Columns["EmployeeID"].Visible = false;

            dgvSalaries.Columns.Add("FullName", "اسم الموظف");
            dgvSalaries.Columns.Add("Month", "الشهر");
            
            dgvSalaries.Columns.Add("BasicSalary", "الراتب الأساسي");
            
            // For incentives and deductions, we store double values but custom-render them
            var incCol = new DataGridViewTextBoxColumn();
            incCol.Name = "Incentives";
            incCol.HeaderText = "الحوافز";
            dgvSalaries.Columns.Add(incCol);

            var dedCol = new DataGridViewTextBoxColumn();
            dedCol.Name = "Deductions";
            dedCol.HeaderText = "الخصومات";
            dgvSalaries.Columns.Add(dedCol);

            dgvSalaries.Columns.Add("Total", "الإجمالي");
            dgvSalaries.Columns.Add("PaymentDate", "تاريخ الدفع");
            dgvSalaries.Columns.Add("Status", "الحالة");
            
            var actionsCol = new DataGridViewImageColumn();
            actionsCol.Name = "Actions";
            actionsCol.HeaderText = "الإجراءات";
            actionsCol.Width = 100;
            dgvSalaries.Columns.Add(actionsCol);
            
            dgvSalaries.RightToLeft = RightToLeft.Yes;
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            allEmployees = Employee.GetAll();
            salaryLogs.Clear();

            // Load all salaries from DB
            var paidSalariesDict = new Dictionary<string, (DateTime Date, double Amount, double Incentives, double Deductions)>();
            try
            {
                using (var conn = ActiveSpaceSystem.Data.DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT employee_id, payment_date, amount, incentives, deductions FROM SALARIES", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string empId = reader.GetString(0);
                            DateTime payDate = reader.GetDateTime(1);
                            double amount = (double)reader.GetDecimal(2);
                            double inc = reader.IsDBNull(3) ? 0.0 : (double)reader.GetDecimal(3);
                            double ded = reader.IsDBNull(4) ? 0.0 : (double)reader.GetDecimal(4);
                            paidSalariesDict[empId] = (payDate, amount, inc, ded);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading salaries: " + ex.Message);
            }

            double totalSalariesSum = 0;
            double paidSalariesSum = 0;
            double pendingSalariesSum = 0;

            foreach (var emp in allEmployees)
            {
                var log = new SalaryLogItem
                {
                    EmployeeID = emp.EmployeeID,
                    FullName = emp.FullName,
                    Month = "مايو 2026",
                    BasicSalary = emp.Salary,
                    Incentives = 0,
                    Deductions = 0
                };

                if (paidSalariesDict.TryGetValue(emp.EmployeeID, out var paidInfo))
                {
                    log.PaymentDate = paidInfo.Date.ToString("yyyy-MM-dd");
                    log.Status = "مدفوع";
                    log.Incentives = paidInfo.Incentives;
                    log.Deductions = paidInfo.Deductions;
                    paidSalariesSum += paidInfo.Amount;
                    totalSalariesSum += paidInfo.Amount;
                    salaryLogs.Add(log);
                }
                else
                {
                    log.PaymentDate = "-";
                    log.Status = "معلق";
                    pendingSalariesSum += log.Total;
                    totalSalariesSum += log.Total;
                }
            }

            // Update stats cards
            cardTotalEmployees.ValueText = allEmployees.Count.ToString();
            cardTotalSalaries.ValueText = $"{totalSalariesSum:N0} د.ل";
            cardPaidSalaries.ValueText = $"{paidSalariesSum:N0} د.ل";
            cardPendingSalaries.ValueText = $"{pendingSalariesSum:N0} د.ل";

            RefreshUI();
        }

        private void RefreshUI()
        {
            string filterText = txtSearch.Texts.Trim().ToLower();

            // 1. Render employee cards
            flowEmployees.Controls.Clear();
            foreach (var emp in allEmployees)
            {
                if (!string.IsNullOrEmpty(filterText) && !emp.FullName.ToLower().Contains(filterText) && !emp.Position.ToLower().Contains(filterText))
                {
                    continue;
                }

                var card = new EmployeeCardControl();
                card.Employee = emp;
                card.PaySalaryClicked += (s, e) => {
                    PaySalary(emp);
                };
                card.EditClicked += (s, e) => {
                    EditEmployee(emp);
                };
                flowEmployees.Controls.Add(card);
            }

            // 2. Render salaries grid
            dgvSalaries.Rows.Clear();
            foreach (var log in salaryLogs)
            {
                if (!string.IsNullOrEmpty(filterText) && !log.FullName.ToLower().Contains(filterText))
                {
                    continue;
                }

                dgvSalaries.Rows.Add(
                    log.EmployeeID,
                    log.FullName,
                    log.Month,
                    $"{log.BasicSalary:N0} د.ل",
                    log.Incentives, 
                    log.Deductions, 
                    $"{log.Total:N0} د.ل",
                    log.PaymentDate,
                    log.Status,
                    null // Actions
                );
            }
        }

        private void BtnTabEmployees_Click(object sender, EventArgs e)
        {
            btnTabEmployees.Checked = true;
            btnTabSalaryLog.Checked = false;
            flowEmployees.Visible = true;
            dgvSalaries.Visible = false;
        }

        private void BtnTabSalaryLog_Click(object sender, EventArgs e)
        {
            btnTabEmployees.Checked = false;
            btnTabSalaryLog.Checked = true;
            flowEmployees.Visible = false;
            dgvSalaries.Visible = true;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void DgvSalaries_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // incentives
            if (e.ColumnIndex == 4)
            {
                double val = Convert.ToDouble(dgvSalaries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                gridRenderer.RenderIncentiveCell(e, val);
            }
            // deductions
            else if (e.ColumnIndex == 5)
            {
                double val = Convert.ToDouble(dgvSalaries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                gridRenderer.RenderDeductionCell(e, val);
            }
            // status
            else if (e.ColumnIndex == 8)
            {
                string status = dgvSalaries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";
                gridRenderer.RenderStatusCell(e, status);
            }
            // actions
            else if (e.ColumnIndex == 9)
            {
                gridRenderer.RenderActionsCell(e);
            }
        }

        private void DgvSalaries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 9) return;

            var cellRect = dgvSalaries.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            var relativeX = dgvSalaries.PointToClient(Cursor.Position).X - cellRect.X;

            var clicked = gridRenderer.GetClickedButton(cellRect, relativeX);
            string empId = dgvSalaries.Rows[e.RowIndex].Cells["EmployeeID"].Value?.ToString() ?? "";
            var emp = allEmployees.FirstOrDefault(x => x.EmployeeID == empId);

            if (emp == null) return;

            if (clicked.IsEdit)
            {
                EditEmployee(emp);
            }
            else if (clicked.IsDelete)
            {
                var result = MessageBox.Show($"هل أنت متأكد من رغبتك في حذف سجل دفع راتب الموظف ({emp.FullName})؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (var conn = ActiveSpaceSystem.Data.DatabaseConnection.GetConnection())
                        {
                            conn.Open();
                            using (var cmd = new SqlCommand("DELETE FROM SALARIES WHERE employee_id = @empId", conn))
                            {
                                cmd.Parameters.AddWithValue("@empId", emp.EmployeeID);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("تم حذف سجل الدفع بنجاح.", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("حدث خطأ أثناء حذف سجل الدفع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void PaySalary(Employee emp)
        {
            // Check if already paid
            using (var conn = ActiveSpaceSystem.Data.DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var checkCmd = new SqlCommand("SELECT COUNT(*) FROM SALARIES WHERE employee_id = @id", conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", emp.EmployeeID);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show($"لقد تم دفع راتب الموظف ({emp.FullName}) بالفعل لهذا الشهر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                double inc = 0;
                double ded = 0;

                double total = emp.Salary + inc - ded;
                string newRef = "SAL-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                string insertQuery = "INSERT INTO SALARIES (salary_ref, employee_id, payment_date, amount, incentives, deductions) VALUES (@ref, @emp_id, @date, @amount, @inc, @ded)";
                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ref", newRef);
                    cmd.Parameters.AddWithValue("@emp_id", emp.EmployeeID);
                    cmd.Parameters.AddWithValue("@date", DateTime.Today);
                    cmd.Parameters.AddWithValue("@amount", total);
                    cmd.Parameters.AddWithValue("@inc", inc);
                    cmd.Parameters.AddWithValue("@ded", ded);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show($"تم تسجيل دفع راتب الموظف ({emp.FullName}) بنجاح بقيمة {emp.Salary:N0} د.ل.", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void EditEmployee(Employee emp)
        {
            MessageBox.Show($"تعديل بيانات الموظف ({emp.FullName}) - سيتم تصميم هذه الشاشة قريباً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            MessageBox.Show("إضافة موظف جديد - سيتم تصميم هذه الشاشة قريباً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnRegisterSalary_Click(object sender, EventArgs e)
        {
            MessageBox.Show("تسجيل راتب جديد - سيتم تصميم هذه الشاشة قريباً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }

    public class SalaryLogItem
    {
        public string EmployeeID { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Month { get; set; } = "";
        public double BasicSalary { get; set; }
        public double Incentives { get; set; }
        public double Deductions { get; set; }
        public double Total => BasicSalary + Incentives - Deductions;
        public string PaymentDate { get; set; } = "";
        public string Status { get; set; } = "";
    }
}
