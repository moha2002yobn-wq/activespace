using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.GridStyle
{
    public class ExpenseGridRenderer
    {
        private readonly ImageList actionImageList;

        public ExpenseGridRenderer(ImageList actionImageList)
        {
            this.actionImageList = actionImageList ?? throw new ArgumentNullException(nameof(actionImageList));
        }

        public void RenderActionsCell(DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            if (actionImageList?.Images.Count < 2) return;

            int buttonSize = ExpenseGridStyles.ActionButtonSize;
            int iconSize = ExpenseGridStyles.ActionIconSize;
            int spacing = ExpenseGridStyles.ActionButtonSpacing;
            int cornerRadius = ExpenseGridStyles.ActionButtonRadius;

            int totalWidth = (buttonSize * 2) + spacing;
            int centerX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
            int centerY = e.CellBounds.Y + (e.CellBounds.Height - buttonSize) / 2;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw Edit (edit is blue/slate background) on the left
            DrawActionButton(e.Graphics, centerX, centerY, buttonSize, iconSize, cornerRadius,
                            ExpenseGridStyles.EditButtonBack, "edit");

            // Draw Delete (delete is light red background) on the right
            DrawActionButton(e.Graphics, centerX + buttonSize + spacing, centerY, buttonSize, iconSize,
                            cornerRadius, ExpenseGridStyles.DeleteButtonBack, "delete");

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

        public (bool IsEdit, bool IsDelete) GetClickedButton(Rectangle cellRect, int relativeX)
        {
            int buttonSize = ExpenseGridStyles.ActionButtonSize;
            int spacing = ExpenseGridStyles.ActionButtonSpacing;
            int totalWidth = (buttonSize * 2) + spacing;
            int centerX = (cellRect.Width - totalWidth) / 2;

            bool isEdit = relativeX >= centerX && relativeX < centerX + buttonSize;
            bool isDelete = relativeX >= centerX + buttonSize + spacing && relativeX < centerX + totalWidth;

            return (isEdit, isDelete);
        }
    }
}