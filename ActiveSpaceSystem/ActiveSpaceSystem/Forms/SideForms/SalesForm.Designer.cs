namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class SalesForm
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
            panelHeader = new Panel();
            btnOpenAdd = new ActiveSpaceSystem.CustomItems.RoundedButton();
            labelSub = new Label();
            labelTitle = new Label();
            tableLayoutPanelCards = new TableLayoutPanel();
            cardTotalPurchases = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            cardMonthPurchases = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            cardItemCount = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            panelFilters = new ActiveSpaceSystem.CustomItems.StatusCard();
            txtSearch = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            btnFilterLighting = new ActiveSpaceSystem.CustomItems.PillButton();
            btnFilterEquipment = new ActiveSpaceSystem.CustomItems.PillButton();
            btnFilterSportsBalls = new ActiveSpaceSystem.CustomItems.PillButton();
            btnFilterAll = new ActiveSpaceSystem.CustomItems.PillButton();
            panelGrid = new Panel();
            dgvPurchases = new ActiveSpaceSystem.CustomItems.CustomDataGridView();
            panelHeader.SuspendLayout();
            tableLayoutPanelCards.SuspendLayout();
            panelFilters.SuspendLayout();
            panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPurchases).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(btnOpenAdd);
            panelHeader.Controls.Add(labelSub);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1022, 120);
            panelHeader.TabIndex = 0;
            // 
            // btnOpenAdd
            // 
            btnOpenAdd.Anchor = AnchorStyles.Left;
            btnOpenAdd.BackColor = Color.FromArgb(38, 191, 141);
            btnOpenAdd.BorderColor = Color.PaleVioletRed;
            btnOpenAdd.BorderRadius = 15;
            btnOpenAdd.BorderSize = 0;
            btnOpenAdd.FlatAppearance.BorderSize = 0;
            btnOpenAdd.FlatStyle = FlatStyle.Flat;
            btnOpenAdd.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenAdd.ForeColor = Color.White;
            btnOpenAdd.Image = Properties.Resources.icons8_add_24;
            btnOpenAdd.ImageAlign = ContentAlignment.MiddleRight;
            btnOpenAdd.Location = new Point(36, 35);
            btnOpenAdd.Name = "btnOpenAdd";
            btnOpenAdd.Padding = new Padding(20, 10, 20, 10);
            btnOpenAdd.Size = new Size(228, 56);
            btnOpenAdd.TabIndex = 2;
            btnOpenAdd.Text = "إضافة مشتري جديد";
            btnOpenAdd.TextAlign = ContentAlignment.MiddleLeft;
            btnOpenAdd.UseVisualStyleBackColor = false;
            btnOpenAdd.Click += btnOpenAdd_Click;
            // 
            // labelSub
            // 
            labelSub.Anchor = AnchorStyles.Right;
            labelSub.AutoSize = true;
            labelSub.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSub.ForeColor = Color.DimGray;
            labelSub.Location = new Point(581, 68);
            labelSub.Name = "labelSub";
            labelSub.RightToLeft = RightToLeft.Yes;
            labelSub.Size = new Size(412, 23);
            labelSub.TabIndex = 1;
            labelSub.Text = "متابعة وتسجيل مشتريات المعدات والمستلزمات الرياضية";
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Right;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Tajawal", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.MidnightBlue;
            labelTitle.Location = new Point(740, 17);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(253, 49);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "إدارة المشتريات";
            // 
            // tableLayoutPanelCards
            // 
            tableLayoutPanelCards.ColumnCount = 3;
            tableLayoutPanelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanelCards.Controls.Add(cardTotalPurchases, 2, 0);
            tableLayoutPanelCards.Controls.Add(cardMonthPurchases, 1, 0);
            tableLayoutPanelCards.Controls.Add(cardItemCount, 0, 0);
            tableLayoutPanelCards.Dock = DockStyle.Top;
            tableLayoutPanelCards.Location = new Point(0, 120);
            tableLayoutPanelCards.Margin = new Padding(2);
            tableLayoutPanelCards.Name = "tableLayoutPanelCards";
            tableLayoutPanelCards.RowCount = 1;
            tableLayoutPanelCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelCards.Size = new Size(1022, 127);
            tableLayoutPanelCards.TabIndex = 1;
            // 
            // cardTotalPurchases
            // 
            cardTotalPurchases.BackColor = Color.White;
            cardTotalPurchases.BorderRadius = 20;
            cardTotalPurchases.CardIcon = Properties.Resources.icons8_shopping_cart_50;
            cardTotalPurchases.Dock = DockStyle.Fill;
            cardTotalPurchases.Font = new Font("Tajawal", 9F);
            cardTotalPurchases.IconBackColor = Color.FromArgb(38, 191, 141);
            cardTotalPurchases.IconSize = 36;
            cardTotalPurchases.Location = new Point(683, 3);
            cardTotalPurchases.Name = "cardTotalPurchases";
            cardTotalPurchases.Padding = new Padding(10);
            cardTotalPurchases.ShadowSize = 1;
            cardTotalPurchases.Size = new Size(336, 121);
            cardTotalPurchases.SubValueColor = Color.Gray;
            cardTotalPurchases.SubValueFont = new Font("Tajawal", 9F);
            cardTotalPurchases.SubValueText = "";
            cardTotalPurchases.TabIndex = 2;
            cardTotalPurchases.TitleColor = Color.Gray;
            cardTotalPurchases.TitleFont = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            cardTotalPurchases.TitleText = "إجمالي المشتريات";
            cardTotalPurchases.ValueColor = Color.FromArgb(38, 191, 141);
            cardTotalPurchases.ValueFont = new Font("Tajawal", 16.1999989F, FontStyle.Bold);
            cardTotalPurchases.ValueText = "0 د.ل";
            // 
            // cardMonthPurchases
            // 
            cardMonthPurchases.BackColor = Color.White;
            cardMonthPurchases.BorderRadius = 20;
            cardMonthPurchases.CardIcon = Properties.Resources.icons8_money_50;
            cardMonthPurchases.Dock = DockStyle.Fill;
            cardMonthPurchases.Font = new Font("Tajawal", 9F);
            cardMonthPurchases.IconBackColor = Color.FromArgb(43, 127, 255);
            cardMonthPurchases.IconSize = 36;
            cardMonthPurchases.Location = new Point(343, 3);
            cardMonthPurchases.Name = "cardMonthPurchases";
            cardMonthPurchases.Padding = new Padding(10);
            cardMonthPurchases.ShadowSize = 1;
            cardMonthPurchases.Size = new Size(334, 121);
            cardMonthPurchases.SubValueColor = Color.Gray;
            cardMonthPurchases.SubValueFont = new Font("Tajawal", 9F);
            cardMonthPurchases.SubValueText = "";
            cardMonthPurchases.TabIndex = 1;
            cardMonthPurchases.TitleColor = Color.Gray;
            cardMonthPurchases.TitleFont = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            cardMonthPurchases.TitleText = "مشتريات الشهر الحالي";
            cardMonthPurchases.ValueColor = Color.FromArgb(43, 127, 255);
            cardMonthPurchases.ValueFont = new Font("Tajawal", 16.1999989F, FontStyle.Bold);
            cardMonthPurchases.ValueText = "0 د.ل";
            // 
            // cardItemCount
            // 
            cardItemCount.BackColor = Color.White;
            cardItemCount.BorderRadius = 20;
            cardItemCount.CardIcon = Properties.Resources.icons8_contract_64;
            cardItemCount.Dock = DockStyle.Fill;
            cardItemCount.Font = new Font("Tajawal", 9F);
            cardItemCount.IconBackColor = Color.FromArgb(110, 68, 255);
            cardItemCount.IconSize = 36;
            cardItemCount.Location = new Point(3, 3);
            cardItemCount.Name = "cardItemCount";
            cardItemCount.Padding = new Padding(10);
            cardItemCount.ShadowSize = 1;
            cardItemCount.Size = new Size(334, 121);
            cardItemCount.SubValueColor = Color.Gray;
            cardItemCount.SubValueFont = new Font("Tajawal", 9F);
            cardItemCount.SubValueText = "";
            cardItemCount.TabIndex = 0;
            cardItemCount.TitleColor = Color.Gray;
            cardItemCount.TitleFont = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            cardItemCount.TitleText = "عدد الأصناف";
            cardItemCount.ValueColor = Color.FromArgb(110, 68, 255);
            cardItemCount.ValueFont = new Font("Tajawal", 16.1999989F, FontStyle.Bold);
            cardItemCount.ValueText = "0";
            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.Transparent;
            panelFilters.BorderColor = Color.Black;
            panelFilters.BorderRadius = 15;
            panelFilters.CardBackColor = Color.White;
            panelFilters.Controls.Add(txtSearch);
            panelFilters.Controls.Add(btnFilterLighting);
            panelFilters.Controls.Add(btnFilterEquipment);
            panelFilters.Controls.Add(btnFilterSportsBalls);
            panelFilters.Controls.Add(btnFilterAll);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(0, 247);
            panelFilters.Margin = new Padding(80);
            panelFilters.Name = "panelFilters";
            panelFilters.Padding = new Padding(40);
            panelFilters.ShadowBlur = 5;
            panelFilters.ShadowColor = Color.FromArgb(0, 0, 192);
            panelFilters.ShowShadow = true;
            panelFilters.Size = new Size(1022, 93);
            panelFilters.TabIndex = 2;
            panelFilters.TitleColor = Color.Gray;
            panelFilters.TitleFont = new Font("Microsoft Sans Serif", 10F);
            panelFilters.TitleText = "";
            panelFilters.ValueColor = Color.FromArgb(46, 204, 113);
            panelFilters.ValueFont = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            panelFilters.ValueText = "";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Right;
            txtSearch.BackColor = Color.White;
            txtSearch.BorderColor = Color.FromArgb(29, 53, 87);
            txtSearch.BorderRadius = 15;
            txtSearch.Icon = Properties.Resources.magnifying_glass;
            txtSearch.IconLocation = HorizontalAlignment.Right;
            txtSearch.IconSize = 24;
            txtSearch.Location = new Point(603, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.passwordChar = "\0";
            txtSearch.PlaceholderText = "بحث عن صنف، مورد، أو فئة...";
            txtSearch.RightToLeft = RightToLeft.Yes;
            txtSearch.Size = new Size(377, 48);
            txtSearch.TabIndex = 4;
            txtSearch.Texts = "";
            txtSearch._TextChanged += txtSearch_TextChanged;
            // 
            // btnFilterLighting
            // 
            btnFilterLighting.BackColor = Color.White;
            btnFilterLighting.BackgroundImageLayout = ImageLayout.None;
            btnFilterLighting.Checked = false;
            btnFilterLighting.CheckedBackColor = Color.FromArgb(41, 51, 146);
            btnFilterLighting.CheckedForeColor = Color.White;
            btnFilterLighting.FlatAppearance.BorderSize = 0;
            btnFilterLighting.FlatStyle = FlatStyle.Flat;
            btnFilterLighting.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            btnFilterLighting.ForeColor = Color.FromArgb(64, 64, 64);
            btnFilterLighting.GroupName = "";
            btnFilterLighting.Location = new Point(36, 22);
            btnFilterLighting.Margin = new Padding(2);
            btnFilterLighting.Name = "btnFilterLighting";
            btnFilterLighting.Radius = 10;
            btnFilterLighting.Size = new Size(120, 43);
            btnFilterLighting.TabIndex = 3;
            btnFilterLighting.Text = "إضاءة";
            btnFilterLighting.UncheckedBackColor = Color.FromArgb(242, 242, 242);
            btnFilterLighting.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnFilterLighting.UseVisualStyleBackColor = false;
            btnFilterLighting.Click += btnFilterLighting_Click;
            // 
            // btnFilterEquipment
            // 
            btnFilterEquipment.BackColor = Color.White;
            btnFilterEquipment.BackgroundImageLayout = ImageLayout.None;
            btnFilterEquipment.Checked = false;
            btnFilterEquipment.CheckedBackColor = Color.FromArgb(41, 51, 146);
            btnFilterEquipment.CheckedForeColor = Color.White;
            btnFilterEquipment.FlatAppearance.BorderSize = 0;
            btnFilterEquipment.FlatStyle = FlatStyle.Flat;
            btnFilterEquipment.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            btnFilterEquipment.ForeColor = Color.FromArgb(64, 64, 64);
            btnFilterEquipment.GroupName = "";
            btnFilterEquipment.Location = new Point(176, 22);
            btnFilterEquipment.Margin = new Padding(2);
            btnFilterEquipment.Name = "btnFilterEquipment";
            btnFilterEquipment.Radius = 10;
            btnFilterEquipment.Size = new Size(140, 43);
            btnFilterEquipment.TabIndex = 2;
            btnFilterEquipment.Text = "معدات الملاعب";
            btnFilterEquipment.UncheckedBackColor = Color.FromArgb(242, 242, 242);
            btnFilterEquipment.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnFilterEquipment.UseVisualStyleBackColor = false;
            btnFilterEquipment.Click += btnFilterEquipment_Click;
            // 
            // btnFilterSportsBalls
            // 
            btnFilterSportsBalls.BackColor = Color.White;
            btnFilterSportsBalls.BackgroundImageLayout = ImageLayout.None;
            btnFilterSportsBalls.Checked = false;
            btnFilterSportsBalls.CheckedBackColor = Color.FromArgb(41, 51, 146);
            btnFilterSportsBalls.CheckedForeColor = Color.White;
            btnFilterSportsBalls.FlatAppearance.BorderSize = 0;
            btnFilterSportsBalls.FlatStyle = FlatStyle.Flat;
            btnFilterSportsBalls.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            btnFilterSportsBalls.ForeColor = Color.FromArgb(64, 64, 64);
            btnFilterSportsBalls.GroupName = "";
            btnFilterSportsBalls.Location = new Point(336, 22);
            btnFilterSportsBalls.Margin = new Padding(2);
            btnFilterSportsBalls.Name = "btnFilterSportsBalls";
            btnFilterSportsBalls.Radius = 10;
            btnFilterSportsBalls.Size = new Size(120, 43);
            btnFilterSportsBalls.TabIndex = 1;
            btnFilterSportsBalls.Text = "كرات رياضية";
            btnFilterSportsBalls.UncheckedBackColor = Color.FromArgb(242, 242, 242);
            btnFilterSportsBalls.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnFilterSportsBalls.UseVisualStyleBackColor = false;
            btnFilterSportsBalls.Click += btnFilterSportsBalls_Click;
            // 
            // btnFilterAll
            // 
            btnFilterAll.BackColor = Color.White;
            btnFilterAll.BackgroundImageLayout = ImageLayout.None;
            btnFilterAll.Checked = true;
            btnFilterAll.CheckedBackColor = Color.FromArgb(41, 51, 146);
            btnFilterAll.CheckedForeColor = Color.White;
            btnFilterAll.FlatAppearance.BorderSize = 0;
            btnFilterAll.FlatStyle = FlatStyle.Flat;
            btnFilterAll.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            btnFilterAll.ForeColor = Color.FromArgb(64, 64, 64);
            btnFilterAll.GroupName = "";
            btnFilterAll.Location = new Point(476, 22);
            btnFilterAll.Margin = new Padding(2);
            btnFilterAll.Name = "btnFilterAll";
            btnFilterAll.Radius = 10;
            btnFilterAll.Size = new Size(90, 43);
            btnFilterAll.TabIndex = 0;
            btnFilterAll.Text = "الكل";
            btnFilterAll.UncheckedBackColor = Color.FromArgb(242, 242, 242);
            btnFilterAll.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnFilterAll.UseVisualStyleBackColor = false;
            btnFilterAll.Click += btnFilterAll_Click;
            // 
            // panelGrid
            // 
            panelGrid.Controls.Add(dgvPurchases);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 340);
            panelGrid.Margin = new Padding(2);
            panelGrid.Name = "panelGrid";
            panelGrid.Size = new Size(1022, 343);
            panelGrid.TabIndex = 3;
            // 
            // dgvPurchases
            // 
            dgvPurchases.AllowUserToAddRows = false;
            dgvPurchases.AllowUserToResizeRows = false;
            dgvPurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPurchases.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvPurchases.BackgroundColor = Color.White;
            dgvPurchases.BorderRadius = 15;
            dgvPurchases.BorderStyle = BorderStyle.None;
            dgvPurchases.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPurchases.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPurchases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPurchases.ColumnHeadersHeight = 50;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPurchases.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPurchases.Dock = DockStyle.Fill;
            dgvPurchases.EnableHeadersVisualStyles = false;
            dgvPurchases.GridColor = Color.White;
            dgvPurchases.HeaderBackColor = Color.FromArgb(243, 244, 246);
            dgvPurchases.HeaderForeColor = Color.FromArgb(33, 37, 41);
            dgvPurchases.Location = new Point(0, 0);
            dgvPurchases.MultiSelect = false;
            dgvPurchases.Name = "dgvPurchases";
            dgvPurchases.ReadOnly = true;
            dgvPurchases.RightToLeft = RightToLeft.Yes;
            dgvPurchases.RowHeadersVisible = false;
            dgvPurchases.RowHeadersWidth = 51;
            dgvPurchases.RowHeight = 55;
            dgvPurchases.RowTemplate.Height = 55;
            dgvPurchases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPurchases.Size = new Size(1022, 343);
            dgvPurchases.TabIndex = 0;
            // 
            // SalesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1022, 683);
            Controls.Add(panelGrid);
            Controls.Add(panelFilters);
            Controls.Add(tableLayoutPanelCards);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "SalesForm";
            Text = "SalesForm";
            Load += SalesForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tableLayoutPanelCards.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPurchases).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSub;
        private CustomItems.RoundedButton btnOpenAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCards;
        private CustomItems.AdvancedStatusCard cardItemCount;
        private CustomItems.AdvancedStatusCard cardMonthPurchases;
        private CustomItems.AdvancedStatusCard cardTotalPurchases;
        private CustomItems.StatusCard panelFilters;
        private CustomItems.PillButton btnFilterAll;
        private CustomItems.PillButton btnFilterSportsBalls;
        private CustomItems.PillButton btnFilterEquipment;
        private CustomItems.PillButton btnFilterLighting;
        private ActiveSpaceSystem.CustomItems.AbdulTextBox txtSearch;
        private System.Windows.Forms.Panel panelGrid;
        private CustomItems.CustomDataGridView dgvPurchases;
    }
}