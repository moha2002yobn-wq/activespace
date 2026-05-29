using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    public class TaskItemControl : UserControl
    {
        private Label chk;
        private Label lblTitle;
        private Label lblTime;

        public event EventHandler StatusChanged;

        private bool _isCompleted;
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                _isCompleted = value;
                UpdateUI();
            }
        }

        public string TitleText { get => lblTitle.Text; set => lblTitle.Text = value; }
        public string TimeText { get => lblTime.Text; set => lblTime.Text = value; }

        public TaskItemControl()
        {
            this.Size = new Size(270, 75);
            this.BackColor = Color.Transparent;
            this.Margin = new Padding(0, 5, 0, 5);
            
            chk = new Label
            {
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(24, 24),
                Cursor = Cursors.Hand
            };
            chk.Paint += (s, e) => {
                using (var path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, chk.Width - 1, chk.Height - 1);
                    chk.Region = new Region(path);
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    if (!IsCompleted)
                        e.Graphics.DrawEllipse(Pens.Gray, 0, 0, chk.Width - 1, chk.Height - 1);
                }
            };
            chk.Click += (s, e) => {
                IsCompleted = !IsCompleted;
                StatusChanged?.Invoke(this, EventArgs.Empty);
            };

            lblTitle = new Label
            {
                Font = new Font("Tajawal Medium", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(15, 12),
                Size = new Size(205, 20)
            };

            lblTime = new Label
            {
                Font = new Font("Tajawal", 8, FontStyle.Regular),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(15, 36),
                Size = new Size(205, 15)
            };

            this.Controls.Add(chk);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblTime);

            this.Paint += TaskItemControl_Paint;
            this.Resize += (s, e) => {
                chk.Location = new Point(15, (this.Height - chk.Height) / 2);

                int newTextWidth = this.Width - 65;
                if (newTextWidth < 50) newTextWidth = 50;

                lblTitle.Width = newTextWidth;
                lblTime.Width = newTextWidth;

                int labelLeft = this.Width - newTextWidth - 15;
                lblTitle.Left = labelLeft;
                lblTime.Left = labelLeft;
            };

            UpdateUI();
        }

        private void UpdateUI()
        {
            if (IsCompleted)
            {
                chk.Text = "✓";
                chk.BackColor = Color.FromArgb(46, 204, 113);
                chk.ForeColor = Color.White;
                lblTitle.Font = new Font("Tajawal Medium", 10, FontStyle.Strikeout);
                lblTitle.ForeColor = Color.Gray;
            }
            else
            {
                chk.Text = "";
                chk.BackColor = Color.White;
                lblTitle.Font = new Font("Tajawal Medium", 10, FontStyle.Regular);
                lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            }
            this.Invalidate();
        }

        private void TaskItemControl_Paint(object sender, PaintEventArgs e)
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
                
                Color bgColor = IsCompleted ? Color.FromArgb(232, 248, 245) : Color.FromArgb(248, 250, 252);
                Color borderColor = IsCompleted ? Color.FromArgb(163, 228, 215) : Color.FromArgb(226, 232, 240);

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
