using ActiveSpaceSystem.CustomItems;
using ActiveSpaceSystem.Models.enums;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.GridStyle
{
    public class PaymentGridRenderer
    {
        private readonly MyGunaButton _btnRenderer;

        public PaymentGridRenderer()
        {
            _btnRenderer = new MyGunaButton
            {
                NormalBackColor = Color.FromArgb(0, 184, 148),
                BorderRadius = 15,
                Font = new Font("Tajawal", 7, FontStyle.Bold)
            };
        }

        // رسم خلية الحالة بألوانها الدائرية الأنيقة
        public void RenderStatusCell(DataGridViewCellPaintingEventArgs e, BookingStatus status)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            string displayStatus;
            Color backColor, textColor;

            switch (status)
            {
                case BookingStatus.Completed:
                    backColor = Color.FromArgb(232, 245, 233);
                    textColor = Color.FromArgb(46, 125, 50);
                    displayStatus = "مكتمل";
                    break;
                case BookingStatus.Confirmed:
                    backColor = Color.FromArgb(255, 249, 196);
                    textColor = Color.FromArgb(245, 127, 23);
                    displayStatus = "جزئي";
                    break;
                default:
                    backColor = Color.FromArgb(255, 235, 238);
                    textColor = Color.FromArgb(198, 40, 40);
                    displayStatus = "غير مدفوع";
                    break;
            }

            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(e.CellBounds.X + 15, e.CellBounds.Y + 12, e.CellBounds.Width - 30, e.CellBounds.Height - 24);
                int d = rect.Height;
                path.AddArc(rect.X, rect.Y, d, d, 90, 180);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 180);
                path.CloseFigure();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush sb = new SolidBrush(backColor))
                    e.Graphics.FillPath(sb, path);
            }

            TextRenderer.DrawText(e.Graphics, displayStatus, e.CellStyle.Font, e.CellBounds, textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

            e.Handled = true;
        }

        // رسم زر تسجيل دفعة مخصص دائر الحواف وثابت الألوان
        public void RenderActionColumn(DataGridViewCellPaintingEventArgs e, double remaining)
        {
            bool isSelected = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected;
            Color cellBack = isSelected ? Color.FromArgb(248, 249, 250) : e.CellStyle.BackColor;

            using (SolidBrush backBrush = new SolidBrush(cellBack))
            {
                e.Graphics.FillRectangle(backBrush, e.CellBounds);
            }
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border);

            if (remaining > 0)
            {
                Rectangle btnRect = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 10, e.CellBounds.Width - 20, e.CellBounds.Height - 20);

                using (GraphicsPath path = new GraphicsPath())
                {
                    int r = _btnRenderer.BorderRadius;
                    path.AddArc(btnRect.X, btnRect.Y, r, r, 180, 90);
                    path.AddArc(btnRect.Right - r, btnRect.Y, r, r, 270, 90);
                    path.AddArc(btnRect.Right - r, btnRect.Bottom - r, r, r, 0, 90);
                    path.AddArc(btnRect.X, btnRect.Bottom - r, r, r, 90, 90);
                    path.CloseFigure();

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (SolidBrush br = new SolidBrush(_btnRenderer.NormalBackColor))
                        e.Graphics.FillPath(br, path);
                }
                TextRenderer.DrawText(e.Graphics, "تسجيل دفعة", _btnRenderer.Font, btnRect, Color.White,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
            e.Handled = true;
        }
    }
}