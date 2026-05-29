namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class EmployeesForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            btnAddEmployee = new ActiveSpaceSystem.CustomItems.RoundedButton();
            btnRegisterSalary = new ActiveSpaceSystem.CustomItems.RoundedButton();
            labelSub = new System.Windows.Forms.Label();
            labelTitle = new System.Windows.Forms.Label();
            tableLayoutPanelCards = new System.Windows.Forms.TableLayoutPanel();
            cardTotalEmployees = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            cardTotalSalaries = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            cardPaidSalaries = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            cardPendingSalaries = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            panelMainContainer = new ActiveSpaceSystem.CustomItems.CustomPanel();
            panelBody = new System.Windows.Forms.Panel();
            flowEmployees = new System.Windows.Forms.FlowLayoutPanel();
            dgvSalaries = new ActiveSpaceSystem.CustomItems.CustomDataGridView();
            panelGridHeader = new System.Windows.Forms.Panel();
            txtSearch = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            btnTabSalaryLog = new ActiveSpaceSystem.CustomItems.PillButton();
            btnTabEmployees = new ActiveSpaceSystem.CustomItems.PillButton();
            panelHeader.SuspendLayout();
            tableLayoutPanelCards.SuspendLayout();
            panelMainContainer.SuspendLayout();
            panelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalaries).BeginInit();
            panelGridHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(btnAddEmployee);
            panelHeader.Controls.Add(btnRegisterSalary);
            panelHeader.Controls.Add(labelSub);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Margin = new System.Windows.Forms.Padding(2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1022, 110);
            panelHeader.TabIndex = 0;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Anchor = System.Windows.Forms.AnchorStyles.Left;
            btnAddEmployee.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            btnAddEmployee.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnAddEmployee.BorderRadius = 12;
            btnAddEmployee.BorderSize = 0;
            btnAddEmployee.FlatAppearance.BorderSize = 0;
            btnAddEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddEmployee.Font = new System.Drawing.Font("Tajawal", 11.5F, System.Drawing.FontStyle.Bold);
            btnAddEmployee.ForeColor = System.Drawing.Color.White;
            btnAddEmployee.Location = new System.Drawing.Point(36, 30);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new System.Drawing.Size(170, 50);
            btnAddEmployee.TabIndex = 3;
            btnAddEmployee.Text = "➕ إضافة موظف";
            btnAddEmployee.UseVisualStyleBackColor = false;
            // 
            // btnRegisterSalary
            // 
            btnRegisterSalary.Anchor = System.Windows.Forms.AnchorStyles.Left;
            btnRegisterSalary.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnRegisterSalary.BorderColor = System.Drawing.Color.PaleVioletRed;
            btnRegisterSalary.BorderRadius = 12;
            btnRegisterSalary.BorderSize = 0;
            btnRegisterSalary.FlatAppearance.BorderSize = 0;
            btnRegisterSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRegisterSalary.Font = new System.Drawing.Font("Tajawal", 11.5F, System.Drawing.FontStyle.Bold);
            btnRegisterSalary.ForeColor = System.Drawing.Color.White;
            btnRegisterSalary.Location = new System.Drawing.Point(220, 30);
            btnRegisterSalary.Name = "btnRegisterSalary";
            btnRegisterSalary.Size = new System.Drawing.Size(170, 50);
            btnRegisterSalary.TabIndex = 2;
            btnRegisterSalary.Text = "💵 تسجيل راتب";
            btnRegisterSalary.UseVisualStyleBackColor = false;
            // 
            // labelSub
            // 
            labelSub.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelSub.AutoSize = true;
            labelSub.Font = new System.Drawing.Font("Tajawal", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelSub.ForeColor = System.Drawing.Color.DimGray;
            labelSub.Location = new System.Drawing.Point(620, 62);
            labelSub.Name = "labelSub";
            labelSub.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            labelSub.Size = new System.Drawing.Size(330, 23);
            labelSub.TabIndex = 1;
            labelSub.Text = "متابعة وتسجيل رواتب الموظفين والحوافز والخصومات";
            // 
            // labelTitle
            // 
            labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Tajawal", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelTitle.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            labelTitle.Location = new System.Drawing.Point(680, 12);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(270, 49);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "إدارة رواتب الموظفين";
            // 
            // tableLayoutPanelCards
            // 
            tableLayoutPanelCards.ColumnCount = 4;
            tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanelCards.Controls.Add(cardTotalEmployees, 3, 0);
            tableLayoutPanelCards.Controls.Add(cardTotalSalaries, 2, 0);
            tableLayoutPanelCards.Controls.Add(cardPaidSalaries, 1, 0);
            tableLayoutPanelCards.Controls.Add(cardPendingSalaries, 0, 0);
            tableLayoutPanelCards.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanelCards.Location = new System.Drawing.Point(0, 110);
            tableLayoutPanelCards.Margin = new System.Windows.Forms.Padding(2);
            tableLayoutPanelCards.Name = "tableLayoutPanelCards";
            tableLayoutPanelCards.RowCount = 1;
            tableLayoutPanelCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelCards.Size = new System.Drawing.Size(1022, 127);
            tableLayoutPanelCards.TabIndex = 1;
            // 
            // cardTotalEmployees
            // 
            cardTotalEmployees.BackColor = System.Drawing.Color.White;
            cardTotalEmployees.BorderRadius = 20;
            cardTotalEmployees.CardIcon = global::ActiveSpaceSystem.Properties.Resources.icons8_contract_64;
            cardTotalEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            cardTotalEmployees.Font = new System.Drawing.Font("Tajawal", 9F);
            cardTotalEmployees.IconBackColor = System.Drawing.Color.FromArgb(224, 231, 255);
            cardTotalEmployees.IconSize = 36;
            cardTotalEmployees.Location = new System.Drawing.Point(768, 3);
            cardTotalEmployees.Name = "cardTotalEmployees";
            cardTotalEmployees.Padding = new System.Windows.Forms.Padding(10);
            cardTotalEmployees.ShadowSize = 1;
            cardTotalEmployees.Size = new System.Drawing.Size(251, 121);
            cardTotalEmployees.SubValueColor = System.Drawing.Color.Gray;
            cardTotalEmployees.SubValueFont = new System.Drawing.Font("Tajawal", 9F);
            cardTotalEmployees.SubValueText = "";
            cardTotalEmployees.TabIndex = 3;
            cardTotalEmployees.TitleColor = System.Drawing.Color.Gray;
            cardTotalEmployees.TitleFont = new System.Drawing.Font("Tajawal Medium", 10.2F, System.Drawing.FontStyle.Bold);
            cardTotalEmployees.TitleText = "عدد الموظفين";
            cardTotalEmployees.ValueColor = System.Drawing.Color.FromArgb(49, 46, 129);
            cardTotalEmployees.ValueFont = new System.Drawing.Font("Tajawal", 16.2F, System.Drawing.FontStyle.Bold);
            cardTotalEmployees.ValueText = "0";
            // 
            // cardTotalSalaries
            // 
            cardTotalSalaries.BackColor = System.Drawing.Color.White;
            cardTotalSalaries.BorderRadius = 20;
            cardTotalSalaries.CardIcon = global::ActiveSpaceSystem.Properties.Resources.icons8_invoice_50;
            cardTotalSalaries.Dock = System.Windows.Forms.DockStyle.Fill;
            cardTotalSalaries.Font = new System.Drawing.Font("Tajawal", 9F);
            cardTotalSalaries.IconBackColor = System.Drawing.Color.FromArgb(254, 226, 226);
            cardTotalSalaries.IconSize = 36;
            cardTotalSalaries.Location = new System.Drawing.Point(513, 3);
            cardTotalSalaries.Name = "cardTotalSalaries";
            cardTotalSalaries.Padding = new System.Windows.Forms.Padding(10);
            cardTotalSalaries.ShadowSize = 1;
            cardTotalSalaries.Size = new System.Drawing.Size(249, 121);
            cardTotalSalaries.SubValueColor = System.Drawing.Color.Gray;
            cardTotalSalaries.SubValueFont = new System.Drawing.Font("Tajawal", 9F);
            cardTotalSalaries.SubValueText = "";
            cardTotalSalaries.TabIndex = 2;
            cardTotalSalaries.TitleColor = System.Drawing.Color.Gray;
            cardTotalSalaries.TitleFont = new System.Drawing.Font("Tajawal Medium", 10.2F, System.Drawing.FontStyle.Bold);
            cardTotalSalaries.TitleText = "إجمالي الرواتب";
            cardTotalSalaries.ValueColor = System.Drawing.Color.FromArgb(220, 38, 38);
            cardTotalSalaries.ValueFont = new System.Drawing.Font("Tajawal", 16.2F, System.Drawing.FontStyle.Bold);
            cardTotalSalaries.ValueText = "0 د.ل";
            // 
            // cardPaidSalaries
            // 
            cardPaidSalaries.BackColor = System.Drawing.Color.White;
            cardPaidSalaries.BorderRadius = 20;
            cardPaidSalaries.CardIcon = global::ActiveSpaceSystem.Properties.Resources.icons8_bank_approved_48;
            cardPaidSalaries.Dock = System.Windows.Forms.DockStyle.Fill;
            cardPaidSalaries.Font = new System.Drawing.Font("Tajawal", 9F);
            cardPaidSalaries.IconBackColor = System.Drawing.Color.FromArgb(209, 250, 229);
            cardPaidSalaries.IconSize = 36;
            cardPaidSalaries.Location = new System.Drawing.Point(258, 3);
            cardPaidSalaries.Name = "cardPaidSalaries";
            cardPaidSalaries.Padding = new System.Windows.Forms.Padding(10);
            cardPaidSalaries.ShadowSize = 1;
            cardPaidSalaries.Size = new System.Drawing.Size(249, 121);
            cardPaidSalaries.SubValueColor = System.Drawing.Color.Gray;
            cardPaidSalaries.SubValueFont = new System.Drawing.Font("Tajawal", 9F);
            cardPaidSalaries.SubValueText = "";
            cardPaidSalaries.TabIndex = 1;
            cardPaidSalaries.TitleColor = System.Drawing.Color.Gray;
            cardPaidSalaries.TitleFont = new System.Drawing.Font("Tajawal Medium", 10.2F, System.Drawing.FontStyle.Bold);
            cardPaidSalaries.TitleText = "رواتب مدفوعة";
            cardPaidSalaries.ValueColor = System.Drawing.Color.FromArgb(16, 185, 129);
            cardPaidSalaries.ValueFont = new System.Drawing.Font("Tajawal", 16.2F, System.Drawing.FontStyle.Bold);
            cardPaidSalaries.ValueText = "0 د.ل";
            // 
            // cardPendingSalaries
            // 
            cardPendingSalaries.BackColor = System.Drawing.Color.White;
            cardPendingSalaries.BorderRadius = 20;
            cardPendingSalaries.CardIcon = global::ActiveSpaceSystem.Properties.Resources.icons8_refresh_50;
            cardPendingSalaries.Dock = System.Windows.Forms.DockStyle.Fill;
            cardPendingSalaries.Font = new System.Drawing.Font("Tajawal", 9F);
            cardPendingSalaries.IconBackColor = System.Drawing.Color.FromArgb(254, 243, 199);
            cardPendingSalaries.IconSize = 36;
            cardPendingSalaries.Location = new System.Drawing.Point(3, 3);
            cardPendingSalaries.Name = "cardPendingSalaries";
            cardPendingSalaries.Padding = new System.Windows.Forms.Padding(10);
            cardPendingSalaries.ShadowSize = 1;
            cardPendingSalaries.Size = new System.Drawing.Size(249, 121);
            cardPendingSalaries.SubValueColor = System.Drawing.Color.Gray;
            cardPendingSalaries.SubValueFont = new System.Drawing.Font("Tajawal", 9F);
            cardPendingSalaries.SubValueText = "";
            cardPendingSalaries.TabIndex = 0;
            cardPendingSalaries.TitleColor = System.Drawing.Color.Gray;
            cardPendingSalaries.TitleFont = new System.Drawing.Font("Tajawal Medium", 10.2F, System.Drawing.FontStyle.Bold);
            cardPendingSalaries.TitleText = "رواتب معلقة";
            cardPendingSalaries.ValueColor = System.Drawing.Color.FromArgb(217, 119, 6);
            cardPendingSalaries.ValueFont = new System.Drawing.Font("Tajawal", 16.2F, System.Drawing.FontStyle.Bold);
            cardPendingSalaries.ValueText = "0 د.ل";
            // 
            // panelMainContainer
            // 
            panelMainContainer.BackColor = System.Drawing.Color.White;
            panelMainContainer.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            panelMainContainer.BorderRadius = 16;
            panelMainContainer.BorderSize = 1F;
            panelMainContainer.Controls.Add(panelBody);
            panelMainContainer.Controls.Add(panelGridHeader);
            panelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMainContainer.Location = new System.Drawing.Point(0, 237);
            panelMainContainer.Name = "panelMainContainer";
            panelMainContainer.Padding = new System.Windows.Forms.Padding(15);
            panelMainContainer.ShowShadow = false;
            panelMainContainer.Size = new System.Drawing.Size(1022, 446);
            panelMainContainer.TabIndex = 2;
            // 
            // panelBody
            // 
            panelBody.Controls.Add(flowEmployees);
            panelBody.Controls.Add(dgvSalaries);
            panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBody.Location = new System.Drawing.Point(15, 65);
            panelBody.Name = "panelBody";
            panelBody.Size = new System.Drawing.Size(992, 366);
            panelBody.TabIndex = 1;
            // 
            // flowEmployees
            // 
            flowEmployees.AutoScroll = true;
            flowEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            flowEmployees.Location = new System.Drawing.Point(0, 0);
            flowEmployees.Name = "flowEmployees";
            flowEmployees.Padding = new System.Windows.Forms.Padding(5);
            flowEmployees.Size = new System.Drawing.Size(992, 366);
            flowEmployees.TabIndex = 0;
            // 
            // dgvSalaries
            // 
            dgvSalaries.AllowUserToAddRows = false;
            dgvSalaries.AllowUserToDeleteRows = false;
            dgvSalaries.AllowUserToResizeRows = false;
            dgvSalaries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalaries.BackgroundColor = System.Drawing.Color.White;
            dgvSalaries.BorderRadius = 15;
            dgvSalaries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvSalaries.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dgvSalaries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvSalaries.ColumnHeadersHeight = 50;
            dgvSalaries.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvSalaries.EnableHeadersVisualStyles = false;
            dgvSalaries.GridColor = System.Drawing.Color.White;
            dgvSalaries.HeaderBackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            dgvSalaries.HeaderForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            dgvSalaries.Location = new System.Drawing.Point(0, 0);
            dgvSalaries.MultiSelect = false;
            dgvSalaries.Name = "dgvSalaries";
            dgvSalaries.ReadOnly = true;
            dgvSalaries.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dgvSalaries.RowHeadersVisible = false;
            dgvSalaries.RowTemplate.Height = 55;
            dgvSalaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSalaries.Size = new System.Drawing.Size(992, 366);
            dgvSalaries.TabIndex = 1;
            dgvSalaries.Visible = false;
            // 
            // panelGridHeader
            // 
            panelGridHeader.BackColor = System.Drawing.Color.White;
            panelGridHeader.Controls.Add(txtSearch);
            panelGridHeader.Controls.Add(btnTabSalaryLog);
            panelGridHeader.Controls.Add(btnTabEmployees);
            panelGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelGridHeader.Location = new System.Drawing.Point(15, 15);
            panelGridHeader.Name = "panelGridHeader";
            panelGridHeader.Size = new System.Drawing.Size(992, 50);
            panelGridHeader.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            txtSearch.BackColor = System.Drawing.Color.White;
            txtSearch.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            txtSearch.BorderRadius = 12;
            txtSearch.Icon = global::ActiveSpaceSystem.Properties.Resources.magnifying_glass;
            txtSearch.IconLocation = System.Windows.Forms.HorizontalAlignment.Right;
            txtSearch.IconSize = 20;
            txtSearch.Location = new System.Drawing.Point(3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.passwordChar = "\0";
            txtSearch.PlaceholderText = "بحث عن موظف...";
            txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            txtSearch.Size = new System.Drawing.Size(350, 42);
            txtSearch.TabIndex = 2;
            txtSearch.Texts = "";
            // 
            // btnTabSalaryLog
            // 
            btnTabSalaryLog.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btnTabSalaryLog.BackColor = System.Drawing.Color.White;
            btnTabSalaryLog.Checked = false;
            btnTabSalaryLog.CheckedBackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            btnTabSalaryLog.CheckedForeColor = System.Drawing.Color.White;
            btnTabSalaryLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTabSalaryLog.Font = new System.Drawing.Font("Tajawal Medium", 10.2F, System.Drawing.FontStyle.Bold);
            btnTabSalaryLog.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnTabSalaryLog.GroupName = "tabs";
            btnTabSalaryLog.Location = new System.Drawing.Point(710, 5);
            btnTabSalaryLog.Name = "btnTabSalaryLog";
            btnTabSalaryLog.Radius = 10;
            btnTabSalaryLog.Size = new System.Drawing.Size(130, 40);
            btnTabSalaryLog.TabIndex = 1;
            btnTabSalaryLog.Text = "سجل الرواتب";
            btnTabSalaryLog.UncheckedBackColor = System.Drawing.Color.White;
            btnTabSalaryLog.UncheckedForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnTabSalaryLog.UseVisualStyleBackColor = false;
            // 
            // btnTabEmployees
            // 
            btnTabEmployees.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btnTabEmployees.BackColor = System.Drawing.Color.White;
            btnTabEmployees.Checked = true;
            btnTabEmployees.CheckedBackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            btnTabEmployees.CheckedForeColor = System.Drawing.Color.White;
            btnTabEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTabEmployees.Font = new System.Drawing.Font("Tajawal Medium", 10.2F, System.Drawing.FontStyle.Bold);
            btnTabEmployees.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnTabEmployees.GroupName = "tabs";
            btnTabEmployees.Location = new System.Drawing.Point(850, 5);
            btnTabEmployees.Name = "btnTabEmployees";
            btnTabEmployees.Radius = 10;
            btnTabEmployees.Size = new System.Drawing.Size(135, 40);
            btnTabEmployees.TabIndex = 0;
            btnTabEmployees.Text = "إدارة الموظفين";
            btnTabEmployees.UncheckedBackColor = System.Drawing.Color.White;
            btnTabEmployees.UncheckedForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnTabEmployees.UseVisualStyleBackColor = false;
            // 
            // EmployeesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            ClientSize = new System.Drawing.Size(1022, 683);
            Controls.Add(panelMainContainer);
            Controls.Add(tableLayoutPanelCards);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "EmployeesForm";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Text = "إدارة رواتب الموظفين";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tableLayoutPanelCards.ResumeLayout(false);
            panelMainContainer.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSalaries).EndInit();
            panelGridHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSub;
        private ActiveSpaceSystem.CustomItems.RoundedButton btnRegisterSalary;
        private ActiveSpaceSystem.CustomItems.RoundedButton btnAddEmployee;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCards;
        private ActiveSpaceSystem.CustomItems.AdvancedStatusCard cardPendingSalaries;
        private ActiveSpaceSystem.CustomItems.AdvancedStatusCard cardPaidSalaries;
        private ActiveSpaceSystem.CustomItems.AdvancedStatusCard cardTotalSalaries;
        private ActiveSpaceSystem.CustomItems.AdvancedStatusCard cardTotalEmployees;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelMainContainer;
        private System.Windows.Forms.Panel panelGridHeader;
        private ActiveSpaceSystem.CustomItems.PillButton btnTabEmployees;
        private ActiveSpaceSystem.CustomItems.PillButton btnTabSalaryLog;
        private ActiveSpaceSystem.CustomItems.AbdulTextBox txtSearch;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.FlowLayoutPanel flowEmployees;
        private ActiveSpaceSystem.CustomItems.CustomDataGridView dgvSalaries;
    }
}