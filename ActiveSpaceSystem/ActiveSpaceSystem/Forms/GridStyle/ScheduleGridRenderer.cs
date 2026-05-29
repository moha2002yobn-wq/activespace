using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.GridStyle
{
    public class ScheduleGridRenderer
    {
        public void RenderScheduleCell(DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value == null) return;

            // 1. رسم الخلفية والحدود الافتراضية لمنع التشويه والحفاظ على خطوط الشبكة
            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

            string cellValue = e.Value.ToString();
            Color backColor = Color.White;
            Color textColor = Color.Black;
            string displayText = "";

            // تحديد الألوان والنصوص بناءً على القيمة المرسلة
            if (cellValue == "AVAILABLE")
            {
                backColor = Color.FromArgb(232, 245, 233); // أخضر فاتح
                textColor = Color.FromArgb(46, 125, 50);    // أخضر داكن
                displayText = "متاح";
            }
            else if (cellValue == "OFF_WORK")
            {
                backColor = Color.FromArgb(245, 245, 245); // رمادي فاتح
                textColor = Color.FromArgb(158, 158, 158); // رمادي داكن
                displayText = "مغلق";
            }
            else if (cellValue.StartsWith("BOOKED|"))
            {
                backColor = Color.FromArgb(255, 235, 238); // أحمر فاتح
                textColor = Color.FromArgb(198, 40, 40);    // أحمر داكن
                displayText = cellValue.Split('|')[1];     // اسم العميل
            }

            // تقليص مساحة الرسم قليلاً لترك حواف جمالية حول الكارد داخل الخلية
            Rectangle rect = new Rectangle(e.CellBounds.X + 3, e.CellBounds.Y + 3, e.CellBounds.Width - 6, e.CellBounds.Height - 6);

            if (rect.Width > 0 && rect.Height > 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // رسم مستطيل بزوايا دائرية متوافقة تماماً مع الاتجاهين (يمين/يسار)
                using (GraphicsPath path = GetRoundedRect(rect, 8))
                {
                    using (SolidBrush sb = new SolidBrush(backColor))
                    {
                        e.Graphics.FillPath(sb, path);
                    }
                }
            }

            // رسم النص المخصص بالاعتماد على اتجاه الـ DataGridView الفعلي تلقائياً
            TextFormatFlags flags = TextFormatFlags.VerticalCenter |
                                    TextFormatFlags.HorizontalCenter |
                                    TextFormatFlags.EndEllipsis;

            if (e.CellStyle.WrapMode == DataGridViewTriState.True)
            {
                flags |= TextFormatFlags.WordBreak;
            }

            TextRenderer.DrawText(e.Graphics, displayText, e.CellStyle.Font, e.CellBounds, textColor, flags);

            e.Handled = true;
        }

        // دالة آمنة ومقاومة للتقلبات البرمجية لإنشاء مستطيل دائري الحواف
        private GraphicsPath GetRoundedRect(Rectangle baseRect, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;

            // تحديد زوايا دائرية دقيقة للمستطيل
            path.AddArc(baseRect.X, baseRect.Y, diameter, diameter, 180, 90);
            path.AddArc(baseRect.Right - diameter, baseRect.Y, diameter, diameter, 270, 90);
            path.AddArc(baseRect.Right - diameter, baseRect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(baseRect.X, baseRect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}