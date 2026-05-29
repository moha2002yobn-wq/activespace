namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class PaymentForm
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
            btnForwardDate = new ActiveSpaceSystem.CustomItems.IconButton();
            btnBackDate = new ActiveSpaceSystem.CustomItems.IconButton();
            dtpPaymentDate = new DateTimePicker();
            label3 = new Label();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            DownPaymentCard = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            TotalDebtsCard = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            DailyIncomeCard = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            tableLayoutPanel2 = new TableLayoutPanel();
            dgvReservation = new ActiveSpaceSystem.CustomItems.CustomDataGridView();
            bookingDetailsCard = new ActiveSpaceSystem.CustomItems.BookingDetailsCard();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservation).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(btnForwardDate);
            panel1.Controls.Add(btnBackDate);
            panel1.Controls.Add(dtpPaymentDate);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1064, 101);
            panel1.TabIndex = 13;
            // 
            // btnForwardDate
            // 
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
            btnForwardDate.Location = new Point(70, 40);
            btnForwardDate.Name = "btnForwardDate";
            btnForwardDate.Size = new Size(40, 31);
            btnForwardDate.TabIndex = 16;
            btnForwardDate.UseVisualStyleBackColor = false;
            btnForwardDate.Click += btnForwardDate_Click;
            // 
            // btnBackDate
            // 
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
            btnBackDate.Location = new Point(367, 40);
            btnBackDate.Name = "btnBackDate";
            btnBackDate.Size = new Size(40, 31);
            btnBackDate.TabIndex = 15;
            btnBackDate.UseVisualStyleBackColor = false;
            btnBackDate.Click += btnBackDate_Click;
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.CustomFormat = "yyyy / MM / dd";
            dtpPaymentDate.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpPaymentDate.Format = DateTimePickerFormat.Custom;
            dtpPaymentDate.Location = new Point(120, 40);
            dtpPaymentDate.Margin = new Padding(2);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.RightToLeft = RightToLeft.Yes;
            dtpPaymentDate.RightToLeftLayout = true;
            dtpPaymentDate.Size = new Size(237, 31);
            dtpPaymentDate.TabIndex = 14;
            dtpPaymentDate.ValueChanged += dtpPaymentDate_ValueChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(818, 48);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(234, 23);
            label3.TabIndex = 9;
            label3.Text = "إدارة ومتابعة المدفوعات والديون";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal Medium", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(703, 0);
            label1.Name = "label1";
            label1.Size = new Size(358, 48);
            label1.TabIndex = 8;
            label1.Text = "المدفوعات والحسابات";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(DownPaymentCard, 2, 0);
            tableLayoutPanel1.Controls.Add(TotalDebtsCard, 1, 0);
            tableLayoutPanel1.Controls.Add(DailyIncomeCard, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 101);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1064, 127);
            tableLayoutPanel1.TabIndex = 16;
            // 
            // DownPaymentCard
            // 
            DownPaymentCard.BackColor = Color.White;
            DownPaymentCard.BorderRadius = 20;
            DownPaymentCard.CardIcon = Properties.Resources.icons8_bank_approved_48;
            DownPaymentCard.Dock = DockStyle.Fill;
            DownPaymentCard.IconBackColor = Color.FromArgb(43, 127, 255);
            DownPaymentCard.Location = new Point(3, 3);
            DownPaymentCard.Name = "DownPaymentCard";
            DownPaymentCard.Padding = new Padding(10);
            DownPaymentCard.ShadowSize = 1;
            DownPaymentCard.Size = new Size(350, 121);
            DownPaymentCard.SubValueColor = Color.Gray;
            DownPaymentCard.SubValueFont = new Font("Tajawal", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DownPaymentCard.SubValueText = "اليوم";
            DownPaymentCard.TabIndex = 18;
            DownPaymentCard.TitleColor = Color.Gray;
            DownPaymentCard.TitleFont = new Font("Tajawal Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DownPaymentCard.TitleText = "إجمالي الدفعات المقدمة";
            DownPaymentCard.ValueColor = Color.FromArgb(43, 127, 255);
            DownPaymentCard.ValueFont = new Font("Tajawal", 16.1999989F, FontStyle.Bold);
            DownPaymentCard.ValueText = "5,650 د.ل";
            // 
            // TotalDebtsCard
            // 
            TotalDebtsCard.BackColor = Color.White;
            TotalDebtsCard.BorderRadius = 20;
            TotalDebtsCard.CardIcon = Properties.Resources.icons8_alert_50__1_;
            TotalDebtsCard.Dock = DockStyle.Fill;
            TotalDebtsCard.IconBackColor = Color.FromArgb(220, 38, 38);
            TotalDebtsCard.Location = new Point(359, 3);
            TotalDebtsCard.Name = "TotalDebtsCard";
            TotalDebtsCard.Padding = new Padding(10);
            TotalDebtsCard.ShadowSize = 1;
            TotalDebtsCard.Size = new Size(348, 121);
            TotalDebtsCard.SubValueColor = Color.Gray;
            TotalDebtsCard.SubValueFont = new Font("Tajawal", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotalDebtsCard.SubValueText = "15 حجز";
            TotalDebtsCard.TabIndex = 15;
            TotalDebtsCard.TitleColor = Color.Gray;
            TotalDebtsCard.TitleFont = new Font("Tajawal Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalDebtsCard.TitleText = "إجمالي الديون";
            TotalDebtsCard.ValueColor = Color.FromArgb(220, 38, 38);
            TotalDebtsCard.ValueFont = new Font("Tajawal", 16.1999989F, FontStyle.Bold);
            TotalDebtsCard.ValueText = "3,290 د.ل";
            // 
            // DailyIncomeCard
            // 
            DailyIncomeCard.BackColor = Color.White;
            DailyIncomeCard.BorderRadius = 20;
            DailyIncomeCard.CardIcon = Properties.Resources.icons8_money_50__1___2_;
            DailyIncomeCard.Dock = DockStyle.Fill;
            DailyIncomeCard.IconBackColor = Color.FromArgb(46, 204, 113);
            DailyIncomeCard.Location = new Point(713, 3);
            DailyIncomeCard.Name = "DailyIncomeCard";
            DailyIncomeCard.Padding = new Padding(10);
            DailyIncomeCard.ShadowSize = 1;
            DailyIncomeCard.Size = new Size(348, 121);
            DailyIncomeCard.SubValueColor = Color.FromArgb(46, 204, 113);
            DailyIncomeCard.SubValueFont = new Font("Tajawal", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DailyIncomeCard.SubValueText = "+12% منذ الأمس";
            DailyIncomeCard.TabIndex = 16;
            DailyIncomeCard.TitleColor = Color.Gray;
            DailyIncomeCard.TitleFont = new Font("Tajawal Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DailyIncomeCard.TitleText = "إجمالي الإيرادات";
            DailyIncomeCard.ValueColor = Color.FromArgb(46, 204, 113);
            DailyIncomeCard.ValueFont = new Font("Tajawal", 16.1999989F, FontStyle.Bold);
            DailyIncomeCard.ValueText = "12,450 د.ل";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(dgvReservation, 0, 0);
            tableLayoutPanel2.Controls.Add(bookingDetailsCard, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 228);
            tableLayoutPanel2.Margin = new Padding(2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1064, 473);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // dgvReservation
            // 
            dgvReservation.AllowUserToAddRows = false;
            dgvReservation.AllowUserToResizeRows = false;
            dgvReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservation.BackgroundColor = Color.White;
            dgvReservation.BorderRadius = 15;
            dgvReservation.BorderStyle = BorderStyle.None;
            dgvReservation.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReservation.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReservation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReservation.ColumnHeadersHeight = 50;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Tajawal", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvReservation.DefaultCellStyle = dataGridViewCellStyle2;
            dgvReservation.Dock = DockStyle.Fill;
            dgvReservation.EnableHeadersVisualStyles = false;
            dgvReservation.GridColor = Color.FromArgb(230, 230, 230);
            dgvReservation.HeaderBackColor = Color.FromArgb(243, 244, 246);
            dgvReservation.HeaderForeColor = Color.FromArgb(33, 37, 41);
            dgvReservation.Location = new Point(323, 3);
            dgvReservation.MultiSelect = false;
            dgvReservation.Name = "dgvReservation";
            dgvReservation.RightToLeft = RightToLeft.Yes;
            dgvReservation.RowHeadersVisible = false;
            dgvReservation.RowHeadersWidth = 51;
            dgvReservation.RowHeight = 50;
            dgvReservation.RowTemplate.Height = 50;
            dgvReservation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservation.Size = new Size(738, 467);
            dgvReservation.TabIndex = 25;
            dgvReservation.CellPainting += dgvReservation_CellPainting;
            // 
            // bookingDetailsCard
            // 
            bookingDetailsCard.BackColor = Color.White;
            bookingDetailsCard.BookingID = "B-2026-001";
            bookingDetailsCard.ButtonBorderRadius = 12;
            bookingDetailsCard.CardBorderRadius = 20;
            bookingDetailsCard.CustomerName = "أحمد محمد علي";
            bookingDetailsCard.DataFont = new Font("Tajawal Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bookingDetailsCard.DepositAmount = "100 د.ل";
            bookingDetailsCard.Dock = DockStyle.Fill;
            bookingDetailsCard.IsItemSelected = false;
            bookingDetailsCard.LabelsFont = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bookingDetailsCard.Location = new Point(3, 3);
            bookingDetailsCard.Name = "bookingDetailsCard";
            bookingDetailsCard.PaidAmount = "100 د.ل";
            bookingDetailsCard.PhoneNumber = "0501234567";
            bookingDetailsCard.PrimaryColor = Color.FromArgb(46, 204, 113);
            bookingDetailsCard.RemainingAmount = "200 د.ل";
            bookingDetailsCard.RemainingColor = Color.Red;
            bookingDetailsCard.Size = new Size(314, 467);
            bookingDetailsCard.TabIndex = 23;
            bookingDetailsCard.TotalAmount = "300 د.ل";
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1064, 701);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PaymentForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "PaymentForm";
            Load += PaymentForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReservation).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label3;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private CustomItems.AdvancedStatusCard DailyIncomeCard;
        private CustomItems.AdvancedStatusCard TotalDebtsCard;
        private TableLayoutPanel tableLayoutPanel2;
        private CustomItems.BookingDetailsCard bookingDetailsCard;
        private CustomItems.AdvancedStatusCard DownPaymentCard;
        private CustomItems.CustomDataGridView dgvReservation;
        public DateTimePicker dtpPaymentDate;
        private CustomItems.IconButton btnForwardDate;
        private CustomItems.IconButton btnBackDate;
    }
}