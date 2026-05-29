namespace ActiveSpaceSystem.Forms.SideForms
{
    partial class InventoryForm
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
            btnDamagedGoods = new ActiveSpaceSystem.CustomItems.RoundedButton();
            labelSub = new Label();
            labelTitle = new Label();
            panelAlertWrapper = new Panel();
            panelAlert = new Panel();
            labelAlertText = new Label();
            tableLayoutPanelCards = new TableLayoutPanel();
            cardTotalValue = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            cardDamagedGoods = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            cardLowStock = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            cardTotalItems = new ActiveSpaceSystem.CustomItems.AdvancedStatusCard();
            panelFilters = new ActiveSpaceSystem.CustomItems.StatusCard();
            txtSearch = new ActiveSpaceSystem.CustomItems.AbdulTextBox();
            btnFilterLighting = new ActiveSpaceSystem.CustomItems.PillButton();
            btnFilterSupplies = new ActiveSpaceSystem.CustomItems.PillButton();
            btnFilterEquipment = new ActiveSpaceSystem.CustomItems.PillButton();
            btnFilterSportsBalls = new ActiveSpaceSystem.CustomItems.PillButton();
            btnFilterAll = new ActiveSpaceSystem.CustomItems.PillButton();
            panelGrid = new Panel();
            dgvInventory = new ActiveSpaceSystem.CustomItems.CustomDataGridView();
            panelGridHeader = new Panel();
            btnTabMovements = new ActiveSpaceSystem.CustomItems.PillButton();
            btnTabInventory = new ActiveSpaceSystem.CustomItems.PillButton();
            panelHeader.SuspendLayout();
            panelAlertWrapper.SuspendLayout();
            panelAlert.SuspendLayout();
            tableLayoutPanelCards.SuspendLayout();
            panelFilters.SuspendLayout();
            panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            panelGridHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(btnDamagedGoods);
            panelHeader.Controls.Add(labelSub);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1022, 110);
            panelHeader.TabIndex = 0;
            // 
            // btnDamagedGoods
            // 
            btnDamagedGoods.Anchor = AnchorStyles.Left;
            btnDamagedGoods.BackColor = Color.FromArgb(220, 38, 38);
            btnDamagedGoods.BorderColor = Color.PaleVioletRed;
            btnDamagedGoods.BorderRadius = 15;
            btnDamagedGoods.BorderSize = 0;
            btnDamagedGoods.FlatAppearance.BorderSize = 0;
            btnDamagedGoods.FlatStyle = FlatStyle.Flat;
            btnDamagedGoods.Font = new Font("Tajawal", 11.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDamagedGoods.ForeColor = Color.White;
            btnDamagedGoods.Image = Properties.Resources.icons8_alert_50;
            btnDamagedGoods.ImageAlign = ContentAlignment.MiddleRight;
            btnDamagedGoods.Location = new Point(36, 30);
            btnDamagedGoods.Name = "btnDamagedGoods";
            btnDamagedGoods.Padding = new Padding(18, 8, 18, 8);
            btnDamagedGoods.Size = new Size(190, 50);
            btnDamagedGoods.TabIndex = 2;
            btnDamagedGoods.Text = "البضائع التالفة";
            btnDamagedGoods.TextAlign = ContentAlignment.MiddleLeft;
            btnDamagedGoods.UseVisualStyleBackColor = false;
            btnDamagedGoods.Click += btnDamagedGoods_Click;
            // 
            // labelSub
            // 
            labelSub.Anchor = AnchorStyles.Right;
            labelSub.AutoSize = true;
            labelSub.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSub.ForeColor = Color.DimGray;
            labelSub.Location = new Point(620, 62);
            labelSub.Name = "labelSub";
            labelSub.RightToLeft = RightToLeft.Yes;
            labelSub.Size = new Size(331, 23);
            labelSub.TabIndex = 1;
            labelSub.Text = "متابعة المعدات والمستلزمات والبضائع التالفة";
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Right;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Tajawal", 19.7999973F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.MidnightBlue;
            labelTitle.Location = new Point(760, 12);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(214, 49);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "إدارة المخزون";
            // 
            // panelAlertWrapper
            // 
            panelAlertWrapper.Controls.Add(panelAlert);
            panelAlertWrapper.Dock = DockStyle.Top;
            panelAlertWrapper.Location = new Point(0, 110);
            panelAlertWrapper.Name = "panelAlertWrapper";
            panelAlertWrapper.Padding = new Padding(15, 0, 15, 10);
            panelAlertWrapper.Size = new Size(1022, 60);
            panelAlertWrapper.TabIndex = 1;
            // 
            // panelAlert
            // 
            panelAlert.BackColor = Color.FromArgb(239, 246, 255);
            panelAlert.BorderStyle = BorderStyle.FixedSingle;
            panelAlert.Controls.Add(labelAlertText);
            panelAlert.Dock = DockStyle.Fill;
            panelAlert.Location = new Point(15, 0);
            panelAlert.Name = "panelAlert";
            panelAlert.Size = new Size(992, 50);
            panelAlert.TabIndex = 0;
            panelAlert.Paint += panelAlert_Paint;
            // 
            // labelAlertText
            // 
            labelAlertText.Dock = DockStyle.Fill;
            labelAlertText.Font = new Font("Tajawal Medium", 10.5F, FontStyle.Bold);
            labelAlertText.ForeColor = Color.FromArgb(29, 78, 216);
            labelAlertText.Location = new Point(0, 0);
            labelAlertText.Name = "labelAlertText";
            labelAlertText.RightToLeft = RightToLeft.Yes;
            labelAlertText.Size = new Size(990, 48);
            labelAlertText.TabIndex = 0;
            labelAlertText.Text = "ملاحظة: يتم إضافة الأصناف للمخزون تلقائياً عند تسجيل مشتريات جديدة. يمكنك تحديث الكميات من صفحة المشتريات.";
            labelAlertText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelCards
            // 
            tableLayoutPanelCards.ColumnCount = 4;
            tableLayoutPanelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelCards.Controls.Add(cardTotalValue, 3, 0);
            tableLayoutPanelCards.Controls.Add(cardDamagedGoods, 2, 0);
            tableLayoutPanelCards.Controls.Add(cardLowStock, 1, 0);
            tableLayoutPanelCards.Controls.Add(cardTotalItems, 0, 0);
            tableLayoutPanelCards.Dock = DockStyle.Top;
            tableLayoutPanelCards.Location = new Point(0, 170);
            tableLayoutPanelCards.Margin = new Padding(2);
            tableLayoutPanelCards.Name = "tableLayoutPanelCards";
            tableLayoutPanelCards.RowCount = 1;
            tableLayoutPanelCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelCards.Size = new Size(1022, 127);
            tableLayoutPanelCards.TabIndex = 2;
            // 
            // cardTotalValue
            // 
            cardTotalValue.BackColor = Color.White;
            cardTotalValue.BorderRadius = 20;
            cardTotalValue.CardIcon = Properties.Resources.icons8_invoice_50;
            cardTotalValue.Dock = DockStyle.Fill;
            cardTotalValue.Font = new Font("Tajawal", 9F);
            cardTotalValue.IconBackColor = Color.FromArgb(209, 250, 229);
            cardTotalValue.IconSize = 36;
            cardTotalValue.Location = new Point(768, 3);
            cardTotalValue.Name = "cardTotalValue";
            cardTotalValue.Padding = new Padding(10);
            cardTotalValue.ShadowSize = 1;
            cardTotalValue.Size = new Size(251, 121);
            cardTotalValue.SubValueColor = Color.Gray;
            cardTotalValue.SubValueFont = new Font("Tajawal", 9F);
            cardTotalValue.SubValueText = "";
            cardTotalValue.TabIndex = 3;
            cardTotalValue.TitleColor = Color.Gray;
            cardTotalValue.TitleFont = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            cardTotalValue.TitleText = "قيمة المخزون";
            cardTotalValue.ValueColor = Color.FromArgb(5, 150, 105);
            cardTotalValue.ValueFont = new Font("Tajawal", 16.1999989F, FontStyle.Bold);
            cardTotalValue.ValueText = "0 د.ل";
            // 
            // cardDamagedGoods
            // 
            cardDamagedGoods.BackColor = Color.White;
            cardDamagedGoods.BorderRadius = 20;
            cardDamagedGoods.CardIcon = Properties.Resources.icons8_alert_50;
            cardDamagedGoods.Dock = DockStyle.Fill;
            cardDamagedGoods.Font = new Font("Tajawal", 9F);
            cardDamagedGoods.IconBackColor = Color.FromArgb(254, 226, 226);
            cardDamagedGoods.IconSize = 36;
            cardDamagedGoods.Location = new Point(513, 3);
            cardDamagedGoods.Name = "cardDamagedGoods";
            cardDamagedGoods.Padding = new Padding(10);
            cardDamagedGoods.ShadowSize = 1;
            cardDamagedGoods.Size = new Size(249, 121);
            cardDamagedGoods.SubValueColor = Color.Gray;
            cardDamagedGoods.SubValueFont = new Font("Tajawal", 9F);
            cardDamagedGoods.SubValueText = "";
            cardDamagedGoods.TabIndex = 2;
            cardDamagedGoods.TitleColor = Color.Gray;
            cardDamagedGoods.TitleFont = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            cardDamagedGoods.TitleText = "بضائع تالفة";
            cardDamagedGoods.ValueColor = Color.FromArgb(220, 38, 38);
            cardDamagedGoods.ValueFont = new Font("Tajawal", 16.1999989F, FontStyle.Bold);
            cardDamagedGoods.ValueText = "0";
            // 
            // cardLowStock
            // 
            cardLowStock.BackColor = Color.White;
            cardLowStock.BorderRadius = 20;
            cardLowStock.CardIcon = Properties.Resources.icons8_refresh_50;
            cardLowStock.Dock = DockStyle.Fill;
            cardLowStock.Font = new Font("Tajawal", 9F);
            cardLowStock.IconBackColor = Color.FromArgb(254, 243, 199);
            cardLowStock.IconSize = 36;
            cardLowStock.Location = new Point(258, 3);
            cardLowStock.Name = "cardLowStock";
            cardLowStock.Padding = new Padding(10);
            cardLowStock.ShadowSize = 1;
            cardLowStock.Size = new Size(249, 121);
            cardLowStock.SubValueColor = Color.Gray;
            cardLowStock.SubValueFont = new Font("Tajawal", 9F);
            cardLowStock.SubValueText = "";
            cardLowStock.TabIndex = 1;
            cardLowStock.TitleColor = Color.Gray;
            cardLowStock.TitleFont = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            cardLowStock.TitleText = "أصناف منخفضة";
            cardLowStock.ValueColor = Color.FromArgb(217, 119, 6);
            cardLowStock.ValueFont = new Font("Tajawal", 16.1999989F, FontStyle.Bold);
            cardLowStock.ValueText = "0";
            // 
            // cardTotalItems
            // 
            cardTotalItems.BackColor = Color.White;
            cardTotalItems.BorderRadius = 20;
            cardTotalItems.CardIcon = Properties.Resources.icons8_contract_64;
            cardTotalItems.Dock = DockStyle.Fill;
            cardTotalItems.Font = new Font("Tajawal", 9F);
            cardTotalItems.IconBackColor = Color.FromArgb(224, 231, 255);
            cardTotalItems.IconSize = 36;
            cardTotalItems.Location = new Point(3, 3);
            cardTotalItems.Name = "cardTotalItems";
            cardTotalItems.Padding = new Padding(10);
            cardTotalItems.ShadowSize = 1;
            cardTotalItems.Size = new Size(249, 121);
            cardTotalItems.SubValueColor = Color.Gray;
            cardTotalItems.SubValueFont = new Font("Tajawal", 9F);
            cardTotalItems.SubValueText = "";
            cardTotalItems.TabIndex = 0;
            cardTotalItems.TitleColor = Color.Gray;
            cardTotalItems.TitleFont = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            cardTotalItems.TitleText = "إجمالي الأصناف";
            cardTotalItems.ValueColor = Color.FromArgb(49, 46, 129);
            cardTotalItems.ValueFont = new Font("Tajawal", 16.1999989F, FontStyle.Bold);
            cardTotalItems.ValueText = "0";
            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.Transparent;
            panelFilters.BorderColor = Color.Black;
            panelFilters.BorderRadius = 15;
            panelFilters.CardBackColor = Color.White;
            panelFilters.Controls.Add(txtSearch);
            panelFilters.Controls.Add(btnFilterLighting);
            panelFilters.Controls.Add(btnFilterSupplies);
            panelFilters.Controls.Add(btnFilterEquipment);
            panelFilters.Controls.Add(btnFilterSportsBalls);
            panelFilters.Controls.Add(btnFilterAll);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(0, 297);
            panelFilters.Margin = new Padding(80);
            panelFilters.Name = "panelFilters";
            panelFilters.Padding = new Padding(40);
            panelFilters.ShadowBlur = 5;
            panelFilters.ShadowColor = Color.FromArgb(0, 0, 192);
            panelFilters.ShowShadow = true;
            panelFilters.Size = new Size(1022, 93);
            panelFilters.TabIndex = 3;
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
            txtSearch.PlaceholderText = "بحث في المخزون...";
            txtSearch.RightToLeft = RightToLeft.Yes;
            txtSearch.Size = new Size(377, 48);
            txtSearch.TabIndex = 5;
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
            btnFilterLighting.Size = new Size(80, 43);
            btnFilterLighting.TabIndex = 4;
            btnFilterLighting.Text = "إضاءة";
            btnFilterLighting.UncheckedBackColor = Color.FromArgb(242, 242, 242);
            btnFilterLighting.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnFilterLighting.UseVisualStyleBackColor = false;
            btnFilterLighting.Click += btnFilterLighting_Click;
            // 
            // btnFilterSupplies
            // 
            btnFilterSupplies.BackColor = Color.White;
            btnFilterSupplies.BackgroundImageLayout = ImageLayout.None;
            btnFilterSupplies.Checked = false;
            btnFilterSupplies.CheckedBackColor = Color.FromArgb(41, 51, 146);
            btnFilterSupplies.CheckedForeColor = Color.White;
            btnFilterSupplies.FlatAppearance.BorderSize = 0;
            btnFilterSupplies.FlatStyle = FlatStyle.Flat;
            btnFilterSupplies.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            btnFilterSupplies.ForeColor = Color.FromArgb(64, 64, 64);
            btnFilterSupplies.GroupName = "";
            btnFilterSupplies.Location = new Point(130, 22);
            btnFilterSupplies.Margin = new Padding(2);
            btnFilterSupplies.Name = "btnFilterSupplies";
            btnFilterSupplies.Radius = 10;
            btnFilterSupplies.Size = new Size(100, 43);
            btnFilterSupplies.TabIndex = 3;
            btnFilterSupplies.Text = "مستلزمات";
            btnFilterSupplies.UncheckedBackColor = Color.FromArgb(242, 242, 242);
            btnFilterSupplies.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnFilterSupplies.UseVisualStyleBackColor = false;
            btnFilterSupplies.Click += btnFilterSupplies_Click;
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
            btnFilterEquipment.Location = new Point(244, 22);
            btnFilterEquipment.Margin = new Padding(2);
            btnFilterEquipment.Name = "btnFilterEquipment";
            btnFilterEquipment.Radius = 10;
            btnFilterEquipment.Size = new Size(120, 43);
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
            btnFilterSportsBalls.Location = new Point(378, 22);
            btnFilterSportsBalls.Margin = new Padding(2);
            btnFilterSportsBalls.Name = "btnFilterSportsBalls";
            btnFilterSportsBalls.Radius = 10;
            btnFilterSportsBalls.Size = new Size(110, 43);
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
            btnFilterAll.Location = new Point(502, 22);
            btnFilterAll.Margin = new Padding(2);
            btnFilterAll.Name = "btnFilterAll";
            btnFilterAll.Radius = 10;
            btnFilterAll.Size = new Size(70, 43);
            btnFilterAll.TabIndex = 0;
            btnFilterAll.Text = "الكل";
            btnFilterAll.UncheckedBackColor = Color.FromArgb(242, 242, 242);
            btnFilterAll.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnFilterAll.UseVisualStyleBackColor = false;
            btnFilterAll.Click += btnFilterAll_Click;
            // 
            // panelGrid
            // 
            panelGrid.Controls.Add(dgvInventory);
            panelGrid.Controls.Add(panelGridHeader);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 390);
            panelGrid.Margin = new Padding(2);
            panelGrid.Name = "panelGrid";
            panelGrid.Size = new Size(1022, 293);
            panelGrid.TabIndex = 4;
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.AllowUserToResizeRows = false;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.BackgroundColor = Color.White;
            dgvInventory.BorderRadius = 15;
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvInventory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvInventory.ColumnHeadersHeight = 50;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Tajawal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvInventory.DefaultCellStyle = dataGridViewCellStyle2;
            dgvInventory.Dock = DockStyle.Fill;
            dgvInventory.EnableHeadersVisualStyles = false;
            dgvInventory.GridColor = Color.White;
            dgvInventory.HeaderBackColor = Color.FromArgb(243, 244, 246);
            dgvInventory.HeaderForeColor = Color.FromArgb(33, 37, 41);
            dgvInventory.Location = new Point(0, 50);
            dgvInventory.MultiSelect = false;
            dgvInventory.Name = "dgvInventory";
            dgvInventory.ReadOnly = true;
            dgvInventory.RightToLeft = RightToLeft.Yes;
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.RowHeight = 55;
            dgvInventory.RowTemplate.Height = 55;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new Size(1022, 243);
            dgvInventory.TabIndex = 1;
            // 
            // panelGridHeader
            // 
            panelGridHeader.BackColor = Color.White;
            panelGridHeader.Controls.Add(btnTabMovements);
            panelGridHeader.Controls.Add(btnTabInventory);
            panelGridHeader.Dock = DockStyle.Top;
            panelGridHeader.Location = new Point(0, 0);
            panelGridHeader.Name = "panelGridHeader";
            panelGridHeader.Size = new Size(1022, 50);
            panelGridHeader.TabIndex = 0;
            // 
            // btnTabMovements
            // 
            btnTabMovements.Anchor = AnchorStyles.Right;
            btnTabMovements.BackColor = Color.White;
            btnTabMovements.BackgroundImageLayout = ImageLayout.None;
            btnTabMovements.Checked = false;
            btnTabMovements.CheckedBackColor = Color.FromArgb(41, 51, 146);
            btnTabMovements.CheckedForeColor = Color.White;
            btnTabMovements.FlatAppearance.BorderSize = 0;
            btnTabMovements.FlatStyle = FlatStyle.Flat;
            btnTabMovements.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            btnTabMovements.ForeColor = Color.FromArgb(64, 64, 64);
            btnTabMovements.GroupName = "tabs";
            btnTabMovements.Location = new Point(740, 5);
            btnTabMovements.Margin = new Padding(2);
            btnTabMovements.Name = "btnTabMovements";
            btnTabMovements.Radius = 10;
            btnTabMovements.Size = new Size(120, 40);
            btnTabMovements.TabIndex = 1;
            btnTabMovements.Text = "سجل الحركات";
            btnTabMovements.UncheckedBackColor = Color.White;
            btnTabMovements.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnTabMovements.UseVisualStyleBackColor = false;
            btnTabMovements.Click += btnTabMovements_Click;
            // 
            // btnTabInventory
            // 
            btnTabInventory.Anchor = AnchorStyles.Right;
            btnTabInventory.BackColor = Color.White;
            btnTabInventory.BackgroundImageLayout = ImageLayout.None;
            btnTabInventory.Checked = true;
            btnTabInventory.CheckedBackColor = Color.FromArgb(41, 51, 146);
            btnTabInventory.CheckedForeColor = Color.White;
            btnTabInventory.FlatAppearance.BorderSize = 0;
            btnTabInventory.FlatStyle = FlatStyle.Flat;
            btnTabInventory.Font = new Font("Tajawal Medium", 10.2F, FontStyle.Bold);
            btnTabInventory.ForeColor = Color.FromArgb(64, 64, 64);
            btnTabInventory.GroupName = "tabs";
            btnTabInventory.Location = new Point(870, 5);
            btnTabInventory.Margin = new Padding(2);
            btnTabInventory.Name = "btnTabInventory";
            btnTabInventory.Radius = 10;
            btnTabInventory.Size = new Size(130, 40);
            btnTabInventory.TabIndex = 0;
            btnTabInventory.Text = "قائمة المخزون";
            btnTabInventory.UncheckedBackColor = Color.White;
            btnTabInventory.UncheckedForeColor = Color.FromArgb(64, 64, 64);
            btnTabInventory.UseVisualStyleBackColor = false;
            btnTabInventory.Click += btnTabInventory_Click;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1022, 683);
            Controls.Add(panelGrid);
            Controls.Add(panelFilters);
            Controls.Add(tableLayoutPanelCards);
            Controls.Add(panelAlertWrapper);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "InventoryForm";
            Text = "InventoryForm";
            Load += InventoryForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelAlertWrapper.ResumeLayout(false);
            panelAlert.ResumeLayout(false);
            tableLayoutPanelCards.ResumeLayout(false);
            panelFilters.ResumeLayout(false);
            panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            panelGridHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSub;
        private CustomItems.RoundedButton btnDamagedGoods;
        private System.Windows.Forms.Panel panelAlertWrapper;
        private System.Windows.Forms.Panel panelAlert;
        private System.Windows.Forms.Label labelAlertText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCards;
        private CustomItems.AdvancedStatusCard cardTotalValue;
        private CustomItems.AdvancedStatusCard cardDamagedGoods;
        private CustomItems.AdvancedStatusCard cardLowStock;
        private CustomItems.AdvancedStatusCard cardTotalItems;
        private CustomItems.StatusCard panelFilters;
        private ActiveSpaceSystem.CustomItems.AbdulTextBox txtSearch;
        private CustomItems.PillButton btnFilterAll;
        private CustomItems.PillButton btnFilterSportsBalls;
        private CustomItems.PillButton btnFilterEquipment;
        private CustomItems.PillButton btnFilterSupplies;
        private CustomItems.PillButton btnFilterLighting;
        private System.Windows.Forms.Panel panelGrid;
        private CustomItems.CustomDataGridView dgvInventory;
        private System.Windows.Forms.Panel panelGridHeader;
        private CustomItems.PillButton btnTabMovements;
        private CustomItems.PillButton btnTabInventory;
    }
}