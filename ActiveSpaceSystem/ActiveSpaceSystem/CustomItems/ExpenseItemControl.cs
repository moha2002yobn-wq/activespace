using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ActiveSpaceSystem.Models;

namespace ActiveSpaceSystem.CustomItems
{
    public partial class ExpenseItemControl : UserControl
    {
        public event EventHandler DeleteClicked;

        private int _index = 1;
        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                lblIndex.Text = $"مصروف رقم {value}";
            }
        }

        public string CategoryName
        {
            get => cmbCategory.Text;
            set => cmbCategory.Text = value;
        }

        public double Amount
        {
            get => double.TryParse(txtAmount.Texts.Trim(), out var val) ? val : 0.0;
            set => txtAmount.Texts = value > 0 ? value.ToString("0.00") : "";
        }

        public string ExpenseDescription
        {
            get => txtDescription.Texts.Trim();
            set => txtDescription.Texts = value;
        }

        public bool ShowDeleteButton
        {
            get => btnDelete.Visible;
            set => btnDelete.Visible = value;
        }

        public ExpenseItemControl()
        {
            InitializeComponent();
            LoadCategories();

            // Set up amount change handler to update totals dynamically
            txtAmount._TextChanged += (sender, e) => AmountChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler AmountChanged;

        private void LoadCategories()
        {
            try
            {
                var types = ExpenseType.GetDefaultTypes();
                if (types != null)
                {
                    cmbCategory.DataSource = types;
                    cmbCategory.DisplayMember = "ExpenseName";
                    cmbCategory.ValueMember = "ExpenseName";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading expense categories: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        public bool ValidateInput()
        {
            if (cmbCategory.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show($"يرجى اختيار فئة المصروف في (مصروف رقم {Index})", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAmount.Texts) || !double.TryParse(txtAmount.Texts, out var amt) || amt <= 0)
            {
                MessageBox.Show($"يرجى إدخال مبلغ صحيح أكبر من الصفر في (مصروف رقم {Index})", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Texts))
            {
                MessageBox.Show($"يرجى إدخال وصف المصروف في (مصروف رقم {Index})", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            return true;
        }
    }
}
