using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class StatusCard : Panel
    {
        // الحقول الخاصة بالبيانات
        private string titleText = "العقود النشطة";
        private string valueText = "18";
        private int borderRadius = 15;

        // ألوان النصوص
        private Color titleColor = Color.Gray;
        private Color valueColor = Color.FromArgb(46, 204, 113);
        private Color cardBackColor = Color.White;
        private Color borderColor = Color.FromArgb(240, 240, 240); // إطار خفيف جداً

        // خصائص الظل الجديدة
        private bool showShadow = true;
        private Color shadowColor = Color.FromArgb(100, 0, 0, 0); // ظل أسود شفاف (100 هي الـ Alpha)
        private int shadowBlur = 5; // مدى انتشار الظل

        // خطوط قابلة للتعديل
        private Font titleFont = new Font("Tajawal", 10, FontStyle.Regular);
        private Font valueFont = new Font("Tajawal", 18, FontStyle.Bold);

        [Category("Abdul Style - Content")]
        public string TitleText { get => titleText; set { titleText = value; Invalidate(); } }

        [Category("Abdul Style - Content")]
        public string ValueText { get => valueText; set { valueText = value; Invalidate(); } }

        [Category("Abdul Style - Content")]
        public Font TitleFont { get => titleFont; set { titleFont = value; Invalidate(); } }

        [Category("Abdul Style - Content")]
        public Font ValueFont { get => valueFont; set { valueFont = value; Invalidate(); } }

        [Category("Abdul Style - Content")]
        public Color TitleColor { get => titleColor; set { titleColor = value; Invalidate(); } }

        [Category("Abdul Style - Content")]
        public Color ValueColor { get => valueColor; set { valueColor = value; Invalidate(); } }

        [Category("Abdul Style - Structure")]
        public int BorderRadius { get => borderRadius; set { borderRadius = value; Invalidate(); } }

        [Category("Abdul Style - Structure")]
        public Color CardBackColor { get => cardBackColor; set { cardBackColor = value; Invalidate(); } }

        [Category("Abdul Style - Structure")]
        public Color BorderColor { get => borderColor; set { borderColor = value; Invalidate(); } }

        // خصائص الظل في الـ Properties
        [Category("Abdul Style - Shadow")]
        public bool ShowShadow { get => showShadow; set { showShadow = value; Invalidate(); } }

        [Category("Abdul Style - Shadow")]
        public Color ShadowColor { get => shadowColor; set { shadowColor = value; Invalidate(); } }

        [Category("Abdul Style - Shadow")]
        public int ShadowBlur { get => shadowBlur; set { shadowBlur = value; Invalidate(); } }

        public StatusCard()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(200, 100);
            this.BackColor = Color.Transparent; // مهم جداً لظهور الظل خلف الكارد
            this.Padding = new Padding(shadowBlur); // ترك مساحة للظل داخل الأداة
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // مساحة الكارد الفعلي بعد خصم مساحة الظل
            Rectangle cardRect = new Rectangle(shadowBlur, shadowBlur, this.Width - (shadowBlur * 2) - 1, this.Height - (shadowBlur * 2) - 1);

            // 1. رسم الظل (إذا كان مفعلاً)
            if (showShadow && shadowBlur > 0)
            {
                using (GraphicsPath shadowPath = GetRoundedRectPath(cardRect, borderRadius))
                {
                    // رسم طبقات من الظل الخفيف تدريجياً ليعطي تأثير الـ Blur
                    for (int i = 0; i < shadowBlur; i++)
                    {
                        using (PathGradientBrush pgb = new PathGradientBrush(shadowPath))
                        {
                            pgb.CenterColor = shadowColor;
                            pgb.SurroundColors = new Color[] { Color.Transparent };
                            pgb.FocusScales = new PointF(1.0f - (0.1f * i), 1.0f - (0.1f * i));

                            g.FillPath(pgb, shadowPath);
                        }
                    }
                }
            }

            // 2. رسم جسم البطاقة (الحواف الدائرية)
            using (GraphicsPath path = GetRoundedRectPath(cardRect, borderRadius))
            {
                // رسم الخلفية
                using (SolidBrush brush = new SolidBrush(cardBackColor))
                    g.FillPath(brush, path);

                // رسم الإطار الخارجي (Border)
                using (Pen pen = new Pen(borderColor, 1))
                    g.DrawPath(pen, path);
            }

            // 3. رسم العنوان (Title)
            using (SolidBrush brush = new SolidBrush(titleColor))
            {
                Rectangle titleRect = new Rectangle(cardRect.X + 10, cardRect.Y + 15, cardRect.Width - 25, 30);
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Far };
                g.DrawString(titleText, titleFont, brush, titleRect, sf);
            }

            // 4. رسم القيمة (Value)
            using (SolidBrush brush = new SolidBrush(valueColor))
            {
                Rectangle valueRect = new Rectangle(cardRect.X + 10, cardRect.Bottom - 50, cardRect.Width - 25, 40);
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Far };
                g.DrawString(valueText, valueFont, brush, valueRect, sf);
            }
        }

        // دالة مساعدة لإنشاء مسار المستطيل الدائري
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}