using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class CustomActionButton : Button
    {
        // --- الخصائص الحالية ---
        private int borderRadius = 10;
        private int borderSize = 1;
        private Color borderColor = Color.FromArgb(225, 225, 225);
        private Color toggleColor = Color.FromArgb(245, 245, 245);
        private bool isToggled = false;

        // --- الخصائص الجديدة للأيقونة ---
        private Image buttonIcon = null;
        private Size iconSize = new Size(16, 16);
        private ContentAlignment iconAlignment = ContentAlignment.MiddleLeft;
        private int iconPadding = 8;

        [Category("Custom Layout - Icon")]
        public Image ButtonIcon
        {
            get => buttonIcon;
            set { buttonIcon = value; Invalidate(); }
        }

        [Category("Custom Layout - Icon")]
        public Size IconSize
        {
            get => iconSize;
            set { iconSize = value; Invalidate(); }
        }

        [Category("Custom Layout - Icon")]
        public ContentAlignment IconAlignment
        {
            get => iconAlignment;
            set { iconAlignment = value; Invalidate(); }
        }

        [Category("Custom Layout")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; Invalidate(); }
        }

        // باقي الخصائص السابقة...
        [Category("Custom Layout")]
        public int BorderSize { get => borderSize; set { borderSize = value; Invalidate(); } }
        [Category("Custom Layout")]
        public Color BorderColor { get => borderColor; set { borderColor = value; Invalidate(); } }
        [Category("Custom Layout")]
        public Color ToggleColor { get => toggleColor; set { toggleColor = value; Invalidate(); } }
        [Category("Custom Layout")]
        public bool IsToggled { get => isToggled; set { isToggled = value; Invalidate(); } }

        public CustomActionButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(120, 45);
            this.BackColor = Color.White;
            this.Cursor = Cursors.Hand;
        }

        protected override void OnClick(EventArgs e)
        {
            isToggled = !isToggled;
            base.OnClick(e);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // لا نستدعي base.OnPaint لمنع الرسم الافتراضي وتجنب الوميض
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectSurface = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle rectBorder = new Rectangle(1, 1, this.Width - 2, this.Height - 2);

            using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, borderRadius))
            {
                this.Region = new Region(pathSurface);

                // 1. تلوين الخلفية
                Color currentBg = isToggled ? toggleColor : this.BackColor;
                using (SolidBrush brush = new SolidBrush(currentBg))
                {
                    g.FillPath(brush, pathSurface);
                }

                // 2. رسم الإطار
                if (borderSize > 0)
                {
                    using (Pen pen = new Pen(borderColor, borderSize))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        g.DrawPath(pen, pathBorder);
                    }
                }

                // 3. رسم الأيقونة والنص
                DrawIconAndText(g);
            }
        }

        private void DrawIconAndText(Graphics g)
        {
            Rectangle textRect = new Rectangle(0, 0, this.Width, this.Height);

            if (buttonIcon != null)
            {
                int x = iconPadding;
                int y = (this.Height - iconSize.Height) / 2;

                // تحديد مكان الأيقونة (يمين أو يسار)
                if (iconAlignment == ContentAlignment.MiddleRight)
                {
                    x = this.Width - iconSize.Width - iconPadding;
                    // تعديل مساحة النص لتبتعد عن الأيقونة في اليمين
                    textRect.Width -= (iconSize.Width + iconPadding);
                }
                else // افتراضياً يسار MiddleLeft
                {
                    x = iconPadding;
                    // إزاحة النص لليمين قليلاً
                    textRect.X += (iconSize.Width + iconPadding);
                    textRect.Width -= (iconSize.Width + iconPadding);
                }

                g.DrawImage(buttonIcon, x, y, iconSize.Width, iconSize.Height);
            }

            // رسم النص في المساحة المتبقية
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;
            TextRenderer.DrawText(g, this.Text, this.Font, textRect, this.ForeColor, flags);
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = Math.Max(radius * 2f, 1f);
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