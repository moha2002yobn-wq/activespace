using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class CustomPanel : Panel
    {
        // --- الخصائص القابلة للتعديل ---
        private int borderRadius = 20;
        private Color borderColor = Color.FromArgb(230, 230, 230);
        private float borderSize = 1f;
        private bool showShadow = true;
        private int shadowOpacity = 20; // شفافية الظل

        [Category("Custom Properties")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; this.Invalidate(); }
        }

        [Category("Custom Properties")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; this.Invalidate(); }
        }

        [Category("Custom Properties")]
        public float BorderSize
        {
            get => borderSize;
            set { borderSize = value; this.Invalidate(); }
        }

        [Category("Custom Properties")]
        public bool ShowShadow
        {
            get => showShadow;
            set { showShadow = value; this.Invalidate(); }
        }

        public CustomPanel()
        {
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
            this.Size = new Size(200, 100);
        }

        // --- ميثود الرسم الأساسية ---
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 1. حل مشكلة الزوايا: تلوين الخلفية الخارجية بلون الحاوية الأب (Parent) غير الشفاف
            if (this.Parent != null)
            {
                Color parentColor = this.Parent.BackColor;
                Control currentParent = this.Parent;
                while (parentColor == Color.Transparent && currentParent.Parent != null)
                {
                    currentParent = currentParent.Parent;
                    parentColor = currentParent.BackColor;
                }
                if (parentColor == Color.Transparent)
                {
                    parentColor = Color.FromArgb(248, 250, 252); // اللون الاحتياطي الافتراضي للوحة التحكم
                }

                using (SolidBrush parentBrush = new SolidBrush(parentColor))
                {
                    g.FillRectangle(parentBrush, this.ClientRectangle);
                }
            }

            // تحديد مساحة الرسم مع ترك هامش بسيط للظل
            Rectangle rectSurface = new Rectangle(5, 5, this.Width - 15, this.Height - 15);

            using (GraphicsPath path = GetRoundedPath(rectSurface, borderRadius))
            {
                // 2. رسم الظل الخفيف (Shadow)
                if (showShadow)
                {
                    // رسم عدة طبقات بسيطة لتعطي تأثير ظل ناعم (Gradient-like shadow)
                    for (int i = 1; i <= 3; i++)
                    {
                        using (Pen shadowPen = new Pen(Color.FromArgb(shadowOpacity / i, Color.Black), i * 2))
                        {
                            g.DrawPath(shadowPen, path);
                        }
                    }
                }

                // 3. تلوين خلفية البانل الأساسية
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(brush, path);
                }

                // 4. رسم الإطار الخارجي (Border)
                if (borderSize > 0)
                {
                    using (Pen pen = new Pen(borderColor, borderSize))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
        }

        // ميثود بناء المسار المنحني
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = Math.Max(radius * 2f, 1f);

            // ضمان عدم تجاوز القطر لأبعاد المستطيل
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

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Invalidate();
        }

        // إعادة الرسم عند تغيير لون الخلفية لضمان استجابة البانل
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.Invalidate();
        }
    }
}