using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class QuickActionCard : CustomPanel
    {
        private Label lblTitle;
        private Label lblSubText;

        private Color _themeColor = Color.FromArgb(43, 127, 255);
        private Image _cardIconImage;
        private int _iconSize = 30;
        private int _iconBoxSize = 50;
        private int _iconBorderRadius = 12;

        // --- Properties ---

        [Category("Quick Action")]
        public string TitleText { get => lblTitle.Text; set => lblTitle.Text = value; }

        [Category("Quick Action")]
        public string SubText { get => lblSubText.Text; set => lblSubText.Text = value; }

        [Category("Quick Action")]
        public string IconEmoji { get; set; } = "📅"; // kept for designer backward compat, not rendered

        [Category("Quick Action")]
        public Color ThemeColor
        {
            get => _themeColor;
            set { _themeColor = value; Invalidate(); }
        }

        [Category("Quick Action")]
        public Image CardIconImage
        {
            get => _cardIconImage;
            set { _cardIconImage = value; Invalidate(); }
        }

        [Category("Quick Action")]
        [Description("حجم الأيقونة داخل المربع الملون")]
        public int IconSize
        {
            get => _iconSize;
            set { _iconSize = value; Invalidate(); }
        }

        [Category("Quick Action")]
        [Description("حجم المربع الملون الذي يحتوي الأيقونة")]
        public int IconBoxSize
        {
            get => _iconBoxSize;
            set { _iconBoxSize = value; PositionControls(); Invalidate(); }
        }

        [Category("Quick Action")]
        [Description("زاوية استدارة مربع الأيقونة")]
        public int IconBorderRadius
        {
            get => _iconBorderRadius;
            set { _iconBorderRadius = value; Invalidate(); }
        }

        public QuickActionCard()
        {
            this.Size = new Size(240, 110);
            this.BackColor = Color.White;
            this.BorderColor = Color.FromArgb(226, 232, 240);
            this.BorderRadius = 18;
            this.BorderSize = 1;
            this.ShowShadow = true;
            this.Cursor = Cursors.Hand;
            this.Margin = new Padding(10);
            this.Padding = new Padding(5);

            lblTitle = new Label
            {
                Font = new Font("Tajawal Medium", 13, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                TextAlign = ContentAlignment.MiddleRight,
                RightToLeft = RightToLeft.Yes,
                BackColor = Color.Transparent
            };
            lblTitle.Click += (s, e) => this.InvokeOnClick(this, EventArgs.Empty);

            lblSubText = new Label
            {
                Font = new Font("Tajawal", 9.5F, FontStyle.Regular),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleRight,
                RightToLeft = RightToLeft.Yes,
                BackColor = Color.Transparent
            };
            lblSubText.Click += (s, e) => this.InvokeOnClick(this, EventArgs.Empty);

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblSubText);

            PositionControls();
        }

        private void PositionControls()
        {
            if (lblTitle == null || lblSubText == null) return;

            // Text positioned to the right of the icon box area
            int textLeft = _iconBoxSize + 35; // 20px icon left margin + iconBox + 15px gap
            int textWidth = this.Width - textLeft - 20;
            if (textWidth < 50) textWidth = 50;

            lblTitle.Size = new Size(textWidth, 30);
            lblTitle.Location = new Point(textLeft, (this.Height / 2) - lblTitle.Height + 2);

            lblSubText.Size = new Size(textWidth, 24);
            lblSubText.Location = new Point(textLeft, (this.Height / 2) + 6);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw icon box (rounded rectangle like CustomerCard)
            Rectangle iconRect = new Rectangle(20, (this.Height - _iconBoxSize) / 2, _iconBoxSize, _iconBoxSize);

            using (GraphicsPath iconPath = GetRoundedRect(iconRect, _iconBorderRadius))
            {
                using (SolidBrush iconBackBrush = new SolidBrush(_themeColor))
                {
                    g.FillPath(iconBackBrush, iconPath);
                }

                if (_cardIconImage != null)
                {
                    // Draw the icon image centered inside the box
                    g.DrawImage(_cardIconImage,
                        iconRect.X + (_iconBoxSize - _iconSize) / 2,
                        iconRect.Y + (_iconBoxSize - _iconSize) / 2,
                        _iconSize,
                        _iconSize);
                }
            }
        }

        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = Math.Max(radius * 2f, 1f);
            if (diameter >= rect.Width || diameter >= rect.Height)
                diameter = Math.Min(rect.Width, rect.Height) - 1;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            PositionControls();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            PositionControls();
        }
    }
}
