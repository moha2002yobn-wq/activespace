using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Forms.DialogForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.SideForms
{
    public partial class StaduimSteting : Form
    {
        public StaduimSteting()
        {
            InitializeComponent();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            AddStadiumForm frms = new AddStadiumForm();
            frms.ShowDialog();
            if (frms.DialogResult == DialogResult.OK)
            {
                refreshCourtGrid();
            }
        }

        private void refreshCourtGrid()
        {
            dgvMonthlyContract.DataSource = null;

            var courts = Court.GetAll();
            var displayList = courts.Select(c => new
            {
                CourtID = c.CourtName,
                c.CourtName,
                TypeName = c.SportType,
                OpenTime = c.OpenTime.ToString(@"hh\:mm"),
                CloseTime = c.CloseTime.ToString(@"hh\:mm")
            }).ToList();

            dgvMonthlyContract.DataSource = displayList;
        }

        private void StaduimSteting_Load(object sender, EventArgs e)
        {
            dgvMonthlyContract.AutoGenerateColumns = false;
            refreshCourtGrid();
        }

        private void dgvMonthlyContract_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string columnName = dgvMonthlyContract.Columns[e.ColumnIndex].Name;

            var courts = Court.GetAll();
            if (e.RowIndex >= courts.Count) return;
            var selectedcourt = courts[e.RowIndex];

            if (columnName == "EditColumn")
            {
                AddStadiumForm frm = new AddStadiumForm(selectedcourt);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    refreshCourtGrid();
                }
            }
            else if (columnName == "DeleteColumn")
            {
                var confirmResult = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا الملعب؟", "تأكيد الحذف", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    Court.Delete(selectedcourt.CourtName);
                    refreshCourtGrid();
                }
            }
        }
    }
}
