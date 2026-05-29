using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class UserListItem : Panel
    {
        // --- الخصائص العامة ---
        [Category("User Data")]
        public string UserName { get; set; } = "اسم المستخدم";
        [Category("User Data")]
        public string UserEmail { get; set; } = "user@example.com";
        [Category("User Data")]
        public string RoleText { get; set; } = "مدير النظام";
        [Category("User Data")]
        public Color RoleColor { get; set; } = Color.FromArgb(46, 204, 113);

        // خاصية لإضافة صورة القلم من الخارج
        [Category("User Appearance")]
        public Image EditIcon { get; set; }

        // حدث الضغط على زر التعديل
        public event EventHandler EditClicked;

        // متغير لحفظ مساحة الزر للكشف عن التصادم
        private Rectangle editIconRect;

        public UserListItem()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(800, 75);
            this.BackColor = Color.White;
            this.Padding = new Padding(10);
            // جعل المؤشر عادياً بشكل افتراضي وتغييره عند الحركة
            this.Cursor = Cursors.Default;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // 1. رسم خلفية السطر وحوافه المنحنية
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            using (GraphicsPath path = GetRoundedPath(rect, 15))
            {
                using (Pen pen = new Pen(Color.FromArgb(240, 240, 240), 1))
                {
                    g.DrawPath(pen, path);
                }
            }

            int margin = 20;

            // 2. رسم النصوص (الاسم والإيميل)
            Rectangle textRect = new Rectangle(margin + 150, 0, this.Width - margin - 40 - 150, this.Height);
            StringFormat rf = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };

            using (Font nameFont = new Font("Tajawal", 11, FontStyle.Bold))
            {
                g.DrawString(UserName, nameFont, new SolidBrush(Color.FromArgb(44, 62, 80)),
                    new Rectangle(textRect.X, textRect.Y + 20, textRect.Width, 25), rf);
            }
            using (Font emailFont = new Font("Tajawal", 9))
            {
                g.DrawString(UserEmail, emailFont, Brushes.Gray,
                    new Rectangle(textRect.X, textRect.Y + 43, textRect.Width, 20), rf);
            }

            // 3. رسم "تاج" الحالة (Badge)
            int badgeWidth = 80;
            int badgeHeight = 26;
            Rectangle badgeRect = new Rectangle(margin + 60, (this.Height - badgeHeight) / 2, badgeWidth, badgeHeight);

            using (GraphicsPath badgePath = GetRoundedPath(badgeRect, 8))
            {
                g.FillPath(new SolidBrush(Color.FromArgb(40, RoleColor)), badgePath);
                using (Font badgeFont = new Font("Tajawal", 8, FontStyle.Bold))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(RoleText, badgeFont, new SolidBrush(RoleColor), badgeRect, sf);
                }
            }

            // 4. رسم أيقونة التعديل (أقصى اليسار)
            int iconSize = 22;
            editIconRect = new Rectangle(margin, (this.Height - iconSize) / 2, iconSize, iconSize);

            if (EditIcon != null)
            {
                g.DrawImage(EditIcon, editIconRect);
            }
            else
            {
                // رسم شكل قلم تجريبي في حال عدم وجود صورة
                using (Pen p = new Pen(Color.FromArgb(180, 180, 180), 2))
                {
                    g.DrawRectangle(p, editIconRect.X + 4, editIconRect.Y + 4, 12, 12);
                    g.DrawLine(p, editIconRect.X + 12, editIconRect.Y + 4, editIconRect.X + 16, editIconRect.Y);
                }
            }
        }

        // كشف الضغط على أيقونة التعديل فقط
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (editIconRect.Contains(e.Location))
            {
                EditClicked?.Invoke(this, EventArgs.Empty);
            }
        }

        // تغيير شكل الماوس عند الوقوف فوق الأيقونة
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (editIconRect.Contains(e.Location))
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

       
    }
}