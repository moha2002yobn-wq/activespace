namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class AddUserForm
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
            btnCancel = new ActiveSpaceSystem.CustomItems.RoundedButton();
            roundedButton1 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            customPanel2 = new ActiveSpaceSystem.CustomItems.CustomPanel();
            cmbRoule = new ComboBox();
            label5 = new Label();
            label3 = new Label();
            txtName = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            label2 = new Label();
            label1 = new Label();
            txtPhone = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            txtPassword = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            label11 = new Label();
            customPanel2.SuspendLayout();
            SuspendLayout();
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
            btnCancel.Location = new Point(79, 279);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(312, 64);
            btnCancel.TabIndex = 74;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.FromArgb(16, 185, 129);
            roundedButton1.BorderColor = Color.PaleVioletRed;
            roundedButton1.BorderRadius = 10;
            roundedButton1.BorderSize = 0;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Tajawal", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedButton1.ForeColor = Color.White;
            roundedButton1.Location = new Point(420, 279);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.RightToLeft = RightToLeft.Yes;
            roundedButton1.Size = new Size(312, 64);
            roundedButton1.TabIndex = 73;
            roundedButton1.Text = "+ إضافة مستخدم";
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // customPanel2
            // 
            customPanel2.BackColor = Color.White;
            customPanel2.BorderColor = Color.Black;
            customPanel2.BorderRadius = 10;
            customPanel2.BorderSize = 1F;
            customPanel2.Controls.Add(cmbRoule);
            customPanel2.Location = new Point(34, 203);
            customPanel2.Name = "customPanel2";
            customPanel2.ShowShadow = false;
            customPanel2.Size = new Size(330, 55);
            customPanel2.TabIndex = 72;
            // 
            // cmbRoule
            // 
            cmbRoule.FlatStyle = FlatStyle.Flat;
            cmbRoule.FormattingEnabled = true;
            cmbRoule.Location = new Point(18, 13);
            cmbRoule.Name = "cmbRoule";
            cmbRoule.RightToLeft = RightToLeft.Yes;
            cmbRoule.Size = new Size(295, 28);
            cmbRoule.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(274, 171);
            label5.Name = "label5";
            label5.Size = new Size(90, 25);
            label5.TabIndex = 62;
            label5.Text = "الصلاحية ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(259, 72);
            label3.Name = "label3";
            label3.Size = new Size(105, 25);
            label3.TabIndex = 60;
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
            txtName.Location = new Point(438, 112);
            txtName.Name = "txtName";
            txtName.passwordChar = "\0";
            txtName.PlaceholderText = "أدخل النص هنا...";
            txtName.RightToLeft = RightToLeft.Yes;
            txtName.Size = new Size(330, 50);
            txtName.TabIndex = 59;
            txtName.Texts = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(626, 74);
            label2.Name = "label2";
            label2.Size = new Size(142, 25);
            label2.TabIndex = 58;
            label2.Text = "إسم المستخدم";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(292, 17);
            label1.Name = "label1";
            label1.Size = new Size(225, 33);
            label1.TabIndex = 57;
            label1.Text = "إضافة مستخدم جديد";
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
            txtPhone.Location = new Point(34, 112);
            txtPhone.Name = "txtPhone";
            txtPhone.passwordChar = "\0";
            txtPhone.PlaceholderText = "أدخل النص هنا...";
            txtPhone.RightToLeft = RightToLeft.Yes;
            txtPhone.Size = new Size(330, 50);
            txtPhone.TabIndex = 54;
            txtPhone.Texts = "";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderColor = Color.FromArgb(29, 53, 87);
            txtPassword.BorderRadius = 15;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Icon = null;
            txtPassword.IconLocation = HorizontalAlignment.Left;
            txtPassword.IconSize = 20;
            txtPassword.Location = new Point(438, 208);
            txtPassword.Name = "txtPassword";
            txtPassword.passwordChar = "\0";
            txtPassword.PlaceholderText = "أدخل السعر هنا...";
            txtPassword.RightToLeft = RightToLeft.Yes;
            txtPassword.Size = new Size(330, 50);
            txtPassword.TabIndex = 66;
            txtPassword.Texts = "";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(660, 171);
            label11.Name = "label11";
            label11.Size = new Size(108, 25);
            label11.TabIndex = 67;
            label11.Text = "كلمة المرور";
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 375);
            Controls.Add(btnCancel);
            Controls.Add(roundedButton1);
            Controls.Add(customPanel2);
            Controls.Add(label11);
            Controls.Add(txtPassword);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPhone);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddUserForm";
            Text = "AddUserForm";
            customPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomItems.RoundedButton btnCancel;
        private CustomItems.RoundedButton roundedButton1;
        private CustomItems.CustomPanel customPanel2;
        public ComboBox cmbRoule;
        public DateTimePicker dtpStartTime;
        public DateTimePicker dtpEndTime;
        public DateTimePicker dtpBookingDate;
        private Label label10;
        private CustomItems.AbdulTextBox deposittxt;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private CustomItems.AbdulTextBox txtName;
        private Label label2;
        private Label label1;
        private CustomItems.AbdulTextBox txtPhone;
        private CustomItems.AbdulTextBox txtPassword;
        private Label label11;
    }
}