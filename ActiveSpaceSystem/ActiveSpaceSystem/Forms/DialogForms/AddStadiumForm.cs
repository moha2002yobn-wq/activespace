using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.DialogForms
{
    public partial class AddStadiumForm : Form
    {
        private Court _courtToEdit;

        public AddStadiumForm()
        {
            InitializeComponent();
        }

        public AddStadiumForm(Court court)
        {
            InitializeComponent();
            _courtToEdit = court;
            label1.Text = "تعديل بيانات الملعب";
            roundedButton2.Text = "تحديث";

            nametxt.Texts = court.CourtName;
            dtpOpenTime.Value = DateTime.Today.Add(court.OpenTime);
            dtpCloseTime.Value = DateTime.Today.Add(court.CloseTime);
            pricetxt.Texts = court.PricePerHour.ToString("0.00");
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private void AddStadiumForm_Load(object sender, EventArgs e)
        {
            FillCourtTypesCompo();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

            if (_courtToEdit != null)
            {
                cmbCourtType.Text = _courtToEdit.SportType;
            }
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            AddCourtTypeForm frm = new AddCourtTypeForm();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                FillCourtTypesCompo();
            }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nametxt.Texts))
            {
                MessageBox.Show("الرجاء كتابة اسم الملعب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbCourtType.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار نوع الملعب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var selecttype = (CourtType)cmbCourtType.SelectedItem;

                if (_courtToEdit == null)
                {
                    Court newcort = new Court
                    {
                        CourtName = nametxt.Texts,
                        SportType = selecttype.TypeName,
                        OpenTime = dtpOpenTime.Value.TimeOfDay,
                        CloseTime = dtpCloseTime.Value.TimeOfDay,
                        PricePerHour = double.TryParse(pricetxt.Texts, out var p) ? p : 50.0
                    };

                    newcort.Save();
                    MessageBox.Show("تم إضافة الملعب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // To handle primary key update if CourtName changes, we delete the old name and insert the new one
                    if (_courtToEdit.CourtName != nametxt.Texts)
                    {
                        Court.Delete(_courtToEdit.CourtName);
                    }

                    Court updatedCourt = new Court
                    {
                        CourtName = nametxt.Texts,
                        SportType = selecttype.TypeName,
                        OpenTime = dtpOpenTime.Value.TimeOfDay,
                        CloseTime = dtpCloseTime.Value.TimeOfDay,
                        PricePerHour = double.TryParse(pricetxt.Texts, out var p) ? p : 50.0
                    };

                    updatedCourt.Save();
                    MessageBox.Show("تم تحديث بيانات الملعب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCourtTypesCompo()
        {
            cmbCourtType.DataSource = null;
            cmbCourtType.DataSource = CourtType.GetFakeData();
            cmbCourtType.DisplayMember = "TypeName";
            cmbCourtType.ValueMember = "TypeName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
