using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    [ToolboxItem(true)]
    public class PillButton : Button
    {
        public PillButton()
        {
            // إعدادات أساسية لضمان نعومة الرسم
            DoubleBuffered = true;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;

            CheckedBackColor = Color.FromArgb(41, 51, 146);
            CheckedForeColor = Color.White;
            UncheckedBackColor = Color.FromArgb(242, 242, 242);
            UncheckedForeColor = Color.FromArgb(64, 64, 64);

            Size = new Size(110, 36);
            Font = new Font("Segoe UI Semibold", 10F);
        }

        private bool _checked;
        public bool Checked
        {
            get => _checked;
            set { _checked = value; Invalidate(); OnCheckedChanged(EventArgs.Empty); }
        }

        public Color CheckedBackColor { get; set; }
        public Color CheckedForeColor { get; set; }
        public Color UncheckedBackColor { get; set; }
        public Color UncheckedForeColor { get; set; }
        public int Radius { get; set; } = 15;
        public string GroupName { get; set; } = string.Empty;

        public event EventHandler CheckedChanged;
        protected virtual void OnCheckedChanged(EventArgs e) => CheckedChanged?.Invoke(this, e);

        // هذا التابع هو السر: يقوم بقص حدود الأداة لتصبح منحنية فعلياً
        private void UpdateRegion()
        {
            using (GraphicsPath path = GetRoundedRect(new Rectangle(0, 0, Width, Height), Radius))
            {
                this.Region = new Region(path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion(); // إعادة القص عند تغيير الحجم
        }

        protected override void OnClick(EventArgs e)
        {
            if (!string.IsNullOrEmpty(GroupName) && Parent != null)
            {
                foreach (Control ctl in Parent.Controls)
                {
                    if (ctl is PillButton pb && pb != this && pb.GroupName == GroupName)
                        pb.Checked = false;
                }
                Checked = true;
            }
            else { Checked = !Checked; }
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color currentBack = Checked ? CheckedBackColor : UncheckedBackColor;
            Color currentText = Checked ? CheckedForeColor : UncheckedForeColor;

            // تلوين الخلفية
            using (SolidBrush brush = new SolidBrush(currentBack))
            {
                g.FillRectangle(brush, ClientRectangle);
            }

            // رسم النص
            TextRenderer.DrawText(g, Text, Font, ClientRectangle, currentText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float d = radius * 2f;
            if (d > rect.Width) d = rect.Width;
            if (d > rect.Height) d = rect.Height;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}