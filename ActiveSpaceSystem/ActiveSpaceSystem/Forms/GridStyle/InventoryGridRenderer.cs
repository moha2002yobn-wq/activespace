using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.GridStyle
{
    public class InventoryGridRenderer
    {
        public void RenderCategoryCell(DataGridViewCellPaintingEventArgs e, string text)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            if (!string.IsNullOrEmpty(text))
            {
                RenderPillCell(e, text, InventoryGridStyles.CategoryDefaultBack, InventoryGridStyles.CategoryDefaultText);
            }
            e.Handled = true;
        }

        public void RenderCourtCell(DataGridViewCellPaintingEventArgs e, string text)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            if (!string.IsNullOrEmpty(text))
            {
                RenderPillCell(e, text, InventoryGridStyles.CourtBack, InventoryGridStyles.CourtText);
            }
            e.Handled = true;
        }

        public void RenderStatusCell(DataGridViewCellPaintingEventArgs e, string text)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            if (text == "متوفر")
            {
                RenderPillCell(e, text, InventoryGridStyles.StatusAvailableBack, InventoryGridStyles.StatusAvailableText);
            }
            else
            {
                RenderPillCell(e, text, InventoryGridStyles.StatusLowStockBack, InventoryGridStyles.StatusLowStockText);
            }
            e.Handled = true;
        }

        public void RenderMovementTypeCell(DataGridViewCellPaintingEventArgs e, string text, Color backColor, Color textColor)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Font font = e.CellStyle.Font;

            // Measure text
            Size textSize = TextRenderer.MeasureText(text, font);
            int paddingX = 12;
            int paddingY = 5;

            // Pill dimensions
            int pillWidth = textSize.Width + paddingX * 2;
            int pillHeight = textSize.Height + paddingY * 2;

            // Circle icon dimensions
            int circleSize = 16;
            int spacing = 8;

            // Total width of pill + spacing + circle
            int totalWidth = pillWidth + spacing + circleSize;

            // Centering layout
            int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
            int startY = e.CellBounds.Y + (e.CellBounds.Height - Math.Max(pillHeight, circleSize)) / 2;

            // Rectangles
            Rectangle pillRect = new Rectangle(startX, startY + (Math.Max(pillHeight, circleSize) - pillHeight) / 2, pillWidth, pillHeight);
            Rectangle circleRect = new Rectangle(startX + pillWidth + spacing, startY + (Math.Max(pillHeight, circleSize) - circleSize) / 2, circleSize, circleSize);

            // Draw Pill
            if (pillRect.Width > 0 && pillRect.Height > 0)
            {
                using (GraphicsPath path = CreateCapsulePath(pillRect))
                using (SolidBrush sb = new SolidBrush(backColor))
                {
                    e.Graphics.FillPath(sb, path);
                }
                TextRenderer.DrawText(e.Graphics, text, font, pillRect, textColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis);
            }

            // Draw Circle Icon
            using (var pen = new Pen(textColor, 1.8f))
            {
                e.Graphics.DrawEllipse(pen, circleRect);
            }

            // Draw Icon details inside the circle
            if (text == "إضافة")
            {
                // Up arrow inside circleRect
                float cx = circleRect.X + circleRect.Width / 2f;
                float cy = circleRect.Y + circleRect.Height / 2f;
                using (var pen = new Pen(textColor, 1.8f))
                {
                    e.Graphics.DrawLine(pen, cx, cy + 4, cx, cy - 4);
                    e.Graphics.DrawLine(pen, cx, cy - 4, cx - 3, cy - 1);
                    e.Graphics.DrawLine(pen, cx, cy - 4, cx + 3, cy - 1);
                }
            }
            else if (text == "خصم")
            {
                // Down arrow inside circleRect
                float cx = circleRect.X + circleRect.Width / 2f;
                float cy = circleRect.Y + circleRect.Height / 2f;
                using (var pen = new Pen(textColor, 1.8f))
                {
                    e.Graphics.DrawLine(pen, cx, cy - 4, cx, cy + 4);
                    e.Graphics.DrawLine(pen, cx, cy + 4, cx - 3, cy + 1);
                    e.Graphics.DrawLine(pen, cx, cy + 4, cx + 3, cy + 1);
                }
            }
            else if (text == "تالف")
            {
                // Exclamation mark (!) inside circleRect
                float cx = circleRect.X + circleRect.Width / 2f;
                float cy = circleRect.Y + circleRect.Height / 2f;
                using (var brush = new SolidBrush(textColor))
                using (var pen = new Pen(textColor, 1.8f))
                {
                    e.Graphics.DrawLine(pen, cx, cy - 4, cx, cy + 1);
                    e.Graphics.FillEllipse(brush, cx - 1f, cy + 2.5f, 2f, 2f);
                }
            }
            else // تعديل
            {
                // Refresh detail
                float cx = circleRect.X + circleRect.Width / 2f;
                float cy = circleRect.Y + circleRect.Height / 2f;
                using (var pen = new Pen(textColor, 1.5f))
                {
                    e.Graphics.DrawArc(pen, cx - 3, cy - 3, 6, 6, 45, 270);
                    e.Graphics.DrawLine(pen, cx + 2, cy - 1, cx + 4, cy - 3);
                    e.Graphics.DrawLine(pen, cx, cy - 3, cx + 4, cy - 3);
                }
            }
        }

        public void RenderActionsCell(DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            int buttonSize = 32;
            int spacing = 8;
            int totalWidth = (buttonSize * 3) + (spacing * 2);
            int centerX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
            int centerY = e.CellBounds.Y + (e.CellBounds.Height - buttonSize) / 2;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Button 1: Adjust (Green background, dark green icon)
            DrawActionButton(e.Graphics, centerX, centerY, buttonSize, 8, Color.FromArgb(209, 250, 229), Properties.Resources.icons8_shopping_cart_50, Color.FromArgb(4, 120, 87));

            // Button 2: Edit (Blue background, dark blue icon)
            DrawActionButton(e.Graphics, centerX + buttonSize + spacing, centerY, buttonSize, 8, Color.FromArgb(219, 234, 254), Properties.Resources.icons8_edit_48, Color.FromArgb(29, 78, 216));

            // Button 3: Delete (Red background, dark red icon)
            DrawActionButton(e.Graphics, centerX + (buttonSize * 2) + (spacing * 2), centerY, buttonSize, 8, Color.FromArgb(254, 226, 226), Properties.Resources.icons8_delete_48, Color.FromArgb(220, 38, 38));

            e.Handled = true;
        }

        private void DrawActionButton(Graphics graphics, int x, int y, int size, int radius, Color backColor, Image icon, Color iconColor)
        {
            var rect = new Rectangle(x, y, size, size);
            using (var path = CreateRoundedRectanglePath(rect, radius))
            using (var brush = new SolidBrush(backColor))
            {
                graphics.FillPath(brush, path);
            }

            if (icon != null)
            {
                int iconSize = 18;
                int offset = (size - iconSize) / 2;

                // Create a ColorMatrix to recolor the icon dynamically to the high-contrast target color
                float r = iconColor.R / 255f;
                float g = iconColor.G / 255f;
                float b = iconColor.B / 255f;

                float[][] colorMatrixElements = {
                   new float[] {0, 0, 0, 0, 0},        // Red multiplier
                   new float[] {0, 0, 0, 0, 0},        // Green multiplier
                   new float[] {0, 0, 0, 0, 0},        // Blue multiplier
                   new float[] {0, 0, 0, 1, 0},        // Keep alpha intact
                   new float[] {r, g, b, 0, 1}         // Inject target RGB color
                };

                var colorMatrix = new ColorMatrix(colorMatrixElements);
                using (var imageAttributes = new ImageAttributes())
                {
                    imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    graphics.DrawImage(icon,
                        new Rectangle(x + offset, y + offset, iconSize, iconSize),
                        0, 0, icon.Width, icon.Height,
                        GraphicsUnit.Pixel,
                        imageAttributes);
                }
            }
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
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

        private void RenderPillCell(DataGridViewCellPaintingEventArgs e, string text, Color backColor, Color textColor)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Font font = e.CellStyle.Font;

            var items = text.Split(new[] { '،', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .Where(x => !string.IsNullOrEmpty(x))
                            .ToList();

            if (items.Count <= 1)
            {
                Size textSize = TextRenderer.MeasureText(text, font);
                int paddingX = 14;
                int paddingY = 6;
                int pillWidth = Math.Min(textSize.Width + paddingX * 2, e.CellBounds.Width - 16);
                int pillHeight = Math.Min(textSize.Height + paddingY * 2, e.CellBounds.Height - 16);

                int pillX = e.CellBounds.X + (e.CellBounds.Width - pillWidth) / 2;
                int pillY = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;

                Rectangle rect = new Rectangle(pillX, pillY, pillWidth, pillHeight);

                if (rect.Width > 0 && rect.Height > 0)
                {
                    using (GraphicsPath path = CreateCapsulePath(rect))
                    using (SolidBrush sb = new SolidBrush(backColor))
                    {
                        e.Graphics.FillPath(sb, path);
                    }
                }

                TextRenderer.DrawText(e.Graphics, text, font, rect, textColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis);
            }
            else
            {
                // Draw wrapping pills in RTL order
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

                    // Wrap if exceeds left border
                    if (currentX - pillWidth < e.CellBounds.Left + 8)
                    {
                        currentX = startX;
                        currentY += rowHeight + marginY;
                        rowHeight = 0;
                    }

                    if (currentY + pillHeight > e.CellBounds.Bottom - 6)
                    {
                        break; // Out of vertical space
                    }

                    rowHeight = Math.Max(rowHeight, pillHeight);

                    Rectangle rect = new Rectangle(currentX - pillWidth, currentY, pillWidth, pillHeight);

                    if (rect.Width > 0 && rect.Height > 0)
                    {
                        using (GraphicsPath path = CreateCapsulePath(rect))
                        using (SolidBrush sb = new SolidBrush(backColor))
                        {
                            e.Graphics.FillPath(sb, path);
                        }
                    }

                    TextRenderer.DrawText(e.Graphics, item, font, rect, textColor,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis);

                    currentX -= (pillWidth + marginX);
                }
            }
        }

        private GraphicsPath CreateCapsulePath(Rectangle rect)
        {
            var path = new GraphicsPath();
            int d = rect.Height;
            if (d > rect.Width) d = rect.Width;
            if (d <= 0) d = 1;

            path.AddArc(rect.X, rect.Y, d, d, 90, 180);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 180);
            path.CloseFigure();
            return path;
        }

        public (bool IsAdjust, bool IsEdit, bool IsDelete) GetClickedButton(Rectangle cellRect, int relativeX)
        {
            int buttonSize = 32;
            int spacing = 8;
            int totalWidth = (buttonSize * 3) + (spacing * 2);
            int centerX = (cellRect.Width - totalWidth) / 2;

            bool isAdjust = relativeX >= centerX && relativeX < centerX + buttonSize;
            bool isEdit = relativeX >= centerX + buttonSize + spacing && relativeX < centerX + buttonSize * 2 + spacing;
            bool isDelete = relativeX >= centerX + buttonSize * 2 + spacing * 2 && relativeX < centerX + totalWidth;

            return (isAdjust, isEdit, isDelete);
        }
    }
}
