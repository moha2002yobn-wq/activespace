using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.GridStyle
{
    public class EmployeeGridRenderer
    {
        private readonly ImageList actionImageList;

        public EmployeeGridRenderer(ImageList actionImageList)
        {
            this.actionImageList = actionImageList ?? throw new ArgumentNullException(nameof(actionImageList));
        }

        public void RenderStatusCell(DataGridViewCellPaintingEventArgs e, string status)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            
            Color backColor = Color.FromArgb(254, 243, 199); // yellow (معلق)
            Color textColor = Color.FromArgb(217, 119, 6);

            if (status == "مدفوع")
            {
                backColor = Color.FromArgb(209, 250, 229); // green (مدفوع)
                textColor = Color.FromArgb(16, 185, 129);
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Font font = e.CellStyle.Font;

            Size textSize = TextRenderer.MeasureText(status, font);
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

            TextRenderer.DrawText(e.Graphics, status, font, rect, textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis);

            e.Handled = true;
        }

        public void RenderIncentiveCell(DataGridViewCellPaintingEventArgs e, double val)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            
            string text = val > 0 ? $"+{val:N0} د.ل" : "0 د.ل";
            Color textColor = val > 0 ? Color.FromArgb(16, 185, 129) : Color.FromArgb(71, 85, 105);
            Font font = new Font(e.CellStyle.Font, val > 0 ? FontStyle.Bold : FontStyle.Regular);

            TextRenderer.DrawText(e.Graphics, text, font, e.CellBounds, textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis);

            e.Handled = true;
        }

        public void RenderDeductionCell(DataGridViewCellPaintingEventArgs e, double val)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            
            string text = val > 0 ? $"-{val:N0} د.ل" : "0 د.ل";
            Color textColor = val > 0 ? Color.FromArgb(220, 38, 38) : Color.FromArgb(71, 85, 105);
            Font font = new Font(e.CellStyle.Font, val > 0 ? FontStyle.Bold : FontStyle.Regular);

            TextRenderer.DrawText(e.Graphics, text, font, e.CellBounds, textColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis);

            e.Handled = true;
        }

        public void RenderActionsCell(DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            if (actionImageList?.Images.Count < 2) return;

            int buttonSize = 32;
            int spacing = 12;
            int totalWidth = (buttonSize * 2) + spacing;
            int centerX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
            int centerY = e.CellBounds.Y + (e.CellBounds.Height - buttonSize) / 2;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw Edit (edit is blue/slate background) on the left
            DrawActionButton(e.Graphics, centerX, centerY, buttonSize, 8, Color.FromArgb(219, 234, 254),
                             actionImageList.Images["edit"], Color.FromArgb(29, 78, 216));

            // Draw Delete (delete is light red background) on the right
            DrawActionButton(e.Graphics, centerX + buttonSize + spacing, centerY, buttonSize, 8, Color.FromArgb(254, 226, 226),
                             actionImageList.Images["delete"], Color.FromArgb(220, 38, 38));

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

                float r = iconColor.R / 255f;
                float g = iconColor.G / 255f;
                float b = iconColor.B / 255f;

                float[][] colorMatrixElements = {
                   new float[] {0, 0, 0, 0, 0},        // Red
                   new float[] {0, 0, 0, 0, 0},        // Green
                   new float[] {0, 0, 0, 0, 0},        // Blue
                   new float[] {0, 0, 0, 1, 0},        // Keep alpha
                   new float[] {r, g, b, 0, 1}         // Inject target
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

        public (bool IsEdit, bool IsDelete) GetClickedButton(Rectangle cellRect, int relativeX)
        {
            int buttonSize = 32;
            int spacing = 12;
            int totalWidth = (buttonSize * 2) + spacing;
            int centerX = (cellRect.Width - totalWidth) / 2;

            bool isEdit = relativeX >= centerX && relativeX < centerX + buttonSize;
            bool isDelete = relativeX >= centerX + buttonSize + spacing && relativeX < centerX + totalWidth;

            return (isEdit, isDelete);
        }
    }
}
