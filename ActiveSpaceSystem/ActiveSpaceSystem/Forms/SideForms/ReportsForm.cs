using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ActiveSpaceSystem.Forms.SideForms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // رسم مستطيل بحواف ناعمة
            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel1.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(panel1.Width - radius - 1, panel1.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, panel1.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel1.Region = new Region(path);
            g.DrawPath(lightPen, path);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // تنعيم الرسم
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // تحديد أبعاد المستطيل مع ترك مسافة بسيطة للإطار
            Rectangle rect = new Rectangle(0, 0, panel2.Width - 1, panel2.Height - 1);
            int radius = 15; // مقدار انحناء الحواف

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseAllFigures();

                // قص البانل ليأخذ شكل المسار الدائري
                panel2.Region = new Region(path);

                // رسم إطار رمادي خفيف لتعريف حدود التاريخ
                using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // 1. إعداد البيانات والأسماء (Labels)
            var series = chart1.Series[0];
            series.Points.Clear();

            // إضافة النقاط: (الاسم، القيمة)
            series.Points.AddXY("كرة القدم", 145000);
            series.Points.AddXY("التنس", 78000);
            series.Points.AddXY("البادل", 65000);
            series.Points.AddXY("السلة", 32000);

            // 2. تخصيص الألوان بناءً على هوية التصميم البصرية
            series.Points[0].Color = Color.FromArgb(30, 58, 138);  // كحلي داكن
            series.Points[1].Color = Color.FromArgb(16, 185, 129); // أخضر
            series.Points[2].Color = Color.FromArgb(59, 130, 246); // أزرق فاتح
            series.Points[3].Color = Color.FromArgb(20, 184, 166); // تركواز

            // 3. تنسيق ظهور النصوص والقيم (مثل: كرة القدم: 145k)
            // #VALY تعني القيمة، {N0} تعني تنسيق رقمي بفاصلة آلاف
            series.Label = "#AXISLABEL: #VALY{N0}";
            series.Font = new Font("Tajawal", 9, FontStyle.Bold);
            series.LabelForeColor = Color.DimGray;

            // 4. جعل النصوص تظهر خارج الدائرة مع خطوط إشارة
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Silver"; // لون خط الإشارة

            // 5. إضافة فاصل أبيض أنيق بين شرائح الدائرة
            series.BorderColor = Color.White;
            series.BorderWidth = 2;

            // 6. إعدادات عامة للمخطط
            chart1.BackColor = Color.Transparent; // ليتناسب مع خلفية البانل الأبيض
            chart1.Titles.Clear();

            // تفعيل تنعيم الحواف لرسم احترافي
            chart1.AntiAliasing = AntiAliasingStyles.All;

            // إخفاء الـ Legend الافتراضي إذا كنت ستصمم واحد مخصص بالأسفل
            chart1.Legends[0].Enabled = false;

            // تكبير قطر الدائرة بالنسبة للمساحة المتاحة (القيمة الافتراضية تكون صغيرة)
            chart1.Series[0]["PieStartAngle"] = "270"; // اختيار زاوية البداية
            chart1.Series[0]["MinimumRelativePieSize"] = "50"; // تكبير الحجم الأدنى للدائرة

            // جعل الدائرة تملأ كامل مساحة أداة الـ Chart
            chart1.ChartAreas[0].InnerPlotPosition.Auto = true;
            //###########################################################
            var series2 = chart2.Series[0];
            series2.Points.Clear();

            // 1. أهم سطرين لتوزيع الشهور أفقياً
            series2.IsXValueIndexed = true; // هذا السطر سيجعل كل شهر يأخذ مكانه الخاص بالترتيب
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

            // 2. إضافة الشهور والقيم
            series2.Points.AddXY("يناير", 195000);
            series2.Points.AddXY("فبراير", 210000);
            series2.Points.AddXY("مارس", 235000);
            series2.Points.AddXY("أبريل", 258000);
            series2.Points.AddXY("مايو", 280000);
            series2.Points.AddXY("يونيو", 310000);

            // 3. ضبط المحور لعرض جميع التسميات
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            //#############################################################
            //var series3 = chart3.Series[0];
            //series3.Points.Clear();

            //// إضافة البيانات (الساعة، عدد الحجوزات)
            //series3.Points.AddXY("4 PM", 12);
            //series3.Points.AddXY("5 PM", 18);
            //series3.Points.AddXY("6 PM", 25);
            //series3.Points.AddXY("7 PM", 40); // وقت الذروة
            //series3.Points.AddXY("8 PM", 38);
            //series3.Points.AddXY("9 PM", 30);
            //series3.Points.AddXY("10 PM", 22);
            //series3.Points.AddXY("11 PM", 15);

            //// تنسيق الأعمدة
            //series3.ChartType = SeriesChartType.Column;
            //series3.Color = Color.FromArgb(249, 115, 22); // لون برتقالي عصري
            //series3["PointWidth"] = "0.7"; // التحكم في عرض العمود (ليكون أنيقاً وليس ضخماً)

            //// جعل الزوايا العلوية للأعمدة دائرية (تحتاج إصدارات معينة أو رسم يدوي، 
            //// لكن يمكننا تحسين المظهر بتقليل الخطوط)

            //var area = chart3.ChartAreas[0];
            //area.AxisX.MajorGrid.Enabled = false; // إخفاء الخطوط الطولية
            //area.AxisY.MajorGrid.LineColor = Color.FromArgb(243, 244, 246); // خطوط عرضية باهتة جداً

            ////إخفاء الـ Legend لأنه لا داعي له هنا
            //chart3.Legends[0].Enabled = false;
            //#############################################################
            // 1. مسح أي بيانات قديمة (لضمان عدم التكرار عند فتح الشاشة)
            customDataGridView1.Rows.Clear();

            // 2. إضافة الصفوف (المرتبة، الاسم، عدد الحجوزات، المبلغ)
            // تأكد أن ترتيب البيانات يطابق ترتيب الأعمدة التي صممتها
            customDataGridView1.Rows.Add("1", "عبدالرحمن يوسف", "52", "15600 د.ل");
            customDataGridView1.Rows.Add("2", "أحمد محمد علي", "45", "13500 د.ل");
            customDataGridView1.Rows.Add("3", "خالد عبدالله", "32", "9600 د.ل");
            customDataGridView1.Rows.Add("4", "سعيد أحمد", "28", "8400 د.ل");
            customDataGridView1.Rows.Add("5", "محمد سالم", "15", "4500 د.ل");

            // 3. ضبط اتجاه الجدول للعربية
            customDataGridView1.RightToLeft = RightToLeft.Yes;
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // رسم مستطيل بحواف ناعمة
            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel2.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(panel2.Width - radius - 1, panel2.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, panel2.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel2.Region = new Region(path);
            g.DrawPath(lightPen, path);

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // رسم مستطيل بحواف ناعمة
            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel3.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(panel3.Width - radius - 1, panel3.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, panel3.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel3.Region = new Region(path);
            g.DrawPath(lightPen, path);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // رسم مستطيل بحواف ناعمة
            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel4.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(panel4.Width - radius - 1, panel4.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, panel4.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel4.Region = new Region(path);
            g.DrawPath(lightPen, path);

            using (Pen shadowPen = new Pen(Color.FromArgb(240, 240, 240), 2))
            {
                e.Graphics.DrawPath(shadowPen, path); // رسم مسار الظل خلف الكارت
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // رسم مستطيل بحواف ناعمة
            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel5.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(panel5.Width - radius - 1, panel5.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, panel5.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel5.Region = new Region(path);
            g.DrawPath(lightPen, path);

            using (Pen shadowPen = new Pen(Color.FromArgb(240, 240, 240), 2))
            {
                e.Graphics.DrawPath(shadowPen, path); // رسم مسار الظل خلف الكارت
            }

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // رسم مستطيل بحواف ناعمة
            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel6.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(panel6.Width - radius - 1, panel6.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, panel6.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel6.Region = new Region(path);
            g.DrawPath(lightPen, path);

            using (Pen shadowPen = new Pen(Color.FromArgb(240, 240, 240), 2))
            {
                e.Graphics.DrawPath(shadowPen, path); // رسم مسار الظل خلف الكارت
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // رسم مستطيل بحواف ناعمة
            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel7.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(panel7.Width - radius - 1, panel7.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, panel7.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel7.Region = new Region(path);
            g.DrawPath(lightPen, path);

            using (Pen shadowPen = new Pen(Color.FromArgb(240, 240, 240), 2))
            {
                e.Graphics.DrawPath(shadowPen, path); // رسم مسار الظل خلف الكارت
            }
        }



        private void panel8_Paint_1(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // رسم مستطيل بحواف ناعمة
            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel8.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(panel8.Width - radius - 1, panel8.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, panel8.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel8.Region = new Region(path);
            g.DrawPath(lightPen, path);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // رسم مستطيل بحواف ناعمة
            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel9.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(panel9.Width - radius - 1, panel9.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, panel9.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel9.Region = new Region(path);
            g.DrawPath(lightPen, path);

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // رسم مستطيل بحواف ناعمة
            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel10.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(panel10.Width - radius - 1, panel10.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, panel10.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel10.Region = new Region(path);
            g.DrawPath(lightPen, path);

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //// رسم مستطيل بحواف ناعمة
            //int radius = 20;
            //System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            //path.AddArc(0, 0, radius, radius, 180, 90);
            //path.AddArc(panel11.Width - radius - 1, 0, radius, radius, 270, 90);
            //path.AddArc(panel11.Width - radius - 1, panel11.Height - radius - 1, radius, radius, 0, 90);
            //path.AddArc(0, panel11.Height - radius - 1, radius, radius, 90, 90);
            //path.CloseAllFigures();

            //panel11.Region = new Region(path);
            //g.DrawPath(lightPen, path);
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            GraphicsPath path = new GraphicsPath();
            int radius = 10; // درجة الدوران

            // رسم مسار بحواف دائرية
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            pnl.Region = new Region(path);
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            GraphicsPath path = new GraphicsPath();
            int radius = 10; // درجة الدوران

            // رسم مسار بحواف دائرية
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            pnl.Region = new Region(path);

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            GraphicsPath path = new GraphicsPath();
            int radius = 10; // درجة الدوران

            // رسم مسار بحواف دائرية
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            pnl.Region = new Region(path);
        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            GraphicsPath path = new GraphicsPath();
            int radius = 10; // درجة الدوران

            // رسم مسار بحواف دائرية
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            pnl.Region = new Region(path);
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            GraphicsPath path = new GraphicsPath();
            int radius = 10; // درجة الدوران

            // رسم مسار بحواف دائرية
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            pnl.Region = new Region(path);
        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            GraphicsPath path = new GraphicsPath();
            int radius = 10; // درجة الدوران

            // رسم مسار بحواف دائرية
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            pnl.Region = new Region(path);
        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            GraphicsPath path = new GraphicsPath();
            int radius = 10; // درجة الدوران

            // رسم مسار بحواف دائرية
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            pnl.Region = new Region(path);
        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {
            // رسم إطار رمادي فاتح جداً حول الكرت
            Pen lightPen = new Pen(Color.FromArgb(226, 232, 240), 2);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // رسم مستطيل بحواف ناعمة
            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel21.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(panel21.Width - radius - 1, panel21.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, panel21.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel21.Region = new Region(path);
            g.DrawPath(lightPen, path);
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}


