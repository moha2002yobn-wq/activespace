using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ActiveSpaceSystem.Models;
using ActiveSpaceSystem.CustomItems;
using ActiveSpace.Models;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    public partial class AddExpens : Form
    {
        private readonly Expense _targetExpense;
        private readonly bool _isEditMode = false;
        private readonly Employee? _currentUser;

        public AddExpens()
        {
            InitializeComponent();
            _isEditMode = false;
            this.Text = "إضافة مصروفات";
            btSave.Text = "+ حفظ جميع المصروفات";
            this.Paint += AddExpens_Paint;
        }

        public AddExpens(Employee user) : this()
        {
            _currentUser = user;
        }

        public AddExpens(Expense expense) : this()
        {
            if (expense == null) return;

            _targetExpense = expense;
            _isEditMode = true;
            this.Text = "تعديل مصروف";
            lblTitle.Text = "تعديل مصروف";
            btSave.Text = "تحديث المصروف";
            
            // Hide the Add Another button in Edit Mode
            btnAddItem.Visible = false;
            lblExpensesHeader.Text = "تعديل المصروف";
        }

        public AddExpens(Expense expense, Employee user) : this(expense)
        {
            _currentUser = user;
        }

        private void AddExpens_Paint(object sender, PaintEventArgs e)
        {
            // Draw a elegant soft border around the borderless form
            using (var pen = new Pen(Color.FromArgb(220, 224, 230), 1.5f))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void AddExpens_Load(object sender, EventArgs e)
        {
            flowItems.Controls.Clear();

            if (_isEditMode && _targetExpense != null)
            {
                dtpDate.Value = _targetExpense.ExpenseDate > dtpDate.MinDate ? _targetExpense.ExpenseDate : DateTime.Now;

                // Add single item in Edit Mode
                var itemCtrl = AddExpenseItem();
                itemCtrl.Index = 1;
                itemCtrl.CategoryName = _targetExpense.Category;
                itemCtrl.Amount = _targetExpense.Amount;
                itemCtrl.ExpenseDescription = _targetExpense.ExpenseDescription;
                itemCtrl.ShowDeleteButton = false;
            }
            else
            {
                dtpDate.Value = DateTime.Now;

                // Start with one empty item in Add Mode
                AddExpenseItem();
            }

            UpdateTotalExpenses();
        }

        private ExpenseItemControl AddExpenseItem()
        {
            var item = new ExpenseItemControl();
            item.Index = flowItems.Controls.Count + 1;
            item.Width = flowItems.ClientSize.Width - 25;
            item.Margin = new Padding(0, 5, 0, 5);

            // Dynamically listen to amount changes to update total in real time
            item.AmountChanged += (sender, e) => UpdateTotalExpenses();

            // Set delete clicked event handler
            item.DeleteClicked += (sender, e) =>
            {
                if (flowItems.Controls.Count <= 1)
                {
                    return; // Keep at least one item
                }

                flowItems.Controls.Remove(item);
                item.Dispose();

                ReindexItems();
                UpdateDeleteButtons();
                UpdateTotalExpenses();
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
                if (ctrl is ExpenseItemControl itemCtrl)
                {
                    itemCtrl.Index = idx++;
                }
            }

            lblExpensesHeader.Text = $"المصروفات ({flowItems.Controls.Count})";
        }

        private void UpdateDeleteButtons()
        {
            bool showDelete = flowItems.Controls.Count > 1 && !_isEditMode;
            foreach (Control ctrl in flowItems.Controls)
            {
                if (ctrl is ExpenseItemControl itemCtrl)
                {
                    itemCtrl.ShowDeleteButton = showDelete;
                }
            }

            lblExpensesHeader.Text = _isEditMode ? "تعديل المصروف" : $"المصروفات ({flowItems.Controls.Count})";
        }

        private void UpdateTotalExpenses()
        {
            double total = 0.0;
            foreach (Control ctrl in flowItems.Controls)
            {
                if (ctrl is ExpenseItemControl itemCtrl)
                {
                    total += itemCtrl.Amount;
                }
            }

            lblTotalAmount.Text = $"إجمالي المصروفات: {total.ToString("N2")} د.ل";
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddExpenseItem();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            // Validate all items
            foreach (Control ctrl in flowItems.Controls)
            {
                if (ctrl is ExpenseItemControl itemCtrl)
                {
                    if (!itemCtrl.ValidateInput())
                    {
                        return;
                    }
                }
            }

            try
            {
                DateTime date = dtpDate.Value;

                if (_isEditMode && _targetExpense != null)
                {
                    var item = (ExpenseItemControl)flowItems.Controls[0];
                    _targetExpense.ExpenseDate = date;
                    _targetExpense.Category = item.CategoryName;
                    _targetExpense.Amount = item.Amount;
                    _targetExpense.ExpenseDescription = item.ExpenseDescription;
                    if (_currentUser != null)
                    {
                        _targetExpense.EmployeeID = _currentUser.EmployeeID;
                    }

                    _targetExpense.Save();
                }
                else
                {
                    // Add multiple expenses
                    foreach (Control ctrl in flowItems.Controls)
                    {
                        if (ctrl is ExpenseItemControl item)
                        {
                            var newExpense = new Expense
                            {
                                ExpenseDate = date,
                                Category = item.CategoryName,
                                Amount = item.Amount,
                                ExpenseDescription = item.ExpenseDescription,
                                EmployeeID = _currentUser?.EmployeeID
                            };

                            newExpense.Save();
                        }
                    }
                }

                MessageBox.Show("تم حفظ المصروفات بنجاح!", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حفظ البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}