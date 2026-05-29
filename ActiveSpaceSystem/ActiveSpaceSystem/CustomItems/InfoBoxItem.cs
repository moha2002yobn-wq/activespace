using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class InfoBox : Panel
    {
        // الحقول الخاصة بالنصوص والصور
        private string title = "ما هي العقود الشهرية؟";
        private string description = "العقود الشهرية تتيح حجز موعد ثابت أسبوعياً لفترة محددة. مثلاً: حجز ملعب كرة القدم كل يوم سبت الساعة 6 مساءً لمدة 3 أشهر.";
        private Image icon;
        private int iconSize = 25;

        // الخصائص الجديدة للخطوط والحواف
        private int borderRadius = 15;
        private Font titleFont = new Font("Tajawal", 11, FontStyle.Bold);
        private Font descFont = new Font("Tajawal", 9, FontStyle.Regular);

        // الألوان
        private Color borderColor = Color.FromArgb(180, 210, 255);
        private Color fillColor = Color.FromArgb(240, 248, 255);
        private Color titleColor = Color.FromArgb(29, 53, 87);
        private Color descColor = Color.FromArgb(69, 123, 157);

        [Category("Abdul Style")]
        public string Title { get => title; set { title = value; Invalidate(); } }

        [Category("Abdul Style")]
        public string Description { get => description; set { description = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Font TitleFont { get => titleFont; set { titleFont = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Font DescriptionFont { get => descFont; set { descFont = value; Invalidate(); } }

        [Category("Abdul Style")]
        public int BorderRadius { get => borderRadius; set { borderRadius = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Image Icon { get => icon; set { icon = value; Invalidate(); } }

        [Category("Abdul Style")]
        public int IconSize { get => iconSize; set { iconSize = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Color BorderColor { get => borderColor; set { borderColor = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Color FillColor { get => fillColor; set { fillColor = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Color TitleColor { get => titleColor; set { titleColor = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Color DescriptionColor { get => descColor; set { descColor = value; Invalidate(); } }

        public InfoBox()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(600, 90);
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle rect = new Rectangle(1, 1, this.Width - 2, this.Height - 2);

            // 1. رسم الخلفية والحدود الدائرية باستخدام خاصية BorderRadius
            using (GraphicsPath path = new GraphicsPath())
            {
                int d = borderRadius * 2;
                if (d > 1)
                {
                    path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                    path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                    path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                    path.CloseFigure();

                    using (SolidBrush brush = new SolidBrush(fillColor))
                        g.FillPath(brush, path);

                    using (Pen pen = new Pen(borderColor, 1))
                        g.DrawPath(pen, path);

                    this.Region = new Region(path); // لقص الحواف الخارجية
                }
            }

            // 2. رسم الأيقونة (إذا وجدت)
            int iconX = this.Width - iconSize - 15;
            int iconY = 15;
            if (icon != null)
            {
                g.DrawImage(icon, iconX, iconY, iconSize, iconSize);
            }

            // 3. رسم العنوان (باستخدام خاصية TitleFont)
            using (SolidBrush titleBrush = new SolidBrush(titleColor))
            {
                // ترك مساحة للأيقونة إذا كانت موجودة
                int textRightPadding = (icon != null) ? iconSize + 25 : 20;
                Rectangle titleRect = new Rectangle(15, 12, this.Width - textRightPadding - 15, 30);

                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(title, titleFont, titleBrush, titleRect, sf);
            }

            // 4. رسم الوصف (باستخدام خاصية DescriptionFont)
            using (SolidBrush descBrush = new SolidBrush(descColor))
            {
                // المستطيل يبدأ تحت العنوان
                Rectangle descRect = new Rectangle(15, 45, this.Width - 30, this.Height - 55);

                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Near
                };
                g.DrawString(description, descFont, descBrush, descRect, sf);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}