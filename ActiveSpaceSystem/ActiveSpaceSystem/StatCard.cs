using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveSpaceSystem
{
    public partial class StatCard : UserControl
    {
        public StatCard()
        {
            InitializeComponent();
        }

        // خاصية لتغيير العنوان
        public string Title
        {
            get => label6.Text;
            set => label6.Text = value;
        }

        // خاصية لتغيير القيمة (المبلغ أو الرقم)
        public string Value
        {
            get => label5.Text;
            set => label5.Text = value;
        }

        // خاصية لتغيير النسبة المئوية
        public string Percentage
        {
            get => label4.Text;
            set => label4.Text = value;
        }

        // خاصية لتغيير لون أيقونة الخلفية
        public Color IconColor
        {
            get => pictureBox2.BackColor;
            set => pictureBox2.BackColor = value;
        }
    }
}
