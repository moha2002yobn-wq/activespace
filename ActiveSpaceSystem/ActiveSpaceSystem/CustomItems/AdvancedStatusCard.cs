using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class AdvancedStatusCard : Panel
    {
        // --- الحقول الخاصة ---
        private string titleText = "إجمالي الإيرادات اليوم";
        private string valueText = "12,450 د.ل";
        private string subValueText = "";

        private Color titleColor = Color.Gray;
        private Color valueColor = Color.FromArgb(46, 204, 113);
        private Color subValueColor = Color.FromArgb(46, 204, 113);
        private Color iconBackColor = Color.FromArgb(46, 204, 113);

        private Font titleFont = new Font("Tajawal", 10F);
        private Font valueFont = new Font("Tajawal", 16F, FontStyle.Bold);
        private Font subValueFont = new Font("Tajawal", 9F);

        private int borderRadius = 20;
        private int shadowSize = 6;
        private int shadowOpacity = 40;
        private Image cardIcon;
        private int iconSize = 36; // الحقل الخاص بحجم الأيقونة

        // --- الخصائص (Properties) لظهورها في الـ Designer ---

        [Category("Abdul Style - Content")]
        private bool _isUpdating = false; private bool _needsInvalidate = false;
        public string TitleText { get => titleText; set { titleText = value; if (!_isUpdating) Invalidate(); else _needsInvalidate = true; } }
        [Category("Abdul Style - Content")]
        public string ValueText { get => valueText; set { valueText = value; if (!_isUpdating) Invalidate(); else _needsInvalidate = true; } }
        [Category("Abdul Style - Content")]
        public string SubValueText { get => subValueText; set { subValueText = value; if (!_isUpdating) Invalidate(); else _needsInvalidate = true; } }

        [Category("Abdul Style - Colors")]
        public Color TitleColor { get => titleColor; set { titleColor = value; Invalidate(); } }
        [Category("Abdul Style - Colors")]
        public Color ValueColor { get => valueColor; set { valueColor = value; Invalidate(); } }
        [Category("Abdul Style - Colors")]
        public Color SubValueColor { get => subValueColor; set { subValueColor = value; Invalidate(); } }
        [Category("Abdul Style - Colors")]
        public Color IconBackColor { get => iconBackColor; set { iconBackColor = value; Invalidate(); } }

        [Category("Abdul Style - Fonts")]
        public Font TitleFont { get => titleFont; set { titleFont = value; Invalidate(); } }
        [Category("Abdul Style - Fonts")]
        public Font ValueFont { get => valueFont; set { valueFont = value; Invalidate(); } }
        [Category("Abdul Style - Fonts")]
        public Font SubValueFont { get => subValueFont; set { subValueFont = value; if (!_isUpdating) Invalidate(); else _needsInvalidate = true; } }

        [Category("Abdul Style - Appearance")]
        public int BorderRadius { get => borderRadius; set { borderRadius = value; Invalidate(); } }
        [Category("Abdul Style - Appearance")]
        public int ShadowSize { get => shadowSize; set { shadowSize = value; Invalidate(); } }
        [Category("Abdul Style - Appearance")]
        public Image CardIcon { get => cardIcon; set { cardIcon = value; Invalidate(); } }

        // الخاصية الجديدة للتحكم في حجم الأيقونة
        [Category("Abdul Style - Appearance")]
        public int IconSize { get => iconSize; set { iconSize = value; Invalidate(); } }

        public AdvancedStatusCard()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(300, 120);
            this.BackColor = Color.Transparent; // لضمان عدم وجود خلفية رمادية خلف الظل
        }

        // BeginUpdate/EndUpdate pattern to batch property changes
        public void BeginUpdate()
        {
            _isUpdating = true;
            _needsInvalidate = false;
        }

        public void EndUpdate()
        {
            _isUpdating = false;
            if (_needsInvalidate)
            {
                _needsInvalidate = false;
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // حل مشكلة الزوايا: رسم لون خلفية الـ Parent في مكان القص
            if (this.Parent != null)
            {
                using (SolidBrush parentBrush = new SolidBrush(this.Parent.BackColor))
                {
                    g.FillRectangle(parentBrush, this.ClientRectangle);
                }
            }

            // حساب مساحة الكارد مع ترك مساحة للظل
            Rectangle cardRect = new Rectangle(shadowSize, shadowSize, this.Width - (shadowSize * 2) - 1, this.Height - (shadowSize * 2) - 1);

            // 1. رسم الظل الناعم
            for (int i = 1; i <= shadowSize; i++)
            {
                using (GraphicsPath shadowPath = GetRoundedRectPath(new Rectangle(cardRect.X - i, cardRect.Y - i, cardRect.Width + (i * 2), cardRect.Height + (i * 2)), borderRadius + i))
                {
                    int alpha = shadowOpacity / shadowSize;
                    using (Pen shadowPen = new Pen(Color.FromArgb(alpha, Color.Black), i))
                    {
                        g.DrawPath(shadowPen, shadowPath);
                    }
                }
            }

            // 2. رسم جسم الكارد الأبيض
            using (GraphicsPath path = GetRoundedRectPath(cardRect, borderRadius))
            {
                g.FillPath(Brushes.White, path);
                using (Pen borderPen = new Pen(Color.FromArgb(240, 240, 240), 1))
                    g.DrawPath(borderPen, path);
            }

            // 3. رسم مربع الأيقونة
            int iconBoxSize = 55;
            Rectangle iconRect = new Rectangle(cardRect.X + 15, cardRect.Y + (cardRect.Height - iconBoxSize) / 2, iconBoxSize, iconBoxSize);
            using (GraphicsPath iconPath = GetRoundedRectPath(iconRect, 15))
            {
                using (SolidBrush iconBrush = new SolidBrush(iconBackColor))
                    g.FillPath(iconBrush, iconPath);

                if (cardIcon != null)
                {
                    // تم استخدام الخاصية iconSize هنا بدلاً من الرقم الثابت
                    g.DrawImage(cardIcon, iconRect.X + (iconBoxSize - iconSize) / 2, iconRect.Y + (iconBoxSize - iconSize) / 2, iconSize, iconSize);
                }
            }

            // 4. رسم النصوص الثلاثة باستخدام الخصائص
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Far };

            // Title
            g.DrawString(titleText, titleFont, new SolidBrush(titleColor),
                new Rectangle(cardRect.X + iconBoxSize + 20, cardRect.Y + 20, cardRect.Width - iconBoxSize - 40, 25), sf);

            // Value
            g.DrawString(valueText, valueFont, new SolidBrush(valueColor),
                new Rectangle(cardRect.X + iconBoxSize + 20, cardRect.Y + 45, cardRect.Width - iconBoxSize - 40, 35), sf);

            // SubValue
            g.DrawString(subValueText, subValueFont, new SolidBrush(subValueColor),
                new Rectangle(cardRect.X + iconBoxSize + 20, cardRect.Y + 80, cardRect.Width - iconBoxSize - 40, 20), sf);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = Math.Max(1, radius * 2);
            if (d > rect.Width) d = rect.Width;
            if (d > rect.Height) d = rect.Height;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}