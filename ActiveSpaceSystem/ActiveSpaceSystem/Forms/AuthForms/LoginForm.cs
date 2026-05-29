using System;
using System.Linq;
using System.Windows.Forms;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Forms.MainForms;
using ActiveSpace.Models;

namespace ActiveSpaceSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 1. التحقق من وجود الحقول (تجنب NullReferenceException إذا لم يتم تهيئة الأدوات)
                if (txtUsername == null || txtPassword == null) return;

                string inputUser = txtUsername.Texts?.Trim() ?? string.Empty;
                string inputPass = txtPassword.Texts?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(inputUser) || string.IsNullOrWhiteSpace(inputPass))
                {
                    MessageBox.Show("الرجاء إدخال اسم المستخدم وكلمة المرور", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                // البحث في قاعدة البيانات باستخدام Employee.Login
                var employee = Employee.Login(inputUser, inputPass);

                if (employee != null)
                {
                    // 3. مسح البيانات وتغيير الحالة قبل الانتقال
                    txtPassword.Texts = string.Empty;

                    MainForm mainForm = new MainForm(employee);

                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Texts = string.Empty; // من الأفضل مسح الباسورد عند الخطأ للأمان
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                // 4. معالجة أي خطأ غير متوقع لمنع انهيار البرنامج (Crash)
                MessageBox.Show($"حدث خطأ غير متوقع: {ex.Message}", "خطأ تقني", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            // تأكيد الخروج منعاً للضغط بالخطأ
            var result = MessageBox.Show("هل أنت متأكد من رغبتك في الخروج؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtPassword__TextChanged(object sender, EventArgs e)
        {

        }
    }
}