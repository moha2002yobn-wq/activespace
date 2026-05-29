namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class MonthlyContractForm
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
            roundedButton1 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            label3 = new Label();
            label1 = new Label();
            infoBox1 = new ActiveSpaceSystem.CustomItems.InfoBox();
            statusCardCont = new ActiveSpaceSystem.CustomItems.StatusCard();
            statusCardTotal = new ActiveSpaceSystem.CustomItems.StatusCard();
            statusCardEXP = new ActiveSpaceSystem.CustomItems.StatusCard();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            dgvMonthlyContract = new ActiveSpaceSystem.CustomItems.CustomDataGridView();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonthlyContract).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedButton1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 125);
            panel1.TabIndex = 0;
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
            roundedButton1.Location = new Point(50, 33);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new Padding(20, 10, 20, 10);
            roundedButton1.Size = new Size(232, 64);
            roundedButton1.TabIndex = 8;
            roundedButton1.Text = "إضافة عقد جديد";
            roundedButton1.TextAlign = ContentAlignment.MiddleLeft;
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(729, 74);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(275, 23);
            label3.TabIndex = 6;
            label3.Text = "إدارة الحجوزات المتكررة والعقود الدورية";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(754, 26);
            label1.Name = "label1";
            label1.Size = new Size(250, 49);
            label1.TabIndex = 0;
            label1.Text = "العقود الشهرية";
            // 
            // infoBox1
            // 
            infoBox1.BackColor = Color.Transparent;
            infoBox1.BorderColor = Color.FromArgb(180, 210, 255);
            infoBox1.BorderRadius = 15;
            infoBox1.Description = "العقود الشهرية تتيح حجز موعد ثابت أسبوعياً لفترة محددة. مثلاً: حجز ملعب كرة القدم كل يوم سبت الساعة 6 مساءً لمدة 3 أشهر";
            infoBox1.DescriptionColor = Color.FromArgb(69, 123, 157);
            infoBox1.DescriptionFont = new Font("Tajawal", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            infoBox1.Dock = DockStyle.Top;
            infoBox1.FillColor = Color.FromArgb(240, 248, 255);
            infoBox1.Icon = null;
            infoBox1.IconSize = 25;
            infoBox1.Location = new Point(0, 125);
            infoBox1.Name = "infoBox1";
            infoBox1.Size = new Size(1022, 97);
            infoBox1.TabIndex = 1;
            infoBox1.Title = "ما هي العقود الشهرية؟";
            infoBox1.TitleColor = Color.FromArgb(29, 53, 87);
            infoBox1.TitleFont = new Font("Tajawal", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            // 
            // statusCardCont
            // 
            statusCardCont.BackColor = Color.Transparent;
            statusCardCont.BorderColor = Color.FromArgb(240, 240, 240);
            statusCardCont.BorderRadius = 15;
            statusCardCont.CardBackColor = Color.White;
            statusCardCont.Dock = DockStyle.Fill;
            statusCardCont.Location = new Point(3, 3);
            statusCardCont.Name = "statusCardCont";
            statusCardCont.Padding = new Padding(5);
            statusCardCont.ShadowBlur = 5;
            statusCardCont.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            statusCardCont.ShowShadow = true;
            statusCardCont.Size = new Size(334, 114);
            statusCardCont.TabIndex = 2;
            statusCardCont.TitleColor = Color.Gray;
            statusCardCont.TitleFont = new Font("Tajawal", 10.2F);
            statusCardCont.TitleText = "العقود النشطة";
            statusCardCont.ValueColor = Color.FromArgb(46, 204, 113);
            statusCardCont.ValueFont = new Font("Tajawal", 18F, FontStyle.Bold);
            statusCardCont.ValueText = "18";
            // 
            // statusCardTotal
            // 
            statusCardTotal.BackColor = Color.Transparent;
            statusCardTotal.BorderColor = Color.FromArgb(240, 240, 240);
            statusCardTotal.BorderRadius = 15;
            statusCardTotal.CardBackColor = Color.White;
            statusCardTotal.Dock = DockStyle.Fill;
            statusCardTotal.Location = new Point(343, 3);
            statusCardTotal.Name = "statusCardTotal";
            statusCardTotal.Padding = new Padding(5);
            statusCardTotal.ShadowBlur = 5;
            statusCardTotal.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            statusCardTotal.ShowShadow = true;
            statusCardTotal.Size = new Size(334, 114);
            statusCardTotal.TabIndex = 3;
            statusCardTotal.TitleColor = Color.Gray;
            statusCardTotal.TitleFont = new Font("Tajawal", 10.2F);
            statusCardTotal.TitleText = "الإيرادات الشهرية المتوقعة";
            statusCardTotal.ValueColor = Color.FromArgb(30, 58, 138);
            statusCardTotal.ValueFont = new Font("Tajawal", 18F, FontStyle.Bold);
            statusCardTotal.ValueText = "15,200 د.ل";
            // 
            // statusCardEXP
            // 
            statusCardEXP.BackColor = Color.Transparent;
            statusCardEXP.BorderColor = Color.FromArgb(240, 240, 240);
            statusCardEXP.BorderRadius = 15;
            statusCardEXP.CardBackColor = Color.White;
            statusCardEXP.Dock = DockStyle.Fill;
            statusCardEXP.Location = new Point(683, 3);
            statusCardEXP.Name = "statusCardEXP";
            statusCardEXP.Padding = new Padding(5);
            statusCardEXP.ShadowBlur = 5;
            statusCardEXP.ShadowColor = Color.FromArgb(100, 0, 0, 0);
            statusCardEXP.ShowShadow = true;
            statusCardEXP.Size = new Size(336, 114);
            statusCardEXP.TabIndex = 4;
            statusCardEXP.TitleColor = Color.Gray;
            statusCardEXP.TitleFont = new Font("Tajawal", 10.2F);
            statusCardEXP.TitleText = "عقود تنتهي هذا الشهر";
            statusCardEXP.ValueColor = Color.FromArgb(245, 158, 11);
            statusCardEXP.ValueFont = new Font("Tajawal", 18F, FontStyle.Bold);
            statusCardEXP.ValueText = "3";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(statusCardEXP, 2, 0);
            tableLayoutPanel1.Controls.Add(statusCardTotal, 1, 0);
            tableLayoutPanel1.Controls.Add(statusCardCont, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 222);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1022, 120);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvMonthlyContract);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 342);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1022, 341);
            panel2.TabIndex = 7;
            // 
            // dgvMonthlyContract
            // 
            dgvMonthlyContract.AllowUserToAddRows = false;
            dgvMonthlyContract.AllowUserToResizeRows = false;
            dgvMonthlyContract.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonthlyContract.BackgroundColor = Color.White;
            dgvMonthlyContract.BorderRadius = 15;
            dgvMonthlyContract.BorderStyle = BorderStyle.None;
            dgvMonthlyContract.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMonthlyContract.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMonthlyContract.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMonthlyContract.ColumnHeadersHeight = 50;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMonthlyContract.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMonthlyContract.Dock = DockStyle.Fill;
            dgvMonthlyContract.EnableHeadersVisualStyles = false;
            dgvMonthlyContract.GridColor = Color.FromArgb(230, 230, 230);
            dgvMonthlyContract.HeaderBackColor = Color.FromArgb(243, 244, 246);
            dgvMonthlyContract.HeaderForeColor = Color.FromArgb(33, 37, 41);
            dgvMonthlyContract.Location = new Point(0, 0);
            dgvMonthlyContract.MultiSelect = false;
            dgvMonthlyContract.Name = "dgvMonthlyContract";
            dgvMonthlyContract.RightToLeft = RightToLeft.Yes;
            dgvMonthlyContract.RowHeadersVisible = false;
            dgvMonthlyContract.RowHeadersWidth = 51;
            dgvMonthlyContract.RowHeight = 50;
            dgvMonthlyContract.RowTemplate.Height = 50;
            dgvMonthlyContract.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonthlyContract.Size = new Size(1022, 341);
            dgvMonthlyContract.TabIndex = 6;
            // 
            // MonthlyContractForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1022, 683);
            Controls.Add(panel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(infoBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MonthlyContractForm";
            Text = "MonthlyContractForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMonthlyContract).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label3;
        private CustomItems.InfoBox infoBox1;
        private CustomItems.StatusCard statusCardCont;
        private CustomItems.StatusCard statusCardTotal;
        private CustomItems.StatusCard statusCardEXP;
        private CustomItems.RoundedButton roundedButton1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private CustomItems.CustomDataGridView dgvMonthlyContract;
    }
}