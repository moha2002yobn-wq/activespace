namespace ActiveSpaceSystem.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            gradientPanel1 = new ActiveSpaceSystem.CustomItems.GradientPanel();
            panel1 = new Panel();
            ExitBt = new ActiveSpaceSystem.CustomItems.RoundedButton();
            label3 = new Label();
            LoginBt = new ActiveSpaceSystem.CustomItems.RoundedButton();
            txtPassword = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            LabelPassword = new Label();
            label4 = new Label();
            roundedPictureBox1 = new ActiveSpaceSystem.CustomItems.RoundedPictureBox();
            LabelName = new Label();
            txtUsername = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)roundedPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // gradientPanel1
            // 
            gradientPanel1.BorderRadius = 10;
            gradientPanel1.Dock = DockStyle.Left;
            gradientPanel1.GradientColor1 = Color.FromArgb(29, 53, 87);
            gradientPanel1.GradientColor2 = Color.FromArgb(26, 188, 156);
            gradientPanel1.ImageOpacity = 50;
            gradientPanel1.ImageSizeMode = PictureBoxSizeMode.StretchImage;
            gradientPanel1.Location = new Point(0, 0);
            gradientPanel1.Name = "gradientPanel1";
            gradientPanel1.PanelImage = Properties.Resources.vienna_reyes_Zs_o1IjVPt4_unsplash;
            gradientPanel1.Size = new Size(410, 483);
            gradientPanel1.TabIndex = 6;
            gradientPanel1.TitleText = "";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(ExitBt);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(LoginBt);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(LabelPassword);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(roundedPictureBox1);
            panel1.Controls.Add(LabelName);
            panel1.Controls.Add(txtUsername);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(410, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(422, 483);
            panel1.TabIndex = 7;
            // 
            // ExitBt
            // 
            ExitBt.BackColor = Color.Firebrick;
            ExitBt.BorderColor = Color.Firebrick;
            ExitBt.BorderRadius = 1;
            ExitBt.BorderSize = 2;
            ExitBt.FlatAppearance.BorderSize = 0;
            ExitBt.FlatStyle = FlatStyle.Flat;
            ExitBt.Font = new Font("Segoe UI", 15F);
            ExitBt.ForeColor = Color.White;
            ExitBt.Location = new Point(382, 2);
            ExitBt.Margin = new Padding(2);
            ExitBt.Name = "ExitBt";
            ExitBt.Size = new Size(38, 35);
            ExitBt.TabIndex = 39;
            ExitBt.Text = "X";
            ExitBt.UseVisualStyleBackColor = false;
            ExitBt.Click += roundedButton2_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(50, 427);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(324, 23);
            label3.TabIndex = 38;
            label3.Text = "النظام مخصص للموظفين المصرح بهم فقط";
            // 
            // LoginBt
            // 
            LoginBt.Anchor = AnchorStyles.None;
            LoginBt.BackColor = Color.FromArgb(52, 77, 149);
            LoginBt.BorderColor = Color.PaleVioletRed;
            LoginBt.BorderRadius = 15;
            LoginBt.BorderSize = 0;
            LoginBt.FlatAppearance.BorderSize = 0;
            LoginBt.FlatStyle = FlatStyle.Flat;
            LoginBt.Font = new Font("Tajawal", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginBt.ForeColor = Color.White;
            LoginBt.Location = new Point(26, 348);
            LoginBt.Name = "LoginBt";
            LoginBt.Size = new Size(371, 52);
            LoginBt.TabIndex = 37;
            LoginBt.Text = "تسجيل الدخول";
            LoginBt.UseVisualStyleBackColor = false;
            LoginBt.Click += roundedButton1_Click_1;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BackColor = Color.White;
            txtPassword.BorderColor = Color.FromArgb(29, 53, 87);
            txtPassword.BorderRadius = 15;
            txtPassword.Font = new Font("Tajawal", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Icon = Properties.Resources.icons8_lock_50;
            txtPassword.IconLocation = HorizontalAlignment.Right;
            txtPassword.IconSize = 30;
            txtPassword.Location = new Point(38, 278);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.passwordChar = ".";
            txtPassword.PlaceholderText = "أدخل كلمة المرور";
            txtPassword.RightToLeft = RightToLeft.Yes;
            txtPassword.Size = new Size(359, 52);
            txtPassword.TabIndex = 3;
            txtPassword.Texts = "";
            // 
            // LabelPassword
            // 
            LabelPassword.Anchor = AnchorStyles.None;
            LabelPassword.AutoSize = true;
            LabelPassword.BackColor = Color.Transparent;
            LabelPassword.Font = new Font("Tajawal", 10.2F, FontStyle.Bold);
            LabelPassword.ForeColor = Color.Black;
            LabelPassword.Location = new Point(303, 251);
            LabelPassword.Name = "LabelPassword";
            LabelPassword.RightToLeft = RightToLeft.Yes;
            LabelPassword.Size = new Size(94, 25);
            LabelPassword.TabIndex = 2;
            LabelPassword.Text = "كلمة المرور";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.MidnightBlue;
            label4.Location = new Point(126, 97);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(173, 38);
            label4.TabIndex = 32;
            label4.Text = "Active Space";
            // 
            // roundedPictureBox1
            // 
            roundedPictureBox1.Anchor = AnchorStyles.None;
            roundedPictureBox1.BackColor = Color.Transparent;
            roundedPictureBox1.BorderRadius = 60;
            roundedPictureBox1.Image = (Image)resources.GetObject("roundedPictureBox1.Image");
            roundedPictureBox1.Location = new Point(140, 22);
            roundedPictureBox1.Name = "roundedPictureBox1";
            roundedPictureBox1.Size = new Size(122, 72);
            roundedPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            roundedPictureBox1.TabIndex = 31;
            roundedPictureBox1.TabStop = false;
            // 
            // LabelName
            // 
            LabelName.Anchor = AnchorStyles.None;
            LabelName.AutoSize = true;
            LabelName.BackColor = Color.Transparent;
            LabelName.Font = new Font("Tajawal", 10.2F, FontStyle.Bold);
            LabelName.ForeColor = Color.Black;
            LabelName.Location = new Point(268, 152);
            LabelName.Name = "LabelName";
            LabelName.RightToLeft = RightToLeft.Yes;
            LabelName.Size = new Size(129, 25);
            LabelName.TabIndex = 33;
            LabelName.Text = "اسم المستخدم";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.None;
            txtUsername.BackColor = Color.White;
            txtUsername.BorderColor = Color.FromArgb(29, 53, 87);
            txtUsername.BorderRadius = 15;
            txtUsername.Font = new Font("Tajawal Medium", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUsername.Icon = Properties.Resources.icons8_user_50;
            txtUsername.IconLocation = HorizontalAlignment.Right;
            txtUsername.IconSize = 30;
            txtUsername.Location = new Point(38, 179);
            txtUsername.Margin = new Padding(2);
            txtUsername.Name = "txtUsername";
            txtUsername.passwordChar = "\0";
            txtUsername.PlaceholderText = "أدخل اسم المستخدم";
            txtUsername.RightToLeft = RightToLeft.Yes;
            txtUsername.Size = new Size(359, 50);
            txtUsername.TabIndex = 1;
            txtUsername.Texts = "";
            // 
            // LoginForm
            // 
            AcceptButton = LoginBt;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            CancelButton = ExitBt;
            ClientSize = new Size(832, 483);
            Controls.Add(panel1);
            Controls.Add(gradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)roundedPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CustomItems.GradientPanel gradientPanel1;
        private Panel panel1;
        private Label label3;
        private CustomItems.RoundedButton LoginBt;
        private CustomItems.AbdulTextBox txtPassword;
        private Label LabelPassword;
        private Label label4;
        private CustomItems.RoundedPictureBox roundedPictureBox1;
        private Label LabelName;
        private CustomItems.AbdulTextBox txtUsername;
        private CustomItems.RoundedButton ExitBt;
    }
}