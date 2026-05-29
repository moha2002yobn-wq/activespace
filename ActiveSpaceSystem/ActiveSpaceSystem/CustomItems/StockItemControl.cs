using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    public class StockItemControl : UserControl
    {
        private Button btnOrder;
        private Label lblName;
        private Label lblSub;

        public event EventHandler OrderClicked;

        public string ItemName { get => lblName.Text; set => lblName.Text = value; }
        public string SubText { get => lblSub.Text; set => lblSub.Text = value; }

        public StockItemControl()
        {
            this.Size = new Size(270, 95);
            this.BackColor = Color.Transparent;
            this.Margin = new Padding(0, 5, 0, 5);

            btnOrder = new Button
            {
                Text = "طلب",
                Font = new Font("Tajawal", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(75, 32),
                Location = new Point(15, 31),
                Cursor = Cursors.Hand
            };
            btnOrder.FlatAppearance.BorderSize = 0;
            btnOrder.Click += (s, e) => OrderClicked?.Invoke(this, EventArgs.Empty);

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
                ForeColor = Color.FromArgb(185, 119, 14),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(105, 34),
                Size = new Size(150, 36)
            };

            this.Controls.Add(btnOrder);
            this.Controls.Add(lblName);
            this.Controls.Add(lblSub);

            this.Paint += StockItemControl_Paint;
            this.Resize += (s, e) => {
                int newTextWidth = this.Width - 110;
                if (newTextWidth < 50) newTextWidth = 50;
                lblName.Width = newTextWidth;
                lblSub.Width = newTextWidth;

                int labelLeft = this.Width - newTextWidth - 15;
                lblName.Left = labelLeft;
                lblSub.Left = labelLeft;

                btnOrder.Location = new Point(15, (this.Height - btnOrder.Height) / 2);
            };
        }

        private void StockItemControl_Paint(object sender, PaintEventArgs e)
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
                
                Color bgColor = Color.FromArgb(254, 249, 231);
                Color borderColor = Color.FromArgb(249, 231, 159);

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
