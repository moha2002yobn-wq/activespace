using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ActiveSpaceSystem.CustomItems
{
    [DefaultEvent("_TextChanged")] // لتسهيل الوصول لحدث تغيير النص الافتراضي
    public class AbdulTextBox : UserControl
    {
        // الخصائص الخاصة بالتنسيق
        private Color borderColor = Color.FromArgb(29, 53, 87);
        private int borderRadius = 15;
        private Image icon = null;
        private int iconSize = 20;
        private HorizontalAlignment iconLocation = HorizontalAlignment.Left;
        private string placeholderText = "أدخل النص هنا...";
        private bool isPlaceholder = true;

        private TextBox textBox1;

        // --- الأحداث الخارجية الممررة ---

        // حدث تغيير النص
        [Category("Abdul Events")]
        [Description("يحدث عند تغيير النص داخل مربع الإدخال")]
        public event EventHandler _TextChanged;

        // حدث ضغط المفاتيح الموجه (KeyPress) لتفعيل الاختصارات أو زر Enter في الفورم
        [Category("Abdul Events")]
        [Browsable(true)]
        [Description("يحدث عند الضغط على زر مستمر أثناء تركيز عنصر الإدخال")]
        public new event KeyPressEventHandler KeyPress;


        // الخصائص التي تظهر في نافذة Properties
        [Category("Abdul Style")]
        public int BorderRadius { get => borderRadius; set { borderRadius = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Color BorderColor { get => borderColor; set { borderColor = value; Invalidate(); } }

        [Category("Abdul Style")]
        public Image Icon { get => icon; set { icon = value; Invalidate(); } }

        [Category("Abdul Style")]
        public int IconSize { get => iconSize; set { iconSize = value; UpdateTextBoxPosition(); Invalidate(); } }

        [Category("Abdul Style")]
        public HorizontalAlignment IconLocation { get => iconLocation; set { iconLocation = value; UpdateTextBoxPosition(); Invalidate(); } }

        [Category("Abdul Style")]
        public string PlaceholderText { get => placeholderText; set { placeholderText = value; if (isPlaceholder) textBox1.Text = value; Invalidate(); } }

        [Category("Abdul Style")]
        public string passwordChar { get => textBox1.PasswordChar.ToString(); set { textBox1.PasswordChar = string.IsNullOrEmpty(value) ? '\0' : value[0]; } }

        // خاصية النص المعدلة لضمان الظهور في الـ Toolbox والـ Properties
        [Category("Abdul Style")]
        [Browsable(true)] // إجبار الخاصية على الظهور
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("النص الموجود داخل مربع الإدخال")]
        public string Texts
        {
            get => isPlaceholder ? "" : textBox1.Text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    isPlaceholder = true;
                    textBox1.Text = placeholderText;
                    textBox1.ForeColor = Color.Gray;
                }
                else
                {
                    isPlaceholder = false;
                    textBox1.Text = value;
                    textBox1.ForeColor = Color.Black;
                }
                Invalidate();
            }
        }

        public AbdulTextBox()
        {
            textBox1 = new TextBox();
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Tajawal", 11);
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = placeholderText;

            // الأحداث الخاصة بـ Placeholder
            textBox1.Enter += (s, e) => {
                if (isPlaceholder)
                {
                    isPlaceholder = false;
                    textBox1.Text = "";
                    textBox1.ForeColor = Color.Black;
                }
            };

            textBox1.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    isPlaceholder = true;
                    textBox1.Text = placeholderText;
                    textBox1.ForeColor = Color.Gray;
                }
            };

            // ربط وتوجيه حدث الـ KeyPress الخارجي من الـ TextBox الداخلي
            textBox1.KeyPress += (s, e) => {
                KeyPress?.Invoke(this, e);
            };

            // ربط حدث تغيير النص
            textBox1.TextChanged += (s, e) => _TextChanged?.Invoke(this, e);

            this.Controls.Add(textBox1);
            this.Size = new Size(250, 40);
            this.BackColor = Color.White;
            UpdateTextBoxPosition();
        }

        private void UpdateTextBoxPosition()
        {
            if (textBox1 == null) return;

            int txtHeight = textBox1.PreferredHeight;
            int margin = icon == null ? 15 : iconSize + 25;

            if (iconLocation == HorizontalAlignment.Left || icon == null)
            {
                textBox1.Location = new Point(margin, (this.Height - txtHeight) / 2);
            }
            else
            {
                textBox1.Location = new Point(15, (this.Height - txtHeight) / 2);
            }

            textBox1.Width = this.Width - margin - 15;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
                path.AddArc(rect.Right - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
                path.AddArc(rect.Right - borderRadius, rect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);

                using (Pen pen = new Pen(borderColor, 2))
                {
                    g.DrawPath(pen, path);
                }
            }

            if (icon != null)
            {
                int yPos = (this.Height - iconSize) / 2;
                int xPos = (iconLocation == HorizontalAlignment.Left) ? 12 : this.Width - iconSize - 12;
                g.DrawImage(icon, new Rectangle(xPos, yPos, iconSize, iconSize));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateTextBoxPosition();
        }
    }
}