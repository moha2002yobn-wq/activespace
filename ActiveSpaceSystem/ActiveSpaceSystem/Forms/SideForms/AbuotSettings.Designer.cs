
namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class AbuotSettings
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
            label1 = new Label();
            panel2 = new Panel();
            roundedButton1 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            abdulTextBox3 = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            label4 = new Label();
            abdulTextBox2 = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            abdulTextBox1 = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(886, 86);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal Medium", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(694, 24);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(171, 41);
            label1.TabIndex = 0;
            label1.Text = "حول النظام";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(roundedButton1);
            panel2.Controls.Add(abdulTextBox3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(abdulTextBox2);
            panel2.Controls.Add(abdulTextBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 86);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(886, 360);
            panel2.TabIndex = 1;
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = AnchorStyles.None;
            roundedButton1.BackColor = Color.FromArgb(41, 51, 146);
            roundedButton1.BorderColor = Color.FromArgb(41, 51, 146);
            roundedButton1.BorderRadius = 20;
            roundedButton1.BorderSize = 2;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Tajawal Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundedButton1.ForeColor = Color.White;
            roundedButton1.Location = new Point(103, 66);
            roundedButton1.Margin = new Padding(2);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(154, 48);
            roundedButton1.TabIndex = 6;
            roundedButton1.Text = "حفظ";
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // abdulTextBox3
            // 
            abdulTextBox3.Anchor = AnchorStyles.None;
            abdulTextBox3.BackColor = Color.White;
            abdulTextBox3.BorderColor = Color.FromArgb(29, 53, 87);
            abdulTextBox3.BorderRadius = 15;
            abdulTextBox3.Enabled = false;
            abdulTextBox3.Font = new Font("Tajawal", 7.99999952F);
            abdulTextBox3.Icon = null;
            abdulTextBox3.IconLocation = HorizontalAlignment.Left;
            abdulTextBox3.IconSize = 20;
            abdulTextBox3.Location = new Point(325, 275);
            abdulTextBox3.Margin = new Padding(2);
            abdulTextBox3.Name = "abdulTextBox3";
            abdulTextBox3.passwordChar = "\0";
            abdulTextBox3.PlaceholderText = "";
            abdulTextBox3.Size = new Size(562, 48);
            abdulTextBox3.TabIndex = 5;
            abdulTextBox3.Texts = "Active Team";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Tajawal", 10.999999F);
            label4.Location = new Point(778, 235);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(103, 26);
            label4.TabIndex = 4;
            label4.Text = "فريق العمل";
            // 
            // abdulTextBox2
            // 
            abdulTextBox2.Anchor = AnchorStyles.None;
            abdulTextBox2.BackColor = Color.White;
            abdulTextBox2.BorderColor = Color.FromArgb(29, 53, 87);
            abdulTextBox2.BorderRadius = 15;
            abdulTextBox2.Enabled = false;
            abdulTextBox2.Font = new Font("Tajawal", 7.99999952F);
            abdulTextBox2.Icon = null;
            abdulTextBox2.IconLocation = HorizontalAlignment.Left;
            abdulTextBox2.IconSize = 20;
            abdulTextBox2.Location = new Point(325, 173);
            abdulTextBox2.Margin = new Padding(2);
            abdulTextBox2.Name = "abdulTextBox2";
            abdulTextBox2.passwordChar = "\0";
            abdulTextBox2.PlaceholderText = "";
            abdulTextBox2.Size = new Size(562, 48);
            abdulTextBox2.TabIndex = 3;
            abdulTextBox2.Texts = "1.0.0";
            // 
            // abdulTextBox1
            // 
            abdulTextBox1.Anchor = AnchorStyles.None;
            abdulTextBox1.BackColor = Color.White;
            abdulTextBox1.BorderColor = Color.FromArgb(29, 53, 87);
            abdulTextBox1.BorderRadius = 15;
            abdulTextBox1.Font = new Font("Tajawal", 7.99999952F);
            abdulTextBox1.Icon = null;
            abdulTextBox1.IconLocation = HorizontalAlignment.Left;
            abdulTextBox1.IconSize = 20;
            abdulTextBox1.Location = new Point(325, 66);
            abdulTextBox1.Margin = new Padding(2);
            abdulTextBox1.Name = "abdulTextBox1";
            abdulTextBox1.passwordChar = "\0";
            abdulTextBox1.PlaceholderText = "";
            abdulTextBox1.Size = new Size(562, 48);
            abdulTextBox1.TabIndex = 2;
            abdulTextBox1.Texts = "";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Tajawal", 10.999999F);
            label3.Location = new Point(778, 130);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(111, 26);
            label3.TabIndex = 1;
            label3.Text = "اصدار النظام";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Tajawal", 10.999999F);
            label2.Location = new Point(778, 26);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 26);
            label2.TabIndex = 0;
            label2.Text = "اسم النظام";
            label2.Click += label2_Click;
            // 
            // AbuotSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(886, 446);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "AbuotSettings";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "AbuotSettings";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void abdulTextBox1__TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private CustomItems.AbdulTextBox abdulTextBox1;
        private Label label3;
        private Label label2;
        private CustomItems.AbdulTextBox abdulTextBox2;
        private CustomItems.AbdulTextBox abdulTextBox3;
        private Label label4;
        private CustomItems.RoundedButton roundedButton1;
    }
}