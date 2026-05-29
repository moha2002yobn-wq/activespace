using ActiveSpace.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    public partial class AddCourtTypeForm : Form
    {
        public AddCourtTypeForm()
        {
            InitializeComponent();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(namecourttxt.Texts))
            {
                MessageBox.Show("الرجاء كتابة نوع الملعب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CourtType.Add(new CourtType
                {
                    TypeID = CourtType.GetFakeData().Count + 1,
                    TypeName = namecourttxt.Texts
                });
                MessageBox.Show("تمت إضافة نوع الملعب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
