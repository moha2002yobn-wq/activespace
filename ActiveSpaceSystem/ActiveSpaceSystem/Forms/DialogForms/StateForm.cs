using ActiveSpace.Models;
using ActiveSpaceSystem.Data;
using ActiveSpaceSystem.Forms.Views;
using ActiveSpaceSystem.Models.enums;
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
    public partial class StateForm : Form
    {
        private BookingViewModel _booking;
        public StateForm(BookingViewModel booking)
        {
            InitializeComponent();
            _booking = booking;
        }

        private void StateForm_Load(object sender, EventArgs e)
        {
            
            cmbState.Items.Add("مؤكد");
            cmbState.Items.Add("لم يحضر");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selectedState = cmbState.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedState))
            {
                MessageBox.Show("يرجى اختيار حالة جديدة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(selectedState == "مؤكد")
            {
                _booking.Status = BookingStatus.Confirmed;
            }
            else if(selectedState == "لم يحضر")
            {
                _booking.Status = BookingStatus.NoShow;
            }
            

        }
    }
}
