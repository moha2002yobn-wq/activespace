using System.Drawing;

namespace ActiveSpaceSystem.Forms.GridStyle
{
    /// <summary>
    /// يحتوي على كل أنماط التصميم والألوان للشبكة
    /// </summary>
    public static class BookingGridStyles
    {
        // نصوص الحالات
        public const string TextConfirmed = "مؤكد";
        public const string TextCompleted = "مكتمل الدفع";
        public const string TextCanceled = "ملغي";
        public const string TextPending = "قيد الانتظار";

        // ألوان حالة مؤكد
        public static readonly Color ColorConfirmedBack = Color.FromArgb(232, 244, 255);
        public static readonly Color ColorConfirmedText = Color.FromArgb(0, 120, 215);

        // ألوان حالة مكتمل
        public static readonly Color ColorCompletedBack = Color.FromArgb(232, 245, 233);
        public static readonly Color ColorCompletedText = Color.FromArgb(46, 125, 50);

        // ألوان حالة ملغي
        public static readonly Color ColorCanceledBack = Color.FromArgb(255, 235, 238);
        public static readonly Color ColorCanceledText = Color.FromArgb(198, 40, 40);

        // ألوان حالة قيد الانتظار
        public static readonly Color ColorPendingBack = Color.FromArgb(255, 248, 225);
        public static readonly Color ColorPendingText = Color.FromArgb(255, 143, 0);

        // ألوان الأيقونات
        public static readonly Color EditButtonBack = Color.FromArgb(200, 230, 255); // أزرق شفاف
        public static readonly Color DeleteButtonBack = Color.FromArgb(255, 200, 200); // أحمر شفاف
        public static readonly Color EditButtonColor = Color.FromArgb(13, 110, 253); // أزرق
        public static readonly Color DeleteButtonColor = Color.FromArgb(220, 53, 69); // أحمر

        // أحجام الأيقونات
        public const int ActionButtonSize = 32;
        public const int ActionIconSize = 20;
        public const int ActionButtonSpacing = 15;
        public const int ActionButtonRadius = 8;

        // أحجام الحالة
        public const int StatusPadding = 10;
        public const int StatusVerticalPadding = 15;
    }
}
