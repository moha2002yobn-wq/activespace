namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class AddContract
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
            label9 = new Label();
            txtPricePerHour = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label1 = new Label();
            label11 = new Label();
            label10 = new Label();
            btSave = new ActiveSpaceSystem.CustomItems.RoundedButton();
            customPanel3 = new ActiveSpaceSystem.CustomItems.CustomPanel();
            cmbDays = new ComboBox();
            labelHours = new Label();
            customPanel2 = new ActiveSpaceSystem.CustomItems.CustomPanel();
            cmbCourt = new ComboBox();
            customPanel1 = new ActiveSpaceSystem.CustomItems.CustomPanel();
            cmbCourtType = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtName = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            label2 = new Label();
            txtPhone = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            dtpStartTime = new DateTimePicker();
            dtpEndTime = new DateTimePicker();
            dtpBookingDate = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            btnCancel = new ActiveSpaceSystem.CustomItems.RoundedButton();
            label12 = new Label();
            deposittxt = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            panelProperties = new ActiveSpaceSystem.CustomItems.CustomPanel();
            lblPropertiesTitle = new Label();
            btnAddProperty = new ActiveSpaceSystem.CustomItems.RoundedButton();
            flowProperties = new FlowLayoutPanel();
            lblNoProperties = new Label();
            panelAlert = new Panel();
            lblAlertText = new Label();
            btnExit = new Button();
            customPanel3.SuspendLayout();
            customPanel2.SuspendLayout();
            customPanel1.SuspendLayout();
            panelProperties.SuspendLayout();
            panelAlert.SuspendLayout();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(212, 361);
            label9.Name = "label9";
            label9.Size = new Size(152, 25);
            label9.TabIndex = 39;
            label9.Text = "تاريخ بداية العقد";
            // 
            // txtPricePerHour
            // 
            txtPricePerHour.BackColor = Color.White;
            txtPricePerHour.BorderColor = Color.FromArgb(29, 53, 87);
            txtPricePerHour.BorderRadius = 15;
            txtPricePerHour.Icon = null;
            txtPricePerHour.IconLocation = HorizontalAlignment.Left;
            txtPricePerHour.IconSize = 20;
            txtPricePerHour.Location = new Point(436, 580);
            txtPricePerHour.Name = "txtPricePerHour";
            txtPricePerHour.passwordChar = "\0";
            txtPricePerHour.PlaceholderText = "أدخل النص هنا...";
            txtPricePerHour.RightToLeft = RightToLeft.Yes;
            txtPricePerHour.Size = new Size(330, 50);
            txtPricePerHour.TabIndex = 38;
            txtPricePerHour.Texts = "";
            txtPricePerHour.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(646, 361);
            label8.Name = "label8";
            label8.Size = new Size(111, 25);
            label8.TabIndex = 37;
            label8.Text = "وقت النهاية";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(257, 269);
            label7.Name = "label7";
            label7.Size = new Size(107, 25);
            label7.TabIndex = 36;
            label7.Text = "وقت البداية";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(630, 263);
            label6.Name = "label6";
            label6.Size = new Size(136, 25);
            label6.TabIndex = 35;
            label6.Text = "اليوم الاسبوعي";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(300, 9);
            label1.Name = "label1";
            label1.Size = new Size(245, 33);
            label1.TabIndex = 24;
            label1.Text = "إضافة عقد شهري جديد";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(613, 447);
            label11.Name = "label11";
            label11.Size = new Size(156, 25);
            label11.TabIndex = 47;
            label11.Text = "تاريخ نهاية العقد";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(613, 540);
            label10.Name = "label10";
            label10.Size = new Size(152, 25);
            label10.TabIndex = 49;
            label10.Text = "المبلغ لكل ساعة";
            label10.Visible = false;
            // 
            // btSave
            // 
            btSave.BackColor = Color.FromArgb(16, 185, 129);
            btSave.BorderColor = Color.FromArgb(16, 185, 129);
            btSave.BorderRadius = 10;
            btSave.BorderSize = 2;
            btSave.FlatAppearance.BorderSize = 0;
            btSave.FlatStyle = FlatStyle.Flat;
            btSave.Font = new Font("Tajawal", 16.1999989F, FontStyle.Bold);
            btSave.ForeColor = Color.White;
            btSave.Location = new Point(412, 925);
            btSave.Margin = new Padding(2);
            btSave.Name = "btSave";
            btSave.Size = new Size(348, 60);
            btSave.TabIndex = 50;
            btSave.Text = "حفظ العقد";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // customPanel3
            // 
            customPanel3.BackColor = Color.White;
            customPanel3.BorderColor = Color.Black;
            customPanel3.BorderRadius = 10;
            customPanel3.BorderSize = 1F;
            customPanel3.Controls.Add(cmbDays);
            customPanel3.Location = new Point(436, 298);
            customPanel3.Name = "customPanel3";
            customPanel3.RightToLeft = RightToLeft.Yes;
            customPanel3.ShowShadow = false;
            customPanel3.Size = new Size(330, 55);
            customPanel3.TabIndex = 50;
            // 
            // cmbDays
            // 
            cmbDays.DisplayMember = "CourtName";
            cmbDays.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDays.FlatStyle = FlatStyle.Flat;
            cmbDays.FormattingEnabled = true;
            cmbDays.Items.AddRange(new object[] { "السبت", "الاحد", "الاتنين", "التلاتاء", "الاربعاء", "الخميس", "الجمعة" });
            cmbDays.Location = new Point(18, 13);
            cmbDays.Name = "cmbDays";
            cmbDays.RightToLeft = RightToLeft.Yes;
            cmbDays.Size = new Size(295, 28);
            cmbDays.TabIndex = 6;
            cmbDays.SelectedIndexChanged += cmbDays_SelectedIndexChanged;
            // 
            // labelHours
            // 
            labelHours.Font = new Font("Tajawal Medium", 11F, FontStyle.Bold);
            labelHours.Location = new Point(32, 590);
            labelHours.Margin = new Padding(2, 0, 2, 0);
            labelHours.Name = "labelHours";
            labelHours.Size = new Size(330, 30);
            labelHours.TabIndex = 55;
            labelHours.RightToLeft = RightToLeft.Yes;
            // 
            // customPanel2
            // 
            customPanel2.BackColor = Color.White;
            customPanel2.BorderColor = Color.Black;
            customPanel2.BorderRadius = 10;
            customPanel2.BorderSize = 1F;
            customPanel2.Controls.Add(cmbCourt);
            customPanel2.Location = new Point(32, 198);
            customPanel2.Name = "customPanel2";
            customPanel2.ShowShadow = false;
            customPanel2.Size = new Size(330, 55);
            customPanel2.TabIndex = 63;
            // 
            // cmbCourt
            // 
            cmbCourt.FlatStyle = FlatStyle.Flat;
            cmbCourt.FormattingEnabled = true;
            cmbCourt.Location = new Point(18, 13);
            cmbCourt.Name = "cmbCourt";
            cmbCourt.RightToLeft = RightToLeft.Yes;
            cmbCourt.Size = new Size(295, 28);
            cmbCourt.TabIndex = 6;
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderColor = Color.Black;
            customPanel1.BorderRadius = 10;
            customPanel1.BorderSize = 1F;
            customPanel1.Controls.Add(cmbCourtType);
            customPanel1.Location = new Point(436, 198);
            customPanel1.Name = "customPanel1";
            customPanel1.ShowShadow = false;
            customPanel1.Size = new Size(330, 55);
            customPanel1.TabIndex = 62;
            // 
            // cmbCourtType
            // 
            cmbCourtType.DisplayMember = "CourtName";
            cmbCourtType.FlatStyle = FlatStyle.Flat;
            cmbCourtType.FormattingEnabled = true;
            cmbCourtType.Location = new Point(18, 13);
            cmbCourtType.Name = "cmbCourtType";
            cmbCourtType.RightToLeft = RightToLeft.Yes;
            cmbCourtType.Size = new Size(295, 28);
            cmbCourtType.TabIndex = 6;
            cmbCourtType.SelectedIndexChanged += cmbCourtType_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(289, 161);
            label5.Name = "label5";
            label5.Size = new Size(75, 25);
            label5.TabIndex = 61;
            label5.Text = "الملعب";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(658, 161);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 60;
            label4.Text = "نوع الملعب";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(661, 56);
            label3.Name = "label3";
            label3.Size = new Size(105, 25);
            label3.TabIndex = 59;
            label3.Text = "رقم الهاتف";
            // 
            // txtName
            // 
            txtName.BackColor = Color.White;
            txtName.BorderColor = Color.FromArgb(29, 53, 87);
            txtName.BorderRadius = 15;
            txtName.Font = new Font("Tajawal", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Icon = null;
            txtName.IconLocation = HorizontalAlignment.Left;
            txtName.IconSize = 20;
            txtName.Location = new Point(32, 96);
            txtName.Name = "txtName";
            txtName.passwordChar = "\0";
            txtName.PlaceholderText = "أدخل النص هنا...";
            txtName.RightToLeft = RightToLeft.Yes;
            txtName.Size = new Size(330, 50);
            txtName.TabIndex = 58;
            txtName.Texts = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(247, 56);
            label2.Name = "label2";
            label2.Size = new Size(115, 25);
            label2.TabIndex = 57;
            label2.Text = "اسم العميل";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.White;
            txtPhone.BorderColor = Color.FromArgb(29, 53, 87);
            txtPhone.BorderRadius = 15;
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Icon = null;
            txtPhone.IconLocation = HorizontalAlignment.Left;
            txtPhone.IconSize = 20;
            txtPhone.Location = new Point(436, 96);
            txtPhone.Name = "txtPhone";
            txtPhone.passwordChar = "\0";
            txtPhone.PlaceholderText = "أدخل النص هنا...";
            txtPhone.RightToLeft = RightToLeft.Yes;
            txtPhone.Size = new Size(330, 50);
            txtPhone.TabIndex = 56;
            txtPhone.Texts = "";
            txtPhone.Leave += txtPhone_Leave;
            // 
            // dtpStartTime
            // 
            dtpStartTime.CalendarFont = new Font("Tajawal", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpStartTime.CustomFormat = "HH:mm";
            dtpStartTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(32, 305);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.RightToLeft = RightToLeft.Yes;
            dtpStartTime.RightToLeftLayout = true;
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(330, 34);
            dtpStartTime.TabIndex = 65;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CalendarFont = new Font("Tajawal", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpEndTime.CustomFormat = "HH:mm";
            dtpEndTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(436, 396);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.RightToLeft = RightToLeft.Yes;
            dtpEndTime.RightToLeftLayout = true;
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(330, 34);
            dtpEndTime.TabIndex = 64;
            // 
            // dtpBookingDate
            // 
            dtpBookingDate.CalendarFont = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpBookingDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpBookingDate.Format = DateTimePickerFormat.Short;
            dtpBookingDate.Location = new Point(32, 396);
            dtpBookingDate.Name = "dtpBookingDate";
            dtpBookingDate.RightToLeft = RightToLeft.Yes;
            dtpBookingDate.RightToLeftLayout = true;
            dtpBookingDate.Size = new Size(330, 34);
            dtpBookingDate.TabIndex = 66;
            dtpBookingDate.ValueChanged += dtpBookingDate_ValueChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(436, 489);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.RightToLeft = RightToLeft.Yes;
            dateTimePicker1.RightToLeftLayout = true;
            dateTimePicker1.Size = new Size(330, 34);
            dateTimePicker1.TabIndex = 67;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.BorderColor = Color.PaleVioletRed;
            btnCancel.BorderRadius = 10;
            btnCancel.BorderSize = 0;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tajawal", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.GrayText;
            btnCancel.Location = new Point(30, 925);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(348, 60);
            btnCancel.TabIndex = 68;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(247, 447);
            label12.Name = "label12";
            label12.Size = new Size(135, 25);
            label12.TabIndex = 70;
            label12.Text = "الدفعة الأولية :";
            // 
            // deposittxt
            // 
            deposittxt.BackColor = Color.White;
            deposittxt.BorderColor = Color.FromArgb(29, 53, 87);
            deposittxt.BorderRadius = 15;
            deposittxt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deposittxt.Icon = null;
            deposittxt.IconLocation = HorizontalAlignment.Left;
            deposittxt.IconSize = 20;
            deposittxt.Location = new Point(32, 489);
            deposittxt.Name = "deposittxt";
            deposittxt.passwordChar = "\0";
            deposittxt.PlaceholderText = "أدخل قيمة العربون هنا...";
            deposittxt.RightToLeft = RightToLeft.Yes;
            deposittxt.Size = new Size(330, 50);
            deposittxt.TabIndex = 69;
            deposittxt.Texts = "";
            // 
            // panelProperties
            // 
            panelProperties.BackColor = Color.FromArgb(248, 250, 252);
            panelProperties.BorderColor = Color.FromArgb(226, 232, 240);
            panelProperties.BorderRadius = 15;
            panelProperties.BorderSize = 1F;
            panelProperties.Controls.Add(lblPropertiesTitle);
            panelProperties.Controls.Add(btnAddProperty);
            panelProperties.Controls.Add(flowProperties);
            panelProperties.Location = new Point(30, 650);
            panelProperties.Name = "panelProperties";
            panelProperties.ShowShadow = false;
            panelProperties.Size = new Size(736, 200);
            panelProperties.TabIndex = 71;
            // 
            // lblPropertiesTitle
            // 
            lblPropertiesTitle.AutoSize = true;
            lblPropertiesTitle.Font = new Font("Tajawal Medium", 11.5F, FontStyle.Bold);
            lblPropertiesTitle.ForeColor = Color.FromArgb(29, 53, 87);
            lblPropertiesTitle.Location = new Point(460, 12);
            lblPropertiesTitle.Name = "lblPropertiesTitle";
            lblPropertiesTitle.Size = new Size(215, 27);
            lblPropertiesTitle.TabIndex = 0;
            lblPropertiesTitle.Text = "خصائص من المخزون (اختياري)";
            // 
            // btnAddProperty
            // 
            btnAddProperty.BackColor = Color.FromArgb(29, 53, 87);
            btnAddProperty.BorderColor = Color.FromArgb(29, 53, 87);
            btnAddProperty.BorderRadius = 8;
            btnAddProperty.BorderSize = 0;
            btnAddProperty.FlatAppearance.BorderSize = 0;
            btnAddProperty.FlatStyle = FlatStyle.Flat;
            btnAddProperty.Font = new Font("Tajawal Medium", 10F, FontStyle.Bold);
            btnAddProperty.ForeColor = Color.White;
            btnAddProperty.Location = new Point(15, 8);
            btnAddProperty.Name = "btnAddProperty";
            btnAddProperty.Size = new Size(130, 35);
            btnAddProperty.TabIndex = 1;
            btnAddProperty.Text = "+ إضافة خاصية";
            btnAddProperty.UseVisualStyleBackColor = false;
            // 
            // flowProperties
            // 
            flowProperties.AutoScroll = true;
            flowProperties.Controls.Add(lblNoProperties);
            flowProperties.Location = new Point(15, 50);
            flowProperties.Name = "flowProperties";
            flowProperties.Size = new Size(706, 135);
            flowProperties.TabIndex = 2;
            // 
            // lblNoProperties
            // 
            lblNoProperties.Font = new Font("Tajawal", 10F, FontStyle.Regular);
            lblNoProperties.ForeColor = Color.Gray;
            lblNoProperties.Location = new Point(3, 0);
            lblNoProperties.Name = "lblNoProperties";
            lblNoProperties.Size = new Size(700, 100);
            lblNoProperties.TabIndex = 0;
            lblNoProperties.Text = "لا توجد خصائص إضافية. اضغط \"إضافة خاصية\" لإضافة معدات من المخزون.";
            lblNoProperties.TextAlign = ContentAlignment.MiddleCenter;
            lblNoProperties.RightToLeft = RightToLeft.Yes;
            // 
            // panelAlert
            // 
            panelAlert.BackColor = Color.FromArgb(239, 246, 255);
            panelAlert.Location = new Point(30, 865);
            panelAlert.Name = "panelAlert";
            panelAlert.Size = new Size(736, 45);
            panelAlert.TabIndex = 72;
            // 
            // lblAlertText
            // 
            lblAlertText.Dock = DockStyle.Fill;
            lblAlertText.Font = new Font("Tajawal Medium", 9.5F, FontStyle.Bold);
            lblAlertText.ForeColor = Color.FromArgb(29, 78, 216);
            lblAlertText.Location = new Point(0, 0);
            lblAlertText.Name = "lblAlertText";
            lblAlertText.Size = new Size(736, 45);
            lblAlertText.TabIndex = 0;
            lblAlertText.Text = "✓ سيتم حجز هذا الموعد تلقائياً...";
            lblAlertText.TextAlign = ContentAlignment.MiddleCenter;
            lblAlertText.RightToLeft = RightToLeft.Yes;
            panelAlert.Controls.Add(lblAlertText);
            // 
            // btnExit
            // 
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExit.ForeColor = Color.FromArgb(80, 80, 80);
            btnExit.Location = new Point(20, 9);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(35, 35);
            btnExit.TabIndex = 73;
            btnExit.Text = "✕";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // AddContract
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(798, 800);
            Controls.Add(btnExit);
            Controls.Add(panelAlert);
            Controls.Add(panelProperties);
            Controls.Add(label12);
            Controls.Add(deposittxt);
            Controls.Add(btnCancel);
            Controls.Add(dateTimePicker1);
            Controls.Add(dtpBookingDate);
            Controls.Add(dtpStartTime);
            Controls.Add(dtpEndTime);
            Controls.Add(customPanel2);
            Controls.Add(customPanel1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtPhone);
            Controls.Add(labelHours);
            Controls.Add(customPanel3);
            Controls.Add(btSave);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(txtPricePerHour);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "AddContract";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddContract";
            Load += AddContract_Load;
            customPanel3.ResumeLayout(false);
            customPanel2.ResumeLayout(false);
            customPanel1.ResumeLayout(false);
            panelProperties.ResumeLayout(false);
            panelProperties.PerformLayout();
            panelAlert.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label9;
        private CustomItems.AbdulTextBox txtPricePerHour;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label1;
        private Label label11;
        private Label label10;
        private CustomItems.RoundedButton btSave;
        private CustomItems.CustomPanel customPanel3;
        public ComboBox cmbDays;
        private Label labelHours;
        private CustomItems.CustomPanel customPanel2;
        public ComboBox cmbCourt;
        private CustomItems.CustomPanel customPanel1;
        public ComboBox cmbCourtType;
        private Label label5;
        private Label label4;
        private Label label3;
        private CustomItems.AbdulTextBox txtName;
        private Label label2;
        private CustomItems.AbdulTextBox txtPhone;
        public DateTimePicker dtpStartTime;
        public DateTimePicker dtpEndTime;
        public DateTimePicker dtpBookingDate;
        public DateTimePicker dateTimePicker1;
        private CustomItems.RoundedButton btnCancel;
        private Label label12;
        private CustomItems.AbdulTextBox deposittxt;
        private CustomItems.CustomPanel panelProperties;
        private Label lblPropertiesTitle;
        private CustomItems.RoundedButton btnAddProperty;
        public FlowLayoutPanel flowProperties;
        private Label lblNoProperties;
        private Panel panelAlert;
        private Label lblAlertText;
        private Button btnExit;
    }
}