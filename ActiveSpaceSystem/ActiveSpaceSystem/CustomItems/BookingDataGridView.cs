using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SportsApp.Controls
{
    public class BookingDataGridView : DataGridView
    {
        // تعريف الألوان
        private readonly Color HeaderBgColor = Color.FromArgb(245, 247, 249);
        private readonly Color AvailableBg = Color.FromArgb(232, 249, 244);
        private readonly Color AvailableText = Color.FromArgb(46, 204, 113);
        private readonly Color ReservedBg = Color.FromArgb(255, 225, 225);
        private readonly Color ReservedText = Color.FromArgb(231, 76, 60);
        private readonly Color GridLineColor = Color.FromArgb(230, 230, 230);

        // خاصية للتحكم في قطر الانحناء
        public int BorderRadius { get; set; } = 20;

        public BookingDataGridView()
        {
            this.DoubleBuffered = true;
            this.RightToLeft = RightToLeft.Yes;
            this.BackgroundColor = Color.White;
            this.BorderStyle = BorderStyle.None;
            this.RowHeadersVisible = false;
            this.AllowUserToAddRows = false;
            this.EnableHeadersVisualStyles = false;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.RowTemplate.Height = 70;
            this.GridColor = GridLineColor;

            this.ColumnHeadersDefaultCellStyle.BackColor = HeaderBgColor;
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.ColumnHeadersHeight = 50;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; // تم التغيير ليتناسب مع الانحناء
        }

        // كود قص الحواف لجعلها دائرية
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (GraphicsPath path = new GraphicsPath())
            {
                // إنشاء مسار مستطيل بحواف دائرية
                int radius = BorderRadius;
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);
            }
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            // 1. رسم رؤوس الأعمدة
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString(), e.CellStyle.Font,
                    e.CellBounds, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                // رسم خط سفلي فقط للرأس لإعطاء مظهر عصري
                using (Pen p = new Pen(GridLineColor))
                {
                    e.Graphics.DrawLine(p, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }
                e.Handled = true;
            }

            // 2. رسم عمود الملاعب
            else if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                e.PaintBackground(e.CellBounds, true);
                if (e.Value != null)
                {
                    string text = e.Value.ToString();
                    string[] parts = text.Split('\n');

                    Font titleFont = new Font("Segoe UI", 10, FontStyle.Bold);
                    Rectangle rectTitle = new Rectangle(e.CellBounds.X, e.CellBounds.Y + 15, e.CellBounds.Width, 25);
                    TextRenderer.DrawText(e.Graphics, parts[0], titleFont, rectTitle, Color.Black, TextFormatFlags.HorizontalCenter);

                    if (parts.Length > 1)
                    {
                        Font subFont = new Font("Segoe UI", 8, FontStyle.Regular);
                        Rectangle rectSub = new Rectangle(e.CellBounds.X, e.CellBounds.Y + 38, e.CellBounds.Width, 20);
                        TextRenderer.DrawText(e.Graphics, parts[1], subFont, rectSub, Color.Gray, TextFormatFlags.HorizontalCenter);
                    }
                }

                // رسم إطار الخلية
                using (Pen p = new Pen(GridLineColor))
                {
                    e.Graphics.DrawRectangle(p, e.CellBounds);
                }
                e.Handled = true;
            }

            // 3. رسم خلايا الحجز
            else if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                string status = e.Value?.ToString() ?? "";
                Color backColor = status.Contains("محجوز") ? ReservedBg : AvailableBg;
                Color textColor = status.Contains("محجوز") ? ReservedText : AvailableText;

                e.Graphics.FillRectangle(new SolidBrush(this.BackgroundColor), e.CellBounds);

                // رسم مستطيل داخلي منحني قليلاً (Padding) لجعل الخلايا تبدو كبطاقات
                Rectangle cardRect = new Rectangle(e.CellBounds.X + 3, e.CellBounds.Y + 3, e.CellBounds.Width - 6, e.CellBounds.Height - 6);

                using (GraphicsPath path = GetRoundedRect(cardRect, 10)) // انحناء صغير لكل خلية
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (SolidBrush brush = new SolidBrush(backColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }

                TextRenderer.DrawText(e.Graphics, status, e.CellStyle.Font, e.CellBounds,
                    textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                e.Handled = true;
            }
        }

        // وظيفة مساعدة لرسم مستطيل منحني
        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius;
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }

        public void InitializeTimeSlots(int startHour, int endHour)
        {
            this.Columns.Clear();
            this.Columns.Add("CourtName", "الملعب");
            this.Columns[0].Width = 180;

            for (int i = startHour; i <= endHour; i++)
            {
                string colName = $"h{i}";
                string colHeader = $"{i}:00";
                int idx = this.Columns.Add(colName, colHeader);
                this.Columns[idx].Width = 100;
                this.Columns[idx].DefaultCellStyle.Font = new Font("Segoe UI", 9);
            }
        }
    }
}