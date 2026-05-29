using ActiveSpace.Models;
using System.Drawing;

namespace ActiveSpaceSystem.Forms.GridStyle
{
    public static class CustomerGridStyles
    {
        // نصوص الموثوقية
        public const string TextSafe = "آمن";
        public const string TextRisky = "خطر";
        public const string TextBanned = "محظور";

        // ألوان حالة آمن
        public static readonly Color ColorSafeBack = Color.FromArgb(232, 245, 233);
        public static readonly Color ColorSafeText = Color.FromArgb(46, 125, 50);

        // ألوان حالة خطر
        public static readonly Color ColorRiskyBack = Color.FromArgb(255, 248, 225);
        public static readonly Color ColorRiskyText = Color.FromArgb(255, 143, 0);

        // ألوان حالة محظور
        public static readonly Color ColorBannedBack = Color.FromArgb(255, 235, 238);
        public static readonly Color ColorBannedText = Color.FromArgb(198, 40, 40);

        // أنماط الأيقونات (نفس اللي في Booking)
        public static readonly Color EditButtonBack = Color.FromArgb(200, 230, 255);
        public static readonly Color DeleteButtonBack = Color.FromArgb(255, 200, 200);

        public const int ActionButtonSize = 32;
        public const int ActionIconSize = 20;
        public const int ActionButtonSpacing = 15;
        public const int ActionButtonRadius = 8;

        public const int StatusPadding = 10;
        public const int StatusVerticalPadding = 15;
    }
}
