using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.GridStyle
{
    public class PurchaseGridRenderer
    {
        private readonly ImageList actionImageList;

        public PurchaseGridRenderer(ImageList actionImageList)
        {
            this.actionImageList = actionImageList ?? throw new ArgumentNullException(nameof(actionImageList));
        }

        public void RenderCategoryCell(DataGridViewCellPaintingEventArgs e, string category)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            // Always color all categories exactly like "كرات رياضية"
            Color backColor = PurchaseGridStyles.ColorCategorySportsBallsBack;
            Color textColor = PurchaseGridStyles.ColorCategorySportsBallsText;

            Rectangle rect = new Rectangle(
                e.CellBounds.X + 15,
                e.CellBounds.Y + 12,
                Math.Max(0, e.CellBounds.Width - 30),
                Math.Max(0, e.CellBounds.Height - 24)
            );

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (rect.Width > 0 && rect.Height > 0)
            {
                using (GraphicsPath path = CreateCapsulePath(rect))
                using (SolidBrush sb = new SolidBrush(backColor))
                    e.Graphics.FillPath(sb, path);
            }

            TextRenderer.DrawText(e.Graphics, category, e.CellStyle.Font, e.CellBounds,
                                   textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            e.Handled = true;
        }

        public void RenderCourtCell(DataGridViewCellPaintingEventArgs e, string courtName)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            if (string.IsNullOrEmpty(courtName))
            {
                e.Handled = true;
                return;
            }

            Color backColor = PurchaseGridStyles.ColorCourtBack;
            Color textColor = PurchaseGridStyles.ColorCourtText;

            var items = courtName.Split(new[] { '،', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .Where(x => !string.IsNullOrEmpty(x))
                            .ToList();

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Font font = e.CellStyle.Font;

            if (items.Count <= 1)
            {
                // Single pill
                int maxPillWidth = e.CellBounds.Width - 16;
                if (maxPillWidth < 50) maxPillWidth = 50;

                Size textSize = TextRenderer.MeasureText(courtName, font);

                int paddingX = 14;
                int paddingY = 6;

                int pillWidth = textSize.Width + paddingX * 2;
                if (pillWidth > maxPillWidth) pillWidth = maxPillWidth;

                int pillHeight = textSize.Height + paddingY * 2;
                int maxPillHeight = e.CellBounds.Height - 16;
                if (pillHeight > maxPillHeight) pillHeight = maxPillHeight;

                int pillX = e.CellBounds.X + (e.CellBounds.Width - pillWidth) / 2;
                int pillY = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;

                Rectangle rect = new Rectangle(pillX, pillY, pillWidth, pillHeight);

                if (rect.Width > 0 && rect.Height > 0)
                {
                    using (GraphicsPath path = CreateRoundedRectangle(rect, pillHeight / 2))
                    using (SolidBrush sb = new SolidBrush(backColor))
                        e.Graphics.FillPath(sb, path);
                }

                TextRenderer.DrawText(e.Graphics, courtName, font, rect, textColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis);
            }
            else
            {
                // Multiple pills wrapping RTL
                int marginX = 6;
                int marginY = 4;
                int paddingX = 8;
                int paddingY = 4;

                int startX = e.CellBounds.Right - 8;
                int startY = e.CellBounds.Y + 6;

                int currentX = startX;
                int currentY = startY;
                int rowHeight = 0;

                foreach (var item in items)
                {
                    Size itemSize = TextRenderer.MeasureText(item, font);
                    int pillWidth = itemSize.Width + paddingX * 2;
                    int pillHeight = itemSize.Height + paddingY * 2;

                    if (currentX - pillWidth < e.CellBounds.Left + 8)
                    {
                        currentX = startX;
                        currentY += rowHeight + marginY;
                        rowHeight = 0;
                    }

                    if (currentY + pillHeight > e.CellBounds.Bottom - 6)
                    {
                        break;
                    }

                    rowHeight = Math.Max(rowHeight, pillHeight);

                    Rectangle rect = new Rectangle(currentX - pillWidth, currentY, pillWidth, pillHeight);

                    if (rect.Width > 0 && rect.Height > 0)
                    {
                        using (GraphicsPath path = CreateRoundedRectangle(rect, pillHeight / 2))
                        using (SolidBrush sb = new SolidBrush(backColor))
                            e.Graphics.FillPath(sb, path);
                    }

                    TextRenderer.DrawText(e.Graphics, item, font, rect, textColor,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis);

                    currentX -= (pillWidth + marginX);
                }
            }

            e.Handled = true;
        }

        public void RenderActionsCell(DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            if (actionImageList?.Images.Count < 2)
                return;

            int buttonSize = PurchaseGridStyles.ActionButtonSize;
            int iconSize = PurchaseGridStyles.ActionIconSize;
            int spacing = PurchaseGridStyles.ActionButtonSpacing;
            int cornerRadius = PurchaseGridStyles.ActionButtonRadius;

            int totalWidth = (buttonSize * 2) + spacing;
            int centerX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
            int centerY = e.CellBounds.Y + (e.CellBounds.Height - buttonSize) / 2;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw Edit (edit is blue/slate background)
            DrawActionButton(e.Graphics, centerX, centerY, buttonSize, iconSize, cornerRadius,
                            PurchaseGridStyles.EditButtonBack, "edit");

            // Draw Delete (delete is light red background)
            DrawActionButton(e.Graphics, centerX + buttonSize + spacing, centerY, buttonSize, iconSize,
                            cornerRadius, PurchaseGridStyles.DeleteButtonBack, "delete");

            e.Handled = true;
        }

        private void DrawActionButton(Graphics graphics, int x, int y, int buttonSize, int iconSize,
                                      int cornerRadius, Color backgroundColor, string iconKey)
        {
            var buttonRect = new Rectangle(x, y, buttonSize, buttonSize);

            using (var path = CreateRoundedRectangle(buttonRect, cornerRadius))
            using (var brush = new SolidBrush(backgroundColor))
                graphics.FillPath(brush, path);

            int iconOffsetX = (buttonSize - iconSize) / 2;
            int iconOffsetY = (buttonSize - iconSize) / 2;
            var iconRect = new Rectangle(x + iconOffsetX, y + iconOffsetY, iconSize, iconSize);
            graphics.DrawImage(actionImageList.Images[iconKey], iconRect);
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            if (d > rect.Width) d = rect.Width;
            if (d > rect.Height) d = rect.Height;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

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

        public (bool IsEdit, bool IsDelete) GetClickedButton(Rectangle cellRect, int relativeX)
        {
            int buttonSize = PurchaseGridStyles.ActionButtonSize;
            int spacing = PurchaseGridStyles.ActionButtonSpacing;
            int totalWidth = (buttonSize * 2) + spacing;
            int centerX = (cellRect.Width - totalWidth) / 2;

            bool isEdit = relativeX >= centerX && relativeX < centerX + buttonSize;
            bool isDelete = relativeX >= centerX + buttonSize + spacing && relativeX < centerX + totalWidth;

            return (isEdit, isDelete);
        }
    }
}
