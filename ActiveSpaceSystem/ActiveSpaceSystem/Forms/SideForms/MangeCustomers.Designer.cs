namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class MangeCustomers
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
            customerCard2 = new ActiveSpaceSystem.CustomItems.CustomerCard();
            customerCard1 = new ActiveSpaceSystem.CustomItems.CustomerCard();
            customerCard3 = new ActiveSpaceSystem.CustomItems.CustomerCard();
            panel1 = new Panel();
            roundedButton1 = new ActiveSpaceSystem.CustomItems.RoundedButton();
            label3 = new Label();
            label1 = new Label();
            btnDebtFilter = new ActiveSpaceSystem.CustomItems.CustomActionButton();
            btnAll = new ActiveSpaceSystem.CustomItems.CustomActionButton();
            txtSearch = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            customPanel1 = new ActiveSpaceSystem.CustomItems.CustomPanel();
            panel2 = new Panel();
            dgvCustomers = new ActiveSpaceSystem.CustomItems.CustomDataGridView();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            customPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // customerCard2
            // 
            customerCard2.BackColor = Color.White;
            customerCard2.BorderRadius = 15;
            customerCard2.Dock = DockStyle.Fill;
            customerCard2.IconBackColor = Color.FromArgb(235, 239, 253);
            customerCard2.IconImage = Properties.Resources.icons8_users_48__1_;
            customerCard2.IconSize = 32;
            customerCard2.Location = new Point(683, 3);
            customerCard2.Name = "customerCard2";
            customerCard2.Size = new Size(336, 128);
            customerCard2.TabIndex = 1;
            customerCard2.TitleColor = Color.Gray;
            customerCard2.TitleFont = new Font("Tajawal", 12F);
            customerCard2.TitleText = "إجمالي العملاء";
            customerCard2.ValueColor = Color.MidnightBlue;
            customerCard2.ValueFont = new Font("Segoe UI", 18F, FontStyle.Bold);
            customerCard2.ValueText = "156";
            // 
            // customerCard1
            // 
            customerCard1.BackColor = Color.White;
            customerCard1.BorderRadius = 15;
            customerCard1.Dock = DockStyle.Fill;
            customerCard1.IconBackColor = Color.FromArgb(231, 248, 242);
            customerCard1.IconImage = Properties.Resources.icons8_users_48;
            customerCard1.IconSize = 32;
            customerCard1.Location = new Point(343, 3);
            customerCard1.Name = "customerCard1";
            customerCard1.Size = new Size(334, 128);
            customerCard1.TabIndex = 2;
            customerCard1.TitleColor = Color.Gray;
            customerCard1.TitleFont = new Font("Tajawal", 12F);
            customerCard1.TitleText = "العملاء النشطون";
            customerCard1.ValueColor = Color.FromArgb(100, 185, 129);
            customerCard1.ValueFont = new Font("Segoe UI", 18F, FontStyle.Bold);
            customerCard1.ValueText = "120";
            // 
            // customerCard3
            // 
            customerCard3.BackColor = Color.White;
            customerCard3.BorderRadius = 15;
            customerCard3.Dock = DockStyle.Fill;
            customerCard3.IconBackColor = Color.FromArgb(251, 233, 233);
            customerCard3.IconImage = Properties.Resources.icons8_alert_50;
            customerCard3.IconSize = 32;
            customerCard3.Location = new Point(3, 3);
            customerCard3.Name = "customerCard3";
            customerCard3.Size = new Size(334, 128);
            customerCard3.TabIndex = 3;
            customerCard3.TitleColor = Color.Gray;
            customerCard3.TitleFont = new Font("Tajawal", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customerCard3.TitleText = "إجمالي الديون";
            customerCard3.ValueColor = Color.FromArgb(220, 38, 38);
            customerCard3.ValueFont = new Font("Segoe UI", 18F, FontStyle.Bold);
            customerCard3.ValueText = "156";
            // 
            // panel1
            // 
            panel1.Controls.Add(roundedButton1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1022, 134);
            panel1.TabIndex = 4;
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
            roundedButton1.Location = new Point(35, 44);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new Padding(20, 10, 20, 10);
            roundedButton1.Size = new Size(246, 64);
            roundedButton1.TabIndex = 10;
            roundedButton1.Text = "إضافة عميل جديد";
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
            label3.Location = new Point(763, 79);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(223, 23);
            label3.TabIndex = 9;
            label3.Text = "متابعة بيانات وحجوزات العملاء";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Tajawal", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MidnightBlue;
            label1.Location = new Point(792, 28);
            label1.Name = "label1";
            label1.Size = new Size(204, 49);
            label1.TabIndex = 8;
            label1.Text = "إدارة العملاء";
            // 
            // btnDebtFilter
            // 
            btnDebtFilter.BackColor = Color.White;
            btnDebtFilter.BorderColor = Color.FromArgb(225, 225, 225);
            btnDebtFilter.BorderRadius = 10;
            btnDebtFilter.BorderSize = 1;
            btnDebtFilter.ButtonIcon = null;
            btnDebtFilter.FlatAppearance.BorderSize = 0;
            btnDebtFilter.FlatStyle = FlatStyle.Flat;
            btnDebtFilter.Font = new Font("Tajawal", 12F);
            btnDebtFilter.ForeColor = Color.FromArgb(220, 38, 38);
            btnDebtFilter.IconAlignment = ContentAlignment.MiddleLeft;
            btnDebtFilter.IconSize = new Size(16, 16);
            btnDebtFilter.IsToggled = false;
            btnDebtFilter.Location = new Point(14, 30);
            btnDebtFilter.Name = "btnDebtFilter";
            btnDebtFilter.Size = new Size(143, 46);
            btnDebtFilter.TabIndex = 9;
            btnDebtFilter.Text = "عليه ديون";
            btnDebtFilter.ToggleColor = Color.FromArgb(245, 245, 245);
            btnDebtFilter.UseVisualStyleBackColor = false;
            btnDebtFilter.Click += btnDebtFilter_Click;
            // 
            // btnAll
            // 
            btnAll.BackColor = Color.White;
            btnAll.BorderColor = Color.FromArgb(225, 225, 225);
            btnAll.BorderRadius = 10;
            btnAll.BorderSize = 1;
            btnAll.ButtonIcon = null;
            btnAll.FlatAppearance.BorderSize = 0;
            btnAll.FlatStyle = FlatStyle.Flat;
            btnAll.Font = new Font("Tajawal", 12F);
            btnAll.IconAlignment = ContentAlignment.MiddleLeft;
            btnAll.IconSize = new Size(16, 16);
            btnAll.IsToggled = false;
            btnAll.Location = new Point(163, 30);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(118, 46);
            btnAll.TabIndex = 4;
            btnAll.Text = "الكل";
            btnAll.ToggleColor = Color.FromArgb(245, 245, 245);
            btnAll.UseVisualStyleBackColor = false;
            btnAll.Click += btnAll_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Right;
            txtSearch.BackColor = Color.White;
            txtSearch.BorderColor = Color.FromArgb(29, 53, 87);
            txtSearch.BorderRadius = 15;
            txtSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Icon = Properties.Resources.magnifying_glass;
            txtSearch.IconLocation = HorizontalAlignment.Right;
            txtSearch.IconSize = 30;
            txtSearch.Location = new Point(344, 30);
            txtSearch.Margin = new Padding(2);
            txtSearch.Name = "txtSearch";
            txtSearch.passwordChar = "\0";
            txtSearch.PlaceholderText = "بحث عن رقم هاتف";
            txtSearch.RightToLeft = RightToLeft.Yes;
            txtSearch.Size = new Size(642, 46);
            txtSearch.TabIndex = 3;
            txtSearch.Texts = "";
            txtSearch._TextChanged += txtSearch__TextChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(customerCard2, 2, 0);
            tableLayoutPanel1.Controls.Add(customerCard1, 1, 0);
            tableLayoutPanel1.Controls.Add(customerCard3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 134);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1022, 134);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.White;
            customPanel1.BorderColor = Color.FromArgb(230, 230, 230);
            customPanel1.BorderRadius = 20;
            customPanel1.BorderSize = 1F;
            customPanel1.Controls.Add(btnDebtFilter);
            customPanel1.Controls.Add(txtSearch);
            customPanel1.Controls.Add(btnAll);
            customPanel1.Dock = DockStyle.Top;
            customPanel1.Location = new Point(0, 268);
            customPanel1.Margin = new Padding(2);
            customPanel1.Name = "customPanel1";
            customPanel1.ShowShadow = true;
            customPanel1.Size = new Size(1022, 120);
            customPanel1.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvCustomers);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 388);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1022, 295);
            panel2.TabIndex = 11;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToResizeRows = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderRadius = 15;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvCustomers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCustomers.ColumnHeadersHeight = 50;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCustomers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.EnableHeadersVisualStyles = false;
            dgvCustomers.GridColor = Color.White;
            dgvCustomers.HeaderBackColor = Color.FromArgb(243, 244, 246);
            dgvCustomers.HeaderForeColor = Color.FromArgb(33, 37, 41);
            dgvCustomers.Location = new Point(0, 0);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RightToLeft = RightToLeft.Yes;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.RowHeight = 50;
            dgvCustomers.RowTemplate.Height = 50;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(1022, 295);
            dgvCustomers.TabIndex = 9;
            // 
            // MangeCustomers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1022, 683);
            Controls.Add(panel2);
            Controls.Add(customPanel1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MangeCustomers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MangeCustomers";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            customPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        
        private CustomItems.CustomerCard customerCard2;
        private CustomItems.CustomerCard customerCard1;
        private CustomItems.CustomerCard customerCard3;
        private Panel panel1;
        private Label label3;
        private Label label1;
        private CustomItems.AbdulTextBox txtSearch;
        private CustomItems.CustomActionButton btnDebtFilter;
        private CustomItems.CustomActionButton btnAll;
        private CustomItems.RoundedButton roundedButton1;
        private TableLayoutPanel tableLayoutPanel1;
        private CustomItems.CustomPanel customPanel1;
        private CustomItems.CustomDataGridView dgvCustomers;
    }
}