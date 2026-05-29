using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class RoundedPictureBox : PictureBox
    {
        private int borderRadius = 20; // القيمة الافتراضية للميول

        [Category("Abdul Style")]
        [Description("تعديل زوايا الصورة (Radius)")]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                borderRadius = value;
                this.Invalidate(); // إعادة الرسم عند تغيير القيمة
            }
        }

        public RoundedPictureBox()
        {
            this.SizeMode = PictureBoxSizeMode.StretchImage; // القيمة الافتراضية
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // لتكون الزوايا ناعمة وغير مششرة

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            using (GraphicsPath path = new GraphicsPath())
            {
                int d = borderRadius;

                // التأكد من أن القيمة لا تتجاوز حجم الأداة
                if (d > 1)
                {
                    path.AddArc(0, 0, d, d, 180, 90);
                    path.AddArc(this.Width - d, 0, d, d, 270, 90);
                    path.AddArc(this.Width - d, this.Height - d, d, d, 0, 90);
                    path.AddArc(0, this.Height - d, d, d, 90, 90);
                    path.CloseFigure();

                    // قص الأداة لتأخذ شكل المسار الدائري
                    this.Region = new Region(path);

                    // إذا كان هناك إطار (Border) اختياري، يمكنك رسمه هنا
                    /*
                    using (Pen pen = new Pen(Color.Gray, 1))
                    {
                        g.DrawPath(pen, path);
                    }
                    */
                }
                else
                {
                    this.Region = new Region(rect);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // لضمان تحديث الشكل عند تغيير الحجم في الـ Designer
        }
    }
}