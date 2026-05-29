using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;

namespace ActiveSpaceSystem.CustomItems
{
    public class GradientPanel : Panel
    {
        // الخصائص الأساسية
        private Color gradientColor1 = Color.FromArgb(29, 53, 87);
        private Color gradientColor2 = Color.FromArgb(26, 188, 156);
        private int borderRadius = 20;
        private int imageOpacity = 50;
        private string panelTitle = "Active Space";

        private PictureBox pbImage;
        private Image originalImage;

        // الخصائص التي تظهر في الـ Properties
        [Category("Abdul Style")]
        public string TitleText { get => panelTitle; set { panelTitle = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Color GradientColor1 { get => gradientColor1; set { gradientColor1 = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Color GradientColor2 { get => gradientColor2; set { gradientColor2 = value; Invalidate(); } }

        [Category("Abdul Style")]
        public int BorderRadius { get => borderRadius; set { borderRadius = value; Invalidate(); } }

        [Category("Abdul Style")]
        public int ImageOpacity
        {
            get => imageOpacity;
            set { imageOpacity = Math.Clamp(value, 0, 100); ApplyOpacity(); }
        }

        [Category("Abdul Style")]
        public Image PanelImage
        {
            get => originalImage;
            set { originalImage = value; ApplyOpacity(); }
        }

        [Category("Abdul Style")]
        public PictureBoxSizeMode ImageSizeMode { get => pbImage.SizeMode; set { pbImage.SizeMode = value; } }

        public GradientPanel()
        {
            this.DoubleBuffered = true; // لمنع الوميض (Flickering)

            pbImage = new PictureBox();
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImage.BackColor = Color.Transparent;
            pbImage.Dock = DockStyle.Fill;
            pbImage.Enabled = false; // مهم جداً للسماح برسم النص فوق الصورة

            this.Controls.Add(pbImage);
            this.Size = new Size(200, 400);
        }

        // دالة تطبيق الشفافية على الصورة
        private void ApplyOpacity()
        {
            if (originalImage == null) return;

            float opacity = imageOpacity / 100f;
            Bitmap bmp = new Bitmap(originalImage.Width, originalImage.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    g.DrawImage(originalImage, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                0, 0, originalImage.Width, originalImage.Height,
                                GraphicsUnit.Pixel, attributes);
                }
            }
            pbImage.Image = bmp;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();
            int d = borderRadius;

            // 1. رسم التدرج اللوني والحواف
            if (d > 1)
            {
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(this.Width - d, 0, d, d, 270, 90);
                path.AddArc(this.Width - d, this.Height - d, d, d, 0, 90);
                path.AddArc(0, this.Height - d, d, d, 90, 90);
                path.CloseFigure();

                using (LinearGradientBrush brush = new LinearGradientBrush(rect, gradientColor1, gradientColor2, 45F))
                {
                    g.FillPath(brush, path);
                }
                this.Region = new Region(path);
            }

            // 2. رسم النص في المنتصف تماماً (شفافية 100%)
            if (!string.IsNullOrEmpty(panelTitle))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // يمكنك تغيير الخط والحجم هنا
                using (Font font = new Font("Segoe UI", 22, FontStyle.Bold))
                {
                    using (SolidBrush textBrush = new SolidBrush(Color.White))
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;    // توسيط أفقي
                        sf.LineAlignment = StringAlignment.Center; // توسيط عمودي

                        g.DrawString(panelTitle, font, textBrush, rect, sf);
                    }
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}