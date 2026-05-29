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
    public partial class AbuotSettings : Form
    {
        String SystemName = "Active Space";
        public AbuotSettings()
        {
            InitializeComponent();
            abdulTextBox1.Texts = SystemName;

        }


        private void roundedButton1_Click(object sender, EventArgs e)
        {
            SystemName = abdulTextBox1.Texts;
            abdulTextBox1.Texts = SystemName;
        }

      
    }
}
