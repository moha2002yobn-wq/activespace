using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    public class LateContractItemControl : UserControl
    {
        private Button btnCollect;
        private Label lblName;
        private Label lblSub;
        private Label lblLate;

        public event EventHandler CollectClicked;

        public string CustomerName { get => lblName.Text; set => lblName.Text = value; }
        public string SubText { get => lblSub.Text; set => lblSub.Text = value; }
        public string LateDaysText { get => lblLate.Text; set => lblLate.Text = value; }

        public LateContractItemControl()
        {
            this.Size = new Size(270, 95);
            this.BackColor = Color.Transparent;
            this.Margin = new Padding(0, 5, 0, 5);

            btnCollect = new Button
            {
                Text = "تحصيل",
                Font = new Font("Tajawal", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(75, 32),
                Location = new Point(15, 31),
                Cursor = Cursors.Hand
            };
            btnCollect.FlatAppearance.BorderSize = 0;
            btnCollect.Click += (s, e) => CollectClicked?.Invoke(this, EventArgs.Empty);

            lblName = new Label
            {
                Font = new Font("Tajawal Medium", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(105, 10),
                Size = new Size(150, 22)
            };

            lblSub = new Label
            {
                Font = new Font("Tajawal", 8, FontStyle.Regular),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(105, 34),
                Size = new Size(150, 36)
            };

            lblLate = new Label
            {
                Font = new Font("Tajawal", 8, FontStyle.Bold),
                ForeColor = Color.FromArgb(203, 67, 53),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(105, 72),
                Size = new Size(150, 18)
            };

            this.Controls.Add(btnCollect);
            this.Controls.Add(lblName);
            this.Controls.Add(lblSub);
            this.Controls.Add(lblLate);

            this.Paint += LateContractItemControl_Paint;
            this.Resize += (s, e) => {
                int newTextWidth = this.Width - 110;
                if (newTextWidth < 50) newTextWidth = 50;
                lblName.Width = newTextWidth;
                lblSub.Width = newTextWidth;
                lblLate.Width = newTextWidth;

                int labelLeft = this.Width - newTextWidth - 15;
                lblName.Left = labelLeft;
                lblSub.Left = labelLeft;
                lblLate.Left = labelLeft;

                btnCollect.Location = new Point(15, (this.Height - btnCollect.Height) / 2);
            };
        }

        private void LateContractItemControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                int radius = 12;
                Rectangle r = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                path.AddArc(r.X, r.Y, radius, radius, 180, 90);
                path.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90);
                path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                
                Color bgColor = Color.FromArgb(253, 237, 236);
                Color borderColor = Color.FromArgb(242, 215, 213);

                using (var brush = new SolidBrush(bgColor))
                using (var pen = new Pen(borderColor, 1))
                {
                    e.Graphics.FillPath(brush, path);
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}
