namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class ManageBooking
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
            panel2 = new Panel();
            panel3 = new Panel();
            dgvBookings = new ActiveSpaceSystem.CustomItems.CustomDataGridView();
            customPanel1 = new ActiveSpaceSystem.CustomItems.CustomPanel();
            btnForwardDate = new ActiveSpaceSystem.CustomItems.IconButton();
            btnBackDate = new ActiveSpaceSystem.CustomItems.IconButton();
            dtpManageBooking = new DateTimePicker();
            txtsearch = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            customPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(248, 249, 250);
            panel1.Controls.Add(roundedButton1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 131);
            panel1.TabIndex = 1;
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = AnchorStyles.Left;
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
            roundedButton1.Location = new Point(24, 37);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new Padding(20, 10, 20, 10);
            roundedButton1.Size = new Size(234, 67);
            roundedButton1.TabIndex = 7;
            roundedButton1.Text = "إضافة حجز جديد";
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
            label3.Location = new Point(768, 80);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(208, 23);
            label3.TabIndex = 6;
            label3.Text = "إدارة ومتابعة جميع الحجوزات";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(755, 29);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(231, 49);
            label1.TabIndex = 0;
            label1.Text = "إدارة الحجوزات";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(248, 249, 250);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(customPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 131);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1022, 586);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvBookings);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 112);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1022, 474);
            panel3.TabIndex = 9;
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToResizeRows = false;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvBookings.BackgroundColor = Color.White;
            dgvBookings.BorderRadius = 15;
            dgvBookings.BorderStyle = BorderStyle.None;
            dgvBookings.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvBookings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookings.ColumnHeadersHeight = 50;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBookings.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBookings.Dock = DockStyle.Fill;
            dgvBookings.EnableHeadersVisualStyles = false;
            dgvBookings.GridColor = Color.White;
            dgvBookings.HeaderBackColor = Color.FromArgb(243, 244, 246);
            dgvBookings.HeaderForeColor = Color.FromArgb(33, 37, 41);
            dgvBookings.Location = new Point(0, 0);
            dgvBookings.MultiSelect = false;
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.RightToLeft = RightToLeft.Yes;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.RowHeadersWidth = 51;
            dgvBookings.RowHeight = 50;
            dgvBookings.RowTemplate.Height = 50;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(1022, 474);
            dgvBookings.TabIndex = 8;
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderColor = Color.FromArgb(230, 230, 230);
            customPanel1.BorderRadius = 20;
            customPanel1.BorderSize = 1F;
            customPanel1.Controls.Add(btnForwardDate);
            customPanel1.Controls.Add(btnBackDate);
            customPanel1.Controls.Add(dtpManageBooking);
            customPanel1.Controls.Add(txtsearch);
            customPanel1.Dock = DockStyle.Top;
            customPanel1.Location = new Point(0, 0);
            customPanel1.Name = "customPanel1";
            customPanel1.ShowShadow = true;
            customPanel1.Size = new Size(1022, 112);
            customPanel1.TabIndex = 8;
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
            btnForwardDate.Location = new Point(24, 41);
            btnForwardDate.Name = "btnForwardDate";
            btnForwardDate.Size = new Size(40, 33);
            btnForwardDate.TabIndex = 19;
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
            btnBackDate.Location = new Point(321, 41);
            btnBackDate.Name = "btnBackDate";
            btnBackDate.Size = new Size(40, 33);
            btnBackDate.TabIndex = 18;
            btnBackDate.UseVisualStyleBackColor = false;
            btnBackDate.Click += btnBackDate_Click;
            // 
            // dtpManageBooking
            // 
            dtpManageBooking.CustomFormat = "yyyy / MM / dd";
            dtpManageBooking.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpManageBooking.Format = DateTimePickerFormat.Custom;
            dtpManageBooking.Location = new Point(74, 41);
            dtpManageBooking.Margin = new Padding(2);
            dtpManageBooking.Name = "dtpManageBooking";
            dtpManageBooking.RightToLeft = RightToLeft.Yes;
            dtpManageBooking.RightToLeftLayout = true;
            dtpManageBooking.Size = new Size(237, 31);
            dtpManageBooking.TabIndex = 17;
            dtpManageBooking.ValueChanged += dtpManageBooking_ValueChanged;
            // 
            // txtsearch
            // 
            txtsearch.Anchor = AnchorStyles.Right;
            txtsearch.BackColor = Color.White;
            txtsearch.BorderColor = Color.FromArgb(29, 53, 87);
            txtsearch.BorderRadius = 15;
            txtsearch.Icon = Properties.Resources.magnifying_glass;
            txtsearch.IconLocation = HorizontalAlignment.Right;
            txtsearch.IconSize = 32;
            txtsearch.Location = new Point(547, 30);
            txtsearch.Name = "txtsearch";
            txtsearch.passwordChar = "\0";
            txtsearch.PlaceholderText = "بحث عن رقم الهاتف";
            txtsearch.RightToLeft = RightToLeft.Yes;
            txtsearch.Size = new Size(446, 52);
            txtsearch.TabIndex = 0;
            txtsearch.Texts = "";
            txtsearch._TextChanged += txtsearch_TextChanged;
            // 
            // ManageBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1022, 717);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Tajawal", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "ManageBooking";
            Text = "ManageBooking";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            customPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label1;
        private Panel panel2;
        private CustomItems.CustomPanel customPanel1;
        private CustomItems.AbdulTextBox txtsearch;
        private CustomItems.RoundedButton roundedButton1;
        private Panel panel3;
        private CustomItems.CustomDataGridView dgvBookings;
        private CustomItems.IconButton btnForwardDate;
        private CustomItems.IconButton btnBackDate;
        public DateTimePicker dtpManageBooking;
    }
}