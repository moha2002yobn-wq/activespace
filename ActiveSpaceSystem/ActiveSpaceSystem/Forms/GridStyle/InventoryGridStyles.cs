using System.Drawing;

namespace ActiveSpaceSystem.Forms.GridStyle
{
    public static class InventoryGridStyles
    {
        // Category styling (الفئة)
        public static readonly Color CategoryDefaultBack = Color.FromArgb(224, 231, 255);
        public static readonly Color CategoryDefaultText = Color.FromArgb(49, 46, 129);

        // Associated court styling (الملعب المرتبط)
        public static readonly Color CourtBack = Color.FromArgb(236, 253, 245);
        public static readonly Color CourtText = Color.FromArgb(4, 120, 87);

        // Status styling (الحالة)
        public static readonly Color StatusAvailableBack = Color.FromArgb(209, 250, 229);
        public static readonly Color StatusAvailableText = Color.FromArgb(5, 150, 105);

        public static readonly Color StatusLowStockBack = Color.FromArgb(254, 243, 199);
        public static readonly Color StatusLowStockText = Color.FromArgb(217, 119, 6);

        // Action Buttons styling
        public static readonly Color EditButtonBack = Color.FromArgb(200, 230, 255);
        public static readonly Color DeleteButtonBack = Color.FromArgb(255, 200, 200);

        public const int ActionButtonSize = 32;
        public const int ActionIconSize = 20;
        public const int ActionButtonSpacing = 15;
        public const int ActionButtonRadius = 8;
    }
}
