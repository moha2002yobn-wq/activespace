using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class CustomerCard : Panel
    {
        // --- الخصائص القابلة للتعديل من الـ Properties ---
        private string titleText = "إجمالي العملاء";
        private string valueText = "156";
        private int borderRadius = 15;
        private Color iconBackColor = Color.FromArgb(235, 239, 253);
        private Color titleColor = Color.Gray;
        private Color valueColor = Color.MidnightBlue;
        private int iconSize = 24;

        [Category("Custom Layout")]
        public string TitleText { get => titleText; set { titleText = value; Invalidate(); } }

        [Category("Custom Layout")]
        public string ValueText { get => valueText; set { valueText = value; Invalidate(); } }

        [Category("Custom Layout")]
        public Image IconImage { get; set; }

        [Category("Custom Layout")]
        public Color IconBackColor { get => iconBackColor; set { iconBackColor = value; Invalidate(); } }

        [Category("Custom Layout")]
        public int BorderRadius { get => borderRadius; set { borderRadius = value; Invalidate(); } }

        [Category("Custom Layout")]
        public Color TitleColor { get => titleColor; set { titleColor = value; Invalidate(); } }

        [Category("Custom Layout")]
        public Color ValueColor { get => valueColor; set { valueColor = value; Invalidate(); } }

        [Category("Custom Layout")]
        [Description("تحديد حجم الأيقونة داخل المربع الملون")]
        public int IconSize
        {
            get => iconSize;
            set { iconSize = value; Invalidate(); }
        }

        [Category("Custom Layout")]
        public Font TitleFont { get; set; } = new Font("Segoe UI", 9);

        [Category("Custom Layout")]
        public Font ValueFont { get; set; } = new Font("Segoe UI", 18, FontStyle.Bold);

        public CustomerCard()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.Size = new Size(250, 100);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 1. حل مشكلة الزوايا البيضاء: رسم لون خلفية الحاوية (Parent) خلف الكارد
            if (this.Parent != null)
            {
                using (SolidBrush parentBrush = new SolidBrush(this.Parent.BackColor))
                {
                    g.FillRectangle(parentBrush, this.ClientRectangle);
                }
            }

            // تحديد مستطيل الكارد (ترك مسافة بسيطة للظل)
            Rectangle rect = new Rectangle(5, 5, this.Width - 15, this.Height - 15);

            using (GraphicsPath path = GetRoundedRect(rect, borderRadius))
            {
                // 2. رسم الظل الخفيف
                using (Pen shadowPen = new Pen(Color.FromArgb(20, Color.Black), 3))
                {
                    g.DrawPath(shadowPen, path);
                }

                // 3. تلوين خلفية الكارد الأساسية
                using (SolidBrush bgBrush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(bgBrush, path);
                }

                // 4. رسم الإطار الخارجي الباهت
                using (Pen borderPen = new Pen(Color.FromArgb(225, 225, 225), 1))
                {
                    g.DrawPath(borderPen, path);
                }
            }

            // 5. رسم مربع الأيقونة (Icon Box)
            int iconBoxSize = 50;
            Rectangle iconRect = new Rectangle(this.Width - iconBoxSize - 25, (this.Height - iconBoxSize) / 2, iconBoxSize, iconBoxSize);

            using (GraphicsPath iconPath = GetRoundedRect(iconRect, 12))
            {
                using (SolidBrush iconBackBrush = new SolidBrush(iconBackColor))
                {
                    g.FillPath(iconBackBrush, iconPath);
                }

                if (IconImage != null)
                {
                    // رسم الأيقونة وتوسيطها بناءً على الـ IconSize المختار
                    g.DrawImage(IconImage,
                        iconRect.X + (iconBoxSize - iconSize) / 2,
                        iconRect.Y + (iconBoxSize - iconSize) / 2,
                        iconSize,
                        iconSize);
                }
            }

            // 6. رسم النصوص (العنوان والقيمة) مع محاذاة لليمين
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

            // رسم العنوان (Title)
            Rectangle titleRect = new Rectangle(15, 20, iconRect.X - 30, 30);
            using (SolidBrush titleBrush = new SolidBrush(titleColor))
            {
                g.DrawString(titleText, TitleFont, titleBrush, titleRect, sf);
            }

            // رسم القيمة (Value)
            Rectangle valueRect = new Rectangle(15, 45, iconRect.X - 30, 40);
            using (SolidBrush valueBrush = new SolidBrush(valueColor))
            {
                g.DrawString(valueText, ValueFont, valueBrush, valueRect, sf);
            }
        }

        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = Math.Max(radius * 2f, 1f);
            if (diameter >= rect.Width || diameter >= rect.Height) diameter = Math.Min(rect.Width, rect.Height) - 1;

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
    }
}