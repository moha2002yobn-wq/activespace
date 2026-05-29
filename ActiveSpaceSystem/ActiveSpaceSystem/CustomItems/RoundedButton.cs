using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel; // مطلوب لإظهار الخصائص في نافذة الـ Properties

namespace ActiveSpaceSystem.CustomItems
{
    public class RoundedButton : Button
    {
        private int _borderRadius = 30;
        [Category("Custom Appearance")]
        public int BorderRadius 
        { 
            get => _borderRadius;
            set
            {
                _borderRadius = value;
                UpdateRegion();
                this.Invalidate();
            }
        }

        [Category("Custom Appearance")]
        public Color BorderColor { get; set; } = Color.PaleVioletRed;

        [Category("Custom Appearance")]
        public int BorderSize { get; set; } = 2;

        public RoundedButton()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(150, 50);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0; // Hide default windows borders
            this.Cursor = Cursors.Hand;
        }

        private void UpdateRegion()
        {
            using (GraphicsPath pathSurface = GetRoundPath(this.ClientRectangle, BorderRadius))
            {
                this.Region = new Region(pathSurface);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -BorderSize, -BorderSize);

            using (GraphicsPath pathSurface = GetRoundPath(rectSurface, BorderRadius))
            using (GraphicsPath pathBorder = GetRoundPath(rectBorder, Math.Max(1, BorderRadius - BorderSize)))
            using (SolidBrush brushBack = new SolidBrush(this.BackColor))
            using (Pen penBorder = new Pen(BorderColor, BorderSize))
            {
                // Clear background with parent's backcolor to avoid ugly outlines
                g.Clear(this.Parent?.BackColor ?? Color.White);

                // Draw button surface background
                g.FillPath(brushBack, pathSurface);

                // Draw border if set
                if (BorderSize >= 1)
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    g.DrawPath(penBorder, pathSurface);
                }

                // Draw button text perfectly centered
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
                TextRenderer.DrawText(g, this.Text, this.Font, rectSurface, this.ForeColor, flags);
            }
        }

        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = Math.Max(1, radius * 2f);

            // Prevent crash if diameter exceeds bounds
            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
