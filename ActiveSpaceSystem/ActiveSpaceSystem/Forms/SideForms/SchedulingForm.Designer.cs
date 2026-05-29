namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class SchedulingForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label3 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            statusCard1 = new ActiveSpaceSystem.CustomItems.StatusCard();
            customLabel4 = new ActiveSpaceSystem.CustomItems.CustomLabel();
            customLabel3 = new ActiveSpaceSystem.CustomItems.CustomLabel();
            customLabel2 = new ActiveSpaceSystem.CustomItems.CustomLabel();
            customLabel1 = new ActiveSpaceSystem.CustomItems.CustomLabel();
            statusCard5 = new ActiveSpaceSystem.CustomItems.StatusCard();
            statusCard3 = new ActiveSpaceSystem.CustomItems.StatusCard();
            statusCard2 = new ActiveSpaceSystem.CustomItems.StatusCard();
            panel3 = new Panel();
            stadiumGrid1 = new ActiveSpaceSystem.CustomItems.StadiumGrid();
            panel4 = new Panel();
            statusCard4 = new ActiveSpaceSystem.CustomItems.StatusCard();
            btnBackDate = new ActiveSpaceSystem.CustomItems.IconButton();
            btnForwardDate = new ActiveSpaceSystem.CustomItems.IconButton();
            dateTimePicker2 = new DateTimePicker();
            btnPadel = new ActiveSpaceSystem.CustomItems.PillButton();
            btnBasketBall = new ActiveSpaceSystem.CustomItems.PillButton();
            btnFootBall = new ActiveSpaceSystem.CustomItems.PillButton();
            btnAll = new ActiveSpaceSystem.CustomItems.PillButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            statusCard1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stadiumGrid1).BeginInit();
            panel4.SuspendLayout();
            statusCard4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1043, 85);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(780, 57);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(249, 23);
            label3.TabIndex = 8;
            label3.Text = "عرض وإدارة الجدول الزمني للملاعب";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(795, 9);
            label1.Name = "label1";
            label1.Size = new Size(234, 49);
            label1.TabIndex = 7;
            label1.Text = "الجدولة الزمنية";
            // 
            // panel2
            // 
            panel2.Controls.Add(statusCard1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 585);
            panel2.Name = "panel2";
            panel2.Size = new Size(1043, 98);
            panel2.TabIndex = 1;
            // 
            // statusCard1
            // 
            statusCard1.BackColor = Color.Transparent;
            statusCard1.BorderColor = Color.Black;
            statusCard1.BorderRadius = 15;
            statusCard1.CardBackColor = Color.White;
            statusCard1.Controls.Add(customLabel4);
            statusCard1.Controls.Add(customLabel3);
            statusCard1.Controls.Add(customLabel2);
            statusCard1.Controls.Add(customLabel1);
            statusCard1.Controls.Add(statusCard5);
            statusCard1.Controls.Add(statusCard3);
            statusCard1.Controls.Add(statusCard2);
            statusCard1.Dock = DockStyle.Bottom;
            statusCard1.Location = new Point(0, 8);
            statusCard1.Margin = new Padding(2);
            statusCard1.Name = "statusCard1";
            statusCard1.Padding = new Padding(4);
            statusCard1.ShadowBlur = 5;
            statusCard1.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            statusCard1.ShowShadow = true;
            statusCard1.Size = new Size(1043, 90);
            statusCard1.TabIndex = 7;
            statusCard1.TitleColor = Color.Gray;
            statusCard1.TitleFont = new Font("Microsoft Sans Serif", 10F);
            statusCard1.TitleText = "";
            statusCard1.ValueColor = Color.FromArgb(46, 204, 113);
            statusCard1.ValueFont = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            statusCard1.ValueText = "";
            // 
            // customLabel4
            // 
            customLabel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            customLabel4.AutoSize = true;
            customLabel4.BackColor = Color.Transparent;
            customLabel4.Font = new Font("Tajawal", 10.2F);
            customLabel4.Location = new Point(470, 50);
            customLabel4.Margin = new Padding(2, 0, 2, 0);
            customLabel4.Name = "customLabel4";
            customLabel4.Size = new Size(133, 23);
            customLabel4.TabIndex = 6;
            customLabel4.Text = "خارج أوقات العمل";
            // 
            // customLabel3
            // 
            customLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            customLabel3.AutoSize = true;
            customLabel3.BackColor = Color.Transparent;
            customLabel3.Font = new Font("Tajawal", 10.2F);
            customLabel3.Location = new Point(666, 50);
            customLabel3.Margin = new Padding(2, 0, 2, 0);
            customLabel3.Name = "customLabel3";
            customLabel3.Size = new Size(56, 23);
            customLabel3.TabIndex = 5;
            customLabel3.Text = "محجوز";
            // 
            // customLabel2
            // 
            customLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            customLabel2.AutoSize = true;
            customLabel2.BackColor = Color.Transparent;
            customLabel2.Font = new Font("Tajawal", 10.2F);
            customLabel2.Location = new Point(795, 50);
            customLabel2.Margin = new Padding(2, 0, 2, 0);
            customLabel2.Name = "customLabel2";
            customLabel2.Size = new Size(85, 23);
            customLabel2.TabIndex = 4;
            customLabel2.Text = "متاح للحجز";
            // 
            // customLabel1
            // 
            customLabel1.Anchor = AnchorStyles.Right;
            customLabel1.AutoSize = true;
            customLabel1.BackColor = Color.Transparent;
            customLabel1.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customLabel1.Location = new Point(795, 4);
            customLabel1.Margin = new Padding(2, 0, 2, 0);
            customLabel1.Name = "customLabel1";
            customLabel1.Size = new Size(145, 29);
            customLabel1.TabIndex = 3;
            customLabel1.Text = "مفتاح التوضيح";
            // 
            // statusCard5
            // 
            statusCard5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            statusCard5.BackColor = Color.Transparent;
            statusCard5.BorderColor = Color.FromArgb(240, 240, 240);
            statusCard5.BorderRadius = 5;
            statusCard5.CardBackColor = Color.FromArgb(224, 224, 224);
            statusCard5.Location = new Point(602, 44);
            statusCard5.Margin = new Padding(2);
            statusCard5.Name = "statusCard5";
            statusCard5.Padding = new Padding(4);
            statusCard5.ShadowBlur = 5;
            statusCard5.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            statusCard5.ShowShadow = true;
            statusCard5.Size = new Size(36, 33);
            statusCard5.TabIndex = 2;
            statusCard5.TitleColor = Color.Gray;
            statusCard5.TitleFont = new Font("Microsoft Sans Serif", 10F);
            statusCard5.TitleText = "";
            statusCard5.ValueColor = Color.FromArgb(46, 204, 113);
            statusCard5.ValueFont = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            statusCard5.ValueText = "";
            // 
            // statusCard3
            // 
            statusCard3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            statusCard3.BackColor = Color.Transparent;
            statusCard3.BorderColor = Color.FromArgb(240, 240, 240);
            statusCard3.BorderRadius = 5;
            statusCard3.CardBackColor = Color.FromArgb(255, 128, 128);
            statusCard3.Location = new Point(725, 44);
            statusCard3.Margin = new Padding(2);
            statusCard3.Name = "statusCard3";
            statusCard3.Padding = new Padding(4);
            statusCard3.ShadowBlur = 5;
            statusCard3.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            statusCard3.ShowShadow = true;
            statusCard3.Size = new Size(36, 33);
            statusCard3.TabIndex = 1;
            statusCard3.TitleColor = Color.Gray;
            statusCard3.TitleFont = new Font("Microsoft Sans Serif", 10F);
            statusCard3.TitleText = "";
            statusCard3.ValueColor = Color.FromArgb(46, 204, 113);
            statusCard3.ValueFont = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            statusCard3.ValueText = "";
            // 
            // statusCard2
            // 
            statusCard2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            statusCard2.BackColor = Color.Transparent;
            statusCard2.BorderColor = Color.FromArgb(240, 240, 240);
            statusCard2.BorderRadius = 5;
            statusCard2.CardBackColor = Color.FromArgb(192, 255, 192);
            statusCard2.Location = new Point(880, 44);
            statusCard2.Margin = new Padding(2);
            statusCard2.Name = "statusCard2";
            statusCard2.Padding = new Padding(4);
            statusCard2.ShadowBlur = 5;
            statusCard2.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            statusCard2.ShowShadow = true;
            statusCard2.Size = new Size(34, 33);
            statusCard2.TabIndex = 0;
            statusCard2.TitleColor = Color.Gray;
            statusCard2.TitleFont = new Font("Microsoft Sans Serif", 10F);
            statusCard2.TitleText = "";
            statusCard2.ValueColor = Color.FromArgb(46, 204, 113);
            statusCard2.ValueFont = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            statusCard2.ValueText = "";
            // 
            // panel3
            // 
            panel3.Controls.Add(stadiumGrid1);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 85);
            panel3.Name = "panel3";
            panel3.Size = new Size(1043, 500);
            panel3.TabIndex = 2;
            // 
            // stadiumGrid1
            // 
            stadiumGrid1.AllowUserToAddRows = false;
            stadiumGrid1.BackgroundColor = Color.White;
            stadiumGrid1.BorderRadius = 25;
            stadiumGrid1.BorderStyle = BorderStyle.None;
            stadiumGrid1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            stadiumGrid1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(52, 58, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            stadiumGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            stadiumGrid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            stadiumGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            stadiumGrid1.Dock = DockStyle.Fill;
            stadiumGrid1.EnableHeadersVisualStyles = false;
            stadiumGrid1.GridColor = Color.White;
            stadiumGrid1.Location = new Point(0, 93);
            stadiumGrid1.Name = "stadiumGrid1";
            stadiumGrid1.ReadOnly = true;
            stadiumGrid1.RightToLeft = RightToLeft.Yes;
            stadiumGrid1.RowHeadersVisible = false;
            stadiumGrid1.RowHeadersWidth = 51;
            stadiumGrid1.RowTemplate.Height = 70;
            stadiumGrid1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            stadiumGrid1.Size = new Size(1043, 407);
            stadiumGrid1.TabIndex = 9;
            // 
            // panel4
            // 
            panel4.Controls.Add(statusCard4);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1043, 93);
            panel4.TabIndex = 0;
            // 
            // statusCard4
            // 
            statusCard4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            statusCard4.BackColor = Color.Transparent;
            statusCard4.BorderColor = Color.Black;
            statusCard4.BorderRadius = 15;
            statusCard4.CardBackColor = Color.White;
            statusCard4.Controls.Add(btnBackDate);
            statusCard4.Controls.Add(btnForwardDate);
            statusCard4.Controls.Add(dateTimePicker2);
            statusCard4.Controls.Add(btnPadel);
            statusCard4.Controls.Add(btnBasketBall);
            statusCard4.Controls.Add(btnFootBall);
            statusCard4.Controls.Add(btnAll);
            statusCard4.Location = new Point(0, 0);
            statusCard4.Margin = new Padding(80);
            statusCard4.Name = "statusCard4";
            statusCard4.Padding = new Padding(40);
            statusCard4.ShadowBlur = 5;
            statusCard4.ShadowColor = Color.FromArgb(0, 0, 192);
            statusCard4.ShowShadow = true;
            statusCard4.Size = new Size(1043, 93);
            statusCard4.TabIndex = 6;
            statusCard4.TitleColor = Color.Gray;
            statusCard4.TitleFont = new Font("Microsoft Sans Serif", 10F);
            statusCard4.TitleText = "";
            statusCard4.ValueColor = Color.FromArgb(46, 204, 113);
            statusCard4.ValueFont = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            statusCard4.ValueText = "";
            // 
            // btnBackDate
            // 
            btnBackDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBackDate.BackColor = Color.LightGray;
            btnBackDate.BorderColor = Color.PaleVioletRed;
            btnBackDate.BorderRadius = 15;
            btnBackDate.BorderSize = 0;
            btnBackDate.ButtonIcon = Properties.Resources.icons8_arrow_right_50;
            btnBackDate.FlatAppearance.BorderSize = 0;
            btnBackDate.FlatStyle = FlatStyle.Flat;
            btnBackDate.ForeColor = Color.Silver;
            btnBackDate.IconAlignment = ContentAlignment.MiddleCenter;
            btnBackDate.IconSize = new Size(25, 25);
            btnBackDate.Location = new Point(963, 34);
            btnBackDate.Name = "btnBackDate";
            btnBackDate.Size = new Size(40, 31);
            btnBackDate.TabIndex = 18;
            btnBackDate.UseVisualStyleBackColor = false;
            btnBackDate.Click += btnBackDate_Click_1;
            // 
            // btnForwardDate
            // 
            btnForwardDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnForwardDate.BackColor = Color.LightGray;
            btnForwardDate.BorderColor = Color.PaleVioletRed;
            btnForwardDate.BorderRadius = 15;
            btnForwardDate.BorderSize = 0;
            btnForwardDate.ButtonIcon = Properties.Resources.icons8_arrow_left_50;
            btnForwardDate.FlatAppearance.BorderSize = 0;
            btnForwardDate.FlatStyle = FlatStyle.Flat;
            btnForwardDate.ForeColor = Color.Silver;
            btnForwardDate.IconAlignment = ContentAlignment.MiddleCenter;
            btnForwardDate.IconSize = new Size(25, 25);
            btnForwardDate.Location = new Point(660, 34);
            btnForwardDate.Name = "btnForwardDate";
            btnForwardDate.Size = new Size(40, 31);
            btnForwardDate.TabIndex = 17;
            btnForwardDate.UseVisualStyleBackColor = false;
            btnForwardDate.Click += btnForwardDate_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateTimePicker2.CustomFormat = "yyyy / MM / dd";
            dateTimePicker2.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(716, 34);
            dateTimePicker2.Margin = new Padding(2);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.RightToLeft = RightToLeft.Yes;
            dateTimePicker2.RightToLeftLayout = true;
            dateTimePicker2.Size = new Size(237, 31);
            dateTimePicker2.TabIndex = 13;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // btnPadel
            // 
            btnPadel.BackColor = Color.White;
            btnPadel.BackgroundImageLayout = ImageLayout.None;
            btnPadel.Checked = false;
            btnPadel.CheckedBackColor = Color.FromArgb(41, 51, 146);
            btnPadel.CheckedForeColor = Color.White;
            btnPadel.FlatAppearance.BorderSize = 0;
            btnPadel.FlatStyle = FlatStyle.Flat;
            btnPadel.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            btnPadel.ForeColor = Color.FromArgb(64, 64, 64);
            btnPadel.GroupName = "";
            btnPadel.Location = new Point(131, 23);
            btnPadel.Margin = new Padding(2);
            btnPadel.Name = "btnPadel";
            btnPadel.Radius = 10;
            btnPadel.Size = new Size(90, 43);
            btnPadel.TabIndex = 12;
            btnPadel.Text = "بادل";
            btnPadel.UncheckedBackColor = Color.FromArgb(242, 242, 242);
            btnPadel.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnPadel.UseVisualStyleBackColor = false;
            btnPadel.Click += pillButton5_Click;
            // 
            // btnBasketBall
            // 
            btnBasketBall.BackColor = Color.White;
            btnBasketBall.BackgroundImageLayout = ImageLayout.None;
            btnBasketBall.Checked = false;
            btnBasketBall.CheckedBackColor = Color.FromArgb(41, 51, 146);
            btnBasketBall.CheckedForeColor = Color.White;
            btnBasketBall.FlatAppearance.BorderSize = 0;
            btnBasketBall.FlatStyle = FlatStyle.Flat;
            btnBasketBall.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            btnBasketBall.ForeColor = Color.FromArgb(64, 64, 64);
            btnBasketBall.GroupName = "";
            btnBasketBall.Location = new Point(239, 23);
            btnBasketBall.Margin = new Padding(2);
            btnBasketBall.Name = "btnBasketBall";
            btnBasketBall.Radius = 10;
            btnBasketBall.Size = new Size(90, 43);
            btnBasketBall.TabIndex = 10;
            btnBasketBall.Text = "سلة";
            btnBasketBall.UncheckedBackColor = Color.FromArgb(242, 242, 242);
            btnBasketBall.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnBasketBall.UseVisualStyleBackColor = false;
            btnBasketBall.Click += pillButton3_Click;
            // 
            // btnFootBall
            // 
            btnFootBall.BackColor = Color.White;
            btnFootBall.BackgroundImageLayout = ImageLayout.None;
            btnFootBall.Checked = false;
            btnFootBall.CheckedBackColor = Color.FromArgb(41, 51, 146);
            btnFootBall.CheckedForeColor = Color.White;
            btnFootBall.FlatAppearance.BorderSize = 0;
            btnFootBall.FlatStyle = FlatStyle.Flat;
            btnFootBall.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            btnFootBall.ForeColor = Color.FromArgb(64, 64, 64);
            btnFootBall.GroupName = "";
            btnFootBall.Location = new Point(346, 22);
            btnFootBall.Margin = new Padding(2);
            btnFootBall.Name = "btnFootBall";
            btnFootBall.Radius = 10;
            btnFootBall.Size = new Size(90, 43);
            btnFootBall.TabIndex = 9;
            btnFootBall.Text = "القدم";
            btnFootBall.UncheckedBackColor = Color.FromArgb(242, 242, 242);
            btnFootBall.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnFootBall.UseVisualStyleBackColor = false;
            btnFootBall.Click += pillButton2_Click;
            // 
            // btnAll
            // 
            btnAll.BackColor = Color.White;
            btnAll.BackgroundImageLayout = ImageLayout.None;
            btnAll.Checked = true;
            btnAll.CheckedBackColor = Color.FromArgb(41, 51, 146);
            btnAll.CheckedForeColor = Color.White;
            btnAll.FlatAppearance.BorderSize = 0;
            btnAll.FlatStyle = FlatStyle.Flat;
            btnAll.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            btnAll.ForeColor = Color.FromArgb(64, 64, 64);
            btnAll.GroupName = "";
            btnAll.Location = new Point(452, 22);
            btnAll.Margin = new Padding(2);
            btnAll.Name = "btnAll";
            btnAll.Radius = 10;
            btnAll.Size = new Size(90, 43);
            btnAll.TabIndex = 8;
            btnAll.Text = "الكل ";
            btnAll.UncheckedBackColor = Color.FromArgb(242, 242, 242);
            btnAll.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnAll.UseVisualStyleBackColor = false;
            btnAll.Click += pillButton1_Click;
            // 
            // SchedulingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1043, 683);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SchedulingForm";
            Text = "SchedulingForm";
            Load += SchedulingForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            statusCard1.ResumeLayout(false);
            statusCard1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stadiumGrid1).EndInit();
            panel4.ResumeLayout(false);
            statusCard4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private CustomItems.StadiumGrid stadiumGrid1;
        private CustomItems.StatusCard statusCard4;
        private CustomItems.PillButton btnPadel;
        private CustomItems.PillButton btnBasketBall;
        private CustomItems.PillButton btnFootBall;
        private CustomItems.PillButton btnAll;
        private Label label3;
        private Label label1;
        private CustomItems.StatusCard statusCard1;
        private CustomItems.CustomLabel customLabel4;
        private CustomItems.CustomLabel customLabel3;
        private CustomItems.CustomLabel customLabel2;
        private CustomItems.CustomLabel customLabel1;
        private CustomItems.StatusCard statusCard5;
        private CustomItems.StatusCard statusCard3;
        private CustomItems.StatusCard statusCard2;
        public DateTimePicker dateTimePicker2;
        private CustomItems.IconButton btnForwardDate;
        private CustomItems.IconButton btnBackDate;
    }
}