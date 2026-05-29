using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            // تفعيل الشفافية الحقيقية
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // إخبار الأداة بأن ترسم النص فقط وتتجاهل الخلفية
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            base.OnPaint(e);
        }

        // كود إضافي لضمان الشفافية فوق الأدوات المخصصة
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                return cp;
            }
        }
    }
}