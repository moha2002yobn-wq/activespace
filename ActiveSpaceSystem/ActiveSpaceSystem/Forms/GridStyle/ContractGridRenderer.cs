using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.Forms.GridStyle
{
    public class ContractGridRenderer
    {
        private ImageList _actionImages;

        public ContractGridRenderer(ImageList actionImages)
        {
            _actionImages = actionImages;
        }

        public void RenderActionsCell(DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            int buttonSize = 25; // حجم الأزرار
            int spacing = 15; // المسافة بين الزرين
            int totalWidth = (buttonSize * 2) + spacing;
            int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;
            int startY = e.CellBounds.Y + (e.CellBounds.Height - buttonSize) / 2;

            Rectangle editRect = new Rectangle(startX, startY, buttonSize, buttonSize);
            Rectangle deleteRect = new Rectangle(startX + buttonSize + spacing, startY, buttonSize, buttonSize);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (_actionImages.Images.ContainsKey("edit"))
                e.Graphics.DrawImage(_actionImages.Images["edit"], editRect);

            if (_actionImages.Images.ContainsKey("delete"))
                e.Graphics.DrawImage(_actionImages.Images["delete"], deleteRect);

            e.Handled = true;
        }

        public (bool isEdit, bool isDelete) GetClickedButton(Rectangle cellRect, int relativeX)
        {
            int buttonSize = 25;
            int spacing = 15;
            int totalWidth = (buttonSize * 2) + spacing;
            int startXRelative = (cellRect.Width - totalWidth) / 2;

            bool isEdit = relativeX >= startXRelative && relativeX <= startXRelative + buttonSize;
            bool isDelete = relativeX >= startXRelative + buttonSize + spacing && relativeX <= startXRelative + totalWidth;

            return (isEdit, isDelete);
        }
    }
}