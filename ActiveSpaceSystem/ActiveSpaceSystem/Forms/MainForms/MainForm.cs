using System;
using System.Drawing;
using System.Windows.Forms;
using ActiveSpaceSystem.Forms.SideForms;
using ActiveSpace.Models;
using ActiveSpaceSystem.Models.enums;

namespace ActiveSpaceSystem.Forms.MainForms
{
    public partial class MainForm : Form
    {
        private DashBoardForm DashForm = null!;
        private ManageBooking BookingForm = null!;
        private SchedulingForm ScheduleForm = null!;
        private MonthlyContractForm MonthlyContractForm = null!;
        private MangeCustomers MangeCustomersForm = null!;
        private PaymentForm PaymentForm = null!;
        private ReportsForm ReportsForm = null!;
        private Settings SettingsForm = null!;
        private ExpensesForm ExpensesForm = null!;
        private SalesForm SalesForm = null!;
        private InventoryForm InventoryForm = null!;
        private EmployeesForm EmployeesForm = null!;

        private Button? currentActiveButton = null;
        private int oldWidth = 0;
        private int oldheight = 0;
        private Employee CurrentUser { get; set; } = null!;

        public MainForm(Employee user)
        {
            InitializeComponent();
            btBooking.Click += button1_Click;
            btScheduling.Click += button2_Click;
            btMain.Click += button3_Click;
            btPayment.Click += button4_Click;
            btContract.Click += button5_Click;
            btCustomers.Click += button6_Click;
            btReports.Click += button7_Click;
            btSettings.Click += button8_Click;
            btnSales.Click += btnSales_Click;
            btnInventory.Click += btnInventory_Click;
            btnEmployees.Click += btnEmployees_Click;
            this.Resize += MainForm_Resize;
            //1280, 851
            oldWidth = 1280;
            oldheight = 851;
            LabelUser.Text = user.FullName;
            LabelRole.Text = user.Role == UserRole.Admin ? "مدير" : "موظف";
            this.WindowState = FormWindowState.Maximized;
            CurrentUser = user;
            UpdateButtonVisibility();

        }
        private void UpdateButtonVisibility()
        {
            if (CurrentUser.Role == UserRole.Staff)
            {
                btSettings.Visible = false;
                btReports.Visible = false;
            }
            else
            {
                btSettings.Visible = true;
                btReports.Visible = true;
            }
        }




        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            lblDate.Text = DateTime.Now.ToString("dddd، dd MMMM yyyy", new System.Globalization.CultureInfo("ar-EG"));

            // تعيين الزر الرئيسي كنشط افتراضياً
            ActivateButton(btMain);
            ShowFormInPanel(new DashBoardForm()); // أو أي شاشة ترغب بها
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dddd، dd MMMM yyyy", new System.Globalization.CultureInfo("ar-EG"));
        }


        // أزرار القائمة:
        private void button3_Click(object sender, EventArgs e)   // الرئيسية
        {
            ActivateButton(btMain);
            if (DashForm == null || DashForm.IsDisposed)
            {
                DashForm = new DashBoardForm();
                
            }
            if (DashForm != null)
            {
                DashForm.LoadData();
            }
            ShowFormInPanel(DashForm);
        }

        private void button1_Click(object sender, EventArgs e)   // إدارة الحجوزات
        {
            ActivateButton(btBooking);
            if (BookingForm == null || BookingForm.IsDisposed)
            {
                BookingForm = new ManageBooking(CurrentUser);
                BookingForm.LoadData();
            }
            if (BookingForm != null)
            {
                BookingForm.LoadData();
            }

            ShowFormInPanel(BookingForm);
        }

        private void button2_Click(object sender, EventArgs e)   // الجدولة
        {
            ActivateButton(btScheduling);
            if (ScheduleForm == null || ScheduleForm.IsDisposed)
            {
                ScheduleForm = new SchedulingForm();
                

            }
            if (ScheduleForm != null)
            {
                ScheduleForm.LoadDataToGrid(ScheduleForm.dateTimePicker2.Value);
            }
            ShowFormInPanel(ScheduleForm);
        }

        private void button5_Click(object sender, EventArgs e)   // العقود الشهرية
        {
            ActivateButton(btContract);
            if (MonthlyContractForm == null || MonthlyContractForm.IsDisposed)
            {
                MonthlyContractForm = new MonthlyContractForm(CurrentUser);
            }
            if (MangeCustomersForm != null)
            {
                MangeCustomersForm.LoadData();
            }
            ShowFormInPanel(MonthlyContractForm);
        }

        private void button4_Click(object sender, EventArgs e)   // المدفوعات
        {
            ActivateButton(btPayment);
            if (PaymentForm == null || PaymentForm.IsDisposed)
            {
                PaymentForm = new PaymentForm();
                PaymentForm.LoadData();
            }
            if (PaymentForm != null)
            {
                PaymentForm.LoadData();
            }

            ShowFormInPanel(PaymentForm);
        }

        private void button7_Click(object sender, EventArgs e)   // التقارير
        {
            ActivateButton(btReports);
            if (ReportsForm == null || ReportsForm.IsDisposed)
            {
                ReportsForm = new ReportsForm();
            }
            ShowFormInPanel(ReportsForm);
        }

        private void button6_Click(object sender, EventArgs e)   // العملاء
        {
            ActivateButton(btCustomers);
            if (MangeCustomersForm == null || MangeCustomersForm.IsDisposed)
            {
                MangeCustomersForm = new MangeCustomers(CurrentUser);
                MangeCustomersForm.LoadData();
            }
            ShowFormInPanel(MangeCustomersForm);
        }

        private void button8_Click(object sender, EventArgs e)   // الإعدادات
        {
            ActivateButton(btSettings);
            if (SettingsForm == null || SettingsForm.IsDisposed)
            {
                SettingsForm = new Settings(CurrentUser);
            }
            ShowFormInPanel(SettingsForm);
        }

        private void button9_Click_1(object sender, EventArgs e)
        {

            this.Tag = "logout";
            // إظهار واجهة الدخول الموجودة مسبقاً في الذاكرة
            Application.OpenForms["LoginForm"].Show();

            // إغلاق الواجهة الحالية
            this.Close();

        }

        private void button10_Click(object sender, EventArgs e) //المصروفات
        {
            ActivateButton(btExpense);
            if (ExpensesForm == null || ExpensesForm.IsDisposed)
            {
                ExpensesForm = new ExpensesForm(CurrentUser);
            }
            ExpensesForm.RefreshGrid();
            ShowFormInPanel(ExpensesForm);
        }

        private void btnSales_Click(object sender, EventArgs e) //المشتريات
        {
            ActivateButton(btnSales);
            if (SalesForm == null || SalesForm.IsDisposed)
            {
                SalesForm = new SalesForm(CurrentUser);
            }
            SalesForm.LoadData();
            ShowFormInPanel(SalesForm);
        }

        private void btnInventory_Click(object sender, EventArgs e) //المخزون
        {
            ActivateButton(btnInventory);
            if (InventoryForm == null || InventoryForm.IsDisposed)
            {
                InventoryForm = new InventoryForm(CurrentUser);
            }
            InventoryForm.LoadData();
            ShowFormInPanel(InventoryForm);
        }

        private void btnEmployees_Click(object sender, EventArgs e) // إدارة الموظفين
        {
            ActivateButton(btnEmployees);
            if (EmployeesForm == null || EmployeesForm.IsDisposed)
            {
                EmployeesForm = new EmployeesForm(CurrentUser);
            }
            EmployeesForm.LoadData();
            ShowFormInPanel(EmployeesForm);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (this.Tag == null)
            {
                Application.Exit();
            }
        }


        // دالة لتغيير لون الأزرار
        private void ActivateButton(Button btn)
        {
            if (currentActiveButton != null)
            {
                currentActiveButton.BackColor = Color.FromArgb(31, 41, 55); // اللون الأصلي للقائمة
                currentActiveButton.ForeColor = Color.White;
            }
            btn.BackColor = Color.FromArgb(46, 204, 113); // اللون الأخضر
            btn.ForeColor = Color.White;
            currentActiveButton = btn;
        }




        // دالة لعرض النموذج داخل PanelContaint
        private void ShowFormInPanel(Form form)
        {
            PanelContaint.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;

            // التحقق من حالة النافذة عند الفتح
            if (this.WindowState == FormWindowState.Maximized)
            {
                form.Dock = DockStyle.Fill;
            }
            else
            {
                form.Dock = DockStyle.None;
                this.Width = oldWidth;
                this.Height = oldheight;

            }

            form.RightToLeft = RightToLeft.Yes;
            form.RightToLeftLayout = true;
            PanelContaint.Controls.Add(form);
            form.Show();
        }
        // أضف هذا الحدث من نافذة الخصائص (Events) أو داخل Constructor
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (PanelContaint.Controls.Count > 0 && PanelContaint.Controls[0] is Form activeForm)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    activeForm.Dock = DockStyle.Fill;
                }
                else if (this.WindowState == FormWindowState.Normal)
                {
                    activeForm.Dock = DockStyle.None;
                    this.Size = new Size(oldWidth, oldheight); // إرجاع الحجم القديم بالظبط
                    activeForm.Size = new Size(PanelContaint.Width, PanelContaint.Height); // حجم الفورم الداخلي
                }
            }
        }

        private void btMain_Click(object sender, EventArgs e)
        {

        }

        public void NavigateToForm(string formName)
        {
            switch (formName)
            {
                case "Booking":
                    button1_Click(btBooking, EventArgs.Empty);
                    break;
                case "Contract":
                    button5_Click(btContract, EventArgs.Empty);
                    break;
                case "Expense":
                    if (ExpensesForm == null || ExpensesForm.IsDisposed)
                    {
                        ExpensesForm = new ExpensesForm(CurrentUser);
                        ExpensesForm.TopLevel = false;
                        ExpensesForm.FormBorderStyle = FormBorderStyle.None;
                    }
                    ExpensesForm.RefreshGrid();
                    ShowFormInPanel(ExpensesForm);
                    break;
                case "Sales":
                    btnSales_Click(btnSales, EventArgs.Empty);
                    break;
                case "Courts":
                    button8_Click(btSettings, EventArgs.Empty);
                    break;
            }
        }
    }
}