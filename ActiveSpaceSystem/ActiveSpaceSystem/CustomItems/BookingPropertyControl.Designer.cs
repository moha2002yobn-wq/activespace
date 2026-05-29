namespace ActiveSpaceSystem.CustomItems
{
    partial class BookingPropertyControl
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
            this.propCardPanel = new ActiveSpaceSystem.CustomItems.CustomPanel();
            this.lblCategoryHeader = new System.Windows.Forms.Label();
            this.panelCategory = new ActiveSpaceSystem.CustomItems.CustomPanel();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            
            this.lblItemHeader = new System.Windows.Forms.Label();
            this.panelItem = new ActiveSpaceSystem.CustomItems.CustomPanel();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            
            this.lblTypeHeader = new System.Windows.Forms.Label();
            this.panelType = new ActiveSpaceSystem.CustomItems.CustomPanel();
            this.cmbType = new System.Windows.Forms.ComboBox();
            
            this.lblQtyHeader = new System.Windows.Forms.Label();
            this.panelQty = new ActiveSpaceSystem.CustomItems.CustomPanel();
            this.txtQty = new System.Windows.Forms.TextBox();
            
            this.btnDelete = new ActiveSpaceSystem.CustomItems.RoundedButton();
            this.lblPrice = new System.Windows.Forms.Label();

            this.propCardPanel.SuspendLayout();
            this.panelCategory.SuspendLayout();
            this.panelItem.SuspendLayout();
            this.panelQty.SuspendLayout();
            this.panelType.SuspendLayout();
            this.SuspendLayout();

            // 
            // propCardPanel
            // 
            this.propCardPanel.BackColor = System.Drawing.Color.White;
            this.propCardPanel.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.propCardPanel.BorderRadius = 12;
            this.propCardPanel.BorderSize = 1F;
            this.propCardPanel.Controls.Add(this.lblCategoryHeader);
            this.propCardPanel.Controls.Add(this.panelCategory);
            this.propCardPanel.Controls.Add(this.lblItemHeader);
            this.propCardPanel.Controls.Add(this.panelItem);
            this.propCardPanel.Controls.Add(this.lblTypeHeader);
            this.propCardPanel.Controls.Add(this.panelType);
            this.propCardPanel.Controls.Add(this.lblQtyHeader);
            this.propCardPanel.Controls.Add(this.panelQty);
            this.propCardPanel.Controls.Add(this.btnDelete);
            this.propCardPanel.Controls.Add(this.lblPrice);
            this.propCardPanel.Location = new System.Drawing.Point(5, 5);
            this.propCardPanel.Name = "propCardPanel";
            this.propCardPanel.ShowShadow = false;
            this.propCardPanel.Size = new System.Drawing.Size(650, 105);
            this.propCardPanel.TabIndex = 0;

            // 
            // lblCategoryHeader
            // 
            this.lblCategoryHeader.AutoSize = true;
            this.lblCategoryHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblCategoryHeader.Font = new System.Drawing.Font("Tajawal Medium", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategoryHeader.ForeColor = System.Drawing.Color.FromArgb(100, 110, 125);
            this.lblCategoryHeader.Location = new System.Drawing.Point(585, 3);
            this.lblCategoryHeader.Name = "lblCategoryHeader";
            this.lblCategoryHeader.Size = new System.Drawing.Size(43, 20);
            this.lblCategoryHeader.TabIndex = 0;
            this.lblCategoryHeader.Text = "الفئة";
            this.lblCategoryHeader.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // panelCategory
            // 
            this.panelCategory.BackColor = System.Drawing.Color.White;
            this.panelCategory.BorderColor = System.Drawing.Color.FromArgb(215, 225, 240);
            this.panelCategory.BorderRadius = 10;
            this.panelCategory.BorderSize = 1F;
            this.panelCategory.Controls.Add(this.cmbCategory);
            this.panelCategory.Location = new System.Drawing.Point(485, 25);
            this.panelCategory.Name = "panelCategory";
            this.panelCategory.ShowShadow = false;
            this.panelCategory.Size = new System.Drawing.Size(150, 38);
            this.panelCategory.TabIndex = 1;

            // 
            // cmbCategory
            // 
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.Font = new System.Drawing.Font("Tajawal", 9F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(5, 5);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(138, 28);
            this.cmbCategory.TabIndex = 0;

            // 
            // lblItemHeader
            // 
            this.lblItemHeader.AutoSize = true;
            this.lblItemHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblItemHeader.Font = new System.Drawing.Font("Tajawal Medium", 9F, System.Drawing.FontStyle.Bold);
            this.lblItemHeader.ForeColor = System.Drawing.Color.FromArgb(100, 110, 125);
            this.lblItemHeader.Location = new System.Drawing.Point(420, 3);
            this.lblItemHeader.Name = "lblItemHeader";
            this.lblItemHeader.Size = new System.Drawing.Size(52, 20);
            this.lblItemHeader.TabIndex = 2;
            this.lblItemHeader.Text = "الصنف";
            this.lblItemHeader.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // panelItem
            // 
            this.panelItem.BackColor = System.Drawing.Color.White;
            this.panelItem.BorderColor = System.Drawing.Color.FromArgb(215, 225, 240);
            this.panelItem.BorderRadius = 10;
            this.panelItem.BorderSize = 1F;
            this.panelItem.Controls.Add(this.cmbItem);
            this.panelItem.Location = new System.Drawing.Point(250, 25);
            this.panelItem.Name = "panelItem";
            this.panelItem.ShowShadow = false;
            this.panelItem.Size = new System.Drawing.Size(220, 38);
            this.panelItem.TabIndex = 3;

            // 
            // cmbItem
            // 
            this.cmbItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbItem.Font = new System.Drawing.Font("Tajawal", 9F);
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(5, 5);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(208, 28);
            this.cmbItem.TabIndex = 0;

            // 
            // lblTypeHeader
            // 
            this.lblTypeHeader.AutoSize = true;
            this.lblTypeHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblTypeHeader.Font = new System.Drawing.Font("Tajawal Medium", 9F, System.Drawing.FontStyle.Bold);
            this.lblTypeHeader.ForeColor = System.Drawing.Color.FromArgb(100, 110, 125);
            this.lblTypeHeader.Location = new System.Drawing.Point(185, 3);
            this.lblTypeHeader.Name = "lblTypeHeader";
            this.lblTypeHeader.Size = new System.Drawing.Size(43, 20);
            this.lblTypeHeader.TabIndex = 4;
            this.lblTypeHeader.Text = "النوع";
            this.lblTypeHeader.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // panelType
            // 
            this.panelType.BackColor = System.Drawing.Color.White;
            this.panelType.BorderColor = System.Drawing.Color.FromArgb(215, 225, 240);
            this.panelType.BorderRadius = 10;
            this.panelType.BorderSize = 1F;
            this.panelType.Controls.Add(this.cmbType);
            this.panelType.Location = new System.Drawing.Point(145, 25);
            this.panelType.Name = "panelType";
            this.panelType.ShowShadow = false;
            this.panelType.Size = new System.Drawing.Size(95, 38);
            this.panelType.TabIndex = 5;

            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.Font = new System.Drawing.Font("Tajawal", 9F);
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(5, 5);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(83, 28);
            this.cmbType.TabIndex = 0;

            // 
            // lblQtyHeader
            // 
            this.lblQtyHeader.AutoSize = true;
            this.lblQtyHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblQtyHeader.Font = new System.Drawing.Font("Tajawal Medium", 9F, System.Drawing.FontStyle.Bold);
            this.lblQtyHeader.ForeColor = System.Drawing.Color.FromArgb(100, 110, 125);
            this.lblQtyHeader.Location = new System.Drawing.Point(90, 3);
            this.lblQtyHeader.Name = "lblQtyHeader";
            this.lblQtyHeader.Size = new System.Drawing.Size(51, 20);
            this.lblQtyHeader.TabIndex = 6;
            this.lblQtyHeader.Text = "الكمية";
            this.lblQtyHeader.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // panelQty
            // 
            this.panelQty.BackColor = System.Drawing.Color.White;
            this.panelQty.BorderColor = System.Drawing.Color.FromArgb(215, 225, 240);
            this.panelQty.BorderRadius = 10;
            this.panelQty.BorderSize = 1F;
            this.panelQty.Controls.Add(this.txtQty);
            this.panelQty.Location = new System.Drawing.Point(70, 25);
            this.panelQty.Name = "panelQty";
            this.panelQty.ShowShadow = false;
            this.panelQty.Size = new System.Drawing.Size(65, 38);
            this.panelQty.TabIndex = 7;

            // 
            // txtQty
            // 
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQty.Font = new System.Drawing.Font("Tajawal", 10F);
            this.txtQty.Location = new System.Drawing.Point(5, 7);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(53, 23);
            this.txtQty.TabIndex = 0;
            this.txtQty.Text = "1";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            this.btnDelete.BorderColor = System.Drawing.Color.FromArgb(252, 165, 165);
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.BorderSize = 1;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Tajawal", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(10, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 38);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;

            // 
            // lblPrice
            // 
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Tajawal Medium", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(70, 80, 95);
            this.lblPrice.Location = new System.Drawing.Point(180, 71);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(450, 25);
            this.lblPrice.TabIndex = 9;
            this.lblPrice.Text = "السعر: 1 × 50 = 50 د.ل";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // BookingPropertyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(250, 251, 252);
            this.Controls.Add(this.propCardPanel);
            this.Name = "BookingPropertyControl";
            this.Size = new System.Drawing.Size(660, 115);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.propCardPanel.ResumeLayout(false);
            this.propCardPanel.PerformLayout();
            this.panelCategory.ResumeLayout(false);
            this.panelItem.ResumeLayout(false);
            this.panelQty.ResumeLayout(false);
            this.panelQty.PerformLayout();
            this.panelType.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public System.Windows.Forms.ComboBox cmbCategory;
        public System.Windows.Forms.ComboBox cmbItem;
        public System.Windows.Forms.ComboBox cmbType;
        public System.Windows.Forms.TextBox txtQty;
        public System.Windows.Forms.Label lblPrice;
        public ActiveSpaceSystem.CustomItems.RoundedButton btnDelete;
        
        private System.Windows.Forms.Label lblCategoryHeader;
        private System.Windows.Forms.Label lblItemHeader;
        private System.Windows.Forms.Label lblQtyHeader;
        private System.Windows.Forms.Label lblTypeHeader;
        
        private ActiveSpaceSystem.CustomItems.CustomPanel propCardPanel;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelCategory;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelItem;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelQty;
        private ActiveSpaceSystem.CustomItems.CustomPanel panelType;
    }
}
