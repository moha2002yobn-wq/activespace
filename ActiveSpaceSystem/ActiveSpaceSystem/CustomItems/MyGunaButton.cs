using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    [ToolboxItem(true)]
    public class MyGunaButton : Button
    {
        [Category("Guna Style")]
        public int BorderRadius { get; set; } = 15;

        [Category("Guna Style")]
        public Color HoverBackColor { get; set; } = Color.FromArgb(28, 50, 85);

        [Category("Guna Style")]
        public Color NormalBackColor { get; set; } = Color.SteelBlue;

        private Font _defaultFont = new Font("Segoe UI Variable Display", 12, FontStyle.Bold);
        private bool isHovering = false;

        public MyGunaButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            // السطرين القادمين لمنع الويندوز من رسم أي إطار عند الضغط أو التركيز
            this.FlatAppearance.MouseDownBackColor = HoverBackColor;
            this.FlatAppearance.MouseOverBackColor = HoverBackColor;

            this.BackColor = NormalBackColor;
            this.ForeColor = Color.White;
            this.Size = new Size(150, 45);
            this.Cursor = Cursors.Hand;
            this.Font = _defaultFont;
            this.UseVisualStyleBackColor = false;
        }

        // إلغاء مستطيل التركيز نهائياً
        protected override bool ShowFocusCues => false;

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovering = true;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHovering = false;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // لا تستخدم base.OnPaint
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Color currentBgColor = isHovering ? HoverBackColor : NormalBackColor;

            // تحديد المستطيل مع تصغيره قليلاً جداً لتفادي حواف الويندوز المزعجة
            RectangleF rect = new RectangleF(0.5f, 0.5f, this.Width - 1, this.Height - 1);
            float r = BorderRadius;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
                path.AddArc(rect.Width - (r * 2), rect.Y, r * 2, r * 2, 270, 90);
                path.AddArc(rect.Width - (r * 2), rect.Height - (r * 2), r * 2, r * 2, 0, 90);
                path.AddArc(rect.X, rect.Height - (r * 2), r * 2, r * 2, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path); // قص الحواف الفيزيائية للزر

                using (SolidBrush brush = new SolidBrush(currentBgColor))
                {
                    g.FillPath(brush, path);
                }

                // إضافة قلم (Pen) بنفس لون الخلفية لرسم إطار ناعم يخفي عيوب القص
                using (Pen pen = new Pen(currentBgColor, 1.5f))
                {
                    g.DrawPath(pen, path);
                }
            }

            // رسم الأيقونة والنص
            int iconSize = 24;
            int padding = 20;
            int textX = padding;

            if (this.Image != null)
            {
                int yPos = (this.Height - iconSize) / 2;
                g.DrawImage(this.Image, new Rectangle(padding, yPos, iconSize, iconSize));
                textX = padding + iconSize + 12;
            }

            Rectangle textRect = new Rectangle(textX, 0, this.Width - textX, this.Height);
            TextRenderer.DrawText(g, this.Text, this.Font, textRect, this.ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }
    }
}