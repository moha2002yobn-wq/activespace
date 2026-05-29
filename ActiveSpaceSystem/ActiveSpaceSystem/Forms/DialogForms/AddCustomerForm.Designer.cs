namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class AddCustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCustomerForm));
            lblTitle = new Label();
            button1 = new Button();
            label2 = new Label();
            nametxt = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            phonetxt = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            label3 = new Label();
            roundedButton1 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            roundedButton2 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Tajawal", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(270, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(190, 33);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "إضافة عميل جديد";
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Popup;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(44, 27);
            button1.Name = "button1";
            button1.Size = new Size(29, 29);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(331, 79);
            label2.Name = "label2";
            label2.Size = new Size(115, 25);
            label2.TabIndex = 24;
            label2.Text = "اسم العميل";
            // 
            // nametxt
            // 
            nametxt.BackColor = Color.White;
            nametxt.BorderColor = Color.FromArgb(29, 53, 87);
            nametxt.BorderRadius = 15;
            nametxt.Icon = null;
            nametxt.IconLocation = HorizontalAlignment.Left;
            nametxt.IconSize = 20;
            nametxt.Location = new Point(33, 118);
            nametxt.Name = "nametxt";
            nametxt.passwordChar = "\0";
            nametxt.PlaceholderText = "أدخل النص هنا...";
            nametxt.RightToLeft = RightToLeft.Yes;
            nametxt.Size = new Size(413, 50);
            nametxt.TabIndex = 25;
            nametxt.Texts = "";
            nametxt.KeyPress += nametxt_KeyPress;
            // 
            // phonetxt
            // 
            phonetxt.BackColor = Color.White;
            phonetxt.BorderColor = Color.FromArgb(29, 53, 87);
            phonetxt.BorderRadius = 15;
            phonetxt.Icon = null;
            phonetxt.IconLocation = HorizontalAlignment.Left;
            phonetxt.IconSize = 20;
            phonetxt.Location = new Point(33, 220);
            phonetxt.Name = "phonetxt";
            phonetxt.passwordChar = "\0";
            phonetxt.PlaceholderText = "09XXXXXXXX";
            phonetxt.RightToLeft = RightToLeft.Yes;
            phonetxt.Size = new Size(413, 50);
            phonetxt.TabIndex = 27;
            phonetxt.Texts = "";
            phonetxt.KeyPress += phonetxt_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(341, 181);
            label3.Name = "label3";
            label3.Size = new Size(105, 25);
            label3.TabIndex = 26;
            label3.Text = "رقم الهاتف";
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.WhiteSmoke;
            roundedButton1.BorderColor = Color.Transparent;
            roundedButton1.BorderRadius = 30;
            roundedButton1.BorderSize = 2;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedButton1.ForeColor = Color.Gray;
            roundedButton1.Location = new Point(62, 297);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(188, 43);
            roundedButton1.TabIndex = 28;
            roundedButton1.Text = "إلغاء";
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // roundedButton2
            // 
            roundedButton2.BackColor = Color.FromArgb(16, 185, 129);
            roundedButton2.BorderColor = Color.Transparent;
            roundedButton2.BorderRadius = 30;
            roundedButton2.BorderSize = 2;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = FlatStyle.Flat;
            roundedButton2.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedButton2.ForeColor = Color.White;
            roundedButton2.Location = new Point(256, 297);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Size = new Size(188, 43);
            roundedButton2.TabIndex = 29;
            roundedButton2.Text = "إضافة العميل";
            roundedButton2.UseVisualStyleBackColor = false;
            roundedButton2.Click += roundedButton2_Click;
            // 
            // AddCustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(485, 372);
            Controls.Add(roundedButton2);
            Controls.Add(roundedButton1);
            Controls.Add(phonetxt);
            Controls.Add(label3);
            Controls.Add(nametxt);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddCustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddCustomerForm";
            Load += AddCustomerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button button1;
        private Label label2;
        private CustomItems.AbdulTextBox nametxt;
        private CustomItems.AbdulTextBox phonetxt;
        private Label label3;
        private CustomItems.RoundedButton roundedButton1;
        private CustomItems.RoundedButton roundedButton2;
    }
}