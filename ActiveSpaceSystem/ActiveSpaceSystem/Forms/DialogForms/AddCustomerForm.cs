using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    public partial class AddCustomerForm : Form
    {
        private Customer _existingCustomer;
        private bool _isEditMode = false;
        private string _oldPhoneNumber = string.Empty;

        public AddCustomerForm()
        {
            InitializeComponent();
            _isEditMode = false;
        }

        public AddCustomerForm(Customer customer) : this()
        {
            _existingCustomer = customer;
            _isEditMode = true;
            _oldPhoneNumber = customer.Phone;

            nametxt.Texts = customer.FullName;
            phonetxt.Texts = customer.Phone;

            lblTitle.Text = "تعديل بيانات العميل";
            roundedButton2.Text = "حفظ التعديلات";
        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            string errorMsg;

            if (!ValidationHelper.IsValidCustomerName(nametxt.Texts, out errorMsg))
            {
                MessageBox.Show(errorMsg, "خطأ في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nametxt.Focus();
                return;
            }

            if (!ValidationHelper.IsValidPhoneNumber(phonetxt.Texts, out errorMsg))
            {
                MessageBox.Show(errorMsg, "خطأ في البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phonetxt.Focus();
                return;
            }

            try
            {
                if (_isEditMode)
                {
                    // If phone number is edited, we should delete the old record and create a new one to update PK
                    if (_oldPhoneNumber != phonetxt.Texts.Trim())
                    {
                        Customer.Delete(_oldPhoneNumber);
                    }

                    _existingCustomer.FullName = nametxt.Texts.Trim();
                    _existingCustomer.Phone = phonetxt.Texts.Trim();
                    _existingCustomer.Save();

                    MessageBox.Show("تم تحديث بيانات العميل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Customer newCustomer = new Customer
                    {
                        FullName = nametxt.Texts.Trim(),
                        Phone = phonetxt.Texts.Trim()
                    };

                    newCustomer.Save();
                    MessageBox.Show("تمت إضافة العميل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ غير متوقع: " + ex.Message, "خطأ برمجي", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nametxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                phonetxt.Focus();
            }
        }

        private void phonetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                roundedButton2.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}