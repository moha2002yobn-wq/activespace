namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class UsersSettings
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
            panel1 = new Panel();
            roundedButton1 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            label1 = new Label();
            infoBox1 = new ActiveSpaceSystem.CustomItems.InfoBox();
            panel2 = new Panel();
            userListItem2 = new ActiveSpaceSystem.CustomItems.UserListItem();
            userListItem1 = new ActiveSpaceSystem.CustomItems.UserListItem();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedButton1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(942, 72);
            panel1.TabIndex = 2;
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.FromArgb(38, 191, 141);
            roundedButton1.BorderColor = Color.PaleVioletRed;
            roundedButton1.BorderRadius = 15;
            roundedButton1.BorderSize = 0;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedButton1.ForeColor = Color.White;
            roundedButton1.Image = Properties.Resources.icons8_add_50__1_;
            roundedButton1.ImageAlign = ContentAlignment.MiddleRight;
            roundedButton1.Location = new Point(28, 9);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new Padding(20, 10, 20, 10);
            roundedButton1.Size = new Size(274, 52);
            roundedButton1.TabIndex = 10;
            roundedButton1.Text = "إضافة مستخدم جديد";
            roundedButton1.TextAlign = ContentAlignment.MiddleLeft;
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(678, 10);
            label1.Name = "label1";
            label1.Size = new Size(257, 44);
            label1.TabIndex = 0;
            label1.Text = "إدارة المستخدمين";
            // 
            // infoBox1
            // 
            infoBox1.BackColor = Color.Transparent;
            infoBox1.BorderColor = Color.FromArgb(180, 210, 255);
            infoBox1.BorderRadius = 15;
            infoBox1.Description = "(يمكنك إضافة موظفين جدد وتحديد صلاحياتهم في النظام (مدير، موظف استقبال";
            infoBox1.DescriptionColor = Color.FromArgb(69, 123, 157);
            infoBox1.DescriptionFont = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            infoBox1.Dock = DockStyle.Top;
            infoBox1.FillColor = Color.FromArgb(240, 248, 255);
            infoBox1.Icon = null;
            infoBox1.IconSize = 25;
            infoBox1.Location = new Point(0, 72);
            infoBox1.Margin = new Padding(3, 3, 3, 17);
            infoBox1.Name = "infoBox1";
            infoBox1.Size = new Size(942, 83);
            infoBox1.TabIndex = 3;
            infoBox1.Title = "إدارة صلاحيات المستخدمين";
            infoBox1.TitleColor = Color.FromArgb(29, 53, 87);
            infoBox1.TitleFont = new Font("Tajawal", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            // 
            // panel2
            // 
            panel2.Controls.Add(userListItem2);
            panel2.Controls.Add(userListItem1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 155);
            panel2.Margin = new Padding(2, 8, 2, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(942, 279);
            panel2.TabIndex = 4;
            // 
            // userListItem2
            // 
            userListItem2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            userListItem2.BackColor = Color.FromArgb(243, 244, 246);
            userListItem2.EditIcon = Properties.Resources.icons8_edit_48;
            userListItem2.Location = new Point(0, 111);
            userListItem2.Margin = new Padding(2);
            userListItem2.Name = "userListItem2";
            userListItem2.Padding = new Padding(8, 8, 8, 8);
            userListItem2.RoleColor = Color.Silver;
            userListItem2.RoleText = "موظف";
            userListItem2.Size = new Size(940, 75);
            userListItem2.TabIndex = 1;
            userListItem2.UserEmail = "abdo@gmail.com";
            userListItem2.UserName = "عبد المهيمن كشون";
            // 
            // userListItem1
            // 
            userListItem1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            userListItem1.BackColor = Color.FromArgb(243, 244, 246);
            userListItem1.EditIcon = Properties.Resources.icons8_edit_48;
            userListItem1.Font = new Font("Tajawal", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userListItem1.Location = new Point(2, 18);
            userListItem1.Margin = new Padding(2);
            userListItem1.Name = "userListItem1";
            userListItem1.Padding = new Padding(8, 8, 8, 8);
            userListItem1.RoleColor = Color.FromArgb(46, 204, 113);
            userListItem1.RoleText = "مدير النظام";
            userListItem1.Size = new Size(940, 78);
            userListItem1.TabIndex = 0;
            userListItem1.UserEmail = "moha@gmail.com";
            userListItem1.UserName = "محمد يوسف";
            // 
            // UsersSettings
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(942, 434);
            Controls.Add(panel2);
            Controls.Add(infoBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "UsersSettings";
            Text = "UsersSettings";
            Load += UsersSettings_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private CustomItems.InfoBox infoBox1;
        private Panel panel2;
        private CustomItems.UserListItem userListItem1;
        private CustomItems.UserListItem userListItem2;
        private CustomItems.RoundedButton roundedButton1;
    }
}