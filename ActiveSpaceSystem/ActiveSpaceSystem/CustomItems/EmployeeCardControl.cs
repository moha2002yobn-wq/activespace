using System;
using System.Windows.Forms;
using ActiveSpace.Models;

namespace ActiveSpaceSystem.CustomItems
{
    public partial class EmployeeCardControl : UserControl
    {
        private Employee _employee;
        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                if (_employee != null)
                {
                    EmployeeName = _employee.FullName;
                    Position = _employee.Position;
                    Salary = _employee.Salary;
                    StartDate = _employee.HireDate;
                }
            }
        }

        public string EmployeeName
        {
            get => lblEmployeeName.Text;
            set
            {
                lblEmployeeName.Text = value;
                if (!string.IsNullOrEmpty(value))
                {
                    lblAvatar.Text = value.Trim().Substring(0, 1);
                }
                else
                {
                    lblAvatar.Text = "";
                }
            }
        }

        public string Position
        {
            get => lblPosition.Text;
            set => lblPosition.Text = value;
        }

        private double _salary;
        public double Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                lblSalaryValue.Text = $"{value:N0} د.ل";
            }
        }

        private DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                lblStartDate.Text = $"📅 بدأ في: {value:dd-MM-yyyy}";
            }
        }

        public event EventHandler PaySalaryClicked;
        public event EventHandler EditClicked;

        public EmployeeCardControl()
        {
            InitializeComponent();
            SetupEvents();
        }

        private void SetupEvents()
        {
            btnPaySalary.Click += (s, e) => PaySalaryClicked?.Invoke(this, EventArgs.Empty);
            btnEdit.Click += (s, e) => EditClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
