namespace ActiveSpaceSystem.Forms.DialogForms
{
    partial class AddCourtTypeForm
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
            roundedButton2 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            roundedButton1 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            label2 = new Label();
            label1 = new Label();
            namecourttxt = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            SuspendLayout();
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
            roundedButton2.Location = new Point(326, 145);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Size = new Size(188, 43);
            roundedButton2.TabIndex = 53;
            roundedButton2.Text = "إضافة";
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
            roundedButton1.Location = new Point(68, 145);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(188, 43);
            roundedButton1.TabIndex = 52;
            roundedButton1.Text = "إلغاء";
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tajawal Medium", 10.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(403, 92);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 51;
            label2.Text = "نوع الملعب";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(160, 25);
            label1.Name = "label1";
            label1.Size = new Size(183, 33);
            label1.TabIndex = 49;
            label1.Text = "إضافة نوع ملعب";
            // 
            // namecourttxt
            // 
            namecourttxt.BackColor = Color.White;
            namecourttxt.BorderColor = Color.FromArgb(29, 53, 87);
            namecourttxt.BorderRadius = 15;
            namecourttxt.Icon = null;
            namecourttxt.IconLocation = HorizontalAlignment.Left;
            namecourttxt.IconSize = 20;
            namecourttxt.Location = new Point(12, 80);
            namecourttxt.Name = "namecourttxt";
            namecourttxt.passwordChar = "\0";
            namecourttxt.PlaceholderText = "تنس , سلة , قدم , بادل ";
            namecourttxt.RightToLeft = RightToLeft.Yes;
            namecourttxt.Size = new Size(385, 50);
            namecourttxt.TabIndex = 48;
            namecourttxt.Texts = "";
            // 
            // AddCourtTypeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(542, 208);
            Controls.Add(roundedButton2);
            Controls.Add(roundedButton1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(namecourttxt);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddCourtTypeForm";
            Text = "AddCourtTypeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomItems.RoundedButton roundedButton2;
        private CustomItems.RoundedButton roundedButton1;
        private Label label2;
        private Label label1;
        private CustomItems.AbdulTextBox namecourttxt;
    }
}