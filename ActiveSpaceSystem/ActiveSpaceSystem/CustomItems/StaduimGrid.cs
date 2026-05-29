using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    public class StadiumGrid : DataGridView
    {
        private int _borderRadius = 25;
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; UpdateRegion(); }
        }

        public StadiumGrid()
        {
            // إعدادات لضمان النظافة التامة (إخفاء الحدود المزعجة)
            this.DoubleBuffered = true;
            this.BackgroundColor = Color.White;
            this.BorderStyle = BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.RowHeadersVisible = false;
            this.AllowUserToAddRows = false;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.EnableHeadersVisualStyles = false;
            this.GridColor = Color.White;

            // إعداد الهيدر
            this.ColumnHeadersHeight = 50;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(52, 58, 64);
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Tajawal", 10f, FontStyle.Bold);
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.DefaultCellStyle.Font = new Font("Tajawal", 9f);
            this.RowTemplate.Height = 70;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.Columns.Count > 0)
            {
                // تثبيت العمود الأول تلقائياً
                this.Columns[0].Frozen = true;
                this.Columns[0].Width = 180;
                this.Columns[0].DefaultCellStyle.BackColor = Color.FromArgb(250, 251, 252);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                int r = _borderRadius;
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();
                this.Region = new Region(path);
            }
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            // 1. رسم الهيدر بشكل طبيعي لضمان ظهور الأوقات
            if (e.RowIndex < 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Handled = true;
                return;
            }

            // 2. رسم العمود الأول (أسماء الملاعب)
            if (e.ColumnIndex == 0)
            {
                using (SolidBrush backBrush = new SolidBrush(Color.FromArgb(250, 251, 252)))
                {
                    e.Graphics.FillRectangle(backBrush, e.CellBounds);
                }
                if (e.Value != null)
                {
                    TextRenderer.DrawText(e.Graphics, e.Value.ToString(), new Font("Tajawal", 9.5f, FontStyle.Bold),
                        e.CellBounds, Color.FromArgb(52, 58, 64), TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }
                using (Pen p = new Pen(Color.FromArgb(230, 236, 240)))
                {
                    e.Graphics.DrawLine(p, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                }
                e.Handled = true;
                return;
            }

            // 3. مسح خلفية الخلية باللون الأبيض (لمنع الخطوط السوداء)
            e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

            if (e.Value != null)
            {
                string cellValue = e.Value.ToString();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // تعديل البادينق بناءً على طلبك (تم تقليل الهوامش لتملأ الكبسولة الخلية)
                Rectangle rect = new Rectangle(e.CellBounds.X + 2, e.CellBounds.Y + 3, e.CellBounds.Width - 4, e.CellBounds.Height - 6);

                if (cellValue == "متاح")
                {
                    DrawStatusCell(e.Graphics, rect, "متاح", "", Color.FromArgb(235, 250, 242), Color.FromArgb(35, 150, 80));
                }
                else if (cellValue == "خارج وقت العمل") // الخيار الجديد
                {
                    DrawStatusCell(e.Graphics, rect, "خارج وقت العمل", "", Color.FromArgb(240, 242, 245), Color.FromArgb(108, 117, 125));
                }
                else if (cellValue.Contains("|"))
                {
                    var parts = cellValue.Split('|');
                    DrawStatusCell(e.Graphics, rect, parts[0], parts[1], Color.FromArgb(255, 238, 238), Color.FromArgb(210, 45, 60));
                }
            }

            e.Handled = true;
        }

        private void DrawStatusCell(Graphics g, Rectangle rect, string title, string subTitle, Color backColor, Color textColor)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int r = 8; // انحناء بسيط ومناسب للبادينق الجديد
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(backColor))
                    g.FillPath(brush, path);
            }

            Font titleFont = new Font("Tajawal", 9f, FontStyle.Bold);
            // توزيع النص لملء المساحة بعد إلغاء البادينق
            Rectangle titleRect = new Rectangle(rect.X, rect.Y, rect.Width, string.IsNullOrEmpty(subTitle) ? rect.Height : rect.Height / 2 + 5);
            TextRenderer.DrawText(g, title, titleFont, titleRect, textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            if (!string.IsNullOrEmpty(subTitle))
            {
                Font subFont = new Font("Tajawal", 8f);
                Rectangle subRect = new Rectangle(rect.X, rect.Y + (rect.Height / 2), rect.Width, rect.Height / 2);
                TextRenderer.DrawText(g, subTitle, subFont, subRect, Color.Gray, TextFormatFlags.HorizontalCenter | TextFormatFlags.Top);
            }
        }
    }
}