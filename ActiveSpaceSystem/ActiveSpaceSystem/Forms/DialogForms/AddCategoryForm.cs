using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ActiveSpaceSystem.Data;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    public partial class AddCategoryForm : Form
    {
        public string AddedCategoryName { get; private set; } = string.Empty;

        public AddCategoryForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Paint += AddCategoryForm_Paint;
        }

        private void AddCategoryForm_Paint(object sender, PaintEventArgs e)
        {
            // Draw a subtle border around the borderless form
            using (var pen = new Pen(Color.FromArgb(220, 224, 230), 1.5f))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newCatName = txtCategoryName.Texts.Trim();

            if (string.IsNullOrWhiteSpace(newCatName))
            {
                MessageBox.Show("الرجاء إدخال اسم الفئة أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Validation: Check if category already exists (case-insensitive in SQL Server generally)
                    string checkQ = "SELECT COUNT(*) FROM INVENTORY_CATEGORIES WHERE LOWER(category_name) = LOWER(@name)";
                    using (var checkCmd = new SqlCommand(checkQ, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@name", newCatName);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("عذراً، هذه الفئة موجودة مسبقاً في النظام!", "فئة مكررة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Get next category reference CAT-INV-XXX
                    string maxQ = "SELECT ISNULL(MAX(CAST(SUBSTRING(category_ref, 9, 3) AS INT)), 0) FROM INVENTORY_CATEGORIES WHERE category_ref LIKE 'CAT-INV-%'";
                    int nextSeq = 1;
                    using (var maxCmd = new SqlCommand(maxQ, conn))
                    {
                        nextSeq = Convert.ToInt32(maxCmd.ExecuteScalar()) + 1;
                    }
                    string newRef = $"CAT-INV-{nextSeq.ToString("D3")}";

                    // Insert the new category
                    string insQ = "INSERT INTO INVENTORY_CATEGORIES (category_ref, category_name, description) VALUES (@ref, @name, @desc)";
                    using (var insCmd = new SqlCommand(insQ, conn))
                    {
                        insCmd.Parameters.AddWithValue("@ref", newRef);
                        insCmd.Parameters.AddWithValue("@name", newCatName);
                        insCmd.Parameters.AddWithValue("@desc", "أضيفت من واجهة إضافة فئة جديدة");
                        insCmd.ExecuteNonQuery();
                    }
                }

                // Set success state
                AddedCategoryName = newCatName;
                MessageBox.Show("تم إضافة الفئة بنجاح!", "تمت الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء إضافة الفئة: " + ex.Message, "خطأ في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
