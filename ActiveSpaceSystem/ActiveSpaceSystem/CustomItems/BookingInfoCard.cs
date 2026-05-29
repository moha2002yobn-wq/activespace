using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    [DefaultProperty("BookingNumberValue")]
    public class BookingInfoCard : Panel
    {
        // حقول النصوص الخاصة بالمكون
        private string _bookingNumberValue = "B-2026-001";
        private string _remainingAmountValue = "200 د.ل";

        // حقول الألوان
        private Color _remainingAmountColor = Color.FromArgb(239, 68, 68); // اللون الأحمر الافتراضي للنظام (#EF4444)
        private Color _labelTextColor = Color.FromArgb(100, 116, 139);      // لون رمادي خفيف للنصوص الثابتة (#64748B)
        private Color _valueTextColor = Color.FromArgb(30, 41, 59);        // لون داكن لقيمة رقم الحجز (#1E293B)

        // حقل نصف قطر الحواف الدائرية
        private int _borderRadius = 15;

        // حقول مخصصة للتحكم في نوع وحجم الخطوط من الـ Designer
        private string _labelsFontFamily = "Tajawal";
        private string _valuesFontFamily = "Tajawal";
        private float _labelsFontSize = 9.5F;
        private float _valuesFontSize = 11.5F;

        public BookingInfoCard()
        {
            // تفعيل الرسم المزدوج لتقليل الاهتزاز والوميض أثناء إعادة الرسم
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.DoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint, true);

            // تهيئة الخلفية باللون الرمادي الفاتح الافتراضي للتصميم
            this.BackColor = Color.FromArgb(241, 245, 249); // (#F1F5F9)
            this.Size = new Size(350, 85); // الحجم الافتراضي للبطاقة
        }

        #region الخصائص المخصصة للتصميم (Designer Properties)

        [Category("ActiveSpace Properties")]
        [Description("نصف قطر انحناء الحواف الدائرية للبطاقة")]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = Math.Max(0, value); // منع القيم السالبة
                this.Invalidate(); // إعادة رسم البطاقة فور تغيير القيمة
            }
        }

        [Category("ActiveSpace Properties")]
        [Description("رقم الحجز الفعلي المراد عرضه")]
        public string BookingNumberValue
        {
            get => _bookingNumberValue;
            set
            {
                _bookingNumberValue = value;
                this.Invalidate();
            }
        }

        [Category("ActiveSpace Properties")]
        [Description("قيمة المبلغ المتبقي (مثال: 200 د.ل)")]
        public string RemainingAmountValue
        {
            get => _remainingAmountValue;
            set
            {
                _remainingAmountValue = value;
                this.Invalidate();
            }
        }

        [Category("ActiveSpace Properties")]
        [Description("لون نص المبلغ المتبقي")]
        public Color RemainingAmountColor
        {
            get => _remainingAmountColor;
            set
            {
                _remainingAmountColor = value;
                this.Invalidate();
            }
        }

        [Category("ActiveSpace Properties")]
        [Description("لون نصوص العناوين الثابتة (رقم الحجز / المبلغ المتبقي)")]
        public Color LabelTextColor
        {
            get => _labelTextColor;
            set
            {
                _labelTextColor = value;
                this.Invalidate();
            }
        }

        [Category("ActiveSpace Properties")]
        [Description("لون قيمة رقم الحجز")]
        public Color ValueTextColor
        {
            get => _valueTextColor;
            set
            {
                _valueTextColor = value;
                this.Invalidate();
            }
        }

        // --- الخصائص الجديدة للتحكم في الخطوط وحجمها ---

        [Category("ActiveSpace Fonts")]
        [Description("اسم عائلة الخط لعناوين البطاقة (رقم الحجز / المبلغ المتبقي)")]
        public string LabelsFontFamily
        {
            get => _labelsFontFamily;
            set
            {
                _labelsFontFamily = string.IsNullOrWhiteSpace(value) ? "Tajawal" : value;
                this.Invalidate();
            }
        }

        [Category("ActiveSpace Fonts")]
        [Description("اسم عائلة الخط للقيم (مثل قيمة الكود والمبلغ المالي)")]
        public string ValuesFontFamily
        {
            get => _valuesFontFamily;
            set
            {
                _valuesFontFamily = string.IsNullOrWhiteSpace(value) ? "Tajawal" : value;
                this.Invalidate();
            }
        }

        [Category("ActiveSpace Fonts")]
        [Description("حجم خط عناوين البطاقة")]
        public float LabelsFontSize
        {
            get => _labelsFontSize;
            set
            {
                _labelsFontSize = Math.Max(1F, value); // منع الأحجام الصفرية أو السالبة
                this.Invalidate();
            }
        }

        [Category("ActiveSpace Fonts")]
        [Description("حجم خط القيم المعروضة داخل البطاقة")]
        public float ValuesFontSize
        {
            get => _valuesFontSize;
            set
            {
                _valuesFontSize = Math.Max(1F, value);
                this.Invalidate();
            }
        }

        #endregion

        #region عملية الرسم الفنية (Custom Drawing)

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // 1. رسم وتشكيل خلفية البانل بالحواف الدائرية المطلوبة
            Rectangle rectPath = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            using (GraphicsPath path = GetRoundRectPath(rectPath, _borderRadius))
            {
                // تعيين المنطقة الدائرية للبانل حتى لا يخرج أي رسم أو عناصر عن حدود الحواف
                this.Region = new Region(path);

                // ملء خلفية البانل بلون الخلفية المحدد
                using (SolidBrush bgBrush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(bgBrush, path);
                }
            }

            // التحقق من الخطوط المحددة؛ إذا لم تكن مثبتة ننتقل للخط الاحتياطي "Segoe UI"
            string labelFontName = IsFontInstalled(_labelsFontFamily) ? _labelsFontFamily : "Segoe UI";
            string valueFontName = IsFontInstalled(_valuesFontFamily) ? _valuesFontFamily : "Segoe UI";

            // 2. إعدادات النصوص والخطوط بناءً على الخصائص المحددة من المصمم
            using (Font labelFont = new Font(labelFontName, _labelsFontSize, FontStyle.Regular))
            using (Font valueFont = new Font(valueFontName, _valuesFontSize, FontStyle.Bold))
            using (SolidBrush labelBrush = new SolidBrush(_labelTextColor))
            using (SolidBrush valueBrush = new SolidBrush(_valueTextColor))
            using (SolidBrush priceBrush = new SolidBrush(_remainingAmountColor))
            {
                // إعدادات محاذاة النص لليمين واليسار لتتوافق مع الواجهة العربية
                StringFormat rightAlign = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
                StringFormat leftAlign = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };

                // تحديد الهوامش الداخلية للرسم من اليمين واليسار (Padding)
                int paddingX = 18;

                // حساب المسافة الرأسية لكل سطر
                int rowHeight = this.Height / 2;

                // --- السطر الأول (رقم الحجز وعنوانه) ---
                Rectangle rectRow1_Right = new Rectangle(paddingX, 2, this.Width - (paddingX * 2), rowHeight);
                Rectangle rectRow1_Left = new Rectangle(paddingX, 2, this.Width - (paddingX * 2), rowHeight);

                g.DrawString("رقم الحجز", labelFont, labelBrush, rectRow1_Right, rightAlign);
                g.DrawString(_bookingNumberValue, valueFont, valueBrush, rectRow1_Left, leftAlign);

                // --- السطر الثاني (المبلغ المتبقي وقيمته المالية) ---
                Rectangle rectRow2_Right = new Rectangle(paddingX, rowHeight - 2, this.Width - (paddingX * 2), rowHeight);
                Rectangle rectRow2_Left = new Rectangle(paddingX, rowHeight - 2, this.Width - (paddingX * 2), rowHeight);

                g.DrawString("المبلغ المتبقي", labelFont, labelBrush, rectRow2_Right, rightAlign);
                g.DrawString(_remainingAmountValue, valueFont, priceBrush, rectRow2_Left, leftAlign);
            }
        }

        // دالة مساعدة للتأكد من تثبيت الخط على الجهاز المستضيف
        private bool IsFontInstalled(string fontName)
        {
            using (Font testFont = new Font(fontName, 8))
            {
                return string.Equals(fontName, testFont.Name, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        // دالة مساعدة لإنشاء مسار هندسي ذو حواف دائرية احترافية خالية من التشوهات
        private GraphicsPath GetRoundRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float size = radius * 2F;

            // إذا كان التدوير صفراً، ارسم مستطيل عادي حاد الزوايا
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            path.StartFigure();
            // أعلى اليسار
            path.AddArc(rect.X, rect.Y, size, size, 180, 90);
            // أعلى اليمين
            path.AddArc(rect.Right - size, rect.Y, size, size, 270, 90);
            // أسفل اليمين
            path.AddArc(rect.Right - size, rect.Bottom - size, size, size, 0, 90);
            // أسفل اليسار
            path.AddArc(rect.X, rect.Bottom - size, size, size, 90, 90);
            path.CloseFigure();

            return path;
        }

        #endregion
    }
}