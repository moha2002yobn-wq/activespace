using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    public partial class NotificationCard : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private string _type = "Info";

        public NotificationCard()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
        }

        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public string Description
        {
            get => lblDescription.Text;
            set => lblDescription.Text = value;
        }

        public string TimeText
        {
            get => lblTime.Text;
            set => lblTime.Text = value;
        }

        public string NotificationType
        {
            get => _type;
            set
            {
                _type = value;
                UpdateTheme();
            }
        }

        private void UpdateTheme()
        {
            Color baseColor;
            string symbol;

            switch (_type)
            {
                case "Booking":
                    baseColor = Color.FromArgb(43, 127, 255); // Blue
                    symbol = "📅";
                    break;
                case "Payment":
                    baseColor = Color.FromArgb(46, 204, 113); // Green
                    symbol = "💰";
                    break;
                case "Expense":
                    baseColor = Color.FromArgb(220, 38, 38); // Red
                    symbol = "💸";
                    break;
                case "Alert":
                default:
                    baseColor = Color.FromArgb(241, 196, 15); // Yellow
                    symbol = "⚠️";
                    break;
            }

            pnlIconBack.BackColor = Color.FromArgb(20, baseColor);
            lblIcon.Text = symbol;
            lblIcon.ForeColor = baseColor;
            pnlIndicator.BackColor = baseColor;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
    }
}
