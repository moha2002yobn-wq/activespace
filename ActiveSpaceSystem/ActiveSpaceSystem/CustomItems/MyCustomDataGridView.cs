using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ActiveSpaceSystem.CustomItems
{
    public class CustomDataGridView : DataGridView
    {
        // خصائص التحكم في الشكل
        private int borderRadius = 15;
        private Color headerBackColor = Color.FromArgb(248, 249, 250);
        private Color headerForeColor = Color.FromArgb(33, 37, 41);
        private int rowHeight = 50; // للمسافات الواسعة

        [Category("Abdul Style")]
        public int BorderRadius { get => borderRadius; set { borderRadius = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Color HeaderBackColor { get => headerBackColor; set { headerBackColor = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Color HeaderForeColor { get => headerForeColor; set { headerForeColor = value; Invalidate(); } }

        [Category("Abdul Style")]
        public int RowHeight { get => rowHeight; set { rowHeight = value; this.RowTemplate.Height = value; Invalidate(); } }

        public CustomDataGridView()
        {
            // إعدادات افتراضية للشكل المودرن
            this.BorderStyle = BorderStyle.None;
            this.BackgroundColor = Color.White;
            this.EnableHeadersVisualStyles = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MultiSelect = false;
            this.AllowUserToResizeRows = false;
            this.RowHeadersVisible = false; // إخفاء العمود الجانبي الصغير

            // إعدادات الخطوط والمسافات
            this.ColumnHeadersHeight = 50;
            this.RowTemplate.Height = 50;
            this.GridColor = Color.FromArgb(230, 230, 230); // لون الخط الفاصل

            // النمط الافتراضي للخلايا
            this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 245, 255);
            this.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // تطبيق خصائص الترويسة (Header)
            this.ColumnHeadersDefaultCellStyle.BackColor = headerBackColor;
            this.ColumnHeadersDefaultCellStyle.ForeColor = headerForeColor;

            // رسم الحدود الدائرية للمنطقة المحيطة بالجدول
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                int d = borderRadius * 2;
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(this.Width - d, 0, d, d, 270, 90);
                path.AddArc(this.Width - d, this.Height - d, d, d, 0, 90);
                path.AddArc(0, this.Height - d, d, d, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path); // قص الجدول ليأخذ شكل الزوايا الدائرية
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            // لضمان تطبيق ارتفاع الصفوف عند التشغيل
            this.RowTemplate.Height = rowHeight;
            
            // إلغاء الاختيار عند التشغيل لأول مرة
            if (this.IsHandleCreated)
            {
                BeginInvoke(new Action(() => this.ClearSelection()));
            }
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
            
            // إلغاء الاختيار تلقائياً بعد تحميل أو فلترة البيانات
            if (this.IsHandleCreated)
            {
                BeginInvoke(new Action(() => this.ClearSelection()));
            }
            else
            {
                this.ClearSelection();
            }
        }
    }
}