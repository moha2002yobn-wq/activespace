using ActiveSpaceSystem.Models.enums;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.GridStyle
{
    /// <summary>
    /// يتحمل كل عمليات رسم وتصميم شبكة الحجوزات
    /// </summary>
    public class BookingGridRenderer
    {
        private readonly ImageList actionImageList;

        public BookingGridRenderer(ImageList actionImageList)
        {
            this.actionImageList = actionImageList ?? throw new ArgumentNullException(nameof(actionImageList));
        }

        /// <summary>
        /// رسم خلية الحالة ببطاقة ملونة
        /// </summary>
        public void RenderStatusCell(DataGridViewCellPaintingEventArgs e, BookingStatus status)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            var (displayStatus, backColor, textColor) = GetStatusStyle(status);

            // رسم الشكل البيضاوي (Capsule)
            Rectangle rect = new Rectangle(
                e.CellBounds.X + BookingGridStyles.StatusPadding,
                e.CellBounds.Y + BookingGridStyles.StatusVerticalPadding,
                Math.Max(0, e.CellBounds.Width - 20),
                Math.Max(0, e.CellBounds.Height - 30)
            );

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (rect.Width > 0 && rect.Height > 0)
            {
                using (GraphicsPath path = CreateCapsulePath(rect))
                using (SolidBrush sb = new SolidBrush(backColor))
                    e.Graphics.FillPath(sb, path);
            }

            TextRenderer.DrawText(e.Graphics, displayStatus, e.CellStyle.Font, e.CellBounds,
                                  textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            e.Handled = true;
        }

        /// <summary>
        /// رسم خلية الإجراءات بأزرار التعديل والحذف
        /// </summary>
        public void RenderActionsCell(DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            if (actionImageList?.Images.Count < 2)
                return;

            int buttonSize = BookingGridStyles.ActionButtonSize;
            int iconSize = BookingGridStyles.ActionIconSize;
            int spacing = BookingGridStyles.ActionButtonSpacing;
            int cornerRadius = BookingGridStyles.ActionButtonRadius;

            int totalWidth = (buttonSize * 2) + spacing;
            int centerX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
            int centerY = e.CellBounds.Y + (e.CellBounds.Height - buttonSize) / 2;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // رسم زر التعديل
            DrawActionButton(e.Graphics, centerX, centerY, buttonSize, iconSize, cornerRadius,
                            BookingGridStyles.EditButtonBack, "edit");

            // رسم زر الحذف
            DrawActionButton(e.Graphics, centerX + buttonSize + spacing, centerY, buttonSize, iconSize,
                            cornerRadius, BookingGridStyles.DeleteButtonBack, "delete");

            e.Handled = true;
        }

        /// <summary>
        /// الحصول على معلومات الحالة (النص واللون)
        /// </summary>
        private (string DisplayStatus, Color BackColor, Color TextColor) GetStatusStyle(BookingStatus status)
        {
            return status switch
            {
                BookingStatus.Confirmed => (BookingGridStyles.TextConfirmed, BookingGridStyles.ColorConfirmedBack, BookingGridStyles.ColorConfirmedText),
                BookingStatus.Completed => (BookingGridStyles.TextCompleted, BookingGridStyles.ColorCompletedBack, BookingGridStyles.ColorCompletedText),

                _ => (BookingGridStyles.TextPending, BookingGridStyles.ColorPendingBack, BookingGridStyles.ColorPendingText)
            };
        }

        /// <summary>
        /// رسم زر واحد مع الأيقونة
        /// </summary>
        private void DrawActionButton(Graphics graphics, int x, int y, int buttonSize, int iconSize,
                                     int cornerRadius, Color backgroundColor, string iconKey)
        {
            var buttonRect = new Rectangle(x, y, buttonSize, buttonSize);

            // رسم الخلفية برواديوس
            using (var path = CreateRoundedRectangle(buttonRect, cornerRadius))
            using (var brush = new SolidBrush(backgroundColor))
                graphics.FillPath(brush, path);

            // رسم الأيقونة في المنتصف
            int iconOffsetX = (buttonSize - iconSize) / 2;
            int iconOffsetY = (buttonSize - iconSize) / 2;
            var iconRect = new Rectangle(x + iconOffsetX, y + iconOffsetY, iconSize, iconSize);
            graphics.DrawImage(actionImageList.Images[iconKey], iconRect);
        }

        /// <summary>
        /// إنشاء مسار مستطيل برواديوس
        /// </summary>
        private GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        /// <summary>
        /// إنشاء شكل بيضاوي (Capsule)
        /// </summary>
        private GraphicsPath CreateCapsulePath(Rectangle rect)
        {
            var path = new GraphicsPath();
            int d = rect.Height;

            if (d > 0)
            {
                path.AddArc(rect.X, rect.Y, d, d, 90, 180);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 180);
                path.CloseFigure();
            }

            return path;
        }

        /// <summary>
        /// حساب منطقة الزر المضغوط (لكشف النقر)
        /// </summary>
        public (bool IsEdit, bool IsDelete) GetClickedButton(Rectangle cellRect, int relativeX)
        {
            int buttonSize = BookingGridStyles.ActionButtonSize;
            int spacing = BookingGridStyles.ActionButtonSpacing;
            int totalWidth = (buttonSize * 2) + spacing;
            int centerX = (cellRect.Width - totalWidth) / 2;

            bool isEdit = relativeX >= centerX && relativeX < centerX + buttonSize;
            bool isDelete = relativeX >= centerX + buttonSize + spacing && relativeX < centerX + totalWidth;

            return (isEdit, isDelete);
        }
    }
}