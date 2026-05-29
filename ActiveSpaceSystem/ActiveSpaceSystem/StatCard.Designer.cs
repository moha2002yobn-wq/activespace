namespace ActiveSpaceSystem
{
    partial class StatCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatCard));
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(369, 150);
            panel2.TabIndex = 5;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(22, 17);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(70, 70);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Green;
            label4.Location = new Point(278, 103);
            label4.Name = "label4";
            label4.Size = new Size(70, 29);
            label4.TabIndex = 2;
            label4.Text = "+8% ↗";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tajawal", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(224, 50);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(124, 40);
            label5.TabIndex = 1;
            label5.Text = "3000 د.ل";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(165, 17);
            label6.Name = "label6";
            label6.Size = new Size(187, 23);
            label6.TabIndex = 0;
            label6.Text = "إجمالي الإيرادات اليوم ";
            // 
            // StatCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Name = "StatCard";
            Size = new Size(369, 150);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Panel panel2;
        private PictureBox pictureBox2;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
