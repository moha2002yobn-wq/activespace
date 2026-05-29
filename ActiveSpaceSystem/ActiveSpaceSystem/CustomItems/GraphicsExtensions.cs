using System.Drawing.Drawing2D;

namespace ActiveSpaceSystem.CustomItems
{
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle rect, int radius)
        {
            if (rect.Width <= 0 || rect.Height <= 0) return;

            // نصيحة: نقص 1 من العرض والطول باش تهرب من حدود الخلية السوداء
            Rectangle safeRect = new Rectangle(rect.X, rect.Y, rect.Width - 1, rect.Height - 1);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(safeRect.X, safeRect.Y, radius, radius, 180, 90);
                path.AddArc(safeRect.Right - radius, safeRect.Y, radius, radius, 270, 90);
                path.AddArc(safeRect.Right - radius, safeRect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(safeRect.X, safeRect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                g.FillPath(brush, path);
            }
        }
    }

}
