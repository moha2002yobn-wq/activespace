namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class AddStadiumForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStadiumForm));
            label8 = new Label();
            label4 = new Label();
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            nametxt = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            label3 = new Label();
            roundedButton2 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            roundedButton1 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            customPanel1 = new ActiveSpaceSystem.CustomItems.CustomPanel();
            roundedButton3 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            cmbCourtType = new ComboBox();
            dtpOpenTime = new DateTimePicker();
            dtpCloseTime = new DateTimePicker();
            labelPrice = new Label();
            pricetxt = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            customPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(608, 180);
            label8.Name = "label8";
            label8.Size = new Size(99, 25);
            label8.TabIndex = 37;
            label8.Text = "وقت الفتح";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(263, 75);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 32;
            label4.Text = "نوع الملعب";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(589, 75);
            label2.Name = "label2";
            label2.Size = new Size(118, 25);
            label2.TabIndex = 28;
            label2.Text = "اسم الملعب";
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(28, 24);
            button1.Name = "button1";
            button1.Size = new Size(31, 29);
            button1.TabIndex = 27;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(277, 20);
            label1.Name = "label1";
            label1.Size = new Size(195, 33);
            label1.TabIndex = 24;
            label1.Text = "إضافة ملعب جديد";
            // 
            // nametxt
            // 
            nametxt.BackColor = Color.White;
            nametxt.BorderColor = Color.FromArgb(29, 53, 87);
            nametxt.BorderRadius = 15;
            nametxt.Icon = null;
            nametxt.IconLocation = HorizontalAlignment.Left;
            nametxt.IconSize = 20;
            nametxt.Location = new Point(377, 112);
            nametxt.Name = "nametxt";
            nametxt.passwordChar = "\0";
            nametxt.PlaceholderText = "مثال : ملعب كرة قدم 1";
            nametxt.RightToLeft = RightToLeft.Yes;
            nametxt.Size = new Size(330, 50);
            nametxt.TabIndex = 22;
            nametxt.Texts = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(260, 180);
            label3.Name = "label3";
            label3.Size = new Size(111, 25);
            label3.TabIndex = 45;
            label3.Text = "وقت الإغلاق";
            // 
            // roundedButton2
            // 
            roundedButton2.BackColor = Color.FromArgb(16, 185, 129);
            roundedButton2.BorderColor = Color.Transparent;
            roundedButton2.BorderRadius = 10;
            roundedButton2.BorderSize = 2;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = FlatStyle.Flat;
            roundedButton2.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedButton2.ForeColor = Color.White;
            roundedButton2.Location = new Point(377, 350);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Size = new Size(188, 43);
            roundedButton2.TabIndex = 47;
            roundedButton2.Text = "إضافة ملعب";
            roundedButton2.UseVisualStyleBackColor = false;
            roundedButton2.Click += roundedButton2_Click;
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.WhiteSmoke;
            roundedButton1.BorderColor = Color.Transparent;
            roundedButton1.BorderRadius = 10;
            roundedButton1.BorderSize = 2;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedButton1.ForeColor = Color.Gray;
            roundedButton1.Location = new Point(183, 350);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(188, 43);
            roundedButton1.TabIndex = 46;
            roundedButton1.Text = "إلغاء";
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderColor = Color.Black;
            customPanel1.BorderRadius = 10;
            customPanel1.BorderSize = 1F;
            customPanel1.Controls.Add(roundedButton3);
            customPanel1.Controls.Add(cmbCourtType);
            customPanel1.Location = new Point(41, 112);
            customPanel1.Name = "customPanel1";
            customPanel1.ShowShadow = false;
            customPanel1.Size = new Size(330, 55);
            customPanel1.TabIndex = 48;
            // 
            // roundedButton3
            // 
            roundedButton3.BackColor = Color.WhiteSmoke;
            roundedButton3.BorderColor = Color.Transparent;
            roundedButton3.BorderRadius = 10;
            roundedButton3.BorderSize = 2;
            roundedButton3.FlatAppearance.BorderSize = 0;
            roundedButton3.FlatStyle = FlatStyle.Flat;
            roundedButton3.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedButton3.ForeColor = Color.Gray;
            roundedButton3.Location = new Point(18, 11);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Size = new Size(38, 31);
            roundedButton3.TabIndex = 49;
            roundedButton3.Text = "+";
            roundedButton3.UseVisualStyleBackColor = false;
            roundedButton3.Click += roundedButton3_Click;
            // 
            // cmbCourtType
            // 
            cmbCourtType.FlatStyle = FlatStyle.Flat;
            cmbCourtType.FormattingEnabled = true;
            cmbCourtType.Location = new Point(62, 13);
            cmbCourtType.Name = "cmbCourtType";
            cmbCourtType.RightToLeft = RightToLeft.Yes;
            cmbCourtType.Size = new Size(251, 28);
            cmbCourtType.TabIndex = 6;
            // 
            // dtpOpenTime
            // 
            dtpOpenTime.CalendarFont = new Font("Tajawal", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpOpenTime.CustomFormat = "HH:mm";
            dtpOpenTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpOpenTime.Format = DateTimePickerFormat.Custom;
            dtpOpenTime.Location = new Point(377, 211);
            dtpOpenTime.Name = "dtpOpenTime";
            dtpOpenTime.RightToLeft = RightToLeft.Yes;
            dtpOpenTime.RightToLeftLayout = true;
            dtpOpenTime.ShowUpDown = true;
            dtpOpenTime.Size = new Size(330, 34);
            dtpOpenTime.TabIndex = 51;
            // 
            // dtpCloseTime
            // 
            dtpCloseTime.CalendarFont = new Font("Tajawal", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpCloseTime.CustomFormat = "HH:mm";
            dtpCloseTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpCloseTime.Format = DateTimePickerFormat.Custom;
            dtpCloseTime.Location = new Point(41, 211);
            dtpCloseTime.Name = "dtpCloseTime";
            dtpCloseTime.RightToLeft = RightToLeft.Yes;
            dtpCloseTime.RightToLeftLayout = true;
            dtpCloseTime.ShowUpDown = true;
            dtpCloseTime.Size = new Size(330, 34);
            dtpCloseTime.TabIndex = 52;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrice.Location = new Point(570, 255);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(137, 25);
            labelPrice.TabIndex = 53;
            labelPrice.Text = "سعر الساعة (د.ل)";
            // 
            // pricetxt
            // 
            pricetxt.BackColor = Color.White;
            pricetxt.BorderColor = Color.FromArgb(29, 53, 87);
            pricetxt.BorderRadius = 15;
            pricetxt.Icon = null;
            pricetxt.IconLocation = HorizontalAlignment.Left;
            pricetxt.IconSize = 20;
            pricetxt.Location = new Point(377, 285);
            pricetxt.Name = "pricetxt";
            pricetxt.passwordChar = "\0";
            pricetxt.PlaceholderText = "مثال : 50.0";
            pricetxt.RightToLeft = RightToLeft.Yes;
            pricetxt.Size = new Size(330, 50);
            pricetxt.TabIndex = 54;
            pricetxt.Texts = "50.0";
            // 
            // AddStadiumForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 420);
            Controls.Add(labelPrice);
            Controls.Add(pricetxt);
            Controls.Add(dtpCloseTime);
            Controls.Add(dtpOpenTime);
            Controls.Add(customPanel1);
            Controls.Add(roundedButton2);
            Controls.Add(roundedButton1);
            Controls.Add(label3);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(nametxt);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddStadiumForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddStadiumForm";
            Load += AddStadiumForm_Load;
            customPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label8;
        private Label label4;
        private Label label2;
        private Button button1;
        private Label label1;
        private CustomItems.AbdulTextBox nametxt;
        private Label label3;
        private CustomItems.RoundedButton roundedButton2;
        private CustomItems.RoundedButton roundedButton1;
        private CustomItems.CustomPanel customPanel1;
        private ComboBox cmbCourtType;
        private CustomItems.RoundedButton roundedButton3;
        public DateTimePicker dtpOpenTime;
        public DateTimePicker dtpCloseTime;
        private Label labelPrice;
        private CustomItems.AbdulTextBox pricetxt;
    }
}