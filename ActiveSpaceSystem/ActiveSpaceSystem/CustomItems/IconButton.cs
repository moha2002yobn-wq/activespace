using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel; // مطلوب لإظهار الخصائص في نافذة الـ Properties

namespace ActiveSpaceSystem.CustomItems
{
    public class IconButton : Button
    {
        // --- الخصائص الجديدة للتحكم في الإطار والحواف ---
        [Category("Custom Appearance")]
        public int BorderRadius { get; set; } = 30;

        [Category("Custom Appearance")]
        public Color BorderColor { get; set; } = Color.PaleVioletRed;

        [Category("Custom Appearance")]
        public int BorderSize { get; set; } = 2;

        // --- الخصائص الجديدة المضافة للأيقونة ---
        [Category("Custom Appearance")]
        public Image ButtonIcon { get; set; } = null;

        [Category("Custom Appearance")]
        public Size IconSize { get; set; } = new Size(20, 20);

        [Category("Custom Appearance")]
        public ContentAlignment IconAlignment { get; set; } = ContentAlignment.MiddleLeft;

        public IconButton()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(150, 50);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0; // إخفاء إطار الويندوز الافتراضي
            this.Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // تجهيز المستطيلات (مستطيل الزر ومستطيل الإطار) - كودك الأصلي كما هو
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -BorderSize, -BorderSize);

            int smoothSize = 2;
            if (BorderSize > 0) smoothSize = BorderSize;

            using (GraphicsPath pathSurface = GetRoundPath(rectSurface, BorderRadius))
            using (GraphicsPath pathBorder = GetRoundPath(rectBorder, BorderRadius - BorderSize))
            using (Pen penSurface = new Pen(this.Parent != null ? this.Parent.BackColor : Color.White, smoothSize))
            using (Pen penBorder = new Pen(BorderColor, BorderSize))
            {
                this.Region = new Region(pathSurface);

                // 1. رسم خلفية السطح (لتنظيف الحواف)
                g.DrawPath(penSurface, pathSurface);

                // 2. رسم الإطار إذا كان الحجم أكبر من 0
                if (BorderSize >= 1)
                {
                    // ضبط مكان الرسم ليكون دقيقاً
                    penBorder.Alignment = PenAlignment.Inset;
                    g.DrawPath(penBorder, pathSurface);
                }
            }

            // --- إضافة رسم الأيقونة بناءً على المحاذاة (يمين، يسار، إلخ) ---
            if (ButtonIcon != null)
            {
                Rectangle iconRect = GetIconRectangle();
                g.DrawImage(ButtonIcon, iconRect);
            }
        }

        // دالة إضافية لحساب موقع الأيقونة بدقة بناءً على اختيارك من الـ Properties
        private Rectangle GetIconRectangle()
        {
            int x = 10; // Margin افتراضي
            int y = (this.Height - IconSize.Height) / 2; // توسيط رأسي افتراضي

            // تحديد X (أفقي)
            if (IconAlignment == ContentAlignment.TopLeft || IconAlignment == ContentAlignment.MiddleLeft || IconAlignment == ContentAlignment.BottomLeft)
                x = 10;
            else if (IconAlignment == ContentAlignment.TopRight || IconAlignment == ContentAlignment.MiddleRight || IconAlignment == ContentAlignment.BottomRight)
                x = this.Width - IconSize.Width - 10;
            else // Center
                x = (this.Width - IconSize.Width) / 2;

            // تحديد Y (رأسي)
            if (IconAlignment == ContentAlignment.TopLeft || IconAlignment == ContentAlignment.TopCenter || IconAlignment == ContentAlignment.TopRight)
                y = 10;
            else if (IconAlignment == ContentAlignment.BottomLeft || IconAlignment == ContentAlignment.BottomCenter || IconAlignment == ContentAlignment.BottomRight)
                y = this.Height - IconSize.Height - 10;
            else // Middle
                y = (this.Height - IconSize.Height) / 2;

            return new Rectangle(x, y, IconSize.Width, IconSize.Height);
        }

        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = Math.Max(1, radius * 2f);

            // منع الانهيار إذا كان القطر أكبر من حجم الزر
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