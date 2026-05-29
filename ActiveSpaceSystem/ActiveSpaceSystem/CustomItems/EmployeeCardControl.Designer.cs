namespace ActiveSpaceSystem.CustomItems
{
    partial class EmployeeCardControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cardPanel = new CustomPanel();
            lblSalaryTitle = new System.Windows.Forms.Label();
            lblSalaryValue = new System.Windows.Forms.Label();
            panelAvatar = new CustomPanel();
            lblAvatar = new System.Windows.Forms.Label();
            lblEmployeeName = new System.Windows.Forms.Label();
            lblPosition = new System.Windows.Forms.Label();
            lblStartDate = new System.Windows.Forms.Label();
            btnPaySalary = new RoundedButton();
            btnEdit = new RoundedButton();
            cardPanel.SuspendLayout();
            panelAvatar.SuspendLayout();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.BackColor = System.Drawing.Color.White;
            cardPanel.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            cardPanel.BorderRadius = 14;
            cardPanel.BorderSize = 1F;
            cardPanel.Controls.Add(lblSalaryTitle);
            cardPanel.Controls.Add(lblSalaryValue);
            cardPanel.Controls.Add(panelAvatar);
            cardPanel.Controls.Add(lblEmployeeName);
            cardPanel.Controls.Add(lblPosition);
            cardPanel.Controls.Add(lblStartDate);
            cardPanel.Controls.Add(btnPaySalary);
            cardPanel.Controls.Add(btnEdit);
            cardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            cardPanel.Location = new System.Drawing.Point(0, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.ShowShadow = false;
            cardPanel.Size = new System.Drawing.Size(480, 135);
            cardPanel.TabIndex = 0;
            // 
            // lblSalaryTitle
            // 
            lblSalaryTitle.BackColor = System.Drawing.Color.Transparent;
            lblSalaryTitle.Font = new System.Drawing.Font("Tajawal", 9F);
            lblSalaryTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            lblSalaryTitle.Location = new System.Drawing.Point(15, 16);
            lblSalaryTitle.Name = "lblSalaryTitle";
            lblSalaryTitle.Size = new System.Drawing.Size(120, 20);
            lblSalaryTitle.TabIndex = 0;
            lblSalaryTitle.Text = "الراتب الشهري";
            lblSalaryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSalaryValue
            // 
            lblSalaryValue.BackColor = System.Drawing.Color.Transparent;
            lblSalaryValue.Font = new System.Drawing.Font("Tajawal", 13.5F, System.Drawing.FontStyle.Bold);
            lblSalaryValue.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            lblSalaryValue.Location = new System.Drawing.Point(15, 38);
            lblSalaryValue.Name = "lblSalaryValue";
            lblSalaryValue.Size = new System.Drawing.Size(140, 28);
            lblSalaryValue.TabIndex = 1;
            lblSalaryValue.Text = "0 د.ل";
            lblSalaryValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAvatar
            // 
            panelAvatar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            panelAvatar.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            panelAvatar.BorderColor = System.Drawing.Color.FromArgb(30, 58, 138);
            panelAvatar.BorderRadius = 22;
            panelAvatar.BorderSize = 0F;
            panelAvatar.Controls.Add(lblAvatar);
            panelAvatar.Location = new System.Drawing.Point(415, 16);
            panelAvatar.Name = "panelAvatar";
            panelAvatar.ShowShadow = false;
            panelAvatar.Size = new System.Drawing.Size(45, 45);
            panelAvatar.TabIndex = 2;
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = System.Drawing.Color.Transparent;
            lblAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            lblAvatar.Font = new System.Drawing.Font("Tajawal", 13F, System.Drawing.FontStyle.Bold);
            lblAvatar.ForeColor = System.Drawing.Color.White;
            lblAvatar.Location = new System.Drawing.Point(0, 0);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new System.Drawing.Size(45, 45);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "أ";
            lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblEmployeeName.BackColor = System.Drawing.Color.Transparent;
            lblEmployeeName.Font = new System.Drawing.Font("Tajawal", 11.5F, System.Drawing.FontStyle.Bold);
            lblEmployeeName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblEmployeeName.Location = new System.Drawing.Point(165, 14);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new System.Drawing.Size(244, 25);
            lblEmployeeName.TabIndex = 3;
            lblEmployeeName.Text = "اسم الموظف";
            lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPosition
            // 
            lblPosition.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblPosition.BackColor = System.Drawing.Color.Transparent;
            lblPosition.Font = new System.Drawing.Font("Tajawal", 9F);
            lblPosition.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblPosition.Location = new System.Drawing.Point(165, 39);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new System.Drawing.Size(244, 20);
            lblPosition.TabIndex = 4;
            lblPosition.Text = "مدير";
            lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStartDate
            // 
            lblStartDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblStartDate.BackColor = System.Drawing.Color.Transparent;
            lblStartDate.Font = new System.Drawing.Font("Tajawal", 8.5F);
            lblStartDate.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            lblStartDate.Location = new System.Drawing.Point(165, 60);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new System.Drawing.Size(244, 20);
            lblStartDate.TabIndex = 5;
            lblStartDate.Text = "بدأ في: 15-01-2024";
            lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPaySalary
            // 
            btnPaySalary.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnPaySalary.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnPaySalary.BorderRadius = 8;
            btnPaySalary.BorderSize = 0;
            btnPaySalary.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPaySalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPaySalary.Font = new System.Drawing.Font("Tajawal", 9.5F, System.Drawing.FontStyle.Bold);
            btnPaySalary.ForeColor = System.Drawing.Color.White;
            btnPaySalary.Location = new System.Drawing.Point(245, 88);
            btnPaySalary.Name = "btnPaySalary";
            btnPaySalary.Size = new System.Drawing.Size(220, 34);
            btnPaySalary.TabIndex = 6;
            btnPaySalary.Text = "$ دفع راتب";
            btnPaySalary.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            btnEdit.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            btnEdit.BorderRadius = 8;
            btnEdit.BorderSize = 1;
            btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.Font = new System.Drawing.Font("Tajawal", 9.5F, System.Drawing.FontStyle.Bold);
            btnEdit.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnEdit.Location = new System.Drawing.Point(15, 88);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(220, 34);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "📝 تعديل";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // EmployeeCardControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            Controls.Add(cardPanel);
            Name = "EmployeeCardControl";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(480, 135);
            cardPanel.ResumeLayout(false);
            panelAvatar.ResumeLayout(false);
            ResumeLayout(false);
        }

        public CustomPanel cardPanel;
        public System.Windows.Forms.Label lblSalaryTitle;
        public System.Windows.Forms.Label lblSalaryValue;
        public CustomPanel panelAvatar;
        public System.Windows.Forms.Label lblAvatar;
        public System.Windows.Forms.Label lblEmployeeName;
        public System.Windows.Forms.Label lblPosition;
        public System.Windows.Forms.Label lblStartDate;
        public RoundedButton btnPaySalary;
        public RoundedButton btnEdit;
    }
}
