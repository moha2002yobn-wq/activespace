using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class BookingDetailsCard : Panel
    {
        // الحقول الخاصة (Backing Fields)
        private bool isItemSelected = false;
        private string bookingID = "B-2026-001";
        private string customerName = "أحمد محمد علي";
        private string phoneNumber = "0501234567";
        private string totalAmount = "300 د.ل";
        private string depositAmount = "100 د.ل";
        private string paidAmount = "100 د.ل";
        private string remainingAmount = "200 د.ل";

        private Color remainingColor = Color.Red;
        private Color primaryColor = Color.FromArgb(46, 204, 113);
        private int borderRadius = 20;
        private int buttonRadius = 12;
        private Font labelsFont = new Font("Tajawal", 10F);
        private Font dataFont = new Font("Tajawal", 12F, FontStyle.Bold);

        public Button BtnPayment;

        #region Properties (الخصائص كاملة بدون أي نقص)

        [Category("Abdul Style - State")]
        public bool IsItemSelected
        {
            get => isItemSelected;
            set { isItemSelected = value; if (BtnPayment != null) BtnPayment.Visible = value; Invalidate(); }
        }

        [Category("Abdul Style - Data")]
        public string BookingID { get => bookingID; set { bookingID = value; Invalidate(); } }

        [Category("Abdul Style - Data")]
        public string CustomerName { get => customerName; set { customerName = value; Invalidate(); } }

        [Category("Abdul Style - Data")]
        public string PhoneNumber { get => phoneNumber; set { phoneNumber = value; Invalidate(); } }

        [Category("Abdul Style - Data")]
        public string TotalAmount { get => totalAmount; set { totalAmount = value; Invalidate(); } }

        [Category("Abdul Style - Data")]
        public string DepositAmount { get => depositAmount; set { depositAmount = value; Invalidate(); } }

        [Category("Abdul Style - Data")]
        public string PaidAmount { get => paidAmount; set { paidAmount = value; Invalidate(); } }

        [Category("Abdul Style - Data")]
        public string RemainingAmount { get => remainingAmount; set { remainingAmount = value; Invalidate(); } }

        [Category("Abdul Style - Appearance")]
        public Color RemainingColor { get => remainingColor; set { remainingColor = value; Invalidate(); } }

        [Category("Abdul Style - Appearance")]
        public Color PrimaryColor
        {
            get => primaryColor;
            set { primaryColor = value; if (BtnPayment != null) BtnPayment.BackColor = value; Invalidate(); }
        }

        [Category("Abdul Style - Appearance")]
        public int CardBorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; UpdateLayout(); Invalidate(); }
        }

        [Category("Abdul Style - Appearance")]
        public int ButtonBorderRadius
        {
            get => buttonRadius;
            set { buttonRadius = value; UpdateLayout(); Invalidate(); }
        }

        [Category("Abdul Style - Fonts")]
        public Font LabelsFont { get => labelsFont; set { labelsFont = value; Invalidate(); } }

        [Category("Abdul Style - Fonts")]
        public Font DataFont
        {
            get => dataFont;
            set { dataFont = value; if (BtnPayment != null) BtnPayment.Font = value; Invalidate(); }
        }

        #endregion

        public BookingDetailsCard()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(350, 480);
            this.BackColor = Color.White;

            BtnPayment = new Button();
            BtnPayment.Text = "تسجيل دفعة";
            BtnPayment.FlatStyle = FlatStyle.Flat;
            BtnPayment.FlatAppearance.BorderSize = 0;
            BtnPayment.BackColor = primaryColor;
            BtnPayment.ForeColor = Color.White;
            BtnPayment.Font = dataFont;
            BtnPayment.Cursor = Cursors.Hand;
            BtnPayment.Visible = false;

            this.Controls.Add(BtnPayment);
            this.SizeChanged += (s, e) => UpdateLayout();

            // استدعاء أولي لضبط المنطقة المقصوصة والزر
            UpdateLayout();
        }

        private void UpdateLayout()
        {
            // 1. قص حواف الكارد نفسه لإزالة البياض المزعج خلف الزوايا
            if (this.Width > 0 && this.Height > 0)
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                this.Region = new Region(GetRoundedRectPath(rect, borderRadius));
            }

            // 2. تحديث حجم وموقع الزر وتطبيق البوردر راديوس الخاص به
            if (BtnPayment != null)
            {
                BtnPayment.Size = new Size(this.Width - 40, 50);
                BtnPayment.Location = new Point(20, this.Height - 75);

                if (BtnPayment.Width > 0 && BtnPayment.Height > 0)
                {
                    Rectangle r = new Rectangle(0, 0, BtnPayment.Width, BtnPayment.Height);
                    BtnPayment.Region = new Region(GetRoundedRectPath(r, buttonRadius));
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // رسم خلفية بيضاء داخلية مع حدود خفيفة جداً
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            using (GraphicsPath path = GetRoundedRectPath(rect, borderRadius))
            {
                g.FillPath(Brushes.White, path);
                using (Pen borderPen = new Pen(Color.FromArgb(235, 235, 235), 1))
                    g.DrawPath(borderPen, path);
            }

            if (!isItemSelected)
            {
                DrawEmptyState(g);
            }
            else
            {
                DrawFullState(g);
            }
        }

        private void DrawEmptyState(Graphics g)
        {
            Font iconFont = new Font("Segoe UI", 55);
            g.DrawString("$", iconFont, new SolidBrush(Color.FromArgb(220, 225, 230)),
                (this.Width - 55) / 2, (this.Height / 2) - 80);

            string hint = "اختر حجزاً لعرض التفاصيل";
            SizeF hintSize = g.MeasureString(hint, labelsFont);
            g.DrawString(hint, labelsFont, Brushes.Gray, (this.Width - hintSize.Width) / 2, (this.Height / 2) + 20);
        }

        private void DrawFullState(Graphics g)
        {
            StringFormat sfRight = new StringFormat { Alignment = StringAlignment.Far };
            StringFormat sfLeft = new StringFormat { Alignment = StringAlignment.Near };
            int startY = 25;

            // العنوان (تم تحسين المساحة لمنع التداخل)
            g.DrawString("تفاصيل الحجز", new Font(dataFont.FontFamily, 13, FontStyle.Bold), Brushes.Black,
                new Rectangle(20, startY, this.Width - 40, 35), sfRight);

            startY += 60;

            // بيانات العميل (تم ضبط المسافات لضمان عدم تداخل النصوص)
            DrawRow(g, "رقم الحجز", bookingID, ref startY, labelsFont, dataFont, Brushes.Black);
            DrawRow(g, "اسم العميل", customerName, ref startY, labelsFont, dataFont, Brushes.Black);
            DrawRow(g, "رقم الهاتف", phoneNumber, ref startY, labelsFont, dataFont, Brushes.Black);

            // خط فاصل
            g.DrawLine(new Pen(Color.FromArgb(245, 245, 245), 1), 25, startY, this.Width - 25, startY);
            startY += 20;

            // المبالغ المالية
            DrawAmountRow(g, "المبلغ الكلي", totalAmount, ref startY, labelsFont, dataFont, Brushes.Black);
            DrawAmountRow(g, "العربون", depositAmount, ref startY, labelsFont, dataFont, Brushes.Black);
            DrawAmountRow(g, "المدفوع", paidAmount, ref startY, labelsFont, dataFont, new SolidBrush(primaryColor));

            startY += 10;
            g.DrawLine(new Pen(Color.FromArgb(245, 245, 245), 1), 25, startY, this.Width - 25, startY);
            startY += 15;

            // المتبقي (رسم مباشر لضمان المساحة ومنع نزول النص لسطر جديد)
            Rectangle remRect = new Rectangle(20, startY, this.Width - 40, 40);
            g.DrawString("المتبقي", dataFont, Brushes.Gray, remRect, sfRight);
            g.DrawString(remainingAmount, new Font(dataFont.FontFamily, 14, FontStyle.Bold), new SolidBrush(remainingColor), remRect, sfLeft);
        }

        private void DrawRow(Graphics g, string label, string value, ref int y, Font lFont, Font vFont, Brush vBrush)
        {
            StringFormat sfRight = new StringFormat { Alignment = StringAlignment.Far };
            g.DrawString(label, lFont, Brushes.DarkGray, new Rectangle(20, y, this.Width - 40, 20), sfRight);
            g.DrawString(value, vFont, vBrush, new Rectangle(20, y + 25, this.Width - 40, 30), sfRight);
            y += 68; // مسافة كافية لمنع التداخل
        }

        private void DrawAmountRow(Graphics g, string label, string value, ref int y, Font lFont, Font vFont, Brush vBrush)
        {
            StringFormat sfRight = new StringFormat { Alignment = StringAlignment.Far };
            StringFormat sfLeft = new StringFormat { Alignment = StringAlignment.Near };
            g.DrawString(label, lFont, Brushes.DarkGray, new Rectangle(20, y, this.Width - 40, 30), sfRight);
            g.DrawString(value, vFont, vBrush, new Rectangle(20, y, this.Width - 40, 30), sfLeft);
            y += 42;
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = Math.Max(1, radius * 2);
            if (rect.Width <= d) d = rect.Width;
            if (rect.Height <= d) d = rect.Height;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}