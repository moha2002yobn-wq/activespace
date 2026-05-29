namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class AddPaymentForm
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
            label1 = new Label();
            bookingInfoCard1 = new ActiveSpaceSystem.CustomItems.BookingInfoCard();
            label2 = new Label();
            abdulTextBox1 = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            btnConfirm = new ActiveSpaceSystem.CustomItems.RoundedButton();
            btnCancel = new ActiveSpaceSystem.CustomItems.RoundedButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(300, 18);
            label1.Name = "label1";
            label1.Size = new Size(212, 33);
            label1.TabIndex = 1;
            label1.Text = "تسجيل دفعة جديدة";
            // 
            // bookingInfoCard1
            // 
            bookingInfoCard1.BackColor = Color.FromArgb(241, 245, 249);
            bookingInfoCard1.BookingNumberValue = "001";
            bookingInfoCard1.BorderRadius = 15;
            bookingInfoCard1.LabelsFontFamily = "Tajawal";
            bookingInfoCard1.LabelsFontSize = 12F;
            bookingInfoCard1.LabelTextColor = Color.FromArgb(100, 116, 139);
            bookingInfoCard1.Location = new Point(44, 82);
            bookingInfoCard1.Name = "bookingInfoCard1";
            bookingInfoCard1.RemainingAmountColor = Color.FromArgb(239, 68, 68);
            bookingInfoCard1.RemainingAmountValue = "200 د.ل";
            bookingInfoCard1.Size = new Size(447, 114);
            bookingInfoCard1.TabIndex = 2;
            bookingInfoCard1.ValuesFontFamily = "Tajawal";
            bookingInfoCard1.ValuesFontSize = 11.5F;
            bookingInfoCard1.ValueTextColor = Color.FromArgb(30, 41, 59);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tajawal Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(342, 220);
            label2.Name = "label2";
            label2.Size = new Size(149, 28);
            label2.TabIndex = 3;
            label2.Text = "المبلغ المدفوع";
            // 
            // abdulTextBox1
            // 
            abdulTextBox1.BackColor = Color.White;
            abdulTextBox1.BorderColor = Color.FromArgb(29, 53, 87);
            abdulTextBox1.BorderRadius = 15;
            abdulTextBox1.Icon = null;
            abdulTextBox1.IconLocation = HorizontalAlignment.Left;
            abdulTextBox1.IconSize = 20;
            abdulTextBox1.Location = new Point(44, 273);
            abdulTextBox1.Name = "abdulTextBox1";
            abdulTextBox1.passwordChar = "\0";
            abdulTextBox1.PlaceholderText = "الحد الأقصى : 200";
            abdulTextBox1.RightToLeft = RightToLeft.Yes;
            abdulTextBox1.Size = new Size(447, 50);
            abdulTextBox1.TabIndex = 4;
            abdulTextBox1.Texts = "";
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(16, 185, 129);
            btnConfirm.BorderColor = Color.Transparent;
            btnConfirm.BorderRadius = 15;
            btnConfirm.BorderSize = 0;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(274, 356);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(217, 62);
            btnConfirm.TabIndex = 30;
            btnConfirm.Text = "تأكيد الدفع";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.BorderColor = Color.Transparent;
            btnCancel.BorderRadius = 15;
            btnCancel.BorderSize = 0;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Gray;
            btnCancel.Location = new Point(44, 356);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(217, 62);
            btnCancel.TabIndex = 31;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddPaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(534, 434);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(abdulTextBox1);
            Controls.Add(label2);
            Controls.Add(bookingInfoCard1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddPaymentForm";
            Text = "AddPaymentForm";
            Load += AddPaymentForm_Load;
            Paint += AddPaymentForm_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CustomItems.RoundedButton btnConfirm;
        private CustomItems.RoundedButton btnCancel;
        public CustomItems.BookingInfoCard bookingInfoCard1;
        public CustomItems.AbdulTextBox abdulTextBox1;
    }
}